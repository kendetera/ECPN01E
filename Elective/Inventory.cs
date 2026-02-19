using System;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;
using ZXing;
using ZXing.Common;
using ZXing.Windows.Compatibility;

namespace Elective
{
    public partial class Inventory : Form
    {
        private readonly SqlConnection cn = new();
        private readonly SqlCommand cm = new();
        private readonly InventoryDB dbcon = new();

        public Inventory()
        {
            InitializeComponent();
            cn.ConnectionString = dbcon.MyConnection();
            cm.Connection = cn;

            try
            {
                cn.Open();
                MessageBox.Show("Database Connected");
            }
            catch (SqlException ex)
            {
                MessageBox.Show($"Failed to connect to database:\n{ex.Message}", "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            this.FormClosing += (_, __) =>
            {
                if (cn.State != ConnectionState.Closed) cn.Close();
                cn.Dispose();
                cm.Dispose();
            };
        }

        private void Inventory_Load(object? sender, EventArgs e)
        {
            try { LoadProductsIntoGrid(); }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load products:\n{ex.Message}", "Load Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // --- UI Actions ---

        private void button2_Click(object sender, EventArgs e) // Generate Barcode
        {
            try
            {
                var generated = GenerateUniqueBarcode();
                barcodeTextbox.Text = generated;
                barcodePicturebox.Image = RenderBarcodeImage(generated, barcodePicturebox.Width, barcodePicturebox.Height, showText: true);
                barcodePicturebox.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Generating Barcode: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e) // Browse product image
        {
            try
            {
                using var ofd = new OpenFileDialog
                {
                    Title = "Select an Image",
                    Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif",
                    Multiselect = false,
                    CheckFileExists = true,
                    CheckPathExists = true
                };

                if (ofd.ShowDialog(this) == DialogResult.OK)
                {
                    productPicturebox.Image = LoadImageSafely(ofd.FileName);
                    productPicturebox.SizeMode = PictureBoxSizeMode.StretchImage;
                    productpicpathTextbox.Text = ofd.FileName;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load image:\n{ex.Message}", "Browse Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            if (!TryValidateInputs(out var inputs)) return;

            using SqlTransaction tx = cn.BeginTransaction();
            try
            {
                int categoryId = GetOrCreateCategoryId(inputs.CategoryName, tx);

                const string insertSql = @"
INSERT INTO PRODUCTS
    (Category_ID, Barcode, Product_Name, Product_Price, Product_Description, Stock_Quantity, PicPath, Manufacture_Date, Expiration_Date)
VALUES
    (@Category_ID, @Barcode, @Product_Name, @Product_Price, @Product_Description, @Stock_Quantity, @PicPath, @Manufacture_Date, @Expiration_Date);";

                using var cmd = new SqlCommand(insertSql, cn, tx);
                cmd.Parameters.AddWithValue("@Category_ID", categoryId);
                cmd.Parameters.AddWithValue("@Barcode", inputs.Barcode);
                cmd.Parameters.AddWithValue("@Product_Name", inputs.ProductName);
                cmd.Parameters.AddWithValue("@Product_Price", inputs.Price);
                cmd.Parameters.AddWithValue("@Product_Description", string.IsNullOrWhiteSpace(inputs.ProductDescription) ? (object)DBNull.Value : inputs.ProductDescription);
                cmd.Parameters.AddWithValue("@Stock_Quantity", inputs.StockQuantity);
                cmd.Parameters.AddWithValue("@PicPath", string.IsNullOrWhiteSpace(inputs.PicPath) ? (object)DBNull.Value : inputs.PicPath);
                cmd.Parameters.AddWithValue("@Manufacture_Date", inputs.ManufactureDate.Date);
                cmd.Parameters.AddWithValue("@Expiration_Date", inputs.ExpirationDate.Date);
                cmd.ExecuteNonQuery();

                // Save barcode image to folder (uses current barcodePicturebox image or renders if missing)
                var imageToSave = barcodePicturebox.Image ?? RenderBarcodeImage(inputs.Barcode, 406, 206, showText: true);
                SaveBarcodeImageToFolder(inputs.Barcode, imageToSave);

                tx.Commit();

                LoadProductsIntoGrid();
                MessageBox.Show("Product saved successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (SqlException ex) when (ex.Number is 2627 or 2601) // unique violation
            {
                tx.Rollback();
                MessageBox.Show("A product with the same Barcode already exists.", "Duplicate Barcode", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (SqlException ex)
            {
                tx.Rollback();
                MessageBox.Show($"Database error:\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                tx.Rollback();
                MessageBox.Show($"Unexpected error:\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void searchBtn_Click(object sender, EventArgs e)
        {
            string barcode = barcodeTextbox.Text.Trim();
            if (string.IsNullOrWhiteSpace(barcode))
            {
                MessageBox.Show("Enter a barcode to search.", "Search", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                EnsureOpen();
                const string sql = @"
SELECT TOP 1
    p.Product_ID, p.Barcode, p.Product_Name, p.Product_Price, p.Product_Description,
    p.Stock_Quantity, p.PicPath, p.Manufacture_Date, p.Expiration_Date, c.Category_Name
FROM PRODUCTS p
LEFT JOIN CATEGORY c ON c.Category_ID = p.Category_ID
WHERE p.Barcode = @Barcode;";

                using var cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("@Barcode", barcode);

                using var reader = cmd.ExecuteReader();
                if (!reader.Read())
                {
                    MessageBox.Show("No product found for the given barcode.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                nameTxtbox.Text = reader["Product_Name"]?.ToString() ?? "";
                priceTxtbox.Text = Convert.ToDecimal(reader["Product_Price"]).ToString("0.00");
                descriptionTxtbox.Text = reader["Product_Description"]?.ToString() ?? "";
                categoryTxtbox.Text = reader["Category_Name"]?.ToString() ?? "";
                stocksTxtbox.Text = Convert.ToInt32(reader["Stock_Quantity"]).ToString();

                if (reader["Manufacture_Date"] is DateTime mfg) manufacturedDate.Value = mfg;
                if (reader["Expiration_Date"] is DateTime exp) expDate.Value = exp;

                var picPathObj = reader["PicPath"];
                string? picPath = picPathObj == DBNull.Value ? null : picPathObj?.ToString();
                productpicpathTextbox.Text = picPath ?? "";
                productPicturebox.Image = (!string.IsNullOrWhiteSpace(picPath) && File.Exists(picPath)) ? LoadImageSafely(picPath!) : null;
                productPicturebox.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Search failed:\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            finally
            {
                try
                {
                    LoadProductsIntoGrid();
                    SelectRowByBarcode(barcode);
                }
                catch { /* ignore grid refresh errors */ }
            }

            // Render barcode image for the searched barcode
            try
            {
                barcodePicturebox.Image = RenderBarcodeImage(barcode, barcodePicturebox.Width, barcodePicturebox.Height, showText: true);
                barcodePicturebox.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to render barcode image:\n{ex.Message}", "Barcode Image", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // --- Helpers ---

        private void LoadProductsIntoGrid()
        {
            EnsureOpen();

            const string sql = @"
SELECT 
    p.Product_ID, p.Barcode, p.Product_Name, p.Product_Price, p.Product_Description,
    p.Stock_Quantity, p.PicPath, p.Manufacture_Date, p.Expiration_Date, c.Category_Name
FROM PRODUCTS p
LEFT JOIN CATEGORY c ON c.Category_ID = p.Category_ID
ORDER BY p.Product_ID DESC;";

            var table = FillTable(sql);
            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.DataSource = table;

            if (dataGridView1.Columns.Contains("Product_ID")) dataGridView1.Columns["Product_ID"].HeaderText = "ID";
            if (dataGridView1.Columns.Contains("Product_Name")) dataGridView1.Columns["Product_Name"].HeaderText = "Name";
            if (dataGridView1.Columns.Contains("Product_Price")) dataGridView1.Columns["Product_Price"].HeaderText = "Price";
            if (dataGridView1.Columns.Contains("Product_Description")) dataGridView1.Columns["Product_Description"].HeaderText = "Description";
            if (dataGridView1.Columns.Contains("Stock_Quantity")) dataGridView1.Columns["Stock_Quantity"].HeaderText = "Stocks";
            if (dataGridView1.Columns.Contains("Category_Name")) dataGridView1.Columns["Category_Name"].HeaderText = "Category";
        }

        private void EnsureOpen()
        {
            if (cn.State != ConnectionState.Open) cn.Open();
        }

        private object? ExecuteScalar(string sql, SqlTransaction? tx = null, params SqlParameter[] parameters)
        {
            using var cmd = tx is null ? new SqlCommand(sql, cn) : new SqlCommand(sql, cn, tx);
            if (parameters?.Length > 0) cmd.Parameters.AddRange(parameters);
            return cmd.ExecuteScalar();
        }

        private DataTable FillTable(string sql, params SqlParameter[] parameters)
        {
            using var da = new SqlDataAdapter(sql, cn);
            if (parameters?.Length > 0) da.SelectCommand!.Parameters.AddRange(parameters);
            var table = new DataTable();
            da.Fill(table);
            return table;
        }

        private int GetOrCreateCategoryId(string categoryName, SqlTransaction tx)
        {
            var idObj = ExecuteScalar(
                "SELECT Category_ID FROM CATEGORY WHERE Category_Name = @name;",
                tx,
                new SqlParameter("@name", categoryName));
            if (idObj is int id) return id;

            var newIdObj = ExecuteScalar(
                "INSERT INTO CATEGORY (Category_Name) VALUES (@name); SELECT SCOPE_IDENTITY();",
                tx,
                new SqlParameter("@name", categoryName));
            return Convert.ToInt32(newIdObj);
        }

        private bool TryValidateInputs(out (string Barcode, string ProductName, decimal Price, string ProductDescription,
            string CategoryName, int StockQuantity, DateTime ManufactureDate, DateTime ExpirationDate, string PicPath) inputs)
        {
            inputs = default;

            string barcode = barcodeTextbox.Text.Trim();
            string productName = nameTxtbox.Text.Trim();
            string priceText = priceTxtbox.Text.Trim();
            string productDescription = descriptionTxtbox.Text.Trim();
            string categoryName = categoryTxtbox.Text.Trim();
            string manufacturedText = manufacturedDate.Text.Trim();
            string expirationText = expDate.Text.Trim();
            string stocksText = stocksTxtbox.Text.Trim();
            string picPath = productpicpathTextbox.Text.Trim();

            if (string.IsNullOrWhiteSpace(barcode) ||
                string.IsNullOrWhiteSpace(productName) ||
                string.IsNullOrWhiteSpace(priceText) ||
                string.IsNullOrWhiteSpace(categoryName) ||
                string.IsNullOrWhiteSpace(manufacturedText) ||
                string.IsNullOrWhiteSpace(expirationText) ||
                string.IsNullOrWhiteSpace(stocksText))
            {
                MessageBox.Show("Please fill all required fields: Barcode, Name, Price, Category Name, Manufactured Date, Expiration Date, Stocks.",
                    "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!decimal.TryParse(priceText, out decimal price) || price < 0)
            {
                MessageBox.Show("Price must be a valid non-negative number.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!int.TryParse(stocksText, out int stockQuantity) || stockQuantity < 0)
            {
                MessageBox.Show("Stocks must be a valid non-negative integer.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!DateTime.TryParse(manufacturedText, out DateTime manufactureDate))
            {
                MessageBox.Show("Manufactured Date is not valid.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!DateTime.TryParse(expirationText, out DateTime expirationDate))
            {
                MessageBox.Show("Expiration Date is not valid.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (expirationDate < manufactureDate)
            {
                MessageBox.Show("Expiration Date cannot be earlier than Manufactured Date.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            inputs = (barcode, productName, price, productDescription, categoryName, stockQuantity, manufactureDate, expirationDate, picPath);
            return true;
        }

        private Image LoadImageSafely(string filePath)
        {
            using var fs = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read);
            using var tempImage = Image.FromStream(fs);
            return new Bitmap(tempImage);
        }

        private Image RenderBarcodeImage(string value, int width, int height, bool showText)
        {
            var writer = new BarcodeWriter
            {
                Format = ZXing.BarcodeFormat.CODE_128,
                Options = new EncodingOptions { Height = height, Width = width, Margin = 10, PureBarcode = !showText }
            };

            Bitmap barcodeBitmap = writer.Write(value);
            if (!showText) return barcodeBitmap;

            int textHeight = 20;
            var composed = new Bitmap(barcodeBitmap.Width, barcodeBitmap.Height + textHeight);
            using var g = Graphics.FromImage(composed);
            g.Clear(Color.White);
            g.DrawImage(barcodeBitmap, 0, 0);

            using var font = new Font("Consolas", 16, FontStyle.Bold, GraphicsUnit.Pixel);
            using var brush = new SolidBrush(Color.Black);
            var sf = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center };
            var textRect = new Rectangle(0, barcodeBitmap.Height, composed.Width, textHeight);
            g.DrawString(value, font, brush, textRect, sf);
            return composed;
        }

        private void SaveBarcodeImageToFolder(string barcode, Image? image)
        {
            if (image == null)
            {
                MessageBox.Show("No barcode image to save. Please generate a barcode first.", "Image Missing", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string targetDir = @"C:\Users\kende\source\repos\ECPN01E\Elective\Barcode Images";
                if (!Directory.Exists(targetDir)) Directory.CreateDirectory(targetDir);

                string safeName = string.Concat(barcode.Where(char.IsDigit));
                if (string.IsNullOrWhiteSpace(safeName)) safeName = "barcode";

                string targetPath = Path.Combine(targetDir, safeName + ".png");
                using var bmp = new Bitmap(image);
                bmp.Save(targetPath, ImageFormat.Png);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to save barcode image:\n{ex.Message}", "File Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SelectRowByBarcode(string barcode)
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.DataBoundItem is DataRowView drv &&
                    drv.Row.Table.Columns.Contains("Barcode") &&
                    string.Equals(drv.Row["Barcode"]?.ToString(), barcode, StringComparison.Ordinal))
                {
                    row.Selected = true;
                    if (dataGridView1.Columns.Contains("Product_Name"))
                        dataGridView1.CurrentCell = row.Cells["Product_Name"];
                    break;
                }
            }
        }

        // --- Barcode generation ---

        private string GenerateUniqueBarcode()
        {
            const int maxAttempts = 20;
            for (int attempt = 0; attempt < maxAttempts; attempt++)
            {
                string candidate = GenerateNumericBarcodeWithChecksum();

                using var cmd = new SqlCommand("SELECT 1 FROM PRODUCTS WHERE Barcode = @bc;", cn);
                cmd.Parameters.AddWithValue("@bc", candidate);
                var exists = cmd.ExecuteScalar();
                if (exists == null) return candidate;
            }
            throw new InvalidOperationException("Unable to generate a unique barcode after multiple attempts.");
        }

        private static string GenerateNumericBarcodeWithChecksum()
        {
            var rng = Random.Shared;
            var digits = new char[12];
            for (int i = 0; i < digits.Length; i++) digits[i] = (char)('0' + rng.Next(0, 10));

            int sum = 0;
            for (int i = digits.Length - 1, pos = 0; i >= 0; i--, pos++)
            {
                int d = digits[i] - '0';
                if (pos % 2 == 1)
                {
                    d *= 2;
                    if (d > 9) d -= 9;
                }
                sum += d;
            }
            int checkDigit = (10 - (sum % 10)) % 10;
            return new string(digits) + checkDigit;
        }

        private void newBtn_Click(object sender, EventArgs e)
        {
            try
            {
                // Clear text inputs
                barcodeTextbox.Clear();
                nameTxtbox.Clear();
                priceTxtbox.Clear();
                descriptionTxtbox.Clear();
                categoryTxtbox.Clear();
                stocksTxtbox.Clear();
                productpicpathTextbox.Clear();

                // Reset date pickers to today
                manufacturedDate.Value = DateTime.Today;
                expDate.Value = DateTime.Today;

                // Clear images
                productPicturebox.Image = null;
                barcodePicturebox.Image = null;

                // Optional: clear grid selection (keep data)
                dataGridView1.ClearSelection();

                // Set focus to the first input
                nameTxtbox.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to reset form:\n{ex.Message}", "New", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            string barcode = barcodeTextbox.Text.Trim();
            if (string.IsNullOrWhiteSpace(barcode))
            {
                MessageBox.Show("Enter or select a product barcode to delete.", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var confirm = MessageBox.Show(
                $"Are you sure you want to delete the product with barcode:\n{barcode}?",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (confirm != DialogResult.Yes) return;

            using SqlTransaction tx = cn.BeginTransaction();
            try
            {
                // Ensure the product exists
                using (var chk = new SqlCommand("SELECT TOP 1 Product_ID FROM PRODUCTS WHERE Barcode = @Barcode;", cn, tx))
                {
                    chk.Parameters.AddWithValue("@Barcode", barcode);
                    var exists = chk.ExecuteScalar();
                    if (exists == null)
                    {
                        MessageBox.Show("No product found for the given barcode.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        tx.Rollback();
                        return;
                    }
                }

                // Delete the product
                using (var del = new SqlCommand("DELETE FROM PRODUCTS WHERE Barcode = @Barcode;", cn, tx))
                {
                    del.Parameters.AddWithValue("@Barcode", barcode);
                    del.ExecuteNonQuery();
                }

                tx.Commit();

                // Optionally delete the barcode image file if present
                try
                {
                    string safeName = string.Concat(barcode.Where(char.IsDigit));
                    if (string.IsNullOrWhiteSpace(safeName)) safeName = "barcode";
                    string targetDir = @"C:\Users\kende\source\repos\ECPN01E\Elective\Barcode Images";
                    string path = Path.Combine(targetDir, safeName + ".png");
                    if (File.Exists(path))
                    {
                        File.Delete(path);
                    }
                }
                catch
                {
                    // Ignore file deletion errors; product is already deleted from DB
                }

                // Refresh and clear UI
                LoadProductsIntoGrid();
                newBtn_Click(sender, e);
                MessageBox.Show("Product deleted.", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (SqlException ex)
            {
                tx.Rollback();
                MessageBox.Show($"Database error during delete:\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                tx.Rollback();
                MessageBox.Show($"Unexpected error during delete:\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}

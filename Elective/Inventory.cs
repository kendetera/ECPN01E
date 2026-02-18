using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZXing;
using ZXing.Common;
using ZXing.Windows.Compatibility;
using Microsoft.Data.SqlClient;

namespace Elective
{
    public partial class Inventory : Form
    {
        SqlConnection cn = new SqlConnection();
        SqlCommand cm = new SqlCommand();
        InventoryDB dbcon = new InventoryDB();
        public Inventory()
        {
            InitializeComponent();
            cn.ConnectionString = dbcon.MyConnection();

            try
            {
                cn.Open();
                MessageBox.Show("Database Connected");
            }
            catch (SqlException ex)
            {
                MessageBox.Show($"Failed to connect to database:\n{ex.Message}", "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // Optionally associate the command with the connection if you plan to use it.
            cm.Connection = cn;

            // Ensure the connection is closed when the form is closing.
            this.FormClosing += (_, __) =>
            {
                if (cn.State != ConnectionState.Closed)
                {
                    cn.Close();
                }
                cn.Dispose();
                cm.Dispose();
            };

        }

        private void Inventory_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e) // Barcode Generator Button
        {
            try
            {
                // Generate a unique 13-digit numeric barcode (12 random + 1 checksum)
                string generated = GenerateUniqueBarcode();

                // Set textbox and render
                barcodeTextbox.Text = generated;

                var writer = new ZXing.Windows.Compatibility.BarcodeWriter
                {
                    Format = ZXing.BarcodeFormat.CODE_128,
                    Options = new ZXing.Common.EncodingOptions
                    {
                        Height = barcodePicturebox.Height,
                        Width = barcodePicturebox.Width,
                        Margin = 10,
                        PureBarcode = true
                    }
                };

                // Render barcode bitmap
                Bitmap barcodeBitmap = writer.Write(generated);

                // Compose a new image with text under the barcode
                int textHeight = 20; // space for the text
                var composed = new Bitmap(barcodeBitmap.Width, barcodeBitmap.Height + textHeight);
                using (var g = Graphics.FromImage(composed))
                {
                    g.Clear(Color.White);
                    // draw barcode
                    g.DrawImage(barcodeBitmap, 0, 0);

                    // draw text centered
                    using var font = new Font("Consolas", 16, FontStyle.Bold, GraphicsUnit.Pixel);
                    using var brush = new SolidBrush(Color.Black);
                    var sf = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center };
                    var textRect = new Rectangle(0, barcodeBitmap.Height, composed.Width, textHeight);
                    g.DrawString(generated, font, brush, textRect, sf);
                }

                // set composed image into the PictureBox (fit to control size)
                barcodePicturebox.SizeMode = PictureBoxSizeMode.StretchImage;
                barcodePicturebox.Image = composed;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Generating Barcode: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string GenerateUniqueBarcode()
        {
            // Try up to N times to get a unique barcode
            const int maxAttempts = 20;
            for (int attempt = 0; attempt < maxAttempts; attempt++)
            {
                string candidate = GenerateNumericBarcodeWithChecksum();

                // Check uniqueness in DB
                using var cmd = new SqlCommand("SELECT 1 FROM PRODUCTS WHERE Barcode = @bc;", cn);
                cmd.Parameters.AddWithValue("@bc", candidate);
                var exists = cmd.ExecuteScalar();
                if (exists == null)
                {
                    return candidate;
                }
            }
            throw new InvalidOperationException("Unable to generate a unique barcode after multiple attempts.");
        } // Barcode Generator function

        private static string GenerateNumericBarcodeWithChecksum()
        {
            // Generate 12-digit random numeric string
            var rng = Random.Shared;
            var digits = new char[12];
            for (int i = 0; i < digits.Length; i++)
            {
                digits[i] = (char)('0' + rng.Next(0, 10));
            }

            // Compute a simple checksum (Mod 10, Luhn-like)
            int sum = 0;
            // Starting from rightmost, double every second digit
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

            // Return 13-digit barcode
            return new string(digits) + checkDigit.ToString();
        } // Barcode number generator function with checksum

        private void button1_Click(object sender, EventArgs e)
        {
            // Let the user pick an image file.
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Title = "Select an Image";
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif";
                openFileDialog.Multiselect = false;

                // If a file was chosen, load it into the PictureBox.
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    Image selectedImage = Image.FromFile(openFileDialog.FileName);
                    productPicturebox.Image = selectedImage;
                    productPicturebox.SizeMode = PictureBoxSizeMode.StretchImage; // Fit image to box.
                    // Optional: store path for DB
                    productpicpathTextbox.Text = openFileDialog.FileName;
                }
            }
        } // Browse button

        private void saveBtn_Click(object sender, EventArgs e) // save button for inserting product into database
        {
            // Inputs
            string barcode = barcodeTextbox.Text.Trim();
            string productName = nameTxtbox.Text.Trim();
            string priceText = priceTxtbox.Text.Trim();
            string productDescription = descriptionTxtbox.Text.Trim();
            string categoryName = categoryTxtbox.Text.Trim(); // user types category name
            string manufacturedText = manufacturedDate.Text.Trim();
            string expirationText = expDate.Text.Trim();
            string stocksText = stocksTxtbox.Text.Trim();
            string picPath = productpicpathTextbox.Text.Trim();

            // Validation
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
                return;
            }

            if (!decimal.TryParse(priceText, out decimal price) || price < 0)
            {
                MessageBox.Show("Price must be a valid non-negative number.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(stocksText, out int stockQuantity) || stockQuantity < 0)
            {
                MessageBox.Show("Stocks must be a valid non-negative integer.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!DateTime.TryParse(manufacturedText, out DateTime manufactureDate))
            {
                MessageBox.Show("Manufactured Date is not valid.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!DateTime.TryParse(expirationText, out DateTime expirationDate))
            {
                MessageBox.Show("Expiration Date is not valid.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (expirationDate < manufactureDate)
            {
                MessageBox.Show("Expiration Date cannot be earlier than Manufactured Date.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using SqlTransaction tx = cn.BeginTransaction();
            try
            {
                // Get or create Category_ID by Category_Name
                int categoryId;
                using (var getCatCmd = new SqlCommand("SELECT Category_ID FROM CATEGORY WHERE Category_Name = @name;", cn, tx))
                {
                    getCatCmd.Parameters.AddWithValue("@name", categoryName);
                    object? result = getCatCmd.ExecuteScalar();
                    if (result is int id)
                    {
                        categoryId = id;
                    }
                    else
                    {
                        using var insertCatCmd = new SqlCommand(
                            "INSERT INTO CATEGORY (Category_Name) VALUES (@name); SELECT SCOPE_IDENTITY();",
                            cn, tx);
                        insertCatCmd.Parameters.AddWithValue("@name", categoryName);
                        object? newIdObj = insertCatCmd.ExecuteScalar();
                        categoryId = Convert.ToInt32(newIdObj);
                    }
                }

                // Insert product
                const string insertProductSql = @"
INSERT INTO PRODUCTS
    (Category_ID, Barcode, Product_Name, Product_Price, Product_Description, Stock_Quantity, PicPath, Manufacture_Date, Expiration_Date)
VALUES
    (@Category_ID, @Barcode, @Product_Name, @Product_Price, @Product_Description, @Stock_Quantity, @PicPath, @Manufacture_Date, @Expiration_Date);";

                using var cmd = new SqlCommand(insertProductSql, cn, tx);
                cmd.Parameters.AddWithValue("@Category_ID", categoryId);
                cmd.Parameters.AddWithValue("@Barcode", barcode);
                cmd.Parameters.AddWithValue("@Product_Name", productName);
                cmd.Parameters.AddWithValue("@Product_Price", price);
                cmd.Parameters.AddWithValue("@Product_Description", string.IsNullOrWhiteSpace(productDescription) ? (object)DBNull.Value : productDescription);
                cmd.Parameters.AddWithValue("@Stock_Quantity", stockQuantity);
                cmd.Parameters.AddWithValue("@PicPath", string.IsNullOrWhiteSpace(picPath) ? (object)DBNull.Value : picPath);
                cmd.Parameters.AddWithValue("@Manufacture_Date", manufactureDate.Date);
                cmd.Parameters.AddWithValue("@Expiration_Date", expirationDate.Date);

                cmd.ExecuteNonQuery();

                tx.Commit();
                MessageBox.Show("Product saved successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (SqlException ex) when (ex.Number == 2627 || ex.Number == 2601) // Unique violation (Barcode)
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

        }
    }
}

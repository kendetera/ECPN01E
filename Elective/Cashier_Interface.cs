using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace Elective
{
    public partial class Cashier_Interface : Form
    {
        private readonly SqlConnection cn = new();
        private readonly SqlCommand cm = new();
        private readonly InventoryDB dbcon = new();
        private DataTable cartTable;

        public Cashier_Interface()
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

            this.Shown += (_, __) => barcodeTxtbox.Focus();

            InitializeCartTable();
        }

        private void Cashier_Interface_Load(object sender, EventArgs e)
        {
            KeyPreview = true;
            timer1.Start();

            totalAmountTxtbox.Enabled = false;
            changeTxtbox.Enabled = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            dateLbl.Text = DateTime.Now.ToLongDateString();
            timeLbl.Text = DateTime.Now.ToLongTimeString();
        }

        private void InitializeCartTable()
        {
            cartTable = new DataTable();
            cartTable.Columns.Add("Quantity", typeof(int));
            cartTable.Columns.Add("Name", typeof(string));
            cartTable.Columns.Add("Price", typeof(decimal));
            cartTable.Columns.Add("Total", typeof(decimal));

            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.DataSource = cartTable;

            // Make columns fill the grid width
            foreach (DataGridViewColumn col in dataGridView1.Columns)
            {
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }

            // Optional: format columns
            if (dataGridView1.Columns["Price"] is DataGridViewColumn priceCol)
                priceCol.DefaultCellStyle.Format = "0.00";
            if (dataGridView1.Columns["Total"] is DataGridViewColumn totalCol)
                totalCol.DefaultCellStyle.Format = "0.00";
        }

        private void AddToCart(string productName, decimal price)
        {
            // Check if product already in cart
            var existingRow = cartTable.AsEnumerable()
                .FirstOrDefault(r => r.Field<string>("Name") == productName);

            if (existingRow != null)
            {
                // Increment quantity
                int qty = existingRow.Field<int>("Quantity") + 1;
                existingRow["Quantity"] = qty;
                existingRow["Total"] = qty * price;
            }
            else
            {
                // Add new row
                cartTable.Rows.Add(1, productName, price, price);
            }

            UpdateTotalAmount();
        }

        private void UpdateTotalAmount()
        {
            decimal total = cartTable.AsEnumerable()
                .Sum(r => r.Field<decimal>("Total"));
            totalAmountTxtbox.Text = total.ToString("0.00");
        }

        private void txtBarcode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string scannedCode = barcodeTxtbox.Text.Trim();
                FetchProductData(scannedCode);
                barcodeTxtbox.Clear();
                e.SuppressKeyPress = true;
            }
        }

        private void FetchProductData(string barcode)
        {
            if (string.IsNullOrWhiteSpace(barcode)) return;

            const string sql = @"
SELECT 
    p.Product_Name,
    p.Product_Price
FROM PRODUCTS p
WHERE p.Barcode = @barcode;";

            using var cmd = new SqlCommand(sql, cn);
            cmd.Parameters.AddWithValue("@barcode", barcode);

            try
            {
                using var reader = cmd.ExecuteReader();
                if (!reader.Read())
                {
                    MessageBox.Show("Product not found!", "Lookup", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                string productName = reader["Product_Name"]?.ToString() ?? "";
                decimal price = Convert.ToDecimal(reader["Product_Price"]);

                // Add to cart (aggregates quantity)
                AddToCart(productName, price);
            }
            catch (SqlException ex)
            {
                MessageBox.Show($"Database error during lookup:\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Unexpected error:\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cashRenderedTxtbox_TextChanged(object sender, EventArgs e)
        {

        }

        private void enterBtn_Click(object sender, EventArgs e)
        {
            // Validate cash rendered input
            if (!decimal.TryParse(cashRenderedTxtbox.Text.Trim(), out decimal cashRendered) || cashRendered < 0)
            {
                MessageBox.Show("Please enter a valid cash amount.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cashRenderedTxtbox.Focus();
                return;
            }

            // Get total amount
            if (!decimal.TryParse(totalAmountTxtbox.Text.Trim(), out decimal totalAmount))
            {
                MessageBox.Show("Total amount is invalid. Please scan items first.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Check if cash rendered is sufficient
            if (cashRendered < totalAmount)
            {
                MessageBox.Show("Insufficient cash. Please enter an amount equal to or greater than the total.", "Insufficient Cash", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cashRenderedTxtbox.Focus();
                return;
            }

            // Calculate and display change
            decimal change = cashRendered - totalAmount;
            changeTxtbox.Text = change.ToString("0.00");

            // Optional: focus back to barcode for next transaction
            barcodeTxtbox.Focus();
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {

        }
    }
}

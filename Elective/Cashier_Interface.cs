using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace Elective
{
    public partial class Cashier_Interface : Form
    {
        SqlConnection cn = new SqlConnection();
        SqlCommand cm = new SqlCommand();
        InventoryDB dbcon = new InventoryDB();

        public Cashier_Interface()
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

            cm.Connection = cn;

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

        private void Cashier_Interface_Load(object sender, EventArgs e)
        {
            KeyPreview = true;
            barcodeTxtbox.Focus();
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            dateLbl.Text = DateTime.Now.ToLongDateString();
            timeLbl.Text = DateTime.Now.ToLongTimeString();
        }

        private void AddToCart(DataRow productRow)
        {
            // Append scanned product to the DataGridView
            // If the grid has no DataSource, create one on first add.
            var grid = dataGridView1;
            if (grid.DataSource is DataTable dt)
            {
                dt.ImportRow(productRow);
            }
            else
            {
                var newTable = productRow.Table.Clone(); // same schema
                newTable.ImportRow(productRow);
                grid.AutoGenerateColumns = true;
                grid.DataSource = newTable;
            }
        }

        private void txtBarcode_KeyDown(object sender, KeyEventArgs e)
        {
            // Check if the 'Enter' key was pressed (sent by Barcode to PC)
            if (e.KeyCode == Keys.Enter)
            {
                string scannedCode = barcodeTxtbox.Text.Trim();
                FetchProductData(scannedCode);

                // Clear for the next scan
                barcodeTxtbox.Clear();
                e.SuppressKeyPress = true;
            }
        }

        private void FetchProductData(string barcode)
        {
            if (string.IsNullOrWhiteSpace(barcode))
            {
                return;
            }

            const string sql = @"
SELECT 
    p.Product_ID,
    p.Barcode,
    p.Product_Name,
    p.Product_Price,
    p.Product_Description,
    p.Stock_Quantity,
    p.PicPath,
    p.Manufacture_Date,
    p.Expiration_Date,
    c.Category_Name
FROM PRODUCTS p
LEFT JOIN CATEGORY c ON c.Category_ID = p.Category_ID
WHERE p.Barcode = @barcode;";

            using var cmd = new SqlCommand(sql, cn);
            cmd.Parameters.AddWithValue("@barcode", barcode);

            try
            {
                using var adapter = new SqlDataAdapter(cmd);
                var table = new DataTable();
                adapter.Fill(table);

                if (table.Rows.Count == 0)
                {
                    MessageBox.Show("Product not found!", "Lookup", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // Show latest scan in labels if present
                var row = table.Rows[0];
                if (this.Controls.Find("lblProductName", true).FirstOrDefault() is Label nameLbl)
                {
                    nameLbl.Text = Convert.ToString(row["Product_Name"]);
                }
                if (this.Controls.Find("lblPrice", true).FirstOrDefault() is Label priceLbl)
                {
                    if (row["Product_Price"] is decimal price)
                    {
                        priceLbl.Text = price.ToString("0.00");
                    }
                    else
                    {
                        priceLbl.Text = Convert.ToString(row["Product_Price"]);
                    }
                }

                // Append to cart/grid
                AddToCart(row);
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
    }
}

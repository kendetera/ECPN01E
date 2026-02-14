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
    }
}

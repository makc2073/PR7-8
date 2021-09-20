using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace PR7_8
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }
        string connectionString = "server=10.10.1.24;Trusted_Connection=No;DataBase=romPZ;User=pro-41;PWD=IsPro-41";
        private void Form4_Load(object sender, EventArgs e)
        {
            string hist = "SELECT * FROM History$";
            string bank = "SELECT * FROM BankAccount$";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(hist, connection);
                DataSet ds = new DataSet();
                adapter.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
                SqlDataAdapter adapter1 = new SqlDataAdapter(bank, connection);
                DataSet ds1 = new DataSet();
                adapter.Fill(ds1);
                dataGridView2.DataSource = ds1.Tables[0];
                connection.Close();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}

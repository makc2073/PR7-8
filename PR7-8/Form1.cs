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
    public partial class Form1 : Form

    {
        
        public Form1()
        {
            InitializeComponent();
          
        }
        string connectionString = "server=10.10.1.24;Trusted_Connection=No;DataBase=romPZ;User=pro-41;PWD=IsPro-41";
        private void button1_Click(object sender, EventArgs e)
        {
            string sqlExpression = "SELECT COUNT(*) FROM User$ Where Login = "+textBox1.Text+" and Password = '"+textBox2.Text+"'";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);

                try
                { int count = (int)command.ExecuteScalar(); 




                if (count > 0)
                {
                    MessageBox.Show("Авторизовался");
                    Form2 newForm = new Form2(this);
                    newForm.Show();
                }
                
            }
                 catch (Exception ex)
                {
                    MessageBox.Show("Неправильный логин и пароль" );
                }
            }

        }

        struct dateUser
        {
            public static string loginu { get; set; }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        
    }
    }
}



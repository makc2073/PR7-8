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
    public partial class Form2 : Form
    {
                
        public Form2(Form1 f)
        {
            InitializeComponent();
            f.Visible = false;
           
            
        }
        string connectionString = "server=10.10.1.24;Trusted_Connection=No;DataBase=romPZ;User=pro-41;PWD=IsPro-41";
        private void Form2_Load(object sender, EventArgs e)
        {
           
            string users = "SELECT * FROM User$";
            

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                // Создаем объект DataAdapter
                SqlDataAdapter adapter = new SqlDataAdapter(users, connection);
                // Создаем объект Dataset
                DataSet ds = new DataSet();
                // Заполняем Dataset
                adapter.Fill(ds);
                // Отображаем данные
                dataGridView1.DataSource = ds.Tables[0];
                connection.Close();

            }





        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form3 newForm = new Form3();
            newForm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form4 newForm = new Form4();
            newForm.Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            string useradd = "INSERT INTO User$ (ID, Login, Password, Name, Surname, Patronymic, Series, Number, Phone, Adress, [E-Mail], DateOfIssue, Issued, DateOfBirth, PlaceOfBirth) VALUES ("+ textBox1.Text + ", " + textBox2.Text + ", '" + textBox3.Text + "', '" + textBox4.Text + "', '" + textBox5.Text + "', '" + textBox6.Text + "', " + textBox7.Text + ", " + textBox8.Text + ", " + textBox9.Text + ", '" + textBox10.Text + "', '" + textBox11.Text + "', '" + textBox12.Text + "', '" + textBox13.Text + "', '" + textBox14.Text + "', '" + textBox15.Text + "')";
            string up = "SELECT * FROM User$";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(useradd, connection);
                int number = command.ExecuteNonQuery();
                MessageBox.Show("Добавлен объект");
                SqlDataAdapter adapter = new SqlDataAdapter(up, connection);
                DataSet ds = new DataSet();
                adapter.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
                connection.Close();
            }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //INSERT INTO User$ (ID, Login, Password, Name, Surname, Patronymic, Series, Number, Phone, Adress, [E-Mail], DateOfIssue, Issued, DateOfBirth, PlaceOfBirth) VALUES (51,1,'123','132','16','651',1,1,1)
        }

        private void button4_Click(object sender, EventArgs e)
        {
            
            string userred = "UPDATE User$ SET  Login = "+ textBox2.Text + ", Password = '" + textBox3.Text + "', Name = '" + textBox4.Text + "', Surname = '" + textBox5.Text + "', Patronymic = '" + textBox6.Text + "', Series = " + textBox7.Text + ", Number = " + textBox8.Text + ", Phone = " + textBox9.Text + ", Adress = '" + textBox10.Text + "', [E-Mail] = '" + textBox11.Text + "', DateOfIssue = '" + textBox12.Text + "', Issued = '" + textBox13.Text + "', DateOfBirth = '" + textBox14.Text + "', PlaceOfBirth = '" + textBox15.Text + "' WHERE ID = " + textBox1.Text +"";
            string up = "SELECT * FROM User$";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(userred, connection);
                int number = command.ExecuteNonQuery();
                MessageBox.Show("Объект изменен");
                SqlDataAdapter adapter = new SqlDataAdapter(up, connection);
                DataSet ds = new DataSet();
                adapter.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
                connection.Close();
            }

        }
    }
}

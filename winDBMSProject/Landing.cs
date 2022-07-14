using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace winDBMSProject
{
    public partial class Landing : Form
    {
        SqlConnection con = new SqlConnection(@"Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=RestaurantManangementSystem;Data Source=SUFI\MYSQL");
        public static int customerId = -1;
        public Landing()
        {
            InitializeComponent();
        }


        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            SignUp sign = new SignUp();
            sign.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length > 0 && textBox2.Text.Length > 0)
            {

                string sqlQuery = "Select Customer_id, Customer_name from Customer where email = '" + textBox1.Text +"' and password = '" +  textBox2.Text + "'";

                SqlCommand command = new SqlCommand(sqlQuery, con);
                Boolean foundRow = false;


                try
                {
                    con.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        foundRow = true;
                        Landing.customerId = int.Parse(reader["Customer_id"].ToString());
                        break;
                    }
                    reader.Close();
            }
                catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                con.Close();
            }
            if (foundRow)
                {
                    MessageBox.Show("Login Successfull");
                    new HomeScreen().Show();
                    this.Hide();
                }
                else { 
                    MessageBox.Show("Login Failed");
                }

            }
        }

        private void Landing_Load(object sender, EventArgs e)
        {

        }
    }
}

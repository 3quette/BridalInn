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
    public partial class ManagerLogin : Form
    {
        SqlConnection con = new SqlConnection(@"Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=RestaurantManangementSystem;Data Source=SUFI\MYSQL");
        public static int manager_id = -1;
        public ManagerLogin()
        {
            InitializeComponent();
        }

     
        private void btnManagerLogin_Click(object sender, EventArgs e)
        {
            if (txtManagerName.Text.Length > 0 && txtManagerPass.Text.Length > 0)
            {

                string sqlQuery = "Select manager_id, manager_name from Management where mang_email = '" + txtManagerName.Text + "' and [manager_password] = '" + txtManagerPass.Text + "'";

                SqlCommand command = new SqlCommand(sqlQuery, con);
                Boolean foundRow = false;


                try
                {
                    con.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        foundRow = true;
                        ManagerLogin.manager_id = int.Parse(reader["manager_id"].ToString());
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
                    new ManageMenu().Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Login Failed");
                }

            }

        }

        private void ManagerLogin_Load(object sender, EventArgs e)
        {

        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace winDBMSProject
{
 
  
    public partial class Payment : Form
    {
        SqlConnection con = new SqlConnection(@"Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=RestaurantManangementSystem;Data Source=SUFI\MYSQL");
        public Payment()
        {
            InitializeComponent();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Name Field cannot be empty!");
                return;
            }
            if (textBox3.Text == "")
            {
                MessageBox.Show("Address Field cannot be empty!");
                return;
            }
            if (textBox4.Text == "")
            {
                MessageBox.Show("Contact Field cannot be empty!");
                return;
            }

            string QRY = "Insert into [dbo].[Purchased] (Customer_name, Address,Contact) Values ('" + textBox1.Text+ "', '" + textBox3.Text + "', '" + textBox4.Text + "')";
            SqlCommand obj = new SqlCommand(QRY, con);
            con.Open();
            obj.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Information recieved!");
          


        }

        private void radbtnDelivery_CheckedChanged(object sender, EventArgs e)
        {
            //string QRY = "Insert into [dbo].[Purchased] (Payment_method) Values ('" + radbtnDelivery. + "', '" + textBox3.Text + "', '" + textBox4.Text + "')";
            //SqlCommand obj = new SqlCommand(QRY, con);
            //con.Open();
            //obj.ExecuteNonQuery();
            //con.Close();

        }

        private void Payment_Load(object sender, EventArgs e)
        {

        }
    }
}

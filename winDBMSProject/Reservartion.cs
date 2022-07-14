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
    public partial class Reservation : Form
    {
        SqlConnection con = new SqlConnection(@"Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=RestaurantManangementSystem;Data Source=SUFI\MYSQL");

        public Reservation()
        {
            InitializeComponent();
        }
        private void btnReserve_Click_1(object sender, EventArgs e)
        {
            string QRY = "Insert into [dbo].[TableCustomerInfo] (Customer_id, Date, Time,no_of_seats) Values ('" + Landing.customerId + "','" + txtDate.Text + "', '" + txtTime.Text + "',"+ txtSeats.Text + ");";
            SqlCommand obj = new SqlCommand(QRY, con);
            if (txtSeats.Text != "0")
            { 
                con.Open();
                obj.ExecuteNonQuery();
                con.Close();
                ViewReserve vr = new ViewReserve();
                vr.Show();
            }
            else
            {
                MessageBox.Show("Pleaee enter Number of Seats");
            }
           
        


        }

        private void btnViewReserve_Click(object sender, EventArgs e)
        {
            ViewReserve vr = new ViewReserve();
            vr.Show();
        }

        private void Reservation_Load(object sender, EventArgs e)
        {

        }
    }
}

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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace winDBMSProject
{
    public partial class SignUp : Form
    {
        SqlConnection con = new SqlConnection(@"Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=RestaurantManangementSystem;Data Source=SUFI\MYSQL");

        public SignUp()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (signEmail.Text.Length > 0 && signPass.Text.Length > 0)
            {
                con.Open();
                SqlCommand obj;
                DataTable dtData = new DataTable();
                obj = new SqlCommand("SignIn", con);
                obj.CommandType = CommandType.StoredProcedure;
                obj.Parameters.AddWithValue("@ActionType", "Insert");
                obj.Parameters.AddWithValue("@Customer_name", signName.Text);
                obj.Parameters.AddWithValue("@email", signEmail.Text);
                obj.Parameters.AddWithValue("@password", signPass.Text);
                obj.Parameters.AddWithValue("@Address", signAdd.Text);
                obj.Parameters.AddWithValue("@Contact", signContact.Text);
                obj.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Account Created Successfully!");
                this.Hide();
                Landing land = new Landing();
                land.Show();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Landing land = new Landing();
            land.Show();
        }

        private void SignUp_Load(object sender, EventArgs e)
        {

        }
    }
}

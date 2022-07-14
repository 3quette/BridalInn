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


    public partial class Menu : Form
    {
        private int selectedRow = -1;
        string selectedCartRow = "";
        SqlConnection con = new SqlConnection(@"Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=RestaurantManangementSystem;Data Source=SUFI\MYSQL");
        public Menu()
        {
            InitializeComponent();
        }
    
        public void BindGrid()
        {
            SqlDataAdapter da = new SqlDataAdapter("Select * from Items", con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            gvMenu.DataSource = ds.Tables[0];

            SqlDataAdapter d2 = new SqlDataAdapter("Select * from Carts where Customer_Id = " + Landing.customerId, con);
            DataSet ds2 = new DataSet();
            d2.Fill(ds2);
            gvCart.DataSource = ds2.Tables[0];
        }

        private void btnPayment_Click(object sender, EventArgs e)
        {
            DisplayDetails d = new DisplayDetails();
            d.Show();
        }

        private void gvMenu_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            this.selectedRow = e.RowIndex;
        }


        private void Menu_Load_1(object sender, EventArgs e)
        {
            BindGrid();

        }

        private void btnCart_Click(object sender, EventArgs e)
        {
            if (this.selectedRow != -1) {
                string QRY = "Insert into [dbo].[Carts] (Item, Price, Customer_id) Values ('" + gvMenu.Rows[this.selectedRow].Cells[1].Value.ToString() + "', " + gvMenu.Rows[this.selectedRow].Cells[2].Value.ToString() + ", " + Landing.customerId + ");";
                SqlCommand obj = new SqlCommand(QRY, con);
                con.Open();
                obj.ExecuteNonQuery();
                con.Close();
                this.BindGrid();
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (this.selectedCartRow != "")
            {
                string QRY = "Delete from Carts where id = " + this.selectedCartRow;
                SqlCommand obj = new SqlCommand(QRY, con);
                con.Open();
                obj.ExecuteNonQuery();
                con.Close();
                this.BindGrid();
            }
        }

        private void gvCart_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                this.selectedCartRow = gvCart.Rows[e.RowIndex].Cells[0].Value.ToString();
            }
            catch (Exception ex)
            {
            }
        }

        private void gvMenu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            this.selectedRow = e.RowIndex;
        }

        private void gvCart_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
            this.selectedCartRow = gvCart.Rows[e.RowIndex].Cells[0].Value.ToString();
            }
            catch (Exception ex) { 
            }

        }

        private void btnViewOrder_Click(object sender, EventArgs e)
        {
            DisplayDetails d = new DisplayDetails();
            d.Show();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}

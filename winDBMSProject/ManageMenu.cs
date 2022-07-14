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
    public partial class ManageMenu : Form
    {
        SqlConnection con = new SqlConnection(@"Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=RestaurantManangementSystem;Data Source=SUFI\MYSQL");
        string selectedRow = "";

        public ManageMenu()
        {
            InitializeComponent();
        }
        public void BindGrid()
        {
            SqlDataAdapter da = new SqlDataAdapter("Select * from Items", con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            gvManagerMenu.DataSource = ds.Tables[0];

        }
        private void ManageMenu_Load(object sender, EventArgs e)
        {
            BindGrid();
        }

        private void btnAddItem_Click(object sender, EventArgs e)
        {
            string QRY = "Insert into [dbo].[Items] (Item, Price)Values ('" + txtItem.Text + "', '" + txtPrice.Text + "')";

            SqlCommand obj = new SqlCommand(QRY, con);
            con.Open();
            obj.ExecuteNonQuery();
            con.Close();
            this.BindGrid();
        }

        private void btnPriceEdit_Click(object sender, EventArgs e)
        {
            string QRY = "Update [dbo].[Items] set Item='" + txtItem.Text + "', Price='" + txtPrice.Text + "' Where items_Id = " + this.selectedRow; 

            SqlCommand obj = new SqlCommand(QRY, con);

            con.Open();
            obj.ExecuteNonQuery();
            con.Close();
            this.BindGrid();
        }

        private void gvManagerMenu_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            this.selectedRow = gvManagerMenu.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtItem.Text = gvManagerMenu.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtPrice.Text = gvManagerMenu.Rows[e.RowIndex].Cells[2].Value.ToString();
        }

        private void gvManagerMenu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            this.selectedRow = gvManagerMenu.Rows[e.RowIndex].Cells[0].Value.ToString();
        }

        private void btnMenuDelete_Click(object sender, EventArgs e)
        {
            if (this.selectedRow != "")
            {
                string QRY = "Delete from Items where items_Id = " + this.selectedRow;
                SqlCommand obj = new SqlCommand(QRY, con);
                con.Open();
                obj.ExecuteNonQuery();
                con.Close();
                this.BindGrid();
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}

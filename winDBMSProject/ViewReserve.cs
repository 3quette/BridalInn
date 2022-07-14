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
    public partial class ViewReserve : Form
    {
        SqlConnection con = new SqlConnection(@"Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=RestaurantManangementSystem;Data Source=SUFI\MYSQL");

        public ViewReserve()
        {
            InitializeComponent();
        }
        public void BindGrid()
        {
            string Query = "select c.customer_name , t.Table_no,t.no_of_seats,t.date,t.time from customer c inner join TableCustomerInfo t on c.Customer_id = t.Customer_id where c.Customer_id = " + Landing.customerId;
            SqlDataAdapter da = new SqlDataAdapter(Query, con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            gvReserve.DataSource = ds.Tables[0];
            con.Open();
        }

        private void ViewReserve_Load(object sender, EventArgs e)
        {
            BindGrid();
        }
    }
}

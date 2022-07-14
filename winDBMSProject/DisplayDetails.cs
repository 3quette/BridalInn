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
    public partial class DisplayDetails : Form
    {
        SqlConnection con = new SqlConnection(@"Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=RestaurantManangementSystem;Data Source=SUFI\MYSQL");

        public DisplayDetails()
        {
            InitializeComponent();
        }
        public void BindGrid()
        {
            string Query = "Select Customer_name, ca.item,ca.Price from Carts ca inner join Customer cu on cu.Customer_id = ca.Customer_id where cu.Customer_id = " + Landing.customerId;
            SqlDataAdapter da = new SqlDataAdapter(Query, con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            gvOrderDetails.DataSource = ds.Tables[0];
            string QRY = "select SUM(Price) as 'TotalPrice' from Carts where Customer_id = " + Landing.customerId;
            SqlCommand command = new SqlCommand(QRY, con);
            con.Open();
            SqlDataReader reader = command.ExecuteReader();
            Boolean foundRow = false;
            while (reader.Read())
            {
                foundRow = true;
                txtTotalPrice.Text = reader.GetValue(0).ToString();
                break;

            }
            reader.Close();
            con.Close();
        }
       

        private void DisplayDetails_Load(object sender, EventArgs e)
        {
            BindGrid();
        }

       
    }
}

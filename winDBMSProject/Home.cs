using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace winDBMSProject
{
    public partial class HomeScreen : Form
    {
        
        public HomeScreen()
        {
            InitializeComponent();
        }

        

        private void Form1_Load(object sender, EventArgs e)
        {

        }

 
 

      
        private void btnReserve_Click(object sender, EventArgs e)
        {
            Reservation r = new Reservation();
            r.Show();
        }

        private void btnMenu_Click_1(object sender, EventArgs e)
        {
            Menu m = new Menu();
            m.Show();

        }
    }
}

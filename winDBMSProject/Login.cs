using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace winDBMSProject
{
    public partial class MainScreen : Form
    {
        public MainScreen()
        {
            InitializeComponent();
        }

        private void btnManagement_Click(object sender, EventArgs e)
        {
            ManagerLogin ml = new ManagerLogin();
            ml.Show();
            
        }

        private void btnCustomer_Click(object sender, EventArgs e)
        {
            Landing l = new Landing();
            l.Show();
        }

        private void MainScreen_Load(object sender, EventArgs e)
        {

        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Wsc2023Day2Paper2App
{
    public partial class FrmManagement : Form
    {
        public FrmManagement()
        {
            InitializeComponent();
        }

        private void btnviewdashboard_Click(object sender, EventArgs e)
        {
            FrmDashboard frmDashboard = new FrmDashboard();
            frmDashboard.Show();
            this.Hide();
        }

        private void btnmanageticketcategory_Click(object sender, EventArgs e)
        {
            FrmTicketManagement frmTicketManagement = new FrmTicketManagement();
            frmTicketManagement.Show();
            this.Hide();

        }

        private void btnlogout_Click(object sender, EventArgs e)
        {
            FrmLogin frmLogin = new FrmLogin();
            frmLogin.Show();
            this.Hide();
        }
    }
}

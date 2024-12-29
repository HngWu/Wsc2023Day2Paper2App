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
    public partial class FrmBackroomStuff : Form
    {
        public FrmBackroomStuff()
        {
            InitializeComponent();
        }

        private void btncheckin_Click(object sender, EventArgs e)
        {
            FrmUpdatePassengerRecords frmUpdatePassengerRecords = new FrmUpdatePassengerRecords();
            frmUpdatePassengerRecords.Show();
            this.Hide();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            FrmLogin frmLogin = new FrmLogin();
            frmLogin.Show();
            this.Hide();
        }

        private void btnmanageitinerary_Click(object sender, EventArgs e)
        {
            FrmManagementItinerary frmManagementItinerary = new FrmManagementItinerary();
            frmManagementItinerary.Show();
            this.Hide();
        }

        private void btndataimport_Click(object sender, EventArgs e)
        {
            FrmImportData frmImportData = new FrmImportData();  
            frmImportData.Show();
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

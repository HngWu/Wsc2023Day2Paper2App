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
    public partial class FrmCounterStuff : Form
    {
        public FrmCounterStuff()
        {
            InitializeComponent();
        }

        private void btncheckin_Click(object sender, EventArgs e)
        {
            FrmCheckIn frmCheckIn = new FrmCheckIn();
            frmCheckIn.Show();
            this.Hide();
        }

        private void btnupdatepassengerrecords_Click(object sender, EventArgs e)
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

        private void btnlogout_Click(object sender, EventArgs e)
        {
            FrmLogin frmLogin = new FrmLogin();
            frmLogin.Show();
            this.Hide();
        }
    }
}

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
    public partial class FrmLogin : Form
    {
        Wsc2023Day2Paper2Context context = new Wsc2023Day2Paper2Context();
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void btnsignin_Click(object sender, EventArgs e)
        {

            try
            {
                var username = tbusername.Text;
                var passworsd = tbpassword.Text;

                if(string.IsNullOrEmpty(username) || string.IsNullOrEmpty(passworsd))
                {
                    MessageBox.Show("Please enter username and password");
                    return;
                }

                var user = context.Users.FirstOrDefault(x => x.username == username && x.password == passworsd);


                if(user != null)
                {
                    var userTypeId = user.userTypeId;

                    if (userTypeId == 1)
                    {
                        FrmCounterStuff frmCounterStuff = new FrmCounterStuff();
                        frmCounterStuff.Show();
                        this.Hide();
                    }
                    else if (userTypeId == 2)
                    {
                        FrmBackroomStuff frmAdmin = new FrmBackroomStuff();
                        frmAdmin.Show();
                        this.Hide();
                    }
                    else if (userTypeId == 3)
                    {
                        FrmManagement frmAdmin = new FrmManagement();
                        frmAdmin.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Invalid username or password");
                    }
                    
                }
                else
                {
                    MessageBox.Show("Invalid username or password");
                }




            }
            catch (Exception)
            {

                MessageBox.Show("Invalid username or password");
            }




        }
    }
}

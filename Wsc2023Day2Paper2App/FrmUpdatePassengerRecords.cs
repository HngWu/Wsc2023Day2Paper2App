using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Migrations;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Wsc2023Day2Paper2App
{
    public partial class FrmUpdatePassengerRecords : Form
    {
        Wsc2023Day2Paper2Context context = new Wsc2023Day2Paper2Context();
        static string passengerEmail = "";
        public FrmUpdatePassengerRecords()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;

            LoadData();
            DataGridViewLinkColumn updateLink = new DataGridViewLinkColumn();
            updateLink.UseColumnTextForLinkValue = true;
            updateLink.HeaderText = "Update";
            updateLink.DataPropertyName = "lnkColumn";
            updateLink.LinkBehavior = LinkBehavior.SystemDefault;
            updateLink.Text = "Update";
            updateLink.Name = "Update";
            dgvpassengers.Columns.Add(updateLink);



        }


        public void ClearTextBox()
        {
            tbfrequetnflyernumber.Text = "";
            tbfirstname.Text = "";
            tblastname.Text = "";
            tbcontactdetails.Text = "";
        }

        public void LoadData()
        {
            var passengers = context.Passengers.ToList();
            dgvpassengers.DataSource = passengers;
        }

        private void dgvpassengers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == dgvpassengers.Columns["Update"].Index)
                {
                    var passengerEmailtostore = dgvpassengers.Rows[e.RowIndex].Cells["Passenger_Email"].Value.ToString();
                    passengerEmail = passengerEmailtostore;
                    var passenger = context.Passengers.FirstOrDefault(x => x.Passenger_Email == passengerEmail);


                    tbfirstname.Text = passenger.Passenger_First_Name.ToString();
                    tblastname.Text = passenger.Passenger_Last_Name;
                    tbfrequetnflyernumber.Text = passenger.Passenger_Frequent_Flyer_Number;
                    tbcontactdetails.Text = passenger.Contact_number.ToString();



                }
            }
            catch (Exception)
            {

                MessageBox.Show("Misclick");
            }
            
        }

        private void btnupdate_Click(object sender, EventArgs e)
        {
            try
            {
                if(tbfrequetnflyernumber.Text.ToString() == "" || tbfirstname.Text.ToString() == "" || tblastname.Text.ToString() == "" || tbcontactdetails.Text.ToString() == "")
                {
                    MessageBox.Show("Please fill all the fields");
                    return;
                }
                //if(tbcontactdetails.Text.ToString().Length != 8)
                //{
                //    MessageBox.Show("Please enter a valid contact number");
                //    return;
                //}


                if(int.TryParse(tbcontactdetails.Text.ToString(), out int contactNumber))
                {

                    var passenger = context.Passengers.FirstOrDefault(x => x.Passenger_Email == passengerEmail);
                    passenger.Passenger_First_Name = tbfirstname.Text.ToString();
                    passenger.Passenger_Last_Name = tblastname.Text.ToString();
                    passenger.Passenger_Frequent_Flyer_Number = tbfrequetnflyernumber.Text.ToString();
                    passenger.Contact_number = contactNumber;


                    context.Passengers.AddOrUpdate(passenger);
                    context.SaveChanges();
                    ClearTextBox();
                    LoadData();
                    MessageBox.Show("Passenger details updated successfully");

                    
                }
                else
                {
                    MessageBox.Show("Please enter a valid 8 digit contact number");
                    return;
                }



            }
            catch (Exception)
            {

                MessageBox.Show("An error has occured");
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            FrmLogin frmLogin = new FrmLogin();
            frmLogin.Show();
            this.Hide();
        }
    }
}

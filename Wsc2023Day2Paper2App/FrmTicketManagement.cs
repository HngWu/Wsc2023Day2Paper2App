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
    public partial class FrmTicketManagement : Form
    {
        Wsc2023Day2Paper2Context context = new Wsc2023Day2Paper2Context();
        BindingSource bs = new BindingSource();
        public static string selectedTicketCategoryId;
        public FrmTicketManagement()
        {
            InitializeComponent();
            var ticketCategories = context.TicketCategories.ToList();
            bs.DataSource = ticketCategories;
            dgvticketcategories.DataSource = bs;

            DataGridViewLinkColumn editLink = new DataGridViewLinkColumn();
            editLink.HeaderText = "Edit";
            editLink.Text = "Edit";
            editLink.UseColumnTextForLinkValue = true;
            editLink.Name = "Edit";
            dgvticketcategories.Columns.Add(editLink);

            DataGridViewLinkColumn deleteLink = new DataGridViewLinkColumn();
            deleteLink.HeaderText = "Delete";
            deleteLink.Text = "Delete";
            deleteLink.UseColumnTextForLinkValue = true;
            deleteLink.Name = "Delete";
            dgvticketcategories.Columns.Add(deleteLink);


            var flights = context.Flights.Select(x=>x.Flight_ID).ToArray();
            cbfiights.Items.AddRange(flights);

            var airlines = context.Airplanes.Select(x=>x.Airplane_ID).ToArray();
            cbairline.Items.AddRange(airlines);



        }


        public void loadData()
        {
            var ticketCategories = context.TicketCategories.ToList();
            bs.DataSource = ticketCategories;
            dgvticketcategories.DataSource = bs;
        }


        private void FrmTicketManagement_Load(object sender, EventArgs e)
        {

        }

        private void dgvticketcategories_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == dgvticketcategories.Columns["Edit"].Index)
                {
                    var ticketCategoryId = dgvticketcategories.Rows[e.RowIndex].Cells["Ticket_Category"].Value.ToString();
                    var ticketCategory = context.TicketCategories.Where(x => x.Ticket_Category == ticketCategoryId).FirstOrDefault();

                    tbseats.Text = ticketCategory.Seats;
                    tbfare.Text = ticketCategory.Fare.ToString();
                    tbchangefee.Text = ticketCategory.Change_fee.ToString();
                    tbclass.Text = ticketCategory.Class;
                    tbnumberofbaggages.Text = ticketCategory.Number_of_Baggage.ToString();
                    tbticketcategoryId.Text = ticketCategory.Ticket_Category;
                    tbweightofbaggages.Text = ticketCategory.Weight_of_Baggage.ToString();
                    tbcancellation.Text = ticketCategory.Cancellation_fee.ToString();
                    cbairline.Text = ticketCategory.Airplane;
                    cbfiights.Text = ticketCategory.Flight;
                    selectedTicketCategoryId = ticketCategoryId;


                    
                }
                else if(e.ColumnIndex == dgvticketcategories.Columns["Delete"].Index)
                {
                    var ticketCategoryId = dgvticketcategories.Rows[e.RowIndex].Cells["Ticket_Category"].Value.ToString();
                    var ticketCategory = context.TicketCategories.Where(x => x.Ticket_Category == ticketCategoryId).FirstOrDefault();
                    context.TicketCategories.Remove(ticketCategory);
                    context.SaveChanges();
                    loadData();
                    MessageBox.Show("Ticket category deleted successfully.");
                }
                else
                {
                    MessageBox.Show("Misclick");
                }



            }
            catch (Exception)
            {

                MessageBox.Show("Misclick");
            }
        }
        public void clearFields()
        {
            tbcancellation.Text = "";
            tbfare.Text = "";
            tbchangefee.Text = "";
            tbclass.Text = "";
            tbnumberofbaggages.Text = "";
            tbseats.Text = "";
            tbticketcategoryId.Text = "";
            tbweightofbaggages.Text = "";
            cbairline.Text = "";
            cbfiights.Text = "";

        }
        private void btncreate_Click(object sender, EventArgs e)
        {
            var isDulplicate = context.TicketCategories.Where(x => x.Ticket_Category == tbticketcategoryId.Text.ToString()).Any();

            if(isDulplicate)
            {
                MessageBox.Show("Ticket Category already exists");
                return;
            }
            // Null or empty validation
            if (string.IsNullOrEmpty(tbcancellation.Text) ||
                string.IsNullOrEmpty(tbfare.Text) ||
                string.IsNullOrEmpty(tbchangefee.Text) ||
                string.IsNullOrEmpty(tbclass.Text) ||
                string.IsNullOrEmpty(tbnumberofbaggages.Text) ||
                string.IsNullOrEmpty(tbseats.Text) ||
                string.IsNullOrEmpty(tbticketcategoryId.Text) ||
                string.IsNullOrEmpty(tbweightofbaggages.Text) ||
                string.IsNullOrEmpty(cbairline.Text) ||
                string.IsNullOrEmpty(cbfiights.Text))
            {
                MessageBox.Show("Please fill in all the fields.");
                return;
            }

            // Number validation
            decimal fare;
            if (!decimal.TryParse(tbfare.Text, out fare))
            {
                MessageBox.Show("Invalid fare value. Please enter a valid number.");
                return;
            }

            decimal changeFee;
            if (!decimal.TryParse(tbchangefee.Text, out changeFee))
            {
                MessageBox.Show("Invalid change fee value. Please enter a valid number.");
                return;
            }

            int numberOfBaggages;
            if (!int.TryParse(tbnumberofbaggages.Text, out numberOfBaggages))
            {
                MessageBox.Show("Invalid number of baggages value. Please enter a valid number.");
                return;
            }

           

            decimal weightOfBaggages;
            if (!decimal.TryParse(tbweightofbaggages.Text, out weightOfBaggages))
            {
                MessageBox.Show("Invalid weight of baggages value. Please enter a valid number.");
                return;
            }

            // Create ticket category
            // TODO: Add code to create the ticket category using the input values


            var newTicketCategory = new TicketCategory
            {
                Cancellation_fee = (short)fare,
                Change_fee = (byte)changeFee,
                Class = tbclass.Text.ToString(),
                Number_of_Baggage = (byte)numberOfBaggages,
                Seats = tbseats.Text.ToString(),
                Ticket_Category = tbticketcategoryId.Text.ToString(),
                Weight_of_Baggage = (byte)weightOfBaggages,
                Airplane = cbairline.SelectedItem.ToString(),
                Flight = cbfiights.SelectedItem.ToString(),
                Fare = (int)fare
            };
            context.TicketCategories.Add(newTicketCategory);
            context.SaveChanges();
            loadData();

            MessageBox.Show("Ticket category created successfully.");
            // Clear fields
            clearFields();
        }

        private void btnupdate_Click(object sender, EventArgs e)
        {
            try
            {
                var isDulplicate = context.TicketCategories.Where(x => x.Ticket_Category == tbticketcategoryId.Text.ToString()).Any();

                if (isDulplicate && tbticketcategoryId.Text.ToString() != selectedTicketCategoryId)
                {
                    MessageBox.Show("Ticket Category already exists");
                    return;
                }
                // Null or empty validation
                if (string.IsNullOrEmpty(tbcancellation.Text) ||
                    string.IsNullOrEmpty(tbfare.Text) ||
                    string.IsNullOrEmpty(tbchangefee.Text) ||
                    string.IsNullOrEmpty(tbclass.Text) ||
                    string.IsNullOrEmpty(tbnumberofbaggages.Text) ||
                    string.IsNullOrEmpty(tbseats.Text) ||
                    string.IsNullOrEmpty(tbticketcategoryId.Text) ||
                    string.IsNullOrEmpty(tbweightofbaggages.Text) ||
                    string.IsNullOrEmpty(cbairline.Text) ||
                    string.IsNullOrEmpty(cbfiights.Text))
                {
                    MessageBox.Show("Please fill in all the fields.");
                    return;
                }

                // Number validation
                decimal fare;
                if (!decimal.TryParse(tbfare.Text, out fare))
                {
                    MessageBox.Show("Invalid fare value. Please enter a valid number.");
                    return;
                }

                decimal changeFee;
                if (!decimal.TryParse(tbchangefee.Text, out changeFee))
                {
                    MessageBox.Show("Invalid change fee value. Please enter a valid number.");
                    return;
                }

                int numberOfBaggages;
                if (!int.TryParse(tbnumberofbaggages.Text, out numberOfBaggages))
                {
                    MessageBox.Show("Invalid number of baggages value. Please enter a valid number.");
                    return;
                }



                decimal weightOfBaggages;
                if (!decimal.TryParse(tbweightofbaggages.Text, out weightOfBaggages))
                {
                    MessageBox.Show("Invalid weight of baggages value. Please enter a valid number.");
                    return;
                }

                // Create ticket category
                // TODO: Add code to create the ticket category using the input values
                var ticketCategory = context.TicketCategories.Where(x => x.Ticket_Category == selectedTicketCategoryId).FirstOrDefault();

                ticketCategory.Cancellation_fee = (int)fare;
                ticketCategory.Change_fee = (int)changeFee;
                ticketCategory.Class = tbclass.Text.ToString();
                ticketCategory.Number_of_Baggage = (int)numberOfBaggages;
                ticketCategory.Seats = tbseats.Text.ToString();
                ticketCategory.Ticket_Category = tbticketcategoryId.Text.ToString();
                ticketCategory.Weight_of_Baggage = (int)weightOfBaggages;
                ticketCategory.Airplane = cbairline.SelectedItem.ToString();
                ticketCategory.Flight = cbfiights.SelectedItem.ToString();
                ticketCategory.Fare = (int)fare;




                context.TicketCategories.AddOrUpdate(ticketCategory);
                context.SaveChanges();
                loadData();

                MessageBox.Show("Ticket category updated successfully.");
                // Clear fields
                clearFields();
            }
            catch (Exception ex)
            {

                MessageBox.Show("An error has occured / cannot modify ticket category id");
            }
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            FrmManagement frmManagement = new FrmManagement();
            frmManagement.Show();
            this.Hide();
        }
    }
}

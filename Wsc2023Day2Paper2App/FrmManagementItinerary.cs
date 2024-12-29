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
    public partial class FrmManagementItinerary : Form
    {
        Wsc2023Day2Paper2Context context = new Wsc2023Day2Paper2Context();
        BindingSource bs = new BindingSource();
        public static Boolean createColumn = true;

        BindingSource bsflights = new BindingSource();
        BindingSource bsticketCategories = new BindingSource();


        public static string selectedTicketCategoryId;

        public FrmManagementItinerary()
        {
            InitializeComponent();
            var flights = context.Flights.ToList();
            bsflights.DataSource = flights;
            dgvflights.DataSource = bsflights;




        }
        public void loadData()
        {
            var bookingReference = tbbookingreference.Text.ToString();
            var tickets = context.Tickets.Where(x => x.Booking_Reference == bookingReference).ToList();
            bs.DataSource = tickets;
            dgvtickets.DataSource = bs;
        }
        private void btnenterbookingreference_Click(object sender, EventArgs e)
        {
            var bookingReference = tbbookingreference.Text.ToString();

            var existingBooking = context.Iteneraries.Where(x => x.Booking_Reference == bookingReference).Any();



            if(existingBooking)
            {
                var tickets = context.Tickets.Where(x => x.Booking_Reference == bookingReference).ToList();
                bs.DataSource = tickets;
                dgvtickets.DataSource = bs;
                if(createColumn)
                {
                    DataGridViewLinkColumn cancelLink = new DataGridViewLinkColumn();
                    cancelLink.HeaderText = "Cancel";
                    cancelLink.Name = "Cancel";
                    cancelLink.Text = "Cancel";
                    cancelLink.UseColumnTextForLinkValue = true;
                    dgvtickets.Columns.Add(cancelLink);
                    createColumn = false;


                    DataGridViewLinkColumn changeLink
                        = new DataGridViewLinkColumn();
                    changeLink.HeaderText = "Change";
                    changeLink.Name = "Change";
                    changeLink.Text = "Change";
                    changeLink.UseColumnTextForLinkValue = true;
                    dgvtickets.Columns.Add(changeLink);

                }


            }
            else
            {
                MessageBox.Show("Booking does not exist in itinerary");

            }
        }

        private void dgvtickets_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if(e.ColumnIndex == dgvtickets.Columns["Cancel"].Index)
                {
                    var ticketId = dgvtickets.Rows[e.RowIndex].Cells["Ticket_ID"].Value.ToString();

                    var ticket = context.Tickets.Where(x => x.Ticket_ID == ticketId).FirstOrDefault();
                    ticket.Status = "Cancelled";
                    ticket.Seat = null;
                    context.Tickets.AddOrUpdate(ticket);
                    context.SaveChanges();

                    var cancellationFee = ticket.TicketCategory.Cancellation_fee;

                    if(!string.IsNullOrEmpty(ticket.Booking_Reference))
                    {
                        MessageBox.Show("Ticket has been cancelled. Cancellation fee is " + cancellationFee);
                    }
                    loadData();
                }
                else if(e.ColumnIndex == dgvtickets.Columns["Change"].Index)
                {
                    var ticketId = dgvtickets.Rows[e.RowIndex].Cells["Ticket_ID"].Value.ToString();

                    var ticket = context.Tickets.Where(x => x.Ticket_ID == ticketId).FirstOrDefault();
                    
                    ticket.Status = "Changed";
                    var ticketCategory = context.TicketCategories.Where(x => x.Ticket_Category == common.selectedTicketCategoryId).FirstOrDefault();

                    ticket.TicketCategory = ticketCategory;
                    ticket.Seat = null;




                    context.Tickets.AddOrUpdate(ticket);
                    context.SaveChanges();
                    loadData();
                    var changeFee = ticket.TicketCategory.Change_fee;

                    if(!string.IsNullOrEmpty(ticket.Booking_Reference))
                    {
                        MessageBox.Show("Ticket has been changed. Change fee is " + changeFee);
                    }
                }


            }
            catch (Exception)
            {

                MessageBox.Show("Misclick. Please click on a flight and ticket category before proceeding");
            }
        }

        private void dgvflights_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvflights_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                var selectedRow = dgvflights.SelectedRows[0];

                var flightId = selectedRow.Cells["Flight_ID"].Value.ToString();

                var ticketCategories = context.TicketCategories.Where(x => x.Flight == flightId).ToList();
                bsticketCategories.DataSource = ticketCategories;
                dgvticketcategory.DataSource = bsticketCategories;
                



            }
            catch (Exception ex)
            {

                MessageBox.Show("Misclick");
            }
        }

        private void dgvticketcategory_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                var selectedRow = dgvticketcategory.SelectedRows[0];

                var ticketCategoryId = selectedRow.Cells["Ticket_Category"].Value.ToString();
                selectedTicketCategoryId = ticketCategoryId;




            }
            catch (Exception)
            {

                MessageBox.Show("Misclick");
            }
        }

        private void dgvticketcategory_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                var selectedRow = dgvticketcategory.SelectedRows[0];

                var ticketCategoryId = selectedRow.Cells["Ticket_Category"].Value.ToString();
                selectedTicketCategoryId = ticketCategoryId;

                common.selectedTicketCategoryId = ticketCategoryId;
            }
            catch (Exception)
            {

                MessageBox.Show("Misclick");
            }


        }
    }
}

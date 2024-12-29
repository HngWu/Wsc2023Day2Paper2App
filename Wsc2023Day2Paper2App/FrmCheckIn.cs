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

    //TODO data import only show records with issues
    //TODO check in each passenger, then assign seat for all passengers
    //TODO Dashboard show line graph based on payments table






    public partial class FrmCheckIn : Form
    {
        Wsc2023Day2Paper2Context context = new Wsc2023Day2Paper2Context();
        BindingSource flightBindingSource = new BindingSource();
        BindingSource passengerBindingSource = new BindingSource();
        public static TicketCategory ticketForChecking;
        public static string bookingRef;
        public static string seatNo;
        public static List<string> bookedSeatsToCheck;
        public static string selectedPassengerEmail;

        public FrmCheckIn()
        {
            this.WindowState = FormWindowState.Maximized;
            InitializeComponent();

        }

        private void button29_Click(object sender, EventArgs e)
        {

        }

        private void FrmCheckIn_Load(object sender, EventArgs e)
        {

        }
        // Modify the GenerateSeatMap method to set a fixed size for each seat

        public List<string> getAllSeatNumbers()
        {
            var allSeats = new List<string>();
            foreach (Control control in tlpseats.Controls)
            {
                if (control is Button seatButton)
                {
                    allSeats.Add(seatButton.Text);
                }
            }
            return allSeats;
        }

        private void GenerateSeatMap()
        {
            int rows = 15; // Number of rows in the seat layout
            int columns = 7; // Number of columns
            int seatSize = 50; // Size of each seat in pixels
            //var disabledSeats = new List<string> { "A2", "A2", "A3", "A4", "A5", "B3", "B4", "O1", "O6" }; // Example of disabled seats 
            // Remove the existing seatLayout if it exists
            if (tlpseats.Controls.Count > 0)
            {
                tlpseats.Controls.Clear();
            }

            tlpseats.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;

            // Set the size of each cell in the table layout panel
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    if (j == 3) // Skip column 4
                    {
                        continue;
                    }

                    var columnNumber = j;
                    if (j > 3)
                    {
                        columnNumber--; // Adjust column number to skip column 4
                    }


                    string seatNumber = $"{(char)('A' + i)}{(columnNumber + 1)}"; // E.g., "A1", "B1"
                    Button seatButton = new Button
                    {
                        Text = seatNumber,
                        Dock = DockStyle.Fill,
                        Tag = "Available", // Custom tag to store seat status
                        Width = 10, // Set the width of the seat
                        Height = 10 // Set the height of the seat
                    };
                    if (seatNumber.Contains("L") || seatNumber.Contains("M") || seatNumber.Contains("N") || seatNumber.Contains("O"))
                    {
                        seatButton.BackColor = Color.Yellow; // Set backcolor to yellow
                        seatButton.ForeColor = Color.Black; // Set text color to black
                    }
                    else
                    {
                        seatButton.BackColor = Color.Green; // Available seat
                        seatButton.ForeColor = Color.White; // Set text color to white
                    }

                    // Event to handle seat selection
                    seatButton.Click += SeatButton_Click;

                   
                   
                        tlpseats.Controls.Add(seatButton, j, i);
                    

                }
            }
        }

        private void SeatButton_Click(object sender, EventArgs e)
        {
            Button seatButton = sender as Button;

            


            if (seatButton.Tag.ToString() == "Available")
            {
                if (string.IsNullOrEmpty(seatNo) == false)
                {
                    MessageBox.Show("Seat Has already been selected");
                    return;
                }


                seatButton.BackColor = Color.Blue; // Selected for check-in
                seatButton.Tag = "Selected";
                seatButton.ForeColor = Color.White; // Set text color to white

                seatNo = seatButton.Text.ToString();


            }
            else if (seatButton.Tag.ToString() == "Selected")
            {
                if (seatButton.Text.ToString().Contains("L") || seatButton.Text.ToString().Contains("M") || seatButton.Text.ToString().Contains("N") || seatButton.Text.ToString().Contains("O"))
                {
                    seatButton.BackColor = Color.Yellow; // Set backcolor to yellow
                    seatButton.ForeColor = Color.Black; // Set text color to black
                }
                else
                {
                    seatButton.BackColor = Color.Green; // Available seat
                    seatButton.ForeColor = Color.White; // Set text color to white
                }


                seatNo = null;
                seatButton.Tag = "Available";
            }
            else
            {
                MessageBox.Show("This seat is already booked!", "Seat Selection");
            }
        }

        // Example of setting booked seats
        private void SetBookedSeats(List<string> bookedSeats)
        {
            foreach (Control control in tlpseats.Controls)
            {
                if (control is Button seatButton && bookedSeats.Contains(seatButton.Text))
                {
                    seatButton.BackColor = Color.LightBlue; // Booked seat
                    seatButton.Tag = "Booked";
                    seatButton.Enabled = false; // Disable booked seat
                }
            }
        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btncheckin_Click(object sender, EventArgs e)
        {
            // Get the booking reference

            try
            {
                var numberOfBaggages = int.Parse(tbquantity.Text.ToString());
                var baggageWeight = int.Parse(tbweight.Text.ToString());
                var additionalCost = 0;
                var description = "";

                if (numberOfBaggages > ticketForChecking.Number_of_Baggage)
                {
                    additionalCost = (numberOfBaggages - ticketForChecking.Number_of_Baggage) * 150;
                    description = "Extra Baggage.";
                }
                if (baggageWeight > ((23 * ticketForChecking.Number_of_Baggage)  + ticketForChecking.Weight_of_Baggage))
                {
                    additionalCost += (int)Math.Ceiling((double)(baggageWeight - ((23 * ticketForChecking.Number_of_Baggage)  + ticketForChecking.Weight_of_Baggage)) / 9) * 100;
                    description = "Extra Weight.";

                }

                DialogResult result = MessageBox.Show($"Additional cost for (extra)baggage is ${additionalCost}", "Check-in", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    var bookingReference = bookingRef;
                    if (additionalCost > 0)
                    {
                        var newPayment = new Payment
                        {
                            Booking_Reference = bookingReference,
                            Item = "Baggage Add-On",
                            Description = description,
                            Payment_Date = DateTime.Now,
                            Fare = additionalCost,
                        };
                        context.Payments.Add(newPayment);
                    }

                    var ticket = context.Tickets.Where(x => x.Booking_Reference == bookingReference && x.Passenger == selectedPassengerEmail).FirstOrDefault();

                    if (ticket.Status == "Checked In" || ticket.Status == "Cancelled")
                    {
                        MessageBox.Show("Passenger has already been checked in");
                        return;
                    }

                    ticket.Status = "Checked In";
                    ticket.Number_of_Baggage = (int)numberOfBaggages;

                    if (string.IsNullOrEmpty(seatNo))
                    {
                        var allSeats = getAllSeatNumbers();
                        seatNo = allSeats.Except(bookedSeatsToCheck).FirstOrDefault();
                    }

                    ticket.Seat = seatNo;

                    context.Tickets.AddOrUpdate(ticket);
                    context.SaveChanges();
                    MessageBox.Show("Check-in successful!", "Check-in");
                    tbbookingreference.Text = "";
                    tbquantity.Text = "";
                    tbweight.Text = "";
                    seatNo = null;
                    var bookedSeats = context.Tickets.Where(x => x.Ticket_Category == ticketForChecking.Ticket_Category).Select(x => x.Seat).ToList();
                    bookedSeatsToCheck = bookedSeats;
                    SetBookedSeats(bookedSeats);


                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Fill in all fields");
            }
            
            
            


            
        }

      

       
        private void btnenterbookingreference_Click(object sender, EventArgs e)
        {
            var bookingReference = tbbookingreference.Text.ToString();
            bookingRef = bookingReference;
            var ticket = context.Tickets.Where(x => x.Booking_Reference == bookingReference).FirstOrDefault();

            seatNo = null;


            var passengerEmails = context.Tickets.Where(x => x.Booking_Reference == bookingReference).Select(x => x.Passenger).ToList();
            var ticketCategoryId = context.Tickets.Where(x => x.Booking_Reference == bookingReference).Select(x => x.Ticket_Category).FirstOrDefault();
            var ticketCategory = context.TicketCategories.Where(x => x.Ticket_Category == ticketCategoryId).FirstOrDefault();
            var flightId = ticketCategory.Flight;
            ticketForChecking = ticketCategory;
            var flight = context.Flights.Where(x => x.Flight_ID == flightId).Select(x => new
            {
                x.Flight_ID,
                From = x.Origin + " " + x.Departure_time,
                To = x.Destination + " " + x.Arrival_time,
            }).FirstOrDefault();

            



            if (passengerEmails.Count() > 0)
            {

                GenerateSeatMap();



                var passenger = context.Passengers.Where(x => passengerEmails.Contains(x.Passenger_Email))
                    .Select(x=> new
                    {
                        Name = x.Passenger_First_Name + " " + x.Passenger_Last_Name,
                        x.Passenger_Frequent_Flyer_Number,
                        x.Passenger_Passport_number,
                        x.Passenger_Email,
                        x.Contact_number,
                    }).ToList();

                passengerBindingSource.DataSource = passenger;
                dgvpassengers.DataSource = passengerBindingSource;

                flightBindingSource.DataSource = flight;
                dgvflights.DataSource = flightBindingSource;



                var bookedSeats = context.Tickets.Where(x => x.Ticket_Category == ticketCategory.Ticket_Category).Select(x => x.Seat).ToList();
                bookedSeatsToCheck = bookedSeats;
                SetBookedSeats(bookedSeats);
            }




            else
            {
                MessageBox.Show("Booking reference not found!", "Check-in");
            }
            

        }

        private void tableLayoutPanel2_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void dgvpassengers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                var selectedRow = dgvpassengers.SelectedRows[0];
                var passengerEmail = selectedRow.Cells["Passenger_Email"].Value.ToString();

                var ticket = context.Tickets.Where(x => x.Booking_Reference == bookingRef && x.Passenger == passengerEmail).FirstOrDefault();
                var NumberOfBaggages = ticket.Number_of_Baggage;
                var BaggageWeight = ticket.Weight_of_Baggage;


                if (NumberOfBaggages != null)
                {
                    tbquantity.Text = NumberOfBaggages.ToString();
                }
                if (BaggageWeight != null)
                {
                    tbweight.Text = BaggageWeight.ToString();
                }



            }
            catch (Exception)
            {

                MessageBox.Show("Misclick");
            }
        }

        private void dgvpassengers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                var selectedRow = dgvpassengers.SelectedRows[0];
                var passengerEmail = selectedRow.Cells["Passenger_Email"].Value.ToString();
                selectedPassengerEmail = passengerEmail;
                var ticket = context.Tickets.Where(x => x.Booking_Reference == bookingRef && x.Passenger == passengerEmail).FirstOrDefault();
                var NumberOfBaggages = ticket.Number_of_Baggage;
                var BaggageWeight = ticket.Weight_of_Baggage;


                if (NumberOfBaggages != null)
                {
                    tbquantity.Text = NumberOfBaggages.ToString();
                }
                if (BaggageWeight != null)
                {
                    tbweight.Text = BaggageWeight.ToString();
                }



            }
            catch (Exception)
            {

                MessageBox.Show("Misclick");
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            FrmCounterStuff frmCounterStuff = new FrmCounterStuff();
            frmCounterStuff.Show();
            this.Hide();
        }

        private void btnclear_Click(object sender, EventArgs e)
        {
            FrmCheckIn checkIn = new FrmCheckIn();
            checkIn.Show();
            this.Hide();
        }
    }
}

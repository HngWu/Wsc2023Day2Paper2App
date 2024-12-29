using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Wsc2023Day2Paper2App
{
    public partial class FrmDashboard : Form
    {
        Wsc2023Day2Paper2Context context = new Wsc2023Day2Paper2Context();
        public FrmDashboard()
        {
            InitializeComponent();


            cbfilter.SelectedIndex = 0;
            loadData();
        }

        public void loadData()
        {
            if(cbfilter.SelectedItem.ToString() == "Ticket Category")
            {
                var ticketCategories = context.TicketCategories.ToList();
                var revenueByCategory = new Dictionary<string, decimal>();

                foreach (var category in ticketCategories)
                {
                    var totalTickets = context.Tickets
                        .Where(t => t.Ticket_Category == category.Ticket_Category)
                        .Count();

                    var totalRevenue = totalTickets * category.Fare;

                    revenueByCategory.Add(category.Ticket_Category, totalRevenue);
                }

                // Set up bar chart for total revenue by ticket category
                barchart.Series.Clear();
                barchart.ChartAreas.Clear();
                barchart.ChartAreas.Add(new ChartArea());

                var series = new Series();
                series.ChartType = SeriesChartType.Bar;
                series.Name = "Revenue by Ticket Category";
                foreach (var category in revenueByCategory)
                {
                    series.Points.AddXY(category.Key, category.Value);
                }

                barchart.Series.Add(series);
            }
            else
            {
                var flights = context.Flights.ToList();
                var revenueByFlight = new Dictionary<string, decimal>();

                foreach (var flight in flights)
                {
                    var categories = context.TicketCategories.Where(t => t.Flight == flight.Flight_ID).ToList();
                    var totalRevenue = 0m;
                    foreach (var category in categories)
                    {
                        var totalTickets = context.Tickets
                        .Where(t => t.Ticket_Category == category.Ticket_Category)
                        .Count();
                        totalRevenue += totalTickets * category.Fare;

                    }





                    revenueByFlight.Add(flight.Flight_ID, totalRevenue);
                }

                // Set up bar chart for total revenue by ticket category
                barchart.Series.Clear();
                barchart.ChartAreas.Clear();
                barchart.ChartAreas.Add(new ChartArea());

                var series = new Series();
                series.ChartType = SeriesChartType.Bar;
                series.Name = "Revenue by Flight ID";
                foreach (var category in revenueByFlight)
                {
                    series.Points.AddXY(category.Key, category.Value);
                }

                barchart.Series.Add(series);

            }

           
        }


        private void FrmDashboard_Load(object sender, EventArgs e)
        {
            // Calculate total revenue of tickets for each ticket category
            
        }

        private void barchart_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadData();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            FrmManagement frmManagement = new FrmManagement();
            frmManagement.Show();
            this.Hide();
        }
    }
}

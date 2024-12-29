using ExcelDataReader;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Migrations;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Wsc2023Day2Paper2App
{
    public partial class FrmImportData : Form
    {
        Wsc2023Day2Paper2Context context = new Wsc2023Day2Paper2Context();
        BindingSource bs = new BindingSource();
        private string logFilePath = "import_log.txt"; // Specify the path and name of the log file

        public FrmImportData()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
        }

        private void btnupload_Click(object sender, EventArgs e)
        {
            // Code to import and process the data from the existing system

            // Step 1: Read the CSV file and store the data as a list of Passenger objects
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Excel Files (*.xlsx)|*.xlsx";
            openFileDialog.Title = "Select an Excel File";

            var dataTable = new DataTable();
            var StringBuilder = new StringBuilder();
            dataTable.Columns.Add("Passenger_Email", typeof(string));
            dataTable.Columns.Add("Passenger_First_Name", typeof(string));
            dataTable.Columns.Add("Passenger_Last_Name", typeof(string));
            dataTable.Columns.Add("Passenger_Frequent_Flyer_Number", typeof(string));
            dataTable.Columns.Add("Passenger_Passport_number", typeof(string));
            dataTable.Columns.Add("Contact_number", typeof(string));
            dataTable.Columns.Add("Reason", typeof(string));
            int i = 1;
            try
            {
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = openFileDialog.FileName;

                    using (var stream = File.Open(filePath, FileMode.Open, FileAccess.Read))
                    {
                        using (var reader = ExcelReaderFactory.CreateReader(stream))
                        {
                            var dataSet = reader.AsDataSet(new ExcelDataSetConfiguration
                            {
                                ConfigureDataTable = _ => new ExcelDataTableConfiguration
                                {
                                    UseHeaderRow = true
                                }
                            });
                            var sheet = dataSet.Tables[0];

                            var passengerList = new List<Passenger>();

                            foreach (DataRow row in sheet.Rows)
                            {
                                var email = row["Passenger Email"].ToString();
                                var firstName = row["Passenger First Name"].ToString();
                                var lastName = row["Passenger Last Name"].ToString();
                                var frequentFlyerNumber = row["Passenger Frequent Flyer Number"].ToString();
                                var passportNumber = row["Passenger Passport number"].ToString();
                                var contactNumber = row["Contact number"].ToString();

                                int? ContactToStore = null;

                                if (int.TryParse(contactNumber, out int result))
                                {
                                    ContactToStore = result;
                                }

                                var passenger = new Passenger
                                {
                                    Passenger_Email = email,
                                    Passenger_First_Name = firstName,
                                    Passenger_Last_Name = lastName,
                                    Passenger_Frequent_Flyer_Number = frequentFlyerNumber,
                                    Passenger_Passport_number = passportNumber,
                                    Contact_number = ContactToStore
                                };
                                passengerList.Add(passenger);
                            }

                            foreach (var passenger in passengerList)
                            {
                                var existingPassenger = context.Passengers.FirstOrDefault(p => p.Passenger_Email == passenger.Passenger_Email.Trim());
                                if (existingPassenger == null)
                                {
                                    // New passenger, add to the database

                                    context.Passengers.Add(passenger);
                                    context.SaveChanges();

                                    
                                   


                                }
                                else
                                {
                                    var reason = "Duplicate Found. ";
                                    var row = dataTable.NewRow();
                                    row["Passenger_Email"] = passenger.Passenger_Email;
                                    row["Passenger_First_Name"] = passenger.Passenger_First_Name;
                                    row["Passenger_Last_Name"] = passenger.Passenger_Last_Name;
                                    row["Passenger_Frequent_Flyer_Number"] = passenger.Passenger_Frequent_Flyer_Number;
                                    row["Passenger_Passport_number"] = passenger.Passenger_Passport_number;
                                    row["Contact_number"] = passenger.Contact_number.ToString() ?? "";

                                    // Existing passenger, merge or update based on conditions
                                    if (string.IsNullOrEmpty(existingPassenger.Passenger_First_Name))
                                    {
                                        existingPassenger.Passenger_First_Name = passenger.Passenger_First_Name;
                                        reason += "Merged first name attribute with record in database. ";
                                    }
                                    if (string.IsNullOrEmpty(existingPassenger.Passenger_Last_Name))
                                    {
                                        existingPassenger.Passenger_Last_Name = passenger.Passenger_Last_Name;
                                        reason += "Merged last name attribute with record in database. ";
                                    }

                                    // Check if the attribute is null before assigning a value
                                    if (existingPassenger.Passenger_Frequent_Flyer_Number == null || string.IsNullOrEmpty(existingPassenger.Passenger_Frequent_Flyer_Number))
                                    {
                                        existingPassenger.Passenger_Frequent_Flyer_Number = passenger.Passenger_Frequent_Flyer_Number;
                                        reason += "Merged Passenger_Frequent_Flyer_Number attribute with record in database. ";
                                    }

                                    // Check if the attribute is null before assigning a value
                                    if (existingPassenger.Passenger_Passport_number == null || string.IsNullOrEmpty(existingPassenger.Passenger_Passport_number))
                                    {
                                        existingPassenger.Passenger_Passport_number = passenger.Passenger_Passport_number;
                                        reason += "Merged Passenger_Passport_number attribute with record in database. ";
                                    }

                                    if (existingPassenger.Contact_number == null)
                                    {
                                        if (passenger.Contact_number != null)
                                        {
                                            existingPassenger.Contact_number = passenger.Contact_number;
                                            reason += "Merged Contact_number attribute with record in database. ";
                                        }
                                    }

                                    // Check if the attribute is null before assigning a value
                                    if (existingPassenger.Passenger_First_Name != passenger.Passenger_First_Name && (existingPassenger.Passenger_First_Name == null || string.IsNullOrEmpty(existingPassenger.Passenger_First_Name)))
                                    {
                                        existingPassenger.Passenger_First_Name = passenger.Passenger_First_Name;
                                        reason += "Updated first Name attribute of record in database. ";
                                    }

                                    // Check if the attribute is null before assigning a value
                                    if (existingPassenger.Passenger_Last_Name != passenger.Passenger_Last_Name && (existingPassenger.Passenger_Last_Name == null || string.IsNullOrEmpty(existingPassenger.Passenger_Last_Name)))
                                    {
                                        existingPassenger.Passenger_Last_Name = passenger.Passenger_Last_Name;
                                        reason += "Updated last name attribute of record in database";
                                    }

                                    // Check if the attribute is null before assigning a value
                                    if (existingPassenger.Passenger_Frequent_Flyer_Number != passenger.Passenger_Frequent_Flyer_Number && (existingPassenger.Passenger_Frequent_Flyer_Number == null || string.IsNullOrEmpty(existingPassenger.Passenger_Frequent_Flyer_Number)))
                                    {
                                        existingPassenger.Passenger_Frequent_Flyer_Number = passenger.Passenger_Frequent_Flyer_Number;
                                        reason += "Updated  frequent flyer number attribute of record in database";
                                    }

                                    // Check if the attribute is null before assigning a value
                                    if (existingPassenger.Passenger_Passport_number != passenger.Passenger_Passport_number && (existingPassenger.Passenger_Passport_number == null || string.IsNullOrEmpty(existingPassenger.Passenger_Passport_number)))
                                    {
                                        existingPassenger.Passenger_Passport_number = passenger.Passenger_Passport_number;
                                        reason += "Updated passenger passport number attribute of record in database";
                                    }

                                    row["Reason"] = reason;
                                    StringBuilder.AppendLine($"Passenger Email: {passenger.Passenger_Email}");
                                    StringBuilder.AppendLine($"Passenger First Name: {passenger.Passenger_First_Name}");
                                    StringBuilder.AppendLine($"Passenger Last Name: {passenger.Passenger_Last_Name}");
                                    StringBuilder.AppendLine($"Passenger Frequent Flyer Number: {passenger.Passenger_Frequent_Flyer_Number}");
                                    StringBuilder.AppendLine($"Passenger Passport number: {passenger.Passenger_Passport_number}");
                                    StringBuilder.AppendLine($"Contact number: {passenger.Contact_number}");
                                    StringBuilder.AppendLine($"Reason: {reason}");
                                    StringBuilder.AppendLine();
                                    context.Passengers.AddOrUpdate(existingPassenger);
                                    context.SaveChanges();

                                    dataTable.Rows.Add(row);
                                    i++;
                                }
                            }
                            var passengerCount = context.Passengers.Count();
                            bs.DataSource = dataTable;
                            dgvpassengers.DataSource = bs;
                            MessageBox.Show($"Data Imported Successfully. count: {i}");
                            lbdisplay.Text = $"File name {filePath}\nNumber of Records: {i}\nNumber of records Processed: {passengerCount}\nNumber of Records with Errors: 0 ";
                            // Log the import process
                            using (StreamWriter writer = new StreamWriter(logFilePath, true))
                            {
                                writer.WriteLine($"Imported data from file: {filePath}");
                                writer.WriteLine($"Total records imported: {i}");
                                writer.WriteLine(StringBuilder);
                                writer.WriteLine();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An Error has occurred");
            }
        }

        private void dgvpassengers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }

        

        
    
}

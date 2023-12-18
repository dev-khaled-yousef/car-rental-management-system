﻿using CarRental.GlobalClasses;
using CarRental_Business;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace CarRental.Dashboard
{
    public partial class frmDashboard : Form
    {
        public frmDashboard()
        {
            InitializeComponent();

            int AllVehicles = clsVehicle.GetAllVehiclesCount();

            lblNumberOfCustomers.Text = clsCustomer.GetCustomersCount().ToString();
            lblNumberOfUsers.Text = clsUser.GetUsersCount().ToString();
            lblNumberOfVehicles.Text = AllVehicles.ToString();
            lblNumberOfBooking.Text = clsBooking.GetBookingCount().ToString();
            lblNumberOfReturn.Text = clsReturn.GetReturnCount().ToString();
            lblNumberOfTransaction.Text = clsTransaction.GetTransactionsCount().ToString();


            int AvailableVehiclesCount = clsVehicle.GetAvailableVehiclesCount();
            int RentedVehiclesCount = AllVehicles - AvailableVehiclesCount;

            chartVehiclesStatus.Titles.Add("");
            chartVehiclesStatus.Series["s1"].IsValueShownAsLabel = true;

            // Add data points with legend text
            DataPoint availableDataPoint = new DataPoint();
            availableDataPoint.SetValueXY("Available", AvailableVehiclesCount);
            availableDataPoint.LegendText = "Available";
            chartVehiclesStatus.Series["s1"].Points.Add(availableDataPoint);

            DataPoint rentedDataPoint = new DataPoint();
            rentedDataPoint.SetValueXY("Rented", RentedVehiclesCount);
            rentedDataPoint.LegendText = "Rented";
            chartVehiclesStatus.Series["s1"].Points.Add(rentedDataPoint);

            lblHiUsername.Text = $"Hi {clsGlobal.CurrentUser.Username}";
        }
    }
}

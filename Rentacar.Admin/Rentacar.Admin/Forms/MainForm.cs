using Rentacar.Admin.Forms;
using Rentacar.Admin.Reports;
using Rentacar.Admin.Services;
using Rentacar.Dto;
using Rentacar.Dto.Request;
using Rentacar.Dto.Response;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rentacar.Admin
{
    public partial class MainForm : Form
    {
        private FilterLookupsDto _filterLookupsDto;

        public MainForm()
        {
            InitializeComponent();
            Form loginForm = new LoginForm();
            loginForm.ShowDialog();

            Task.Run(() => InitializeData());
        }

        private async void InitializeData()
        {
            await InitializeHomePage();
            await InitializeBookingFilters();
            await InitializeUsers();
            await InitializeVehicles();
        }

        private async Task InitializeVehicles()
        {
            dataGridViewVehicles.DataSource = await VehicleService.FilterVehicles(new VehicleRequestDto());
            dataGridViewVehicles.Refresh();
        }

        private async Task InitializeBookingFilters()
        {
            _filterLookupsDto = await FilterService.GetFilterLookups();

            comboBoxBookingMake.DataSource = _filterLookupsDto.Makes;
            comboBoxBookingMake.SelectedItem = null;
            comboBoxBookingModel.DataSource = _filterLookupsDto.Models;
            comboBoxBookingModel.SelectedItem = null;
            comboBoxBookingVehicleType.DataSource = _filterLookupsDto.VehicleTypes;
            comboBoxBookingVehicleType.SelectedItem = null;

            comboBoxVehicleNoSeats.DataSource = new List<string>() { "3", "4", "5", "6" };
            comboBoxVehicleNoSeats.SelectedItem = null;
            comboBoxVehiclesVehicleType.DataSource = _filterLookupsDto.VehicleTypes;
            comboBoxVehiclesVehicleType.SelectedItem = null;
            comboBoxVehiclesMake.DataSource = _filterLookupsDto.Makes;
            comboBoxVehiclesMake.SelectedItem = null;
            comboBoxVehiclesModel.DataSource = _filterLookupsDto.Models;
            comboBoxVehiclesModel.SelectedItem = null;
            comboBoxVehicleTransmission.DataSource = new List<ComboBoxItem>() {
                new ComboBoxItem() { Value = 1, Text = "Manual"},
                new ComboBoxItem() { Value = 2, Text = "Automatic"},
            };
            comboBoxVehicleTransmission.SelectedItem = null;
            comboBoxVehiclesLocation.DataSource = _filterLookupsDto.Locations;
            comboBoxVehiclesLocation.SelectedItem = null;

            dataGridViewBookings.DataSource = await BookingService.FilterBookings(new BookingRequestDto());
            dataGridViewBookings.Refresh();
        }

        private async Task InitializeHomePage()
        {
            dataGridViewActiveBookings.Invoke(new Action(async () =>
            {
                dataGridViewActiveBookings.DataSource = await BookingService.GetActiveBookings();
                dataGridViewActiveBookings.Refresh();
            }));

            dataGridViewHistory.Invoke(new Action(async () =>
            {
                dataGridViewHistory.DataSource = await BookingService.GetBookingHistory();
                dataGridViewHistory.Refresh();
            }));
        }

        private async Task InitializeUsers()
        {
            dataGridViewUsers.DataSource = await UserService.FilterUsers(null, null, null, null);
            dataGridViewUsers.Refresh();
        }

        private void buttonExport_Click(object sender, EventArgs e)
        {
            BookingsReport bookingsReport = new BookingsReport(dataGridViewBookings.DataSource as List<BaseBookingDto>);
            bookingsReport.Show();
        }

        private async void buttonSearch_Click(object sender, EventArgs e)
        {
            var bookingInt = int.TryParse(textBoxBookingId.Text, out int bookingId);
            var vehicleInt = int.TryParse(textBoxVehicleId.Text, out int vehicleId);
            var userInt = int.TryParse(textBoxBuyerId.Text, out int userId);

            var bookingQuery = new BookingRequestDto()
            {
                StartDate = dateTimePickerStartDate.Value,
                EndDate = dateTimePickerEndDate.Value,
                BookingId = bookingInt ? bookingId : 0,
                VehicleId = vehicleInt ? vehicleId : 0,
                UserId = userInt ? userId : 0,
                Model = comboBoxBookingModel.SelectedItem?.ToString(),
                Make = comboBoxBookingMake.SelectedItem?.ToString(),
                MinPrice = (int)numericBookingMinPrice.Value,
                MaxPrice = (int)numericBookingMaxPrice.Value,
                VehicleType = comboBoxBookingVehicleType.Text
            };

            dataGridViewBookings.DataSource = await BookingService.FilterBookings(bookingQuery);
            dataGridViewBookings.Refresh();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            var vehicleInt = int.TryParse(textBox1.Text, out int vehicleId);
            var noOfSeatsInt = int.TryParse(comboBoxVehicleNoSeats.SelectedItem?.ToString(), out int numberOfSeats);
            int transmission;
            switch (comboBoxVehicleTransmission.SelectedItem?.ToString())
            {
                case "Manual":
                    transmission = 1;
                    break;
                case "Automatic":
                    transmission = 2;
                    break;
                default:
                    transmission = 0;
                    break;
            };

            var vehiclesQuery = new VehicleRequestDto()
            {
                VehicleId = vehicleInt ? vehicleId : 0,
                Make = comboBoxVehiclesMake.SelectedItem?.ToString(),
                Model = comboBoxVehiclesModel.SelectedItem?.ToString(),
                MinPrice = (int)numericVehiclesMaxPrice.Value,
                MaxPrice = (int)numericBookingsMaxPrice.Value,
                NumberOfSeats = noOfSeatsInt ? numberOfSeats : 0,
                Transmission = transmission,
                VehicleType = comboBoxVehiclesVehicleType.SelectedItem?.ToString()
            };

            dataGridViewVehicles.DataSource = await VehicleService.FilterVehicles(vehiclesQuery);
            dataGridViewVehicles.Refresh();
        }

        private async void buttonUsers_Click(object sender, EventArgs e)
        {
            string userId = numericUpDownUserId.Value.ToString();
            string firstName = textBoxUserFirstName.Text;
            string lastName = textBoxUserLastName.Text;
            string email = textBoxUserEmail.Text;

            
            dataGridViewUsers.DataSource = await UserService.FilterUsers(userId, firstName, lastName, email);
            dataGridViewUsers.Refresh();
        }

        private void buttonExportVehicles_Click(object sender, EventArgs e)
        {
            VehiclesReport vehiclesReport = new VehiclesReport(dataGridViewVehicles.DataSource as List<VehicleBaseDto>);
            vehiclesReport.Show();
        }

        private void dataGridViewBookings_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void OpenVehicleDetails()
        {
            var vehicle = dataGridViewVehicles.SelectedRows[0].DataBoundItem as VehicleBaseDto;
            Form vehicleDetails = new VehicleDetails(vehicle);
            vehicleDetails.ShowDialog();
        }

        private void dataGridViewVehicles_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            OpenVehicleDetails();
        }
    }
}

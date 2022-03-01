using Rentacar.Admin.Forms;
using Rentacar.Admin.Services;
using Rentacar.Dto;
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

        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

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
    }
}

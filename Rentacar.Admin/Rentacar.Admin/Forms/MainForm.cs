using Rentacar.Admin.Forms;
using Rentacar.Admin.Reports;
using Rentacar.Admin.Services;
using Rentacar.Dto;
using Rentacar.Dto.Request;
using Rentacar.Dto.Response;
using System;
using System.Collections.Generic;
using System.Linq;
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
            await InitializeVehicles();
            await InitializeUsers();
        }

        private async Task InitializeVehicles()
        {
            dataGridViewVehicles.DataSource = await VehicleService.FilterVehicles(new VehicleRequestDto());
            dataGridViewVehicles.Refresh();
        }

        private async Task InitializeBookingFilters()
        {
            _filterLookupsDto = await FilterService.GetFilterLookups();

            cbAllMakesBookings.Checked = true;
            cbAllModelsBookings.Checked = true;
            comboBoxBookingMake.DataSource = _filterLookupsDto.Makes;
            comboBoxBookingMake.SelectedItem = null;
            comboBoxBookingMake.Enabled = false;


            comboBoxBookingVehicleType.DataSource = _filterLookupsDto.VehicleTypes;
            comboBoxBookingVehicleType.SelectedItem = null;

            comboBoxVehicleNoSeats.DataSource = new List<string>() { "3", "4", "5", "6" };
            comboBoxVehicleNoSeats.SelectedItem = null;

            comboBoxVehiclesVehicleType.DataSource = _filterLookupsDto.VehicleTypes;
            comboBoxVehiclesVehicleType.SelectedItem = null;

            cbAllMakesVehicles.Checked = true;
            cbAllModelsVehicles.Checked = true;
            comboBoxVehiclesMake.DataSource = _filterLookupsDto.Makes;
            comboBoxVehiclesMake.SelectedItem = null;
            comboBoxVehiclesMake.Enabled = false;

            comboBoxVehicleTransmission.DataSource = new List<ComboBoxItem>() {
                new ComboBoxItem() { Value = 1, Text = "Manual"},
                new ComboBoxItem() { Value = 2, Text = "Automatic"},
            };
            comboBoxVehicleTransmission.SelectedItem = null;

            comboBoxActive.DataSource = new List<ComboBoxItem>() {
                new ComboBoxItem() { Value = 0, Text = "All"},
                new ComboBoxItem() { Value = 1, Text = "True"},
                new ComboBoxItem() { Value = 2, Text = "False"},
            };

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
            Form bookingReport = new BookingsReportForm(dataGridViewBookings.DataSource as List<BaseBookingDto>);
            bookingReport.Show();
        }

        private async void buttonSearch_Click(object sender, EventArgs e)
        {
            var bookingInt = int.TryParse(textBoxBookingId.Text, out int bookingId);
            var vehicleInt = int.TryParse(textBoxVehicleId.Text, out int vehicleId);
            var userInt = int.TryParse(textBoxBuyerId.Text, out int userId);

            string model = cbAllModelsBookings.Checked ? null : comboBoxBookingModel.SelectedItem?.ToString();
            string make;

            if (cbAllMakesBookings.Checked)
            {
                make = null;
                model = null;
            }
            else
            {
                make = comboBoxBookingMake.SelectedItem?.ToString();
            }

            var bookingQuery = new BookingRequestDto()
            {
                StartDate = dateTimePickerStartDate.Value,
                EndDate = dateTimePickerEndDate.Value,
                BookingId = bookingInt ? bookingId : 0,
                VehicleId = vehicleInt ? vehicleId : 0,
                UserId = userInt ? userId : 0,
                Model = model,
                Make = make,
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

            string model = cbAllModelsVehicles.Checked ? null : comboBoxVehiclesModel.SelectedItem?.ToString();
            string make;

            if (cbAllMakesVehicles.Checked)
            {
                make = null;
                model = null;
            }
            else
            {
                make = comboBoxVehiclesMake.SelectedItem?.ToString();
            }

            var vehiclesQuery = new VehicleRequestDto()
            {
                VehicleId = vehicleInt ? vehicleId : 0,
                Make = make,
                Model = model,
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
            string username = textBoxUserUsername.Text;

            
            dataGridViewUsers.DataSource = await UserService.FilterUsers(userId, firstName, lastName, username);
            dataGridViewUsers.Refresh();
        }

        private void buttonExportVehicles_Click(object sender, EventArgs e)
        {
            var vehiclesList = dataGridViewVehicles.DataSource as List<VehicleBaseDto>;
            VehiclesReportMainForm vehiclesReport = new VehiclesReportMainForm(vehiclesList);
            vehiclesReport.Show();
        }

        private void OpenVehicleDetails()
        {
            var vehicle = dataGridViewVehicles.SelectedRows[0].DataBoundItem as VehicleBaseDto;
            Form vehicleDetails = new VehicleDetails(vehicle);
            vehicleDetails.Show();

            vehicleDetails.FormClosed += new FormClosedEventHandler(this.FormClosedActivity);
        }

        private void OpenUserDetails()
        {
            var user = dataGridViewUsers.SelectedRows[0].DataBoundItem as BaseUserDto;
            Form userDetails = new UserDetails(user);
            userDetails.ShowDialog();
        }

        private void dataGridViewVehicles_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            OpenVehicleDetails();
        }

        private void dataGridViewUsers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            OpenUserDetails();
        }

        private async void dataGridViewBookings_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var booking = dataGridViewBookings.SelectedRows[0].DataBoundItem as BaseBookingDto;

            var user = await UserService.FilterUsers(booking.UserId.ToString());

            var vehicle = await VehicleService.FilterVehicles(new VehicleRequestDto()
            {
                VehicleId = booking.VehicleId
            });

            Form bookingDetails = new BookingDetails(booking, user.FirstOrDefault(), vehicle.FirstOrDefault());
            bookingDetails.ShowDialog();
        }

        private void buttonAddNew_Click(object sender, EventArgs e)
        {
            Form vehicleDetails = new NewVehicleForm();
            vehicleDetails.Show();
            vehicleDetails.FormClosed += new FormClosedEventHandler(this.FormClosedActivity);
        }

        private async void FormClosedActivity(object sender, FormClosedEventArgs e)
        {
            await InitializeVehicles();
        }

        private async void comboBoxVehiclesMake_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbAllModelsVehicles.Checked)
            {
                return;
            }
            GetModelsForMake();
        }

        private async void GetModelsForMake()
        {
            if(comboBoxVehiclesMake.SelectedItem != null)
            {
                comboBoxVehiclesModel.Enabled = true;
                MakeBaseDto make;
                make = comboBoxVehiclesMake.SelectedItem as MakeBaseDto;
                var models = await FilterService.GetModelsForMake(make.MakeId);
                comboBoxVehiclesModel.DataSource = models;
            }
            else
            {
                comboBoxVehiclesModel.Enabled = false;
            }
        }

        private async void comboBoxBookingMake_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBoxBookingMake.SelectedItem != null)
            {
                comboBoxBookingModel.Enabled = true;
                MakeBaseDto make;
                make = comboBoxBookingMake.SelectedItem as MakeBaseDto;
                var models = await FilterService.GetModelsForMake(make.MakeId);
                comboBoxBookingModel.DataSource = models;

            }
            else
            {
                comboBoxBookingModel.DataSource = null;
                comboBoxBookingModel.SelectedItem = null;
                comboBoxBookingModel.Enabled = false;
            }
        }

        private BookingReportRequestDto bookingReportRequest;

        private async void button1_Click_1(object sender, EventArgs e)
        {
            if (cbAllDates.Checked)
                this.bookingReportRequest = new BookingReportRequestDto()
                {
                    FromDate = null,
                    ToDate = null
                };
            else
                this.bookingReportRequest = new BookingReportRequestDto()
                {
                    FromDate = dtFromDate.Value,
                    ToDate = dtToDate.Value
                };

            var bookings = await BookingService.BookingReport(bookingReportRequest);

            Form bookingReport = new BookingsReportForm(bookings, bookingReportRequest);
            bookingReport.Show();
        }

        private void cbAllDates_CheckedChanged(object sender, EventArgs e)
        {
            if (cbAllDates.Checked)
            {
                dtFromDate.Enabled = false;
                dtToDate.Enabled = false;
            }
            else
            {
                dtFromDate.Enabled = true;
                dtToDate.Enabled = true;
            }
        }

        private async void btnGetBookings_Click(object sender, EventArgs e)
        {
            if (cbAllDates.Checked)
                this.bookingReportRequest = new BookingReportRequestDto()
                {
                    FromDate = null,
                    ToDate = null
                };
            else
                this.bookingReportRequest = new BookingReportRequestDto()
                {
                    FromDate = dtFromDate.Value,
                    ToDate = dtToDate.Value
                };

            var bookings = await BookingService.BookingReport(bookingReportRequest);
            dgvReportBookings.DataSource = bookings;
            dgvReportBookings.Refresh();
            buttonGenerateReport.Enabled = true;
        }

        private async void buttonVehiclesReport_Click(object sender, EventArgs e)
        {
            var vehiclesReportApiResponse = await VehicleService.VehiclesReport();
            var vehiclesReportChartData = VehicleService.PrepareVehicleReportDataChart(vehiclesReportApiResponse);
            var vehiclesReportTableData = VehicleService.PrepareVehicleReportDataTable(vehiclesReportApiResponse);
            Form vehiclesReportForm = new VehiclesReportForm(vehiclesReportChartData, vehiclesReportTableData);
            vehiclesReportForm.Show();
        }

        private void cbAllMakesVehicles_CheckedChanged(object sender, EventArgs e)
        {
            if (cbAllMakesVehicles.Checked == true)
            {
                comboBoxVehiclesMake.Enabled = false;
                comboBoxVehiclesModel.Enabled = false;
                cbAllModelsVehicles.Enabled = false;
            }
            else
            {
                comboBoxVehiclesMake.Enabled = true;
                cbAllModelsVehicles.Enabled = true;
            }
        }

        private void cbAllModelsVehicles_CheckedChanged(object sender, EventArgs e)
        {
            if (cbAllModelsVehicles.Checked == true)
            {
                comboBoxVehiclesModel.Enabled = false;
            }
            else
            {
                comboBoxVehiclesModel.Enabled = true;
                GetModelsForMake();
            }
        }

        private void cbAllMakesBookings_CheckedChanged(object sender, EventArgs e)
        {
            if (cbAllMakesBookings.Checked == true)
            {
                comboBoxBookingMake.Enabled = false;
                comboBoxBookingModel.Enabled = false;
                cbAllModelsBookings.Enabled = false;
            }
            else
            {
                comboBoxBookingMake.Enabled = true;
                cbAllModelsBookings.Enabled = true;
            }
        }

        private void cbAllModelsBookings_CheckedChanged(object sender, EventArgs e)
        {
            if (cbAllModelsBookings.Checked == true)
            {
                comboBoxBookingModel.Enabled = false;
            }
            else
            {
                comboBoxBookingModel.Enabled = true;
                GetModelsForMakeBookings();
            }
        }

        private void comboBoxBookingMake_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (cbAllModelsBookings.Checked)
            {
                return;
            }
            GetModelsForMakeBookings();
        }

        private async void GetModelsForMakeBookings()
        {
            if(comboBoxBookingMake.SelectedItem != null)
            {
                comboBoxBookingModel.Enabled = true;
                MakeBaseDto make;
                make = comboBoxBookingMake.SelectedItem as MakeBaseDto;
                var models = await FilterService.GetModelsForMake(make.MakeId);
                comboBoxVehiclesModel.DataSource = models;
            }
            else
            {
                comboBoxBookingModel.Enabled = false;
            }
        }
    }
}

using Rentacar.Admin.Dto.Request;
using Rentacar.Admin.Services;
using Rentacar.Dto;
using Rentacar.Dto.Enums;
using Rentacar.Dto.Response;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rentacar.Admin
{
    public partial class VehicleDetails : Form
    {
        private FilterLookupsDto _filterLookupsDto;
        private VehicleBaseDto _vehicle;
        public VehicleDetails()
        {
            InitializeComponent();
        }

        private async void InitializeFilters(VehicleBaseDto vehicle)
        {
            this._vehicle = vehicle;

            if(vehicle.ImageUrl != null)
            {
                var request = WebRequest.Create($"{vehicle.ImageUrl}");

                using (var response = request.GetResponse())
                using (var stream = response.GetResponseStream())
                {
                    pbImage.Image = Bitmap.FromStream(stream);
                }
            }

            _filterLookupsDto = await FilterService.GetFilterLookups();
            comboBoxMake.DataSource = _filterLookupsDto.Makes;
            comboBoxMake.SelectedIndex = _filterLookupsDto.Makes.FindIndex(x => x.MakeName == vehicle.Make);
            comboBoxVehicleNoSeats.DataSource = new List<string>() { "3", "4", "5", "6" };
            comboBoxTransmission.DataSource = new List<ComboBoxItem>() {
                new ComboBoxItem() { Value = 1, Text = "Manual"},
                new ComboBoxItem() { Value = 2, Text = "Automatic"},
            };
            comboBoxType.DataSource = new List<ComboBoxItem>() {
                new ComboBoxItem() { Value = 1, Text = "Small car"},
                new ComboBoxItem() { Value = 2, Text = "Sedan"},
                new ComboBoxItem() { Value = 3, Text = "SUV"},
                new ComboBoxItem() { Value = 4, Text = "Sports car"},
            };

            var typeInt = GetVehicleType();
            await GetModels();

            comboBoxVehicleNoSeats.SelectedItem = vehicle.NumberOfSeats.ToString();
            comboBoxTransmission.SelectedItem = vehicle.TransmissionType.ToString();
            comboBoxType.SelectedIndex = typeInt;
            textBoxPrice.Text = vehicle.RatePerDay.ToString();
            textBoxImageUrl.Text = vehicle.ImageUrl;
        }

        private int GetVehicleType()
        {
            switch (_vehicle.VehicleType)
            {
                case "Small car":
                    return 0;
                case "Sedan":
                    return 1;
                case "SUV":
                    return 2;
                case "Sports car":
                    return 3;
            }
            return 0;
        }

        private async Task GetModels()
        {
            MakeBaseDto make;
            make = comboBoxMake.SelectedItem as MakeBaseDto;
            var models = await FilterService.GetModelsForMake(make.MakeId);
            comboBoxModel.DataSource = models;
            comboBoxModel.SelectedIndex = models.FindIndex(x => x.ModelName.ToLower() == _vehicle.Model.ToLower());
        }

        public VehicleDetails(VehicleBaseDto vehicle)
        {
            InitializeComponent();
            InitializeFilters(vehicle);
        }

        private async void buttonClose_Click(object sender, EventArgs e)
        {
            await VehicleService.DeleteVehicle(_vehicle.VehicleId);
            this.Close();
        }

        private async void buttonSave_Click(object sender, EventArgs e)
        {
            int.TryParse(comboBoxVehicleNoSeats.SelectedItem.ToString(), out var number);
            int.TryParse(textBoxPrice.Text, out var price);

            int transmission;
            switch (comboBoxTransmission.SelectedItem?.ToString())
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

            var updateVehicle = new NewVehicleRequest()
            {
                Make = comboBoxMake.SelectedItem as MakeBaseDto,
                Model = comboBoxModel.SelectedItem as ModelBaseDto,
                //ImageUrl = textBoxImageUrl.Text,
                NumberOfSeats = number,
                PricePerDay = price,
                Transmission = (TransmissionTypeEnum)transmission,
                TypeId = comboBoxType.SelectedIndex +1
            };

            await VehicleService.UpdateVehicle(_vehicle.VehicleId, updateVehicle);
            this.Close();
        }

        private async void comboBoxMake_SelectedIndexChanged(object sender, EventArgs e)
        {
            await GetModels();
        }
    }
}

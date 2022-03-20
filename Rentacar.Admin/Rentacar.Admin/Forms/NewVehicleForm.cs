using Rentacar.Admin.Dto.Request;
using Rentacar.Admin.Services;
using Rentacar.Dto;
using Rentacar.Dto.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rentacar.Admin.Forms
{
    public partial class NewVehicleForm : Form
    {
        private FilterLookupsDto _filterLookupsDto;
        public NewVehicleForm()
        {
            InitializeComponent();
            InitializeFilters();
        }

        private async void InitializeFilters()
        {
            _filterLookupsDto = await FilterService.GetFilterLookups();
            comboBoxMake.DataSource = _filterLookupsDto.Makes;
            comboBoxMake.SelectedItem = _filterLookupsDto.Makes.FirstOrDefault(); ;
            //comboBoxModel.DataSource = _filterLookupsDto.Models;
            comboBoxVehicleNoSeats.DataSource = new List<string>() { "3", "4", "5", "6" };
            comboBoxTransmission.DataSource = new List<ComboBoxItem>() {
                new ComboBoxItem() { Value = 1, Text = "Manual"},
                new ComboBoxItem() { Value = 2, Text = "Automatic"},
            };
            comboBoxType.DataSource = new List<ComboBoxItem>() {
                new ComboBoxItem() { Value = 1, Text = "Small-Car"},
                new ComboBoxItem() { Value = 2, Text = "Sedan"},
                new ComboBoxItem() { Value = 3, Text = "SUV"},
            };
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

            if(number == 0 || price == 0 || transmission == 0 || comboBoxMake?.SelectedItem == null || comboBoxModel?.SelectedItem == null || string.IsNullOrEmpty(textBoxImageUrl.Text))
            {
                errorProvider1.SetError(labelError, "All fields are required.");
                labelError.Visible = true;
                return;
            }
            else
            {
                labelError.Visible = false;
            }

            var newvehicle = new NewVehicleRequest()
            {
                Make = comboBoxMake.SelectedItem as MakeBaseDto,
                Model = comboBoxModel.SelectedItem as ModelBaseDto,
                ImageUrl = textBoxImageUrl.Text,
                NumberOfSeats = number,
                PricePerDay = price,
                Transmission = (TransmissionTypeEnum)transmission,
                TypeId = comboBoxType.SelectedIndex + 1
            };

            var addedVehicle = await VehicleService.AddVehicle(newvehicle);
            this.Close();
        }

        private async void comboBoxMake_SelectedIndexChanged(object sender, EventArgs e)
        {
            MakeBaseDto make;
            make = comboBoxMake.SelectedItem as MakeBaseDto;
            var models = await FilterService.GetModelsForMake(make.MakeId);
            comboBoxModel.DataSource = models;
        }
    }
}

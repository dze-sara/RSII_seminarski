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

namespace Rentacar.Admin.Controls
{
    public partial class VehicleDetailsControl : UserControl
    {
        public VehicleBaseDto Vehicle { get; set; }

        public VehicleDetailsControl()
        {
            InitializeComponent();
        }

        public void RefreshData()
        {
            textBoxMake.Text = Vehicle.Make;
            textBoxModel.Text = Vehicle.Model;
            textBoxVehicleId.Text = Vehicle.VehicleId.ToString();
            textBoxNumberOfSeats.Text = Vehicle.NumberOfSeats.ToString();
            textBoxType.Text = Vehicle.VehicleType;
            textBoxPrice.Text = Vehicle.RatePerDay.ToString();
            textBoxTransmission.Text = Vehicle.TransmissionType.ToString();
        }
    }
}

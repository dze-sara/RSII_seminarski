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
            labelMake.Text = Vehicle.Make;
            labelModel.Text = Vehicle.Model;
            labelVehicleId.Text = Vehicle.VehicleId.ToString();
            labelSeats.Text = Vehicle.NumberOfSeats.ToString();
            labelType.Text = Vehicle.VehicleType;
            labelPrice.Text = Vehicle.RatePerDay.ToString();
            labelTransmission.Text = Vehicle.TransmissionType.ToString();
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }
    }
}

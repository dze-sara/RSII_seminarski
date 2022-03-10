using Rentacar.Dto;
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
    public partial class VehicleDetails : Form
    {
        public VehicleDetails()
        {
            InitializeComponent();
        }

        public VehicleDetails(VehicleBaseDto vehicle)
        {
            InitializeComponent();
            this.vehicleDetailsControl1.Vehicle = vehicle;
            this.vehicleDetailsControl1.RefreshData();
        }

        private void VehicleDetails_Load(object sender, EventArgs e)
        {
        }

        private void vehicleDetailsControl2_Load(object sender, EventArgs e)
        {

        }
    }
}

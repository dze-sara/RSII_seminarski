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

namespace Rentacar.Admin.Reports
{
    public partial class VehiclesReport : Form
    {
        private List<VehicleBaseDto> _vehiclesList;
        public VehiclesReport(List<VehicleBaseDto> vehiclesList)
        {
            _vehiclesList = vehiclesList;
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            BindingList<VehicleBaseDto> vehicles = new BindingList<VehicleBaseDto>(_vehiclesList);

            VehicleBaseDtoBindingSource.DataSource = vehicles;
            reportViewer1.RefreshReport();

            
        }
    }
}

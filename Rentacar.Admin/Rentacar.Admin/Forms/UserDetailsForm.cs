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
    public partial class UserDetails : Form
    {
        public UserDetails()
        {
            InitializeComponent();
        }

        public UserDetails(BaseUserDto user)
        {
            InitializeComponent();
            this.userDetailsControl1.User = user;
            this.userDetailsControl1.RefreshData();
        }
    }
}

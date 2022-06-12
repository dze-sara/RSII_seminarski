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
    public partial class UserDetailsControl : UserControl
    {
        public BaseUserDto User { get; set; }
        public UserDetailsControl()
        {
            InitializeComponent();
        }
        public void RefreshData()
        {
            textBoxUsername.Text = User.Username;
            textBoxFirstName.Text = User.FirstName;
            textBoxUserId.Text = User.UserId.ToString();
            textBoxLastName.Text = User.LastName;
        }

        private void UserDetailsControl_Load(object sender, EventArgs e)
        {

        }
    }
}

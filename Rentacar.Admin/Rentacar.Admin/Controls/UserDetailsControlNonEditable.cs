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

namespace Rentacar.Admin.Controls
{
    public partial class UserDetailsControlNonEditable : UserControl
    {
        public BaseUserDto User { get; set; }
        public UserDetailsControlNonEditable()
        {
            InitializeComponent();
        }
        public void RefreshData()
        {
            textBoxEmail.Text = User.Email;
            textBoxFirstName.Text = User.FirstName;
            textBoxUserId.Text = User.UserId.ToString();
            textBoxLastName.Text = User.LastName;
        }

    }
}

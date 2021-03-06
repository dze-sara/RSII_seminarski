using Rentacar.Admin.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rentacar.Admin.Forms
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private async void buttonLogin_Click(object sender, EventArgs e)
        {
            string username = textBoxUsername.Text;
            string password = maskedTextBoxPassword.Text;
            
            bool adminAuthenticated = await AuthenticationService.Login(username, password);

            if(adminAuthenticated)
            {
                errorProvider1.SetError(labelError, "");
                labelError.Visible = false;
                this.Close();
            }
            else
            {
                errorProvider1.SetError(labelError, "Username or password invalid.");
                labelError.Visible = true;
            }
        }

        private void linkCancel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Application.Exit();
        }
    }
}

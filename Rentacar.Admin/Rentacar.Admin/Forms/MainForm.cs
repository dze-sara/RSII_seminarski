using Rentacar.Admin.Forms;
using Rentacar.Admin.Services;
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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            Form loginForm = new LoginForm();
            loginForm.ShowDialog();

            InitializeData();
        }

        private async void InitializeData()
        {
            dataGridViewUsers.DataSource = await UserService.FilterUsers(null, null, null, null);
            dataGridViewUsers.Refresh();
        }

        private void buttonExport_Click(object sender, EventArgs e)
        {

        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private async void buttonUsers_Click(object sender, EventArgs e)
        {
            string userId = numericUpDownUserId.Value.ToString();
            string firstName = textBoxUserFirstName.Text;
            string lastName = textBoxUserLastName.Text;
            string email = textBoxUserEmail.Text;

            
            dataGridViewUsers.DataSource = await UserService.FilterUsers(userId, firstName, lastName, email);
            dataGridViewUsers.Refresh();
        }
    }
}

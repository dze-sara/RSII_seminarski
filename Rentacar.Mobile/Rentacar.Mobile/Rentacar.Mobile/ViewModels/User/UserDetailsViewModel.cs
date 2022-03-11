using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Rentacar.Mobile.ViewModels
{
    public class UserDetailsViewModel : BaseViewModel
    {
        public Command SaveChangesCommand { get; }

        private string _firstName;
        private string _lastName;
        private string _email;
        private string _password;
        public string FirstName
        {
            get => _firstName;
            set => SetProperty(ref _firstName, value);
        }

        public string LastName
        {
            get => _lastName;
            set => SetProperty(ref _lastName, value);
        }

        public string Email
        {
            get => _email;
            set => SetProperty(ref _email, value);
        }

        public string Password
        {
            get => _password;
            set => SetProperty(ref _password, value);
        }

        public UserDetailsViewModel()
        {
            SaveChangesCommand = new Command(OnSaveChangesClicked);
        }

        private async void OnSaveChangesClicked(object obj)
        {
            
        }
    }
}

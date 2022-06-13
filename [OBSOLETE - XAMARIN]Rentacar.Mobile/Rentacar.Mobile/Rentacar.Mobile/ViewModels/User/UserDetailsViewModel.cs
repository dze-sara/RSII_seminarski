using Rentacar.Dto;
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
            var user = AuthenticationService.User;
            _firstName = user.FirstName;
            _lastName = user.LastName;
            _email = user.Email;
            _password = user.Password;
        }

        private async void OnSaveChangesClicked(object obj)
        {
            if(string.IsNullOrWhiteSpace(_firstName)
               || string.IsNullOrWhiteSpace(_lastName)
               || string.IsNullOrWhiteSpace(_email)
               || string.IsNullOrWhiteSpace(_password))
            {
                await Shell.Current.DisplayAlert("Incorrect", "Please populate all input fields", "OK");
                return;
            }
            var newUserData = new UserDto();
            newUserData.FirstName = _firstName;
            newUserData.LastName = _lastName;
            newUserData.Email = _email;
            newUserData.Password = _password;
            newUserData.UserId = AuthenticationService.UserId;
            var user = await UserService.EditUserInfo(newUserData);
            AuthenticationService.User = user;
        }
    }
}

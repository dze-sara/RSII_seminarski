using Rentacar.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Rentacar.Mobile.ViewModels
{
    public class RegisterNowViewModel : BaseViewModel
    {
        public Command RegisterNowCommand { get; }

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

        public RegisterNowViewModel()
        {
            RegisterNowCommand = new Command(OnRegisterNowClicked);
        }

        private async void OnRegisterNowClicked(object obj)
        {
            UserDto newRegisteredUser = new UserDto()
            {
                FirstName = FirstName,
                LastName = LastName,
                Email = Email,
                Password = Password
            };
            UserDto user = await AuthenticationService.Register(newRegisteredUser);
            if (user != null)
            {
                await Shell.Current.GoToAsync("//mainpage");
            }
            else
            {
                await Shell.Current.DisplayAlert("Error", "Something went wrong while registering", "OK");
            }
        }
    }
}

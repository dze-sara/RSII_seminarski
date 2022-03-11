using Rentacar.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Rentacar.Mobile.ViewModels
{
    public class SignInViewModel : BaseViewModel
    {
        public Command SignInCommand { get; }

        private string _username;
        private string _password;
        public string Username
        {
            get => _username;
            set => SetProperty(ref _username, value);
        }

        public string Password
        {
            get => _password;
            set => SetProperty(ref _password, value);
        }


        public SignInViewModel()
        {
            SignInCommand = new Command(OnSignInClicked);
        }

        private async void OnSignInClicked(object obj)
        {
            App.isLogged = true;

            UserDto user = await AuthenticationService.SignIn(Username, Password);
            if (user != null)
            {
                await Shell.Current.GoToAsync("//mainpage");
            }
            else
            {
                await Shell.Current.DisplayAlert("Incorrect", "Incorrect username or password", "OK");
            }
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Rentacar.Mobile.ViewModels.Filter
{
    public class AdvancedFiltersViewModel : BaseViewModel
    {
        public Command CloseFiltersCommand { get; set; }

        public AdvancedFiltersViewModel()
        {
            CloseFiltersCommand = new Command(OnCloseFiltersCommand);
        }

        private async void OnCloseFiltersCommand(object sender)
        {
        }


    }
}

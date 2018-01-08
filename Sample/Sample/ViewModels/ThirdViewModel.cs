///
/// Copyright © Mohamed Ali NOUIRA. All rights reserved.
using System;
using Xamarin.Forms;
using Sample.IViewModels;
using System.Windows.Input;
using Xamarin.Forms.Navigation;

namespace Sample.ViewModels
{
    public class ThirdViewModel : IThirdViewModel
    {
        private readonly INavigationService _iNavigationService;

        public ICommand BtnTappedCommand { get; set; }

        public ThirdViewModel(INavigationService _iNavigationService)
        {
            this._iNavigationService = _iNavigationService;
            BtnTappedCommand = new Command<String>(BtnTapped);
        }

        private void BtnTapped(string param)
        {
            var navigationParams = _iNavigationService.GetParameters();
            switch (param)
            {
                case "GoBack":
                    _iNavigationService.GoBack();
                    break;
                case "ShowParameters":
                    App.Current.MainPage.DisplayAlert("Parameters", navigationParams.ToString(), "cancel");
                    break;
                default:
                    break;
            }
        }
    }
}

///
/// Copyright © Mohamed Ali NOUIRA. All rights reserved.
using System;
using Sample.Views;
using Xamarin.Forms;
using Sample.IViewModels;
using System.Windows.Input;
using Xamarin.Forms.Navigation;

namespace Sample.ViewModels
{
    public class HomeViewModel : IHomeViewModel
    {
        private readonly INavigationService _iNavigationService;

        public ICommand BtnTappedCommand { get; set; }

        public HomeViewModel(INavigationService _iNavigationService)
        {
            this._iNavigationService = _iNavigationService;
            BtnTappedCommand = new Command<String>(BtnTapped);
        }

        private void BtnTapped(string param)
        {
            var navigationParams = new NavigationParameters();
            switch (param)
            {
                case "FirstView":
                    _iNavigationService.NavigateTo("FirstView");
                    break;
                case "SecondView":
                    _iNavigationService.NavigateTo(new SecondView());
                    break;
                case "ThirdView":
                    navigationParams.Add("Param3", "Parameter3");
                    _iNavigationService.NavigateTo("ThirdView", navigationParams);
                    break;
                case "FourthView":
                    navigationParams.Add("Param4", "Parameter4");
                    _iNavigationService.NavigateTo(new FourthView(), navigationParams);
                    break;
                default:
                    break;
            }
        }
    }
}

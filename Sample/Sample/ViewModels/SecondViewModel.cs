///
/// Copyright © Mohamed Ali NOUIRA. All rights reserved.
using Sample.IViewModels;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Navigation;

namespace Sample.ViewModels
{
    public class SecondViewModel : ISecondViewModel
    {
        private readonly INavigationService _iNavigationService;

        public ICommand BtnTappedCommand { get; set; }

        public SecondViewModel(INavigationService _iNavigationService)
        {
            this._iNavigationService = _iNavigationService;
            BtnTappedCommand = new Command(BtnTapped);
        }

        private void BtnTapped()
        {
            _iNavigationService.GoBack();
        }
    }
}

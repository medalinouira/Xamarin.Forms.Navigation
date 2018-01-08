///
/// Copyright © Mohamed Ali NOUIRA. All rights reserved.
using Xamarin.Forms;
using Sample.IViewModels;
using System.Windows.Input;
using Xamarin.Forms.Navigation;

namespace Sample.ViewModels
{
    public class FirstViewModel : IFirstViewModel
    {
        private readonly INavigationService _iNavigationService;

        public ICommand BtnTappedCommand { get; set; }

        public FirstViewModel(INavigationService _iNavigationService)
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

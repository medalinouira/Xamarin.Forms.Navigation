///
/// Copyright © Mohamed Ali NOUIRA. All rights reserved.
using System.Threading.Tasks;

namespace Xamarin.Forms.Navigation
{
    public interface INavigationService
    {
        Page GetCurrentPage();
        NavigationParameters GetParameters();

        Task<Page> GoBack();
        Task<Page> GoBack(bool animated);

        bool CanGoBack();

        Task PopToRootAsync();
        Task PopToRootAsync(bool animated);

        Task NavigateTo(string pageKey);
        Task NavigateTo(string pageKey, bool animated);
        Task NavigateTo(string pageKey, NavigationParameters parameter);
        Task NavigateTo(string pageKey, NavigationParameters parameter, bool animated);

        Task NavigateTo(Page page);
        Task NavigateTo(Page page, bool animated);
        Task NavigateTo(Page page, NavigationParameters parameter);
        Task NavigateTo(Page page, NavigationParameters parameter, bool animated);

        void RemovePage(Page page);
        void InsertPageBefore(Page page, Page before);
        
        Task<Page> PopModalAsync();
        Task<Page> PopModalAsync(bool animated);

        Task PushModalAsync(Page page);
        Task PushModalAsync(Page page, bool animated);
        Task PushModalAsync(Page page, NavigationParameters parameter);
        Task PushModalAsync(Page page, NavigationParameters parameter, bool animated);

        Task PushModalAsync(string pageName);
        Task PushModalAsync(string pageName, bool animated);
        Task PushModalAsync(string pageName, NavigationParameters parameter);    
        Task PushModalAsync(string pageName, NavigationParameters parameter, bool animated);
    }
}

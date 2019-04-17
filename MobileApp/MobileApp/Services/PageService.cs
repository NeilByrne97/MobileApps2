
using MobileApp.View;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MobileApp
{
    public class PageService : IPageService
    {
        public async Task<bool> DisplayAlert(string title, string message, string ok, string cancel)
        {
            return await Application.Current.MainPage.DisplayAlert(title, message, ok, cancel);
        }

        public async Task PushAsyncPage(Page page)
        {
            await Application.Current.MainPage.Navigation.PushAsync(page);
        }
    }
}

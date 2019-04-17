using System.Threading.Tasks;
using MobileApp.View;
using Xamarin.Forms;

namespace MobileApp
{
    public interface IPageService
    {
        Task PushAsyncPage(Page page);
        Task<bool> DisplayAlert(string title, string message, string ok, string cancel);
       
    }
}

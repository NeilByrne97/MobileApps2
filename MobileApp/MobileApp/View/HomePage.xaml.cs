using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MobileApp.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileApp
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class HomePage : ContentPage
	{
        public HomePage()
        {
            InitializeComponent();
            this.BindingContext = new MainPageViewModel(new PageService());
        }

        private async void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            await (BindingContext as MainPageViewModel).SelectGame(e.SelectedItem as GamesViewModel);
        }

        private void Delete_Clicked(object sender, EventArgs e)
        {
            var button = sender as Button;
            var game = button?.BindingContext as Game;
            var vm = BindingContext as GamesViewModel;
            //vm?.RemoveCommand.Execute(game);
        }

    }
}
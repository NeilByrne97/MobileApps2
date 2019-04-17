using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileApp.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SelectedGamePage : ContentPage
	{
        GamesViewModel _game;
		public SelectedGamePage ( GamesViewModel game)
		{
			InitializeComponent ();
            _game = game;
            this.Title = _game.Name;
		}

       
    }
}
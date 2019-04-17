using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileApp.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AddPage : ContentPage
	{
		public AddPage ()
		{
			InitializeComponent ();
		}

        private void Button_Clicked(object sender, EventArgs e)
        {
            //  Variables for new entry to list
            string nName = newName.Text;
            string nDev = newDev.Text;
            string nPub = newPub.Text;
            string nGenre = newGenre.Text;
            string nRelease = newRelease.Text;

            //  Add to the list
            Game newGame = new Game(nName, nDev, nPub, nGenre, nRelease);
            ObservableCollection<Game> newList = null;
            newList.Add(newGame);
            // Same Code from GamesViewModel
            string path = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            string fileName = Path.Combine(path, "Games.txt");
            using (var reader = new StreamReader(fileName))
            {
               
            }
        }
    }
}
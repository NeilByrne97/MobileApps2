
using MobileApp.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace MobileApp.ViewModel
{
    public class MainPageViewModel : BaseViewModel
    {

        // ICommand propteries
        public ICommand ReadListCommand { get; private set; }
        public ICommand SaveListCommand { get; private set; }
        public ICommand DeleteFromListCommand { get; private set; }
    
        private ObservableCollection<GamesViewModel> _gamesList;
        public ObservableCollection<GamesViewModel> GamesList
        {
            get { return _gamesList; }
            set { SetValue(ref _gamesList, value); }
        }// GamesList()

        private GamesViewModel _selectedGame;
        public GamesViewModel SelectedGame
        {
            get { return _selectedGame; }
            set { SetValue(ref _selectedGame, value);}
        } //SelectedGames()

        // Constuctor that calls the methods by polymorphising them into ICommand Properties
        private readonly IPageService _pageService;
        public MainPageViewModel(IPageService pageService)
        {
            _pageService = pageService;
            ReadList();
            ReadListCommand = new Command(ReadList);
            SaveListCommand = new Command(SaveList);
            DeleteFromListCommand = new Command<GamesViewModel>(DeleteFromList);
        }// Constructor()

        // Private methods becasue they are called in the class
        private void SaveList()
        {
            GamesViewModel.SaveGamesData(GamesList);
        }// SaveList()

        private void ReadList()
        {
            GamesList = GamesViewModel.ReadGamesData();
        }// ReadList()

        private void DeleteFromList(GamesViewModel game)
        {
            GamesList.Remove(game);
            SelectedGame = null;
        }//DeleteFromList()

        // Public so it can be called when the program is running
        public async Task SelectGame(GamesViewModel game)
        {
            if (GamesList == null)return;
            await _pageService.PushAsyncPage(new SelectedGamePage(game));
        }// SelectGame()
    }// MainPageViewModel class
}// MainPageViewModel namespace


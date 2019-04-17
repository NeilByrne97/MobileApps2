using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Reflection;
using System.Text;

namespace MobileApp
{
    public class GamesViewModel : BaseViewModel
    {

        private string _name;
        public string Name
        {
            get { return _name; }
            set { SetValue(ref _name, value); }
        }// Name

        private string _developer;
        public string Developer
        {
            get { return _developer; }
            set { SetValue(ref _developer, value); }
        }// Developer

        private string _publisher;
        public string Publisher
        {
            get { return _publisher; }
            set { SetValue(ref _publisher, value); }
        }// Publisher

        private string _genre;
        public string Genre
        {
            get { return _genre; }
            set { SetValue(ref _genre, value); }
        }// Genre

        private string _release;
        public string Release
        {
            get { return _release; }
            set { SetValue(ref _release, value); }
        }// Release


        // Reads data from json file, deserializes into component data, returns as a list of type ObservableCollection
        public static ObservableCollection<GamesViewModel> ReadGamesData()
        {
            ObservableCollection<GamesViewModel> myList = new ObservableCollection<GamesViewModel>();
            string jsonText;
            try  // Reads localApplicationFolder first
            {
                string path = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                string fileName = Path.Combine(path, "Games.txt");
                using (var reader = new StreamReader(fileName))
                {
                    // Copy the file into a json string
                    jsonText = reader.ReadToEnd();
                }
            }
            catch // Read default file if failed 
            {
                var assembly = IntrospectionExtensions.GetTypeInfo(typeof(HomePage)).Assembly;
                Stream stream = assembly.GetManifestResourceStream("MobileApp.Data.Games.txt");
                using (var reader = new StreamReader(stream))
                {
                    jsonText = reader.ReadToEnd();
                }
            }
            myList = JsonConvert.DeserializeObject<ObservableCollection<GamesViewModel>>(jsonText);
            return myList;
        }// ReadGamesData()

        // Save data to the JSON file
        public static void SaveGamesData(ObservableCollection<GamesViewModel> saveList)
        {
            // Get the path
            string path = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            string fileName = Path.Combine(path, "Games.txt");
            // StreamWriter writes a list
            using (var writer = new StreamWriter(fileName, false))
            {
                // Converts the string into JSON format
                string jsonText = JsonConvert.SerializeObject(saveList);
                // Write the string out to the file
                writer.WriteLine(jsonText);
            }
        }// SaveGameData()
    }   // MobileApp class
}// MobileApp namespace

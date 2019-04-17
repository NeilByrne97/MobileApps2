using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Text;

namespace MobileApp
{
    class Game
    {
        public string Name { get; set; }
        public string Developer { get; set; }
        public string Publisher { get; set; }
        public string Genre { get; set; }
        public string Release { get; set; }

        public Game() { }

        public Game(string Name, string Developer, string Publisher, string Genre, string Release)
        {
            this.Name = Name;
            this.Developer = Developer;
            this.Publisher = Publisher;
            this.Genre = Genre;
            this.Release = Release;
        }
    }
}

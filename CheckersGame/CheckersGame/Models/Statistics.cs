using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CheckersGame.Models
{
    public class Statistics : INotifyPropertyChanged
    {

        public Statistics() { }

        public Statistics(int blackWins, int whiteWins, int mostPiecesBlack, int mostPiecesWhite) 
        {
            BlackWins = blackWins;
            WhiteWins = whiteWins;
            MostPiecesBlack = mostPiecesBlack;
            MostPiecesWhite = mostPiecesWhite;
        }

        private string whiteWinsString;
        [JsonIgnore]
        public string WhiteWinsString
        {
            set
            {
                whiteWinsString = value;
                OnPropertyChanged();
            }
            get
            {
                return whiteWinsString;
            }
        }

        private string blackWinsString;
        [JsonIgnore]
        public string BlackWinsString
        {
            set
            {
                blackWinsString = value;
                OnPropertyChanged();
            }
            get
            {
                return blackWinsString;
            }
        }

        private int whiteWins;
        public int WhiteWins
        {
            set
            {
                whiteWins = value;
                WhiteWinsString = "Wins: " + whiteWins;
                OnPropertyChanged();
            }
            get
            {
                return whiteWins;
            }
        }

        private int blackWins;

        public int BlackWins
        {
            set
            {
                blackWins = value;
                BlackWinsString = "Wins: " + blackWins;
                OnPropertyChanged();
            }
            get
            {
                return blackWins;
            }
        }


        private int mostPiecesBlack;
        public int MostPiecesBlack
        {
            set
            {
                mostPiecesBlack = value;
                OnPropertyChanged();
            }
            get
            {
                return mostPiecesBlack;
            }
        }

        private int mostPiecesWhite;
        public int MostPiecesWhite
        {
            set
            {
                mostPiecesWhite = value;
                OnPropertyChanged();
            }
            get
            {
                return mostPiecesWhite;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}

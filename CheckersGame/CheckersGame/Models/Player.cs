using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckersGame.Models
{
    public class Player : INotifyPropertyChanged
    {
        Player()
        {
        }

        public Player(Color c)
        {
            playerColor = c;
            isMyTurn = false;
            username = playerColor == Color.Black ? "Black" : "White";
        }

        private string username;
        public string Username
        {
            get
            {
                return username;
            }
            set
            {
                username = value;
                NotifyPropertyChanged("Username");
            }
        }

        private bool isMyTurn;
        public bool IsMyTurn
        {
            set
            {
                isMyTurn = value;
                NotifyPropertyChanged("IsMyTurn");
            }
            get
            {
                return isMyTurn;
            }
        }

        private Color playerColor;
        public Color PlayerColor
        {
            set
            {
                playerColor = value;
                NotifyPropertyChanged("PlayerColor");
            }
            get
            {
                return playerColor;
            }
        }

        public void ChangeTurn()
        {
            if (isMyTurn)
            {
                isMyTurn = false;
            }
            else
            {
                isMyTurn = true;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

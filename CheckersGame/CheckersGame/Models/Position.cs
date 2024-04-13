﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckersGame.Models
{
    public class Position : INotifyPropertyChanged
    {
        public Position() 
        { 
        }

        public Position(int coordX, int coordY)
        {
            x = coordX;
            y = coordY;
        }

        private int x;        
        public int X
        {
            set
            {
                x = value;
                NotifyPropertyChanged("X");
            }
            get
            {
                return x;
            }
        }

        private int y;
        public int Y
        {
            set
            {
                y = value;
                NotifyPropertyChanged("Y");
            }
            get
            {
                return y;
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

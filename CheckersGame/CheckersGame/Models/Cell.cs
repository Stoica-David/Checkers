using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CheckersGame.Models
{
    public class Cell : INotifyPropertyChanged
    {
        public Cell()
        {
        }

        public Cell(int x, int y)
        {
            isSelected = false;
            if ((x + y) % 2 == 1)
            {
                CellColor = Color.Black;
            }
            else
            {
                CellColor = Color.White;
            }

            Position = new Position(x, y);
            currentPiece = null;
        }

        private Color cellcolor;
        [XmlElement(Namespace = "CellColor")]
        public Color CellColor
        {
            set
            {
                cellcolor = value;

                if (cellcolor == Color.Black)
                {
                    ColorName = "#774936";
                }
                else
                {
                    ColorName = "#F2F3AE";
                }

                NotifyPropertyChanged("CellColor");
            }
            get
            {
                return cellcolor;
            }
        }

        private string colorName;
        public string ColorName
        {
            get
            {
                return colorName;
            }
            set
            {
                colorName = value;
                NotifyPropertyChanged("ColorName");
            }
        }

        private Position position;
        public Position Position
        {
            get
            {
                return position;
            }
            set
            {
                position = value;
                NotifyPropertyChanged("Position");
            }
        }

        private Piece currentPiece;
        public Piece CurrentPiece
        {
            get
            {
                return currentPiece;
            }
            set
            {
                currentPiece = value;
                NotifyPropertyChanged("CurrentPiece");
            }
        }

        private bool isSelected;
        public bool IsSelected
        {
            set
            {
                if (value == true)
                {
                    ColorName = "#A72C22";
                }
                else
                {
                    if (cellcolor == Color.Black)
                    {
                        ColorName = "#774936";
                    }
                    else
                    {
                        ColorName = "#F2F3AE";
                    }
                }
                isSelected = value;
                NotifyPropertyChanged("IsSelected");
            }

            get
            {
                return isSelected;
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

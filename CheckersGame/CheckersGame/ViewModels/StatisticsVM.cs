using CheckersGame.Services;
using CheckersGame.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Xml;

namespace CheckersGame.ViewModels
{
    public class StatisticsVM : BaseVM
    {
        StatisticsVM () { }

        public StatisticsVM(string filePath)
        {
            //StatisticsVM old = Utils.DeserializeObjectToXML<StatisticsVM>(filePath);

            //BlackWins = old.BlackWins;
            //WhiteWins = old.WhiteWins;

            BlackWins = 1;
            WhiteWins = 10;
        }

        ~StatisticsVM()
        {
            Utils.SerializeObjectToXML<StatisticsVM>(this, "Statistics.xml");
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


        public void UpdateFile()
        {
            Utils.SerializeObjectToXML<StatisticsVM>(this, "Statistics.xml");
        }

        private string whiteWinsString;
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

        public void SwitchToMenu()
        {
            MainWindowVM.Instance.SelectedVM = MainWindowVM.Instance.MenuViewModel;
        }

        private ICommand switchToMenuCommand;
        public ICommand SwitchToMenuCommand
        {
            get
            {
                if (switchToMenuCommand == null)
                {
                    switchToMenuCommand = new RelayCommand(o => true, o => { SwitchToMenu(); });
                }

                return switchToMenuCommand;
            }
        }
    }
}

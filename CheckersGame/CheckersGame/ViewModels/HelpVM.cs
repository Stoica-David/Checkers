using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckersGame.ViewModels
{
    public class HelpVM : BaseVM
    {
        private string gameDescription;
        public string GameDescription
        {
            set
            {
                gameDescription = value;
                OnPropertyChanged();
            }

            get
            {
                return gameDescription;
            }
        }

        private string nameLabel;
        public string NameLabel
        {
            set
            {
                nameLabel = value;
                OnPropertyChanged();
            }

            get
            {
                return nameLabel;
            }
        }      
        
        private string emailLabel;
        public string EMailLabel
        {
            set
            {
                emailLabel = value;
                OnPropertyChanged();
            }

            get
            {
                return emailLabel;
            }
        }   
        
        private string grLabel;
        public string GRLabel
        {
            set
            {
                grLabel = value;
                OnPropertyChanged();
            }

            get
            {
                return grLabel;
            }
        }



        // DELEGATES
        public delegate void SwitchToMenu();
        public SwitchToMenu OnSwitchToMenu { get; set; }

        public HelpVM()
        {
            NameLabel = "David";
            EMailLabel = "david.stoica@student.unitbv.ro";
            GRLabel = "10LF224";


            GameDescription  = 
                    "⦿ Pieces must stay on the dark squares. \n" +
                    "⦿ To capture an opposing piece,\"jump\" over it by moving two diagonal spaces in the direction of the the opposing piece \n" +
                    "⦿ A piece may jump forward over an opponent's pieces in multiple parts of the board to capture them.\n" +
                    "⦿ Keep in mind, the space on the other side of your opponent’s piece must be empty for you to capture it.\n" +
                    "⦿ If your piece reaches the last row on your opponent's side,\nyou may re-take one of your captured pieces and \"crown\"the piece that made it to the Kings Row.Thereby making it a \"King Piece.\"\n" +
                    "⦿ King pieces may still only move one space at a time during a non-capturing move.\n However, when capturing an opponent's piece(s) it may move diagonally forward or backwards\n" +
                    "⦿ There is no limit to how many king pieces a player may have.\n";
        }
    }
}

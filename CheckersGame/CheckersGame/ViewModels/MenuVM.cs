using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CheckersGame.ViewModels
{
    public class MenuVM : BaseVM
    {
        // COMMAND

        private ICommand switchToGameCommand;
        public ICommand SwitchToGameCommand
        {
            get
            {
                if (switchToGameCommand == null)
                {
                    switchToGameCommand = new RelayCommand(o => true, o => { OnSwitchToGame(); });
                }

                return switchToGameCommand;
            }
        }

        private ICommand switchToStatsCommand;
        public ICommand SwitchToStatsCommand
        {
            get
            {
                if (switchToStatsCommand == null)
                {
                    switchToStatsCommand = new RelayCommand(o => true, o => { OnSwitchToStats(); });
                }

                return switchToStatsCommand;
            }
        }

        private ICommand switchToHelpCommand;
        public ICommand SwitchToHelpCommand
        {
            get
            {
                if (switchToHelpCommand  == null)
                {
                    switchToHelpCommand = new RelayCommand(o => true, o => { OnSwitchToHelp(); });
                }

                return switchToHelpCommand;
            }
        }

        // DELEGATES

        public delegate void SwitchToGame();
        public SwitchToGame OnSwitchToGame{ get; set; }

        public delegate void SwitchToStats();
        public SwitchToStats OnSwitchToStats { get; set; }

        public delegate void SwitchToHelp();
        public SwitchToHelp OnSwitchToHelp { get; set; }

        public MenuVM()
        {

        }
    }
}

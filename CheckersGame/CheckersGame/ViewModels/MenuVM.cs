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

        private ICommand switchToLoginCommand;
        public ICommand SwitchToLoginCommand
        {
            get
            {
                if (switchToLoginCommand == null)
                {
                    switchToLoginCommand = new RelayCommand(o => true, o => { OnSwitchToLogin(); });
                }

                return switchToLoginCommand;
            }
        }

        private ICommand switchToSearchCommand;
        public ICommand SwitchToSearchCommand
        {
            get
            {
                if (switchToSearchCommand == null)
                {
                    switchToSearchCommand = new RelayCommand(o => true, o => { OnSwitchToSearch(); });
                }

                return switchToSearchCommand;
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

        public delegate void SwitchToLogin();
        public SwitchToLogin OnSwitchToLogin { get; set; }

        public delegate void SwitchToSearch();
        public SwitchToSearch OnSwitchToSearch { get; set; }

        public delegate void SwitchToGame();
        public SwitchToSearch OnSwitchToHelp { get; set; }

        public MenuVM()
        {

        }
    }
}

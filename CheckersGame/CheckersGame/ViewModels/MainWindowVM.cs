using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace CheckersGame.ViewModels
{
    public class MainWindowVM : BaseVM
    {
        // Properties
        private BaseVM selectedVM;
        public BaseVM SelectedVM
        {
            get
            {
                return selectedVM;
            }
            set
            {
                selectedVM = value;
                OnPropertyChanged();
            }
        }

        // ViewModels
        public MenuVM MenuViewModel { get; set; }
        public HelpVM HelpViewModel { get; set; }

        public StatisticsVM StatisticsViewModel {  get; set; }
        public GameVM GameViewModel { get; set; }


        // Methods
        public MainWindowVM()
        {
            switchToMenu();
        }

        public void switchToHelp()
        {
            HelpViewModel = new HelpVM();
            HelpViewModel.OnSwitchToMenu = switchToMenu;
            SelectedVM = HelpViewModel;
        }

        public void switchToMenu()
        {
            MenuViewModel = new MenuVM();
            MenuViewModel.OnSwitchToHelp = switchToHelp;
            MenuViewModel.OnSwitchToStats = switchToStats;
            MenuViewModel.OnSwitchToGame = switchToGame;
            SelectedVM = MenuViewModel;
        }

        public void switchToStats()
        {
            StatisticsViewModel = new StatisticsVM();
            StatisticsViewModel.OnSwitchToMenu = switchToMenu;
            SelectedVM = StatisticsViewModel;
        }

        public void switchToGame()
        {
            GameViewModel = new GameVM();
            GameViewModel.OnSwitchToMenu = switchToMenu;
            SelectedVM = GameViewModel;
        }
    }
}

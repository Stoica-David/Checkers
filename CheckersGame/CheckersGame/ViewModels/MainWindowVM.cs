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
        // Singleton
        private static MainWindowVM _instance;
        public static MainWindowVM Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new MainWindowVM();
                }
                return _instance;
            }
        }

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
            SelectedVM = MenuViewModel;
        }

        public void switchToStats()
        {
            StatisticsViewModel = new StatisticsVM("Statistics.xml");
            //StatisticsViewModel.OnSwitchToMenu = switchToMenu;
            SelectedVM = StatisticsViewModel;
        }
    }
}

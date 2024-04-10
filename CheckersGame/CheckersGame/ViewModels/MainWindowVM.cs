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

        public MenuVM MenuViewModel { get; set; }

        public MainWindowVM()
        {
            switchToMenu();
        }

        public void switchToMenu()
        {
            MenuViewModel = new MenuVM();
            SelectedVM = MenuViewModel;
        }
    }
}

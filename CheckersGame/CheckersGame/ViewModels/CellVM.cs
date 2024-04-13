using CheckersGame.Models;
using CheckersGame.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CheckersGame.ViewModels
{
    public class CellVM : BaseVM
    {
        public CellVM() { }
        public CellVM(Cell c, GameBusinessLogic businessLogic)
        {
            myCell = c;
            this.businessLogic = businessLogic;
            CellWidth = 58.3333321f;
            CellHeight = 50.8888f;
        }

        private float cellWidth;
        public float CellWidth
        {
            set
            {
                cellWidth = value;
                OnPropertyChanged();
            }
            get 
            {
                return cellWidth; 
            }
        }

        private float cellHeight;
        public float CellHeight
        {
            set
            {
                cellHeight = value;
                OnPropertyChanged();
            }
            get
            { 
                return cellHeight; 
            }
        }
        
        private GameBusinessLogic businessLogic;
        
        private Cell myCell;
        public Cell MyCell
        {
            set
            {
                myCell = value;
                OnPropertyChanged();
            }
            get 
            {
                return myCell; 
            }
        }

        private ICommand clickCommand;
        public ICommand ClickCommand
        {
            get
            {
                if (clickCommand == null)
                {
                    clickCommand = new TemplateRelayCommand<Cell>(businessLogic.ClickAction);
                }
                return clickCommand;
            }
        }
    }
}

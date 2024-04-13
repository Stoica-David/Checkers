using CheckersGame.Models;
using CheckersGame.Services;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CheckersGame.ViewModels
{
    public class GameVM : BaseVM
    {
        public delegate void SwitchToMenu();
        public SwitchToMenu OnSwitchToMenu { get; set; }

        private ICommand switchToMenuCommand;
        public ICommand SwitchToMenuCommand
        {
            get
            {
                if (switchToMenuCommand == null)
                {
                    switchToMenuCommand = new RelayCommand(o => true, o => { OnSwitchToMenu(); });
                }

                return switchToMenuCommand;
            }
        }

        private ObservableCollection<ObservableCollection<CellVM>> gameBoard;
        public ObservableCollection<ObservableCollection<CellVM>> GameBoard
        {
            set
            {
                gameBoard = value;
                OnPropertyChanged();
            }
            get
            {
                return gameBoard;
            }
        }

        public GameVM()
        {
            ObservableCollection<ObservableCollection<Cell>> board = Utils.InitGameBoard();
            this.gameLogic = new GameBusinessLogic(ref board);

            this.GameBoard = CellBoardToCellVMBoard(ref board);
            
            this.WindowHeight = 700;
            this.WindowWidth = 1200;
        }

        public bool MultipleJumps
        {
            set
            {
                gameLogic.MultipleJumps = value;
            }
        }

        private ObservableCollection<ObservableCollection<CellVM>> CellBoardToCellVMBoard(ref ObservableCollection<ObservableCollection<Cell>> board)
        {
            ObservableCollection<ObservableCollection<CellVM>> result = new ObservableCollection<ObservableCollection<CellVM>>();
            
            for (int i = 0; i < board.Count; i++)
            {
                ObservableCollection<CellVM> line = new ObservableCollection<CellVM>();
            
                for (int j = 0; j < board[i].Count; j++)
                {
                    Cell c = board[i][j];
                    CellVM cellVM = new CellVM(c, gameLogic);
                    line.Add(cellVM);
                }
                
                result.Add(line);
            }

            return result;
        }

        private GameBusinessLogic gameLogic;
        public GameBusinessLogic GameLogic
        {
            get
            {
                return gameLogic;
            }
            set
            {
                gameLogic = value;
                OnPropertyChanged();
            }
        }

        private float windowWidth;
        public float WindowWidth
        {
            set
            {
                windowWidth = value;
                
                GameBoard.ToList().ForEach(row => row.ToList().ForEach(cell =>
                {
                    cell.CellWidth = windowWidth / 2 / 8;
                    cell.CellWidth = windowHeight / 6 * 4 / 8;
                }));
            
                OnPropertyChanged();
            }
            get 
            {
                return windowWidth; 
            }
        }

        private float windowHeight;
        public float WindowHeight
        {
            set
            {
                windowHeight = value;
                OnPropertyChanged();
            }
            get 
            {
                return windowHeight; 
            }
        }

        public void RestartGame()
        {
            ObservableCollection<ObservableCollection<Cell>> board = Utils.InitGameBoard();
            this.GameLogic.Statistics.SerializeToFile();
            this.GameLogic = new GameBusinessLogic(ref board);
            this.GameBoard = CellBoardToCellVMBoard(ref board);
        }

        public void SaveToXML()
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            if (saveFileDialog.ShowDialog() == true)
                Utils.SerializeObjectToXML<GameBusinessLogic>(gameLogic, saveFileDialog.FileName);
        }

        public void ReadFromXML()
        {
            OpenFileDialog openfile = new OpenFileDialog();
            string folderpath = System.IO.Directory.GetParent(Environment.CurrentDirectory).Parent.FullName + "\\Resources\\";

            bool? myResult;
            myResult = openfile.ShowDialog();
            if (myResult != null && myResult == true)
            {
                try
                {
                    var logic = Utils.DeserializeObjectToXML<GameBusinessLogic>(openfile.FileName);
                    logic.Statistics = this.GameLogic.Statistics;
                    this.GameLogic = logic;
                    this.GameLogic.Statistics = new StatisticsVM();
                    this.GameLogic.Statistics.DeserializeFromFile();
                    var board = GameLogic.Board;
                    GameBoard = CellBoardToCellVMBoard(ref board);
                }
                catch
                {

                }
            }
        }

        private ICommand newGameCommand;
        public ICommand NewGameCommand
        {
            get
            {
                if (newGameCommand == null)
                {
                    newGameCommand = new TemplateRelayCommand<Object>(o => RestartGame());
                }
                return newGameCommand;
            }
        }

        private ICommand saveGameCommand;
        public ICommand SaveGameCommand
        {
            get
            {
                if (saveGameCommand == null)
                {
                    saveGameCommand = new TemplateRelayCommand<Object>(o => SaveToXML());
                }
                return saveGameCommand;
            }
        }

        private ICommand openGameCommand;
        public ICommand OpenGameCommand
        {
            get
            {
                if (openGameCommand == null)
                {
                    openGameCommand = new TemplateRelayCommand<Object>(o => ReadFromXML());
                }
                return openGameCommand;
            }
        }
    }
}

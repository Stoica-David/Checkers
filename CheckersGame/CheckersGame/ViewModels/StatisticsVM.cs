﻿using CheckersGame.Services;
using CheckersGame.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Xml;
using Newtonsoft.Json;
using System.IO;
using CheckersGame.Models;

namespace CheckersGame.ViewModels
{
    public class StatisticsVM : BaseVM
    {
        private string filePath = "D:\\Faculta an II Sem 2\\C ascutit\\Tema 2 - Dame\\CheckersGame\\CheckersGame\\Resources\\Statistics.json";

        public Statistics Stats { get; set; }

        public StatisticsVM()
        {
            DeserializeFromFile();
        }
        
        ~StatisticsVM() 
        {
            SerializeToFile();
        }

        public void DeserializeFromFile()
        {
            if (File.Exists(filePath))
            {
                StatisticsVM stats = JsonConvert.DeserializeObject<StatisticsVM>(filePath);

                Stats.BlackWins = stats.Stats.BlackWins;
                Stats.WhiteWins = stats.Stats.BlackWins;
                Stats.MostPiecesBlack = stats.Stats.MostPiecesBlack;
                Stats.MostPiecesWhite = stats.Stats.MostPiecesWhite;
            }
            else
            {
                throw new FileNotFoundException("Statistics file not found.", filePath);
            }
        }

        public void SerializeToFile()
        {
            var stats = new Statistics
            (
                Stats.BlackWins,
                Stats.WhiteWins,
                Stats.MostPiecesBlack,
                Stats.MostPiecesWhite
            );

            //var stats = new Statistics(1, 2, 3, 123);

            string json = JsonConvert.SerializeObject(stats);
            File.WriteAllText(filePath, json);
        }

        // DELEGATES
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
    }
}

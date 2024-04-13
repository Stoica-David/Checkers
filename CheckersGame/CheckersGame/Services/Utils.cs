using CheckersGame.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Xml;

namespace CheckersGame.Services
{
    public class Utils
    {
        private static int BoardDimension = 8;

        public static bool InAMultipleJump = false;

        public static Cell SelectedCell { get; set; }

        public static ObservableCollection<ObservableCollection<Cell>> InitGameBoard()
        {
            ObservableCollection<ObservableCollection<Cell>> cells = new ObservableCollection<ObservableCollection<Cell>>();
            for (int line = 0; line < BoardDimension; ++line)
            {
                ObservableCollection<Cell> row = new ObservableCollection<Cell>();
                for (int column = 0; column < BoardDimension; ++column)
                {
                    row.Add(new Cell(line, column));
                }

                cells.Add(row);
            }

            for (int column = 0; column < BoardDimension; ++column)
            {
                if (column % 2 == 0)
                {
                    cells[1][column].CurrentPiece = new Piece(Color.White);
                    cells[5][column].CurrentPiece = new Piece(Color.Black);
                    cells[7][column].CurrentPiece = new Piece(Color.Black);
                }
                else
                {
                    cells[0][column].CurrentPiece = new Piece(Color.White);
                    cells[2][column].CurrentPiece = new Piece(Color.White);
                    cells[6][column].CurrentPiece = new Piece(Color.Black);
                }
            }

            return cells;
        }
        public static void SerializeObjectToXML<T>(T item, string FilePath)
        {
            XmlSerializer xs = new XmlSerializer(typeof(T));
            using (StreamWriter wr = new StreamWriter(FilePath))
            {
                xs.Serialize(wr, item);
            }
        }

        public static T DeserializeObjectToXML<T>(string FilePath)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));

            T targetObj;

            using (FileStream fs = new FileStream(FilePath, FileMode.Open))
            {
                XmlReader reader = XmlReader.Create(fs);

                targetObj = (T)serializer.Deserialize(reader);
            }

            return targetObj;
        }
    }
}

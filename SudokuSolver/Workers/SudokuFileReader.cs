using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuSolver.Workers
{
    public class SudokuFileReader
    {
        public int[,] fileReader(String fileName)

        {
            int[,] sudokuBoard = new int[9,9];
            try {
            String[] sudokuBoardLines=File.ReadAllLines(fileName);
            for (int i=0;i<sudokuBoardLines.Length;i++)
                {
                    string[] elementsInaLine = sudokuBoardLines[i].Split('|').Skip(1).Take(9).ToArray();
                    for(int j=0;j<elementsInaLine.Length;j++)
                    {
                        sudokuBoard[i, j] = elementsInaLine[j].Equals(" ") ? 0 : int.Parse(elementsInaLine[j]);
                    }
                    
            }
                return sudokuBoard;
            }
            
            catch(Exception ex) {
                throw new Exception("Oops! the is an Exception" + ex.Message);
            }
        }


    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuSolver.Workers
{
    class SudokuBoardDisplayer
    {
        public void display(String title, int[,] sudokuBoard)
        {
            Console.WriteLine(title.Equals(string.Empty)?"random board":title, Environment.NewLine);
           for(int i=0; i < sudokuBoard.GetLength(0); i++)
            {
                for(int j =0;j< sudokuBoard.GetLength(0); j++)
                {
                    Console.Write("|"+sudokuBoard[i, j]);

                }
                Console.Write("|");

                Console.WriteLine();
            }

        }
    }
}

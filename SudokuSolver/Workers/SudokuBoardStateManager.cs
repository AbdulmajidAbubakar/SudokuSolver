using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuSolver.Workers
{
    class SudokuBoardStateManager
    {
        public string GenerateState(int[,] sudokuBoard)
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < sudokuBoard.GetLength(0); i++)
            {
                for (int j = 0; j < sudokuBoard.GetLength(0); j++)
                {
                    sb.Append(sudokuBoard[i, j]);
                }
            }

            return sb.ToString();
        }
        public bool isSolved(int[,] sudokuBoard) {

            for (int i = 0; i < sudokuBoard.GetLength(0); i++)
            {
                for (int j = 0; j < sudokuBoard.GetLength(0); j++)
                {
                    if (sudokuBoard[i, j] == 0 || sudokuBoard[i, j].ToString().Length > 1)
                    {
                        return false;
                    }
                }
            }

            return true; 
        
        }
    }
}

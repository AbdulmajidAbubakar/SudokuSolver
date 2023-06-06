using SudokuSolver.Workers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuSolver.Strategy
{
    class NakedPairStrategy: ISudokuStrategy
    {
        private readonly SudokuMapper _sudokuMapper;

        public NakedPairStrategy(SudokuMapper sudokuMapper)
        {
            _sudokuMapper = sudokuMapper;
        }

        public int[,] Solve(int[,] sudokuBoard)
        {
            for (int i = 0; i < sudokuBoard.GetLength(0); i++)
            {
                for (int j = 0; j < sudokuBoard.GetLength(0); j++)
                {
                    if (sudokuBoard[i, j] == 0 || sudokuBoard[i, j].ToString().Length > 1)
                    {
                        EliminatePairsInRows(sudokuBoard, i, j);
                        EliminatePairsIncols(sudokuBoard, i, j);
                        EliminatePairsInblocks(sudokuBoard, i, j);



                    }
                }

            }
            return sudokuBoard;
        }

        private void EliminatePairsInblocks(int[,] sudokuBoard, int i, int j)
        {
            if (!hasNakedPairsInrow(sudokuBoard,  i,  j)) return;
        }

        private bool hasNakedPairsInrow(int[,] sudokuBoard, int i, int j)
        {
            for (int col = 0; col < sudokuBoard.GetLength(0); col++)
            {
                if (j != col && IsNakedPair(sudokuBoard[i, col], sudokuBoard[i, j])) return true;
            }
            return false;
  
        }

        private bool IsNakedPair(int firstPair, int secondPair)
        {
            return firstPair.ToString().Length == 2 && firstPair == secondPair;
        }

        private void EliminatePairsIncols(int[,] sudokuBoard, int i, int j)
        {
            throw new NotImplementedException("this is not implemented");
        }

        private void EliminatePairsInRows(int[,] sudokuBoard, int i, int j)
        {
            if (!hasNakedPairsInrow(sudokuBoard, i, j)) return;
            for (int col = 0; col < sudokuBoard.GetLength(0); col++)
            {
                if (sudokuBoard[i,col]!= sudokuBoard[i,j] && sudokuBoard[i, col] > 1)
                {
                    EliminateNakedPairs(sudokuBoard, sudokuBoard[i, j], i, j);
                }
            }
        }

        private void EliminateNakedPairs(int[,] sudokuBoard, int valuesToEliminate, int i, int j)
        {
            var ValuestoElimianteArray = valuesToEliminate.ToString().ToCharArray();
            foreach (char valueToEliminate in ValuestoElimianteArray)
            {
                sudokuBoard[i, j] = Convert.ToInt32(sudokuBoard[i, j].ToString().Replace(valueToEliminate.ToString(),string.Empty));
            }
        }
    }
}

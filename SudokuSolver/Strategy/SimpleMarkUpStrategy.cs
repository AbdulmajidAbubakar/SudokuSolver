using SudokuSolver.Data;
using SudokuSolver.Workers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuSolver.Strategy
{
    class SimpleMarkUpStrategy: ISudokuStrategy
    {
        private readonly SudokuMapper _sudokumapper;

        public SimpleMarkUpStrategy(SudokuMapper sudokumapper)
        {
            _sudokumapper = sudokumapper;
        }

        public int GetPossibilitiesRowColums(int[,] sudokuBoard, int row, int column)
        {
            int[] possibilities = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            for (int i = 0; i < 9; i++)
            {
                if (IsSingle(sudokuBoard[row, i])) possibilities[sudokuBoard[row, i] - 1] = 0;
            }
            for (int i = 0; i < 9; i++)
            {
                if (IsSingle(sudokuBoard[i, column])) possibilities[sudokuBoard[i, column] - 1] = 0;
            }
            return Convert.ToInt32(string.Join(string.Empty, possibilities.Select(p => p).Where(p => p != 0)));
        }
        public bool IsSingle(int number)
        {
            if(number !=0 && number.ToString().Length==1) return true;
            return false;
        }
        public int GetPossibilitiesBlock(int[,] sudokuBoard, int row, int column)
        {
            int[] possibilities = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            SudokuMapper newFinder=new SudokuMapper();

            SudokuMap block =newFinder.find(row, column);
            int rowBlock = block.startRow;
            int columnBlock = block.startColumn;
            for (int i = rowBlock; i < rowBlock+2; i++)
            {
                for (int j = columnBlock; j < columnBlock + 2; j++)
                {
                    if (IsSingle(sudokuBoard[i, j])) possibilities[sudokuBoard[i, j] - 1] = 0;
                }
            }
           
            return Convert.ToInt32(string.Join(string.Empty, possibilities.Select(p => p).Where(p => p != 0)));

        }
        public int GetPossibilitiesIntersection(int rowAndColPossibilities,int blockPossibilities)
        {
            char[] rowAndColumnCharArray = rowAndColPossibilities.ToString().ToCharArray();
            char[] blockCharArray = blockPossibilities.ToString().ToCharArray();

            var possibilitySubsect=rowAndColumnCharArray.Intersect(blockCharArray);
            return Convert.ToInt32(string.Join(string.Empty,possibilitySubsect));
        }
        public int[,] Solve(int[,] sudokuBoard)
        {
            for (int i = 0; i < sudokuBoard.GetLength(0); i++)
            {
                for (int j = 0; j < sudokuBoard.GetLength(0); j++)
                {
                    if (sudokuBoard[i, j] == 0 || sudokuBoard[i, j].ToString().Length > 1)
                    {
                        int rowPosibilities = GetPossibilitiesRowColums(sudokuBoard, i, j);
                        int blockPosibilities = GetPossibilitiesBlock(sudokuBoard, i, j);
                        sudokuBoard[i,j]= GetPossibilitiesIntersection(rowPosibilities, blockPosibilities);




                    }
                }

            }
            return sudokuBoard;
        }
    }
}

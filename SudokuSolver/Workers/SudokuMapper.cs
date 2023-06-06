using SudokuSolver.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuSolver.Workers
{
    class SudokuMapper
    {
        public SudokuMap find(int row,int column)
        {
            SudokuMap sudokuMap = new SudokuMap();

            if (row <= 2 && column <= 2)
            {
                sudokuMap.startRow = 0;
                sudokuMap.startColumn = 0;
            }
            else if (row <= 2 && column <= 5)
            {
                sudokuMap.startRow = 0;
                sudokuMap.startColumn = 3;
            }
            else if (row <= 2 && column <= 8)
            {
                sudokuMap.startRow = 0;
                sudokuMap.startColumn = 6;
            }
            else if (row <= 5 && column <= 2)
            {
                sudokuMap.startRow = 3;
                sudokuMap.startColumn = 0;
            }
            else if (row <= 5 && column <= 5)
            {
                sudokuMap.startRow = 3;
                sudokuMap.startColumn = 3;
            }
            else if (row <= 5 && column <= 8)
            {
                sudokuMap.startRow = 3;
                sudokuMap.startColumn = 6;
            }
            else if (row <= 8 && column <= 2)
            {
                sudokuMap.startRow = 6;
                sudokuMap.startColumn = 0;
            }
            else if (row <= 8 && column <= 5)
            {
                sudokuMap.startRow = 6;
                sudokuMap.startColumn = 3;
            }
            else if (row <= 8 && column <= 8)
            {
                sudokuMap.startRow = 6;
                sudokuMap.startColumn =6;
            }

            return sudokuMap;

        }
    }
}

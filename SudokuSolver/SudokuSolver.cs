using System;
using SudokuSolver.Workers;

namespace SudokuSolver
{
    class SudokuSolver
    {
       
     
        public static void Main(string[] args)
        {
            SudokuFileReader reader = new SudokuFileReader();
            SudokuBoardDisplayer displayer= new SudokuBoardDisplayer();
           displayer.display("new 9X9 board", reader.fileReader("sudokuSimple.txt"));


        }

        
    }
}

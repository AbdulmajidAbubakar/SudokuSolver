using SudokuSolver.Workers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuSolver.Strategy
{
    class SudokuSolverEngine
    {
        private readonly SudokuBoardStateManager _sudokuBoardStateManager;
        private readonly SudokuMapper _sudokuMapper;

        public SudokuSolverEngine (SudokuBoardStateManager sudokuBoardStateManager, SudokuMapper sudokuMapper)
        {
            _sudokuBoardStateManager = sudokuBoardStateManager;
            _sudokuMapper = sudokuMapper;
        }
        public bool solve(int[,] sudokuBoard)
        {
            List<ISudokuStrategy> strategies = new List<ISudokuStrategy>() { };

            var currentSteate = _sudokuBoardStateManager.GenerateState(sudokuBoard);
            var nextstate= _sudokuBoardStateManager.GenerateState(strategies.First().Solve(sudokuBoard));
            while(!_sudokuBoardStateManager.isSolved(sudokuBoard) && currentSteate != nextstate)
            {
                currentSteate = nextstate;
                foreach(var strategy in strategies) nextstate= _sudokuBoardStateManager.GenerateState(strategy.Solve(sudokuBoard));
                
            }


            return _sudokuBoardStateManager.isSolved(sudokuBoard);
        }
    }
}

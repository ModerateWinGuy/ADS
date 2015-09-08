using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe_Tree
{
    public enum eSquare
    {
        Naught =-1,
        Empty=0,
        Cross=1,
    }

    // Player defualts to Cross
    public enum ePlayer
    {
        Naught,
        Cross,
    }
    public class BoardState
    {

        public eSquare[,] currentBoard;
        private ePlayer currentPlayerTurn;
        private int _boardScore;
        private int _potentialScore;

        public BoardState()
        {
            currentPlayerTurn = ePlayer.Naught;
        }
        public BoardState(eSquare[,] currentBoard)
        {
            currentPlayerTurn = ePlayer.Naught;
            this.currentBoard = currentBoard;
            calculateBoardScore();
        }

       

        public void calculateBoardScore()
        {
            ePlayer? winState = CheckForWin();
            if ( winState == ePlayer.Cross)
            {
                _boardScore = 1; // if the player has won
            }
            else if (winState == ePlayer.Naught)
            {
                _boardScore = -2; // if the player has lost
            }
            else if(CountEmptySpaces() ==0 && winState == null)
            {
                _boardScore = -1; // if it is a draw
            }
            else
            {
                _boardScore = 0; // game still in play.
            }
            
        }


        public void setSquare(int collum, int row, eSquare newSquareType)
        {
            currentBoard[collum, row] = newSquareType;
        }
        

        public List<BoardState> getAllNextMoves()
        {
            List<BoardState> allMoves = new List<BoardState>(CountEmptySpaces());
            Point lastPoint = new Point(0,0);
            if (CheckForWin() != null) return allMoves; // If someone has won, return the list empty since there are no futher moves

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (currentBoard[i, j] == eSquare.Empty)
                    {
                        BoardState newMove = new BoardState((eSquare[,]) currentBoard.Clone());
                        newMove.setSquare(i, j, currentPlayerTurn == ePlayer.Cross ? eSquare.Cross : eSquare.Naught);
                        newMove.setCurrentPlayerTurn(currentPlayerTurn == ePlayer.Cross ? ePlayer.Naught : ePlayer.Cross);
                        allMoves.Add(newMove);
                    }

                }
            }
            return allMoves;
        }

        private void setCurrentPlayerTurn(ePlayer ePlayer)
        {
            currentPlayerTurn = ePlayer;
        }

        private int CountEmptySpaces()
        {
            int totalEmpty = 0;

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (currentBoard[i,j] == eSquare.Empty)
                    {
                        totalEmpty++;
                    }
                }
            }
            
            return totalEmpty;
        }

        public static BoardState getEmptyBord()
        {
            eSquare[,] empty = { 
                { eSquare.Empty, eSquare.Empty, eSquare.Empty},
                { eSquare.Empty, eSquare.Empty, eSquare.Empty},
                { eSquare.Empty, eSquare.Empty, eSquare.Empty} };

            BoardState emptyBoard = new BoardState
            {
                currentBoard = empty
            };
            return emptyBoard;
        }

        /// <summary>
        /// Returns an eplayer depending on which player won, or returns null if no winner.
        /// </summary>
        /// <returns>an eplayer, or none if no winner.</returns>
        public ePlayer? CheckForWin()
        {
            // Check collums
            for (int i = 0; i < 3; i++)
            {
                int total = 0;
                for (int j = 0; j < 3; j++)
                {
                    total += (int)currentBoard[i, j]; // Adds up the points for each square, if it totals 3 on the negetive or posotive end, we know we have 3 in a row
                }
                if (total == 3)
                {
                    return ePlayer.Cross;
                }
                else if (total == -3)
                {
                    return ePlayer.Naught;
                }
            }
            // Check Rows
            for (int i = 0; i < 3; i++)
            {
                int total = 0;
                for (int j = 0; j < 3; j++)
                {
                    total += (int)currentBoard[j, i];
                }
                if (total == 3)
                {
                    return ePlayer.Cross;
                }
                else if (total == -3)
                {
                    return ePlayer.Naught;
                }
            }
            // Check Diags
            {
                int diagTotal = 0;
                diagTotal += (int) currentBoard[0, 0];
                diagTotal += (int) currentBoard[1, 1];
                diagTotal += (int) currentBoard[2, 2];
                if (diagTotal == 3)
                {
                    return ePlayer.Cross;
                }
                if (diagTotal == -3)
                {
                    return ePlayer.Naught;
                }
                diagTotal = 0;
                diagTotal += (int)currentBoard[0, 2];
                diagTotal += (int)currentBoard[1, 1];
                diagTotal += (int)currentBoard[2, 0];
                if (diagTotal == 3)
                {
                    return ePlayer.Cross;
                }
                if (diagTotal == -3)
                {
                    return ePlayer.Naught;
                }
            }

            return null;
        }

        public int PotentialScore
        {
            get { return _potentialScore; }
            set { _potentialScore = value; }
        }

        public int BoardScore
        {
            get { return _boardScore; }
            set { _boardScore = value; }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xo
{
    internal class Computer:Player
    {
        private char opponentShape;
        public Computer(char computerShape, char opponentShape)
        {
            base.name = "Computer";
            this.shape = computerShape;
            this.opponentShape = opponentShape;
        }
        //Method for choosing a move by computer
        public override int[] Choose()
        {
            int[] bestMove = FindBestMove();
            return bestMove;
        }
        //Method for find the best move by Minimax algorithem
        private int[] FindBestMove()
        {
            int bestScore = int.MinValue;
            int[] bestMove = null;

            for (int i = 0; i < Board.size; i++)
            {
                for (int j = 0; j < Board.size; j++)
                {
                    if (Board.mat[i, j] == '\0') // Check if the cell is empty
                    {
                        Board.mat[i, j] = this.shape;// Make a hypothetical move
                        int score = Minimax(Board.mat, 0, false, int.MinValue, int.MaxValue);
                        Board.mat[i, j] = '\0'; // Undo the move

                        if (score > bestScore)// If this move is better than the current best
                        {
                            bestScore = score;
                            bestMove = new int[] { i, j };// Update the best move
                        }
                    }
                }
            }

            return bestMove;
        }
        //Minimax algorithem with improve of Alpha-Beta Pruning algorithem
        private int Minimax(char[,] board, int depth, bool isMaximizing, int alpha, int beta)
        {
            if (Board.IsWin(this.shape)) return 10 - depth;// Return a high score if the computer wins
            if (Board.IsWin(this.opponentShape)) return depth - 10;// Return a low score if the opponent wins
            if (Board.IsFull()) return 0;// Return a neutral score if the board is full (draw)

            if (isMaximizing)
            {
                int bestScore = int.MinValue;
                for (int i = 0; i < Board.size; i++)
                {
                    for (int j = 0; j < Board.size; j++)
                    {
                        if (board[i, j] == '\0')// If the cell is empty
                        {
                            board[i, j] = this.shape;// Make a move
                            int score = Minimax(board, depth + 1, false, alpha, beta);// Recur for the minimizing player
                            board[i, j] = '\0';// Undo the move
                            bestScore = Math.Max(score, bestScore);// Get the best score for the maximizing player
                            alpha = Math.Max(alpha, score);// Update alpha for alpha-beta pruning

                            if (beta <= alpha)// Prune the branch
                                return bestScore; 
                        }
                    }
                }
                return bestScore;
            }
            else
            {
                int bestScore = int.MaxValue;
                for (int i = 0; i < Board.size; i++)
                {
                    for (int j = 0; j < Board.size; j++)
                    {
                        if (board[i, j] == '\0')// If the cell is empty
                        {
                            board[i, j] = this.opponentShape;// Make a move
                            int score = Minimax(board, depth + 1, true, alpha, beta);// Recur for the maximizing player
                            board[i, j] = '\0';// Undo the move
                            bestScore = Math.Min(score, bestScore);// Get the best score for the minimizing player
                            beta = Math.Min(beta, score);// Update beta for alpha-beta pruning

                            if (beta <= alpha)// Prune the branch
                                return bestScore; 
                        }
                    }
                }
                return bestScore;
            }
        }
    }
}

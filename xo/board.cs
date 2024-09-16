using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xo
{
    internal class Board
    {
        public static int size;// The size of the board
        public static char[,] mat;// The game board, represented by a matrix
        public Board(int size)
        {
            Board.size = size;
            Board.mat = new char[size, size];
        }

        //Printing the game board
        public void Print()
        {
            for (int i = 0; i < size; i++)
            {
                Console.WriteLine();
                for (int j = 0; j < size; j++)
                {
                    Console.Write(mat[i, j]=='\0'?' ' : mat[i,j]);// Print the board cells
                    if (j<size-1) Console.Write(" | ");
                }
                Console.WriteLine();
                if(i<size-1) Console.Write(new string('-',size*4-3));// Print separators between rows
            }
        }

        public bool IsNull(int i, int j)
        {
            return i >= 0 && i < size && j >= 0 && j < size && mat[i, j] == '\0';// Check if the cell is within bounds and empty
        }

        public void Insert(int i, int j, char c)
        {
            mat[i, j] = c;// Place the player's shape in the specified cell
        }

        //Checking who wins the game
        public static bool IsWin(char c)
        {
            for (int i = 0; i < size; i++)
            {
                if (CheckRow(i, c) || CheckColumn(i, c)) return true;// Check if a row or column is filled with the same shape
            }
            return CheckDiagonal(c) || CheckAntiDiagonal(c);// Check the diagonals
        }
        public static bool IsFull() => !mat.Cast<char>().Contains('\0'); // Check if the board is full

        private static bool CheckRow(int row, char c) => Enumerable.Range(0, size).All(col => mat[row, col] == c);// Check if a row is filled with the same shape
        private static bool CheckColumn(int col, char c) => Enumerable.Range(0, size).All(row => mat[row, col] == c);// Check if a column is filled with the same shape
        private static bool CheckDiagonal(char c) => Enumerable.Range(0, size).All(i => mat[i, i] == c);// Check if the main diagonal is filled with the same shape
        private static bool CheckAntiDiagonal(char c) => Enumerable.Range(0, size).All(i => mat[i, size - i - 1] == c);// Check if the anti-diagonal is filled with the same shape

    }
}

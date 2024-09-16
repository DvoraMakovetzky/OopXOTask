using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xo
{
    internal class Maneger
    {
        public Board board { get; set; }// The game board
        public Player[] players { get; set; }// Array of players

        public void StartGame()
        {
            Console.WriteLine("Enter the size of the board:");
            int size = int.Parse(Console.ReadLine());// Get the size of the board from the user
            this.board = new Board(size);// Initialize the board

            this.players = new Player[2];
            Console.WriteLine("Insert your name");
            this.players[0] = new Person(Console.ReadLine());// Initialize the first player

            Console.WriteLine("To play with computers press 1, to play with friend press 2:");
            int option = int.Parse(Console.ReadLine());
            if (option == 1)
            {
                players[1] = new Computer('x', 'o');// Initialize the computer player
            }
            else
            {
                Console.WriteLine("Insert your friend's name:");
                players[1] = new Person(Console.ReadLine());// Initialize the person player
            }
            // Set player shapes based on their roles
            players[0].shape = 'o';
            players[1].shape = 'x';
        }
        public void ManageGame()
        {
            StartGame();// Start and initialize the game
            int turn = 0;// Variable to track the turn (used to alternate between players)
            // Continue the game until there's a winner or the board is full (a draw)
            while (!Board.IsFull() && !Board.IsWin(players[0].shape) && !Board.IsWin(players[1].shape))
            {
                board.Print();// Print the current state of the board
                int[] move = players[turn % 2].Choose();// Get the current player's move
                // Validate the move: ensure the selected cell is empty
                while (!board.IsNull(move[0], move[1]))
                {
                    Console.WriteLine("Invalid move, try again.");
                    move = players[turn % 2].Choose();// Prompt the player to choose again if invalid
                }
                // Insert the current player's shape in the chosen cell
                board.Insert(move[0], move[1], players[turn % 2].shape);
                turn++;// Switch to the other player's turn
            }
            // After the game ends (win or draw), print the final board
            board.Print();
            // Check for a winner or declare a draw
            if (Board.IsWin(players[0].shape))
                Console.WriteLine($"{players[0].name} wins!");
            else if (Board.IsWin(players[1].shape))
                Console.WriteLine($"{players[1].name} wins!");
            else
                Console.WriteLine("It's a draw!");
        }
    }
}

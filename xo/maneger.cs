using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xo
{
    internal class maneger
    {
        public board board { get; set; }
        public player[] players { get; set; }
        public void choose()
        {
            this.board = new board();
            this.players = new player[2];
            Console.WriteLine("insert your name");
            this.players[0] = new person(Console.ReadLine());
            Console.WriteLine("to play whith computers : press 1\n to play whith friends : press 2");
            int c = int.Parse(Console.ReadLine());
            switch (c)
            {
                case 1:
                    this.players[1] = new computer();
                    players[0].shape = 'o';
                    players[1].shape = 'x';
                    break;
                case 2:
                    
                    Console.WriteLine("insert yours frind name");
                    this.players[1] = new person(Console.ReadLine());
                    players[0].shape = 'o';
                    players[1].shape = 'x';
                    break;
                default:
                    Console.WriteLine("error");
                    break;
            }
        }
        public void manager()
        {
            choose();
           
            for (int i = 0; i < 9 && !(this.board.Iswin((char)players[0].shape)) && !(this.board.Iswin((char)players[1].shape)); i++)
            {
                this.board.Print();
                int[] loc = players[i % 2].choose();
                while (!(board.Isnull(loc[0], loc[1])))
                {
                    if (players[i % 2] is person)
                    {
                        Console.WriteLine("the location is full");
                    }
                    loc = players[i % 2].choose();
                }
                board.insert(loc[0], loc[1], players[i % 2].shape);
            }
            if (board.Iswin(players[0].shape))
            {
                this.board.Print();
                Console.WriteLine("congratulations " + players[0].name + "!!  you win!!!");
            }
            else
            {
                this.board.Print();
                if (board.Iswin(players[1].shape))
                {
                    Console.WriteLine("congratulations " + players[1].name + "!!  you win!!!");
                }
                else
                    Console.WriteLine("oops..... ");
            }


        }


    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xo
{
    internal abstract class Player
    {
        public char shape { get; set; }// The shape ('X' or 'O') of the player
        public string name { get; set; }// The name of the player
        public abstract int[] Choose();// Abstract method for choosing a move, to be implemented by derived classes
    }
}

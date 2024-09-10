using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xo
{
    internal class computer:player
    {
        
        public computer()
        {
            base.name = "computers";
        }
        public override int[] choose()
        {
            int[] location = new int[2];
            Random rand = new Random();
            location[0] = rand.Next(3);
            location[1] = rand.Next(3);
            return location;
        }
    }
}

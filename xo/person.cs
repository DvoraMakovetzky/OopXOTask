using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xo
{
    internal class person:player
    {
        public person(string name)
        {
            base.name = name;
        }
        public override int[] choose()
        {
            int[] location = new int[2];
            Console.WriteLine("insert i & j");
            location[0] = int.Parse(Console.ReadLine());
            location[1] = int.Parse(Console.ReadLine());
            return location;    
        }
    }
}

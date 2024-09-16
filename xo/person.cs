using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xo
{
    internal class Person:Player
    {
        public Person(string name)
        {
            base.name = name;
        }
        //Method for choosing a move by person
        public override int[] Choose()
        {
            int[] location = new int[2];
            Console.WriteLine("Insert i & j");
            location[0] = int.Parse(Console.ReadLine());
            location[1] = int.Parse(Console.ReadLine());
            return location;    
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace procedural
{
    class Program
    {
        static void Main(string[] args)
        {
            Procedural_generator gen = new Procedural_generator();
            //gen.Cellular_automata(100,50,46,5);
            //gen.EllersMaze(20,20,60,60);
            gen.proceduralPlattformer(10, 30);
        }
    }
}

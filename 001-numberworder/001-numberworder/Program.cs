using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _001_numberworder
{
    class Program
    {
        static void Main(string[] args)
        {
            switch (args.Length)
            {
                case (0):
                    Console.WriteLine("You didn't supply any arguments! Try again with one argument, please.");
                    break;
 
                case (1):
                    var numberWorder = new NumberWorder(args[0]);
                    var output = numberWorder.GetOutput();
                    Console.WriteLine(output);
                    break;

                default:
                    Console.WriteLine("You supplied too many arguments! Try again with one argument, please.");
                    break;
            }

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_Hello
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter your name.");
            string name = Console.ReadLine();

            Console.WriteLine("Hello " + name);
            Console.WriteLine("How many hours of sleep did you get?");
           int hoursOfSleep = int.Parse(Console.ReadLine());

            if (hoursOfSleep >= 8)
            {
                Console.WriteLine("You are well rested.");
            }
            else
            {
                Console.WriteLine("You need more sleep.");
            }
        }
    }
}

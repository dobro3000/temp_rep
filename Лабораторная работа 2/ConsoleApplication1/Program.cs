using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            double f;
            for (double i = 1; i <= 2; i = i + 0.1)
            {
                Console.WriteLine("f= {0}", Math.Round(f = Math.Pow((Math.Cos(3 * i)), 2) / 2 * i +
                  Math.Pow((Math.Sqrt(Math.Tan(5 * i))), 5),3));
            }
            Console.WriteLine("\nНажмите любую клавишу для выхода из программы...");
            Console.ReadKey();
        }
    }
}

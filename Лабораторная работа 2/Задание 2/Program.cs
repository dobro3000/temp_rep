using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Задание_2
{
    class Program
    {
        static void Main(string[] args)
        {
            double s = 0;
            for (int i = 1; i <= 40; i++) s = s + Math.Cos(i);
            Console.WriteLine("Сумма = " + Math.Round(s,3));
            Console.WriteLine("\nНажмите любую клавишу для выхода из программы...");
            Console.ReadKey();
        }
    }
}

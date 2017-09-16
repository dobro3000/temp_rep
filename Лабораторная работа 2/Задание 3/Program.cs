using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Задание_3
{
    class Program
    {
        static double Vvod(string s) //Метод для ввода данных
        {
            while (true)
            {
                try
                {
                    Console.Write("Введите {0}: ", s);
                    return Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception e) { Console.WriteLine("\a"+e.Message); }
            }
        }
        static void Main(string[] args)
        {
            double[] x = new double[20];
            x[0] = Vvod("x[1]");
            x[1] = Vvod("x[2]");
            for (int k = 2; k <= 19; k++)
            {

                Console.WriteLine("x[" + (k + 1) + "]: " + Math.Round(x[k] = (k - 1) * Math.Sin(k * x[k - 1]) +
                      (k - 2) * Math.Sin(x[k - 2]), 3));
            }
            Console.WriteLine("\nНажмите любую клавишу для выхода из программы...");
            Console.ReadKey();
        }
    }
}

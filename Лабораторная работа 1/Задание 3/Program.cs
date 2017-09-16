using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Задание_3
{
    class Program
    {
        static int Vvod(string s) //метод для ввода чисел
        {
            while (true)
            {
                Console.Write("Введите число {0}: ", s);
                try { return Convert.ToInt32(Console.ReadLine()); }
                catch (Exception e)
                { Console.WriteLine("\a"+e.Message); }
            }
        }
        static void Main(string[] args)
        {
           
            int a = Vvod("a"), b = Vvod("b"),c = Vvod("c");

            double x, y;
            Console.WriteLine("x = {0}\ny = {1}", Math.Round(x = Math.Sqrt(a + Math.Log10(Math.Abs(b)) - Math.Cos(a * b)),3),
               Math.Round( y = Math.Log((a / (b * b + c * c)), Math.E) * 
                ((Math.Cos((a / (b * c)) * Math.Pow(Math.Sin(b), 3))) / 
                Math.Cos((a / (b * c)) * Math.Pow(Math.Sin(b), 3)))),3);
            Console.WriteLine("Нажмите любую клавишу для выхода из программы...");
            Console.ReadKey();
        }
    }
}

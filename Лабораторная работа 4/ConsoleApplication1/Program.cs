using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static int Vvod(string s) //Метод для ввода
        {
            while (true)
            {
                try
                {
                    Console.Write("{0}", s);
                    return Convert.ToInt32(Console.ReadLine());

                }
                catch (Exception e) { Console.WriteLine(e.Message); }
            
            }
        
        }
        static public double Emkosti(int l, int d, int r) // Метод для посдчета емкости линии 
        {
            double c = Math.Round(3.14 * 8.85e-1 / 12 * (l / (Math.Log10(d * r))),3);
            return c;
        }


        static void Main(string[] args)
        {
            int[] l = new int[4];
            int r = Vvod("Введите радиус r: ");
            Console.WriteLine();
            for (int i = 0; i <= 3; i++)
                l[i] = Vvod("Введите длинну " + (i + 1) + "-го проводника: ");
            Console.WriteLine();
            int[] d = new int[4];
            for (int i = 0; i <= 3; i++)
                d[i] = Vvod("Введите расстояние между проводами " + (i + 1) + "-го проводника: ");
            Console.WriteLine();
            for (int i = 0; i <= 3; i++)
                Console.WriteLine("Емкость " + (i + 1) + "-го проводника равна: " + Emkosti(l[i], d[i], r));
            Console.WriteLine("\nНажмите любую клавишу для выхода из программы...");
            Console.ReadKey();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication2
{
    class Program
    {
        static int Vvod(string s) //метод для ввода ряда
        {
            while (true)
            {
                try
                {
                    Console.Write("Введите элемент {0}: ", s);
                    return Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception e)
                { Console.WriteLine("\a"+e.Message); }
            } 
        }
        static void Main(string[] args)
        {
            int m;
            while (true)
            {
                try
                {
                    Console.Write("Введите число m: ");
                    m = Convert.ToInt32(Console.ReadLine()); break;
                }
                catch (Exception) { Console.WriteLine("Введено не число, либо число имеет недопустимый формат.\nПожалуйста, повторите ввод!"); }
            }
            double[,] y = new double[m, m];
            int[] x = new int[m];
            int[] z = new int[m];
            for (int i = 0; i <= m - 1; i++)
                x[i] = Vvod("x" + (i + 1));

            for (int j = 0; j <= m - 1; j++)
                z[j] = Vvod("z" + (j + 1));

            for (int i = 0; i <= m - 1; i++)
            {
                for (int j = 0; j <= m - 1; j++)
                {
                    Console.Write("y[" + (i + 1) + "," + (j + 1) + "]= {0}", (Math.Round((y[i, j] = Math.Sin((i + j) * (x[i] / x[j]))), 3)) + " ");
                } Console.WriteLine();
            }
            Console.Write("\nНажмите любую клавишу для выхода из программы...");
            Console.ReadKey();

        }
    }
}

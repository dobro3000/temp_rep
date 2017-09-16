using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication3
{
    class Program
    {
        static void test2(int[] a)//метод для вывода одномерных массивов
        {
            for (int j = 0; j < a.GetLength(0); j++)
            { Console.Write(a[j] + " "); }
            Console.WriteLine();
        }
        static void test(int[,] a)//метод для вывода двумерных массивов
        {
            for (int i = 0; i < a.GetLength(0); i++)
            {
                for (int j = 0; j < a.GetLength(1); j++)
                { Console.Write(a[i, j] + " "); }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        static int Vvod(string s) //Метод для вывода чисел
    {while (true)
    {try
    {Console.Write("Введите число {0}: ", s);
        return Convert.ToInt32(Console.ReadLine());}
        catch (Exception e)
    { Console.WriteLine("\a"+e.Message); }
    }
    }
        static void Main(string[] args)
        {
            double sum1 = 0, sum2 = 0, sum3 = 0;
            Random Rnd = new Random();
            int n = Vvod("n"), m = Vvod("m");
            int[,] x = new int[m, n];

            for (int j = 0; j <= m - 1; j++)
            {
                for (int i = 0; i <= n - 1; i++)
                {
                    x[j, i] = Rnd.Next(10);
                    sum1 = sum1 + Math.Sin(x[j, i]);
                }
            }
            test(x);

            int[,] y = new int[n, m];
            for (int i = 0; i <= n - 1; i++)
            {
                for (int j = 0; j <= m - 1; j++)
                {
                    y[i, j] = Rnd.Next(10);
                    sum1 = sum1 + y[i, j];
                }
            }
            test(y);
            sum3 = sum1 + sum2;

            int k = Vvod("k");
            int[] a = new int[k];
            int[] b = new int[k];

            for (int q = 0; q <= k - 1; q++)
                a[q] = Rnd.Next(10);
            test2(a);

            for (int q = 0; q <= k - 1; q++)
                b[q] = Rnd.Next(10);
            test2(b);

            double[] mas = new double[k];

            for (int q = 0; q <= k - 1; q++)
            {
                Console.WriteLine("Элемент массива c[" + (q + 1) + "]= {0} ", Math.Round(mas[q] = sum3 / (a[q] - b[q]), 3));
            }
            Console.WriteLine("\nНажмите любую клавишу для выхода из программы...");
            Console.ReadKey();
        }
    }
}

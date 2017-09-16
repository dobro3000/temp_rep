using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Задание_4
{
    class Program
    {
        static int Vvod2(string s)  //Метод для ввода чисел ряда
        {
            while (true)
            {
                try
                {
                    Console.Write("Введите {0} элемент ряда: ", s);
                    return Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception e) { Console.WriteLine("\a\nВведено не число, либо число имеет недопустимый формат.\nПожалуйста, повторите ввод!\n"); }
            }
        }
        static int Vvod(string s) //Метод для ввода размерности ряда
        {
            while (true)
            {
                try
                {
                    Console.Write("Введите {0}: ", s);
                    return Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception e) { Console.WriteLine("\a\nВведено не число, либо число имеет недопустимый формат.\nПожалуйста, повторите ввод!\n"); }
            }
        } 
        static void Main(string[] args)
        {
            double s1 = 0, s2 = 0, sum;
            int n = Vvod("n");
            int[] x = new int[n];

            for (int i = 0; i <= n - 1; i++)
                x[i] = Vvod2("X" + (i + 1));

            int[] y = new int[n];
            for (int i = 0; i <= n - 1; i++)
                y[i] = Vvod2("Y" + (i + 1));

            int m = Vvod("m");
            int[] z = new int[m];
            for (int j = 0; j <= m - 1; j++)
                z[j] = Vvod2("Z" + (j + 1));

            for (int i = 0; i <= n - 1; i++)
                s1 = y[i] * x[i] * x[i];

            for (int j = 0; j <= m - 1; j++)
                s2 = Math.Sqrt(Math.Exp(1 / z[j]));


            Console.WriteLine("Сумма равна: {0}", (sum = s1 + s2));
            Console.WriteLine("\nДля выхода из программы нажмите любую клавишу...");
            Console.ReadKey();
        }
    }
}

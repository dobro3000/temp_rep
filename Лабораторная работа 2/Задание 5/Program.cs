using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Задание_5
{
    class Program
    {
        static int Vvod(string s) //Метод для ввода чисел
    {while (true)
    {try
    {
        Console.Write("Введите {0} число: ", s);
        return Convert.ToInt32(Console.ReadLine());}
    catch (Exception e) { Console.WriteLine("\a"+e.Message); }
    }
    }
        static void Main(string[] args)
        {
            int n = Vvod("n");
            int[] Ryad = new int[n];
            for (int i = 0; i <= n - 1; i++)
             Ryad[i] = Vvod((i + 1)+"-ое");

            int max = Ryad[1], min = Ryad[1], f = 0;
            for (int i = 0; i <= n - 1; i++)
            {
                if (Ryad[i] >= max) max = Ryad[i];
            }
            for (int i = 0; i <= n - 1; i++)
            {
                if (Ryad[i] <= min) min = Ryad[i];
            }

            Console.WriteLine();
            Console.WriteLine("Максимальное число в данном ряде равно: {0}, а минимальное число равно: {1}", max, min);
            f = max;
            max = min;
            min = f;
            Console.WriteLine("После обмена максимальное число ранво: {0}, а минимальное число равно: {1}", max, min);
            Console.WriteLine();
            Console.WriteLine("Нажмите любую клавишу для выхода из прогрмаммы...");
            Console.ReadKey();

        }
    }
}

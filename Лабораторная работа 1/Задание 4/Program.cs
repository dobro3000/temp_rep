using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Задание_4
{
    class Program
    {
        static void Main(string[] args)
        {
            double x;
            {
                while (true)
                {
                    try
                    {
                        Console.Write("Введите x = ");
                        x = double.Parse(Console.ReadLine());
                        break;
                    }
                    catch (Exception e)
                    { Console.WriteLine("\a"+e.Message); }
                }
            }
            double z;
            if (x < -3) Console.WriteLine("z = {0}", z = Math.Pow(Math.Log((x), 1 / 3), Math.E));
            else
                if (x >= -3 && x <= 1) Console.WriteLine("z = {0}", Math.Round(z = Math.Sin(x * x)), 3);
                else
                    if (x > 1) Console.WriteLine("z = {0}", z = Math.Pow((Math.Cos(x) / Math.Sin(x)), 1 / 3));


            Console.WriteLine("Нажмите любую клавишу для выхода из приграммы...");
            Console.ReadKey();
        }
    }
}

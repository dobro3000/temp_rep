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
            Random Rnd = new Random();
            
            int[] x = new int[20];
            for (int k = 0; k <= 19; k++)
            {

                x[k] = Rnd.Next(10);
            }
            int[,] b = new int[30, 15];
            for (int i = 0; i <= 29; i++)
            {
                for (int j = 0; j <= 14; j++)
                {

                    b[i, j] = Rnd.Next(10);
                }
            }
            double s1 = 0, s2 = 0, sum = 0;
            for (int k = 0; k <= 19; k++)
            { s1 = s1 + Math.Cos(Math.Exp(x[k])); }
            for (int i = 0; i <= 29; i++)
            {
                for (int j = 0; j <= 14; j++)
                {
                    s2 = Math.Sqrt(Math.Abs(Math.Sin(b[i, j]))) + s2;
                   
                }
            }

            Console.WriteLine("Результат: {0}", Math.Round(sum = (s1 /Math.Log((s2),3)),3));
            Console.WriteLine("\nНажмите любую клавишу для выхода из программы...");
            Console.ReadKey();



        }
    }
}

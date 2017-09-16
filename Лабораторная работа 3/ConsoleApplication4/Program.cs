using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication4
{
    class Program
    {
        static void Main(string[] args)
        {
            Random Rnd = new Random();
            int[,] A = new int[10, 10];
            for (int i = 0; i <= 9; i++)
            {
                for (int j = 0; j <= 9; j++)
                {
                    
                    Console.Write((A[i, j] = Rnd.Next(10))+" ");
                }
                Console.WriteLine();
            }
            int sum = 0, kol = 0;
            
                for (int i = 0; i <= 9; i++)
                {
                    for (int j = 0; j <= 9; j++)
                    {
                        if (i == j)
                        {
                        sum = sum + A[i, j];
                        kol = kol + 1;
                    }
                }
            }
            Console.WriteLine("\nСумма элементов под гланвой диагональю равна: {0} \nЧисло элементов на главной диагонали равно: {1}", sum, kol);
            Console.WriteLine();
            Console.WriteLine("Нажмите любую клавишу для выхода из программы...");
            Console.ReadKey();
        }
    }
}

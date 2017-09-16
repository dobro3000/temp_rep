using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication3
{
    class Program
    {
        static void ArrVivod(int[,] a)
        {
            for (int i = 0; i < a.GetLength(0); i++)
            {
                for (int j = 0; j < a.GetLength(1); j++)
                    Console.Write(a[i, j] + " ");
                Console.WriteLine();
            }
            Console.WriteLine();

        }
        static void Podchet(int[,] A)  //метод для вычисления минимального элемента в строке массива и вывод его столбца и строки
        {
            int str = 0, stolb = 0, max;
            int n = A.GetLength(0), m = A.GetLength(1);
            for (int i = 0; i < n; i++)
            {
                max = A[i, 1];
                for (int j = 0; j < m; j++)
                {
                    if (A[i, j] <= max)
                    {
                        max = A[i, j];
                        str = i + 1;
                        stolb = j + 1;
                    }
                }
                Console.WriteLine("Mинимальный элемент: {0}. Eго строка: {1}. Eго столбец: {2}.", max, str, stolb);

            }

        }

        static void Main(string[] args)
        {

            Random Rnd = new Random();

            int[,] A = new int[9, 6];
            int[,] X = new int[7, 9];
            for (int i = 0; i < A.GetLength(0); i++)
            {
                for (int j = 0; j < A.GetLength(1); j++)
                    A[i, j] = Rnd.Next(10);
            }
            ArrVivod(A);
            Console.WriteLine();
            for (int i = 0; i < X.GetLength(0); i++)
            {
                for (int j = 0; j < X.GetLength(1); j++)
                    X[i, j] = Rnd.Next(10);
            }
            ArrVivod(X);
            Console.WriteLine("\nВывод для матрицы 1:");
            Podchet(A);
            Console.WriteLine("\nВывод для матрицы 2:");
            Podchet(X);
            Console.WriteLine("\nНажмите любую клавишу для выходы из программы...");
            Console.ReadKey();

        }
    }
}



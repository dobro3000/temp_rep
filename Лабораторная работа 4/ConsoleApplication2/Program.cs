using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication2
   
{
    class Program
    {
        static int inp(string s)
        {
            while (true)
            {
                Console.Write("Введите {0}:", s);
                try
                {
                    return Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);

                }
            }
        }

        static void test(int[,] a)
        {
            for (int i = 0; i < a.GetLength(0); i++)
            {
                for (int j = 0; j < a.GetLength(0); j++)
                    Console.Write("{0}", a[i, j]);
                Console.WriteLine();
            }
        }
        static void Main(string[] args)
        {
            
            int[,] x = new int[inp("N"), inp("M")];

            Random rnd = new Random();

            for (int i = 0; i < x.GetLength(0); i++)
                for (int j = 0; j < x.GetLength(1); j++)
                    x[i, j] = rnd.Next(-100, 100);
            test(x);


        }
    }
}

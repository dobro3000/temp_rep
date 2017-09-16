using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test2
{
    class Program
    {
        static double InputArray(int x, int y)
{
Random Rnd = new Random();
int i,j;
double sum;
double[,] array = new double[x,y];
double[] S = new double[x];
for (i = 0; i <= x-1; i++)
for (j = 0; j <= y-1; j++)
array[i, j] = Rnd.Next(10);
for (i = 0; i < x - 1; i++)
{
sum = 0;
for (j = 0; j < y; j++)
{
if (array[i, j] > 0)
{
sum = sum + array[i, j];
S[i] = sum;
}
}
}
for (i = 0; i <= x - 1; i++)
{
for (j = 0; j <= y - 1; j++)
{
Console.Write(array[i, j] + " ");
}
Console.WriteLine();
}
Console.WriteLine("Сумма элементов строк: ");
for (i = 0; i < x - 1; i++)
Console.Write(S[i] + " ");
return (array[x-1, y-1]);

        }
    }
}

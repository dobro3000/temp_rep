using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static int Vvod(string s)//Метод для ввода чисел
        {
            while (true)
            {
                Console.Write("Введите координату {0}: ", s);
                try { return Convert.ToInt32(Console.ReadLine()); }
                catch (Exception e)
                { Console.WriteLine("\a"+e.Message); }
            }
        }


        static void Main(string[] args)
        {
            int x1 = Vvod("x1"), x2 = Vvod("x2"), x3 = Vvod("x3");
            int y1 = Vvod("y1"), y2 = Vvod("y2"), y3 = Vvod("y3");
            int z1 = Vvod("z1"), z2 = Vvod("z2"), z3 = Vvod("z3");



            if (Math.Abs(x3 - x1) < Math.Abs(x3 - x2) && Math.Abs(y3 - y1) < Math.Abs(x3 - x2) && Math.Abs(z3 - z1) < Math.Abs(x3 - x2))
                Console.WriteLine("Точка А находиться ближе к точке С.");
            else Console.WriteLine("Точка В находиться ближе к точке С.");
            Console.WriteLine();
            Console.WriteLine("Для выхода из программы нажмите любую клавишу...");
            Console.ReadKey();
        }
    }
}

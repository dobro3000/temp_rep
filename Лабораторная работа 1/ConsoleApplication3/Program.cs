using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication3
{
    class Program
    { 
        static void Main(string[] args)
        {
            int Plan, FactVipProd;
            {
                while (true)
                {
                    try
                    {
                        Console.Write("Введите план: ");
                        Plan = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Введите фактический выпуск продукции: ");
                        FactVipProd = Convert.ToInt32(Console.ReadLine());
                        double x = (100 * Plan) / FactVipProd;
                        Console.WriteLine("Процент выполнения плана предприятия: {0} ", x); break;
                    }
                    catch (Exception e)
                    { Console.WriteLine("\a"+e.Message); }

                }
            }

            Console.WriteLine("Нажмите любую клавишу для выхода из программы...");
            Console.ReadKey();
        }
    }
}

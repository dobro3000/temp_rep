using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Задание_2
{
    class Program
    {
        static void Processing(string z)
        {

            int i;
            string s = string.Empty, s1;
            string str = string.Empty;
            string[] Parametrs = z.Split(' ');

            for (i = 0; i < Parametrs.Length; i++)
            {
                if (Parametrs[i].StartsWith("/"))
                {
                    switch (Parametrs[i].ToLower())
                    {
                        case "/help": Help(); i = Parametrs.Length - 1; break;
                        case "/invert": s1 = string.Empty; if ((i + 1 < Parametrs.Length))
                                for (int j = i + 1; j < Parametrs.Length; j++)
                                    if (Parametrs[j].Contains("/") == false) s1 = s1 + Parametrs[j];
                                    else
                                        if (Parametrs[i].Contains("/") == true) j = Parametrs.Length;
                            Console.WriteLine("Инверсия строки '{0}' будет выглядеть так: '{1}'. ", s1, s = Invert(s1)); break;
                        case "/inv": Console.WriteLine("Последняя инверсированная строка: '{0}'", Invert(s)); break;
                        case "/cancel": Console.WriteLine("\nВводимые параметры: {0}\n", str); i = Parametrs.Length - 1; break;
                        default: Console.WriteLine("\n\aДанная команда отсутсвует. Попробуйте воспользоваться командой '/Help' для \nвызова справки."); break;
                    }
                }
                str = str + Parametrs[i] + " ";
            }
        }
        static void Help() //метод для вывода справки
        {

            Console.WriteLine("\nКоманда Help(Справка).\nДля работы с программой воспользуйтесь списком команд.\n\nСписок команд:\n\n\t/Help - вызов справки.\n\t/Invert - команда для инверсирования строки.\n\t/Inv - возвращает инверсированную строку в исходный вид.\n\t/Cansel - выводит на экран все вводимые в программу параметры.");
        }
        static string Invert(string s)//метод для инверсирования строк
        {
            string str = string.Empty;
            for (int i = s.Length - 1; i >= 0; i--)
            {
                str = str + s[i];
            }
            return (str);
        }

        static void Main(string[] args)
        {
            Console.WriteLine("\n\t\t\t>>>Добро пожаловать в программу!<<<\n\nДанная программа позволяет инвертировать введенную строку.\nПример ввода: /команда 'строка'.\nНапример: /invert 'ХимТех - лучше всех' /inv.\nВывод:\nИнверсия строки:'ХимТех - лучше всех' будет выглядеть 'хесв ешчул - хеТмиХ'.\nПоследняя инверсированная строка: 'ХимТех - лучше всех'.\n\n\t\t\t   >>>Приятного пользования!<<<\n\n");
            //Цикл для ввода параметров 
            if (args.Length != 0)
                Processing(String.Join(" ", args));
            while (true)
            {
                String s = Console.ReadLine();
                if (s != "")
                    Processing(s);
            }
        }




    }
}
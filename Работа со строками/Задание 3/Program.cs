using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static string Del(string str, string smb)//метод для удаления указанного символа из строки
        {

            string NewStr = string.Empty;
            int i;
            for (i = 0; i < str.Length; i++)
            {
                if (smb.Contains(str[i])) NewStr = NewStr + str[i];
            }

            return (NewStr);

        }
        static string Substr(string str, string pstr)//метод для нахождения подстроки в строке
        {
            if (str.ToLower().Contains(pstr.ToLower().Trim())) return ("Подстрока '" + pstr + "' найдена в строке '" + str + "'");
            else return ("К сожалению подстрока '" + pstr + "' не найдена в строке '" + str + "'");
        }
        static string Z(string str)//метод для проверки является ли слово полидроном
        {
            string NewStr = string.Empty;
            for (int i = str.Length - 1; i >= 0; i--)
            {
                NewStr = NewStr + str[i];
            }
            if (str.Trim().ToLower().Equals(NewStr.Trim().ToLower())) return ("Слово " + str.Trim() + " является полиндромом.");
            else return ("Слово " + str.Trim() + " НЕ является полиндромом.");
        }
        static string Concat(string str)//метод для kонkатинации строк
        {
            string NewStr = string.Empty;
            string[] mas = str.Split(' ');
            for (int i = 0; i < mas.Length; i++)
            {
                if (mas[i] != " ")
                    NewStr = NewStr + mas[i];
            }
            return (NewStr);

        }
        static string Invert(string str)//метод для инверсирования строк
        {
            string NewStr = string.Empty;
            for (int i = str.Length - 1; i >= 0; i--)
            {
                NewStr = NewStr + str[i];
            }
            return (NewStr);
        }
        static void Main(string[] args)
        {
            //Логические флаги
            bool help = false;
            bool cancel = false;
            bool inv = false;

            //Переменные для хранения строк
            string del = string.Empty;
            string substr = string.Empty;
            string z = string.Empty;
            string concat = string.Empty;
            string canc = string.Empty;
            string invert = string.Empty;
            string pstr = string.Empty;
            string smb = string.Empty;

            for (int i = 0; i < args.Length; i++)
            {
                switch (args[i].ToLower())
                {
                    case "/help": help = true; break;
                    case "/invert": while ((i <= args.Length - 2) && !(args[i + 1].StartsWith("/"))) invert = invert + args[++i] + " "; break;
                    //case "/del": while ((i <= args.Length - 2) && !(args[i + 1].StartsWith("/"))) del = del + args[++i] + " "; smb = args[i + 2]; break;
                    //case "/substr": while ((i <= args.Length - 2) && !(args[i + 1].StartsWith("/"))) substr = substr + args[++i] + " "; break;
                    case "/z": while ((i <= args.Length - 2) && !(args[i + 1].StartsWith("/"))) z = z + args[++i] + " "; pstr = args[i + 2]; break;
                    case "/concat": while ((i <= args.Length - 2) && !(args[i + 1].StartsWith("/"))) concat = concat + args[++i] + " "; break;
                    case "/inv": inv = true; break;
                    case "/cancel": cancel = true; break;
                    default: Console.WriteLine("Такой команды не существует."); break;
                }

            }

            if (help)
            {
                Console.WriteLine("\nВы выбрали команду Help(Справка).\nДля работы с программой воспользуйтесь списком команд.\n\nСписок команд:\n\n/Help - вызов справки.\n/About - o программе.\n/Invert - команда для инверсирования строки.\n/Concat - команда для конкатинации строки.\n/Z - команда для проверки, является ли слово полиндромом.\n/Substr - команда для нахождения подстроки в строке.\n/Inv - выводит на экран поседнюю записанную строку.\n/Del - удаляет указанный символ в строке.\n/Developer - разрабочики.\n/Cansel - выход из программы.\n\t\t\tПриятного пользования!");
                return;
            }
            else
            {
                if (!string.IsNullOrWhiteSpace(invert)) Console.WriteLine("Инвертированная строка: {0}", Invert(invert));
                if (!string.IsNullOrWhiteSpace(del)) Console.WriteLine("Исходный вид строки: {0}", Del(del, smb));
                if (!string.IsNullOrWhiteSpace(substr)) Console.WriteLine(Substr(substr, pstr));
                if (!string.IsNullOrWhiteSpace(z)) Console.WriteLine(Z(z));
                if (!string.IsNullOrWhiteSpace(concat)) Console.WriteLine("Конкатинация строк: {0}", Concat(concat));

                if (inv) //выводит все вводимые строки кроме тех, оторые начинаются с '/'
                {
                    Console.Write("Исходный вид строк: ");
                    for (int i = 0; i < args.Length; i++)
                        if (!args[i].StartsWith("/"))
                            Console.Write(args[i] + " ");
                }

                if (cancel)//выводит все аргументы, до 'cancel'
                {
                    Console.Write("Вводимые параметры: ");
                    for (int i = 0; args[i] != "/cancel"; i++)
                    {
                        Console.Write(args[i] + " ");
                    }
                }

            }

            Console.ReadKey();

        }
    }
}
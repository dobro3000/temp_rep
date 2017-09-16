using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication3
{
    namespace GlobalBuf//буфер для хранения последней вводимой строки
    {
        class Global
        {
            public static string Peremen;

            public static void Buf()
            {
            }
        }
    }
    class Program
    {
        static void Help() //метод для вывода справки
        {
            Console.WriteLine("\nВы выбрали команду Help(Справка).\nДля работы с программой воспользуйтесь списком команд.\n\nСписок команд:\n\n/Help - вызов справки.\n/About - o программе.\n/Invert - команда для инверсирования строки.\n/Concat - команда для конкатинации строки.\n/Z - команда для проверки, является ли слово полиндромом.\n/Substr - команда для нахождения подстроки в строке.\n/Inv - выводит на экран поседнюю записанную строку.\n/Del - удаляет указанный символ в строке.\n/Developer - разрабочики.\n/Cansel - выход из программы.");
        }
        static void Del()//метод для удаления указанного символа из строки
        {
            Console.WriteLine("\nВы выбрали команду 'Del'.\nДанная команда позволяет удалить из строки указанный символ.\nНапример: строка 'ХимТех - лучше всех', удалить 'х',\nРезультат: 'имТе - лучше все'.");
            Console.Write("\nВведите строку: ");
            GlobalBuf.Global.Peremen = Convert.ToString(Console.ReadLine());
            bool p = true;
            while (p)
            {
                try
                {
                    Console.Write("Введите символ, который хотите удалить из строки: ");
                    char smb = Convert.ToChar(Console.ReadLine());
                    string str = string.Empty;
                    int i;
                    for (i = 0; i < GlobalBuf.Global.Peremen.Length; i++)
                    {
                        if (GlobalBuf.Global.Peremen[i] != smb) str = str + GlobalBuf.Global.Peremen[i];
                    }
                    p = false;
                    Console.WriteLine("Преобразованная строка: {0}", str);
                }

                catch (FormatException) { Console.WriteLine("\n\aПроизошла ошибка! Скорей всего вы ввели несколько символов.\nПопробуйте ввести только один символ.\n"); }
            }
        }
        static void Substr()//метод для нахождения подстроки в строке
        {
            Console.WriteLine("\nВы выбрали команду 'Substr'.\nДанная команда позволяет найти строку в подстроке и выводит результат на экран.\nНапример: строка 'ХимТех - лучше всех', найти подстроку 'Хим'.");
            Console.Write("\nВведите строку: ");
            GlobalBuf.Global.Peremen = Convert.ToString(Console.ReadLine());
            Console.Write("Введите подстроку, которую хотите найти: ");
            string pst = Convert.ToString(Console.ReadLine());
            if (GlobalBuf.Global.Peremen.ToLower().Contains(pst.ToLower().Trim())) Console.WriteLine("Подстрока '{0}' найдена в строке '{1}'.", pst.Trim(), GlobalBuf.Global.Peremen);
            else Console.WriteLine("К сожалению подстрока '{0}' не найдена в строке '{1}'.", pst.Trim(), GlobalBuf.Global.Peremen);
        }
        static void Z()//метод для проверки является ли слово полидроном
        {
            string str = string.Empty;
            Console.WriteLine("\nВы выбрали команду 'Z'.\nДанная команда определяет, является ли слово полиндромом.\nНапример: слово 'комок' - является  полиндромом,\nа слово 'ручка' не является  полиндромом.");
            Console.Write("\nВведите слово: ");
            GlobalBuf.Global.Peremen = Convert.ToString(Console.ReadLine());
            for (int i = GlobalBuf.Global.Peremen.Length - 1; i >= 0; i--)
            {
                str = str + GlobalBuf.Global.Peremen[i];
            }
            if (GlobalBuf.Global.Peremen.Trim().ToLower().Equals(str.Trim().ToLower())) Console.WriteLine("Слово '{0}' является полиндромом.", GlobalBuf.Global.Peremen.Trim());
            else Console.WriteLine("Слово '{0}' НЕ является полиндромом.", GlobalBuf.Global.Peremen.Trim());
        }
        static void Concat()//метод для kонkатинации строк
        {
            {
                Console.WriteLine("\nВы выбрали команду 'Concat'.\nЭтот метод преобразует вводимую строку в сплошной текст и выводит его на экран.\nНапример: 'ХимТех - лучше всех'.\nПосле преобразования: 'ХимТех-лучшевсех'");
                Console.Write("\nВведите строку: ");
                GlobalBuf.Global.Peremen = Convert.ToString(Console.ReadLine());
                string str = string.Empty;
                string[] mas = GlobalBuf.Global.Peremen.Split(' ');
                str = string.Join(str, mas);
                Console.WriteLine("Преобразованная строка: {0}", str);
            }
        }
        static void Invert()//метод для инверсирования строк
        {
            Console.WriteLine("\nВы выбрали команду 'Invert'.\nЭтот метод преобразует вводимую строку в зеркальный вид и выводит ее на экран.\nНапример: 'ХимТех - лучше всех'.\nПосле преобразования: 'хесв ешчул - хеТмиХ'");
            string str = string.Empty;
            Console.Write("\nВведите строку: ");
            GlobalBuf.Global.Peremen = Convert.ToString(Console.ReadLine());
            for (int i = GlobalBuf.Global.Peremen.Length - 1; i >= 0; i--)
            {
                str = str + GlobalBuf.Global.Peremen[i];
            }
            Console.WriteLine("Преобразованная строка: {0}", str);
        }
        static void Main(string[] args)
        {
            Console.WriteLine("\n\t\t\tДобро пожаловать в программу!");
            bool x = true;
            while (x)
            {
                Console.Write("\nВведите команду: ");
                string komanda = Convert.ToString(Console.ReadLine());

                switch (komanda.ToLower())
                {
                    case "/help": Help(); break;
                    case "/about": Console.WriteLine("\nДанная программа позволяет выполнять некоторые преобразования над строкой.\nДля подробной информации воспользуйтесь справкой '/help'"); break;
                    case "/developer": Console.WriteLine("\nРазработчик: Kubova Anastasiya (=^_^=) "); break;
                    case "/invert": Invert(); break;
                    case "/concat": Concat(); break;
                    case "/substr": Substr(); break;
                    case "/del": Del(); break;
                    case "/inv": ; Console.WriteLine("Последняя введеная строка: {0}", GlobalBuf.Global.Peremen); break;
                    case "/z": Z(); break;
                    case "/cancel": x = false; break;
                    default: Console.WriteLine("\n\aДанная команда отсутсвует. Попробуйте воспользоваться командой '/Help' для \nвызова справки."); break;
                }
            }
        }
    }
}
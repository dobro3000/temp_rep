using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace test
{
    class Program
    {
        static int Test(string dir) //метод для проверки существования каталога 
        {
            DirectoryInfo di = new DirectoryInfo(dir);

            if (!di.Exists)
            {
                Console.WriteLine("\n\aКаталог с именем '{0}' не найден!\n", di.Name); //проверка существование каталога
                return (0);
            }
            else return (1);
        }
        static void Info(string dir)  //Метод для вывода информации о каталоге 
        {
            DirectoryInfo di = new DirectoryInfo(dir);
            Console.WriteLine("\n=====Информация о каталоге '{0}'=====", di.Name);
            Console.WriteLine("Путь к каталогу: {0}", di.FullName);
            Console.WriteLine("Имя: {0}", di.Name);
            Console.WriteLine("Родительский каталог: {0}", di.Parent);
            Console.WriteLine("Дата создания: {0}", di.CreationTime);
            Console.WriteLine("Время последнего обращения к каталогу: {0}", di.LastAccessTime);
            Console.WriteLine("Время последних изменений в каталоге: {0}", di.LastWriteTime);
            Console.WriteLine("Атрибуты: {0}", di.Attributes);
            Console.WriteLine("Диск, на котором размещен каталог: {0}", di.Root);
            Console.WriteLine("========================================\n");

        }
        static void Copy_To(string dir)//Метод для опирования из данного каталога в другой
        {
            DirectoryInfo di = new DirectoryInfo(dir);
            DirectoryInfo InCopy = new DirectoryInfo(@"d:\copy\");
            if (!InCopy.Exists) InCopy.Create(); //создание каталога
            FileInfo[] Files = di.GetFiles(); //создание списка содержимого
            foreach (FileInfo f in Files) //копирование содержимого файла в другой с перезаписью
                f.CopyTo(InCopy + f.Name, true);
            Console.WriteLine("\nКопирование завершенно.\nИз каталога '{0}' cкопированно {1} файла(ов) в каталог '{2}'.\n", di.Name, Files.Length, InCopy.Name);
        }
        static void Write_To(string dir) //Метод для дублирования текста с консоли в файл 
        {
            string fileName = @"d:\CopyText.txt";
            FileStream stream = File.Open(fileName, FileMode.OpenOrCreate, FileAccess.Write, FileShare.Write);
            byte[] buffer = new byte[10];
            buffer = Encoding.ASCII.GetBytes(dir + "\n");
            stream.Seek(2, SeekOrigin.End);
            stream.Write(buffer, 0, buffer.Length);
            stream.Flush(true);
            stream.Close();
        }
        static void Print_Content(string dir) //Метод для выведения содержимого 
        {
            DirectoryInfo di = new DirectoryInfo(dir);
            Console.WriteLine("\nСодержимое каталога '{0}':\n", di.Name);
            FileInfo[] Files = di.GetFiles();
            foreach (FileInfo f in Files)
                Console.WriteLine(">>{0}", f);
        }
        static void Path_Structure(string dir) //Метод для построчного выведения пути 
        {
            DirectoryInfo di = new DirectoryInfo(dir);
            Console.WriteLine("\nПострочный вывод пути каталога '{0}':", di.Name);
            string[] mas = dir.Split('\\');
            for (int i = 0; i < mas.Length; i++)
                Console.WriteLine(">>>{0}", mas[i]);
        }
        ////static DirectoryInfo Recurse(string path, string exit)
        //{
        //    List<string> rec = new List<string>();
        //    string[] file = Directory.GetFiles(path);
        //    foreach (string f in file)
        //    {
        //        if (File.GetExtension(f) == exit)
        //            rec.Add(f);
        //    }
        //    string[] dir = Directory.Getdir(path);
        //    foreach (string d in dir)
        //    {
        //        rec.AddRange(GetFilesWithExit(dir, exit));
        //    }
        //    return (string[])(rec.ToArray(typeof(string)));


        //}
        static void Help() //метод для вывода справки 
        {

            Console.WriteLine("\nКоманда Help(Справка).\nДля работы с программой воспользуйтесь списком команд:\n\n\t/Help - вызов справки.\n\t/Info - информация о файле.\n\t/Write_To - дублирует ввод с консоли в файл.\n\t/Copy_To - копирует содержимое каталога в другой каталог.\n\t/Print_Content - выводит содержимое файла.\n\t/Path_Structure - построчно выводит путь к файлу.\n\t/Cansel - выводит на экран все вводимые в программу параметры.");
        }
        static void Main(string[] args)
        {
            //флаги
            bool help = false;
            bool cancel = false;
            string recurse = string.Empty;
            //переменные для хранения строк
            string info = string.Empty, write_to = string.Empty, print_content = string.Empty, path_structure = string.Empty, str = string.Empty, copy_to = string.Empty;

            for (int i = 0; i < args.Length; i++)
            {

                switch (args[i])
                {
                    case "/help": help = true; break;
                    case "/info": while ((i <= args.Length - 2) && !args[i + 1].StartsWith("/")) info = info + args[++i] + " "; break;
                    case "/write_to": while ((i <= args.Length - 2) && !args[i + 1].StartsWith("/")) write_to = write_to + args[++i]; break;
                    case "/print_content": while ((i <= args.Length - 2) && !args[i + 1].StartsWith("/")) print_content = print_content + args[++i]; break;
                    case "/path_structure": while ((i <= args.Length - 2) && !args[i + 1].StartsWith("/")) path_structure = path_structure + args[++i]; break;
                    case "/copy_to": while ((i <= args.Length - 2) && !args[i + 1].StartsWith("/")) copy_to = copy_to + args[++i]; break;
                    // case "/recurse": while ((i <= args.Length - 2) && !args[i + 1].StartsWith("/")) recurse = recurse + args[++i]; break;
                    case "/cancel": cancel = true; break;
                    default: Console.WriteLine("\n\aДанная команда отсутсвует. Попробуйте воспользоваться командой '/Help' для \nвызова справки."); break;
                }


            }
            if (help)
            {
                Help(); return;
            }
            else
            {
                if (!string.IsNullOrEmpty(info) && Test(info) == 1) Info(info);
                if (!string.IsNullOrEmpty(write_to) && Test(write_to) == 1) Write_To(write_to);
                if (!string.IsNullOrEmpty(print_content) && Test(print_content) == 1) Print_Content(print_content);
                if (!string.IsNullOrEmpty(path_structure) && Test(path_structure) == 1) Path_Structure(path_structure);
                if (!string.IsNullOrEmpty(copy_to) && Test(copy_to) == 1) Copy_To(copy_to);
                //if (!string.IsNullOrEmpty(recurse) && Test(recurse) == 1) { DirectoryInfo rec = new DirectoryInfo(recurse); Recurse(rec); }
                if (cancel)
                {
                    Console.Write("Вводимые параметры: ");
                    for (int i = 0; args[i] != "/cancel"; i++)
                    {
                        Console.Write(" " + args[i]);
                    }
                    return;
                }

            }

            Console.ReadKey();
        }




    }
}

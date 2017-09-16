using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Prog.exe
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
        static void Recurse(string di)
        {

            DirectoryInfo dir = new DirectoryInfo(di);
            //FileSystemInfo[] mas = dir.GetFileSystemInfos();
            //for (int i = 0; i < dir.GetFileSystemInfos().Length; i++)
            // Console.WriteLine(">>>{0}", mas[i]);


            FileInfo[] mas = dir.GetFiles();
            for (int i = 0; i < dir.GetFiles().Length; i++)
                Console.WriteLine(">>>{0}", mas[i]);

            //DirectoryInfo di = new DirectoryInfo(dir);
            //DirectoryInfo[] Dirs = di.GetDirectories( SearchOption.AllDirectories);
            //foreach (DirectoryInfo f in Dirs)
            //    Console.WriteLine(">>>{0}", f.Name);
            // string[] di = Directory.GetDirectories(dir, SearchOption)

        }
        static void Processing(string z) //Метод для работы с вводимыми данными 
        {

            int i;
            string str = string.Empty;
            string[] Parametrs = z.Split(' ');

            for (i = 0; i < Parametrs.Length; i++)
            {
                if (Parametrs[i].StartsWith("/"))
                {
                    switch (Parametrs[i].ToLower())
                    {
                        case "/help": Help(); i = Parametrs.Length - 1; break;
                        case "/info":
                            if (i + 1 < Parametrs.Length)
                                for (int j = i + 1; j < Parametrs.Length; j++)
                                {
                                    if (Parametrs[j].Contains("/") == false) { if (Test(Parametrs[j]) == 1) Info((Parametrs[j])); }
                                    else
                                        if (Parametrs[j].Contains("/") == true) j = Parametrs.Length;
                                } break;
                        case "/write_to":
                            if ((i + 1 < Parametrs.Length))
                                for (int j = i + 1; j < Parametrs.Length; j++)
                                {
                                    if (Parametrs[j].Contains("/") == false) Write_To((Parametrs[j]));
                                    else
                                        if (Parametrs[j].Contains("/") == true) j = Parametrs.Length;
                                } Console.Write("\nТекст скопирован в файл " + @"d:\CopyText.txt.\n"); break;
                        case "/print_content":
                            if ((i + 1 < Parametrs.Length))
                                for (int j = i + 1; j < Parametrs.Length; j++)
                                {
                                    if ((Parametrs[j].Contains("/") == false) && (Test(Parametrs[j]) == 1)) Print_Content((Parametrs[j]));
                                    else
                                        if (Parametrs[j].Contains("/") == true) j = Parametrs.Length;
                                } break;
                        case "/path_structure":
                            if ((i + 1 < Parametrs.Length))
                                for (int j = i + 1; j < Parametrs.Length; j++)
                                {
                                    if ((Parametrs[j].Contains("/") == false) && (Test(Parametrs[j]) == 1)) Path_Structure((Parametrs[j]));
                                    else
                                        if (Parametrs[j].Contains("/") == true) j = Parametrs.Length;
                                } break;
                        case "/copy_to":
                            if ((i + 1 < Parametrs.Length))
                                for (int j = i + 1; j < Parametrs.Length; j++)
                                {
                                    if ((Parametrs[j].Contains("/") == false) && (Test(Parametrs[j]) == 1)) Copy_To((Parametrs[j]));
                                    else
                                        if (Parametrs[j].Contains("/") == true) j = Parametrs.Length;
                                } break;
                        case "/recurse": Recurse(Parametrs[i + 1]); break;
                        case "/cancel": Console.WriteLine("\nВводимые параметры: {0}\n", str); i = Parametrs.Length - 1; break;
                        default: Console.WriteLine("\n\aДанная команда отсутсвует. Попробуйте воспользоваться командой '/Help' для \nвызова справки."); break;
                    }
                }
                str = str + Parametrs[i] + " ";
            }
        }
        static void Help() //метод для вывода справки 
        {

            Console.WriteLine("\nКоманда Help(Справка).\nДля работы с программой воспользуйтесь списком команд:\n\n\t/Help - вызов справки.\n\t/Info - информация о файле.\n\t/Write_To - дублирует ввод с консоли в файл.\n\t/Copy_To - копирует содержимое каталога в другой каталог.\n\t/Print_Content - выводит содержимое файла.\n\t/Path_Structure - построчно выводит путь к файлу.\n\t/Cansel - выводит на экран все вводимые в программу параметры.");
        }
        static void Main(string[] args)
        {
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
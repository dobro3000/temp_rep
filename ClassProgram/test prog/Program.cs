using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FilesDirs;
using System.Reflection;


namespace test_prog
{
    class TestProg
    {
        /// <summary>
        /// Выводит справку.
        /// </summary>
        private static void Help()
        {
            Console.WriteLine("\t\t\t\nДобро пожаловать в программу!\t\t\t\n");
            Console.Write("Вы вызвали команду Help.\n\nСписок команд:\n/set= - путь(и) обьектa(ов).\n/Delete - удаляет обьект. \n/Create - создает обьект. \n/MoveTo= - перемещает обьект по заданному пути. \n/ChangingTheCoding - менят кодировку обьекта. \n/ChangingTheCoding= - менят кодировку обьекта на заданную. \n/Encod - шифрует обьект. \n/Uncod - дешефрует обьект. \n/Arhiving= - архивирует обьект. \n/Desarhiving= - разархивирует обьект. \n/CopyTo= - копирует обьект по заданному пути. \n/View - выводит содержимое обьекта. \n/CompareTo - сортирует обьект. \n/Rename - переименовывает обьект на рандомное имя. \n/Editing - редактирует обьект путем замены символа 'a' на знак '?'");
            Console.WriteLine("\t\t\t\nПриятного пользования.\t\t\t\n");
            return;
        }
        /// <summary>
        /// Иницилизирует интерфейс IManager.
        /// </summary>
        private static IPersonalManager _meneger;

        static void Main(string[] args)
        {

            #region проверка наличия команд set и их подсчет

            int _setCount = 0;
            foreach (string _arg in args)
            {
                if (_arg.ToLower().StartsWith("/set="))
                    _setCount++;
            }
            #endregion

            #region выбор и создание экземпляра класса

            switch (_setCount)
            {
                case 0: Help(); break;
                case 1:
                    string _fileName = string.Empty;
                    for (int i = 0; i < args.Length; i++)
                    {
                        if (args[i].StartsWith("/set="))
                            _fileName = args[i].Remove(0, 5);
                    }
                    if (System.IO.File.Exists(_fileName))
                    {
                        _meneger = new File(_fileName);
                    }
                    else
                    {
                        _meneger = new Directory(_fileName);
                    }
                    break;
                default:
                    List<string> masDir = new List<string>();//хранит именя каталогов
                    List<string> masF = new List<string>();//хранит имена файлов
                    for (int i = 0; i < args.Length; i++)
                    {
                        if (System.IO.File.Exists(args[i].Remove(0, 5)))
                        {
                            masF.Add(args[i].Remove(0, 5));
                        }
                        else if (System.IO.Directory.Exists(args[i].Remove(0, 5)))
                        {
                            masDir.Add(args[i].Remove(0, 5));
                        }
                    }
                    if (masF != null)
                    {
                        _meneger = new Files(masF);
                    }
                    else
                    {
                        _meneger = new Directories(masDir);
                    }
                    break;

            }
            #endregion

            #region определение и вызов методов

            string metodName = string.Empty;

            foreach (string _arg in args)
            {
                switch (_arg.ToLower())
                {
                    case "/help": Help(); return;
                    case "/delete":
                    case "/create":
                    case "/encod":
                    case "/uncod":
                    case "/view":
                    case "/compareto":
                    case "/rename":
                    case "/editing":
                    case "/info":
                    case "/changingthecoding":
                        metodName = _arg.Replace("/", "");
                        _meneger.Messang += _meneger_Messang;
                        try
                        {
                            MethodInfo metod = _meneger.GetType().GetMethod(metodName);
                            metod.Invoke(_meneger, null);
                        }
                        catch { }
                        break;

                    default:
                        #region Поиск методов с входными параметром

                        if (_arg.ToLower().ToLower().StartsWith("/set="))
                        {
                            
                        }
                        else if (_arg.ToLower().StartsWith("/meveto="))
                        {
                            _meneger.Messang += _meneger_Messang;
                            metodName = _arg.Replace("/meveto=", "");
                            _meneger.moveto(metodName);
                        }
                        else if (_arg.ToLower().StartsWith("/copyto="))
                        {
                            _meneger.Messang += _meneger_Messang;
                            metodName = _arg.Replace("/copyto=", "");
                            _meneger.copyto(metodName);
                        }
                        else if (_arg.ToLower().ToLower().StartsWith("/changingthecoding="))
                        {
                            _meneger.Messang += _meneger_Messang;
                            metodName = _arg.Replace("/changingthecoding=", "");
                            _meneger.changingthecoding(metodName);
                        }
                        else if (_arg.ToLower().StartsWith("/arhiving="))
                        {
                            _meneger.Messang += _meneger_Messang;
                            metodName = _arg.Replace("/arhiving=", "");
                            _meneger.arhiving(metodName);
                        }
                        else if (_arg.ToLower().StartsWith("/desarhiving="))
                        {
                            _meneger.Messang += _meneger_Messang;
                            metodName = _arg.Replace("/desarhiving=", "");
                            _meneger.desarhiving(metodName);
                        }
                        else
                        {
                            Console.Write("Команда {0} отсутствует. Возможно вы забили поставить '='  или '/'", _arg);
                        }
                        break;
                        #endregion
                }
            }

            #endregion

            Console.ReadKey();
        }

        /// <summary>
        /// Выводит подписку на событие.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        static void _meneger_Messang(object sender, MyEvenArgs e)
        {
            Console.WriteLine(e.Message);
        }

    }
}


using System;
using System.Collections.Generic;
using System.IO;
using ClassDir = System.IO.Directory;
using Ionic.Zip;

namespace FilesDirs
{
    /// <summary>
    /// Содержит методы для работы с каталогом.
    /// </summary>
    public class Directory : AbctractClass
    {
        /// <summary>
        /// Имя каталога.
        /// </summary>
        private string dirName;

        /// <summary>
        /// Хранит имена каталогов.
        /// </summary>
        List<string> dirList = new List<string>();

        /// <summary>
        /// Конструктор для класса Directories.
        /// </summary>
        /// <param name="a">Массив каталогов.</param>
        internal Directory(List<string> a)
        {
            for (int i = 0; i < a.Count; i++)
            {
                dirList.Add(a[i]);
                string[] str = System.IO.Directory.GetFiles(a[i]);
                for (int j = 0; j < str.Length; j++)
                    fileList.Add(str[j]);
            }

        }

        /// <summary>
        /// Иницилизирует экземпляр класса MyDirectory.
        /// </summary>
        /// <param name="dname">Полное имя каталога.</param>
        public Directory(string dname)
        {
            dirName = dname;
            try
            {
                string[] str = System.IO.Directory.GetFiles(dname);
                for (int i = 0; i < str.Length; i++)
                    fileList.Add(str[i]);
            }
            catch { }
        }

        /// <summary>
        /// Событие класса Directory.
        /// </summary>
        public override event EventHandler<MyEvenArgs> Messang;

        /// <summary>
        /// Удаляет текущий каталог.
        /// </summary>
        public override void delete()
        {
            for (int i = 0; i < dirList.Count; i++)
            {
                try
                {
                    ClassDir.Delete(dirList[i], true);
                    if (Messang != null)
                        Messang(this, new MyEvenArgs(string.Format("Каталог '{0}' удален.", dirList[i])));
                }
                catch { }
            
            }
            dirList.Clear();
        }

        /// <summary>
        /// Создает новый каталог.
        /// </summary>
        public override void create()
        {
            for (int i = 0; i < dirList.Count; i++)
            {
                try
                {
                    ClassDir.CreateDirectory(dirList[i]);
                    if (Messang != null)
                        Messang(this, new MyEvenArgs(string.Format("Каталог '{0}' создан.", dirList[i])));
                }
                catch { }
            }
        }

        /// <summary>
        /// Перемещает текущий каталог по заданному пути.
        /// </summary>
        /// <param name="newName">Путь, куда переместить.</param>
        public override void moveto(string newName)
        {
            for (int i = 0; i < dirList.Count; i++)
            {
                peremech_updates(dirList[i], newName);
            }
        }
        /// <summary>
        /// Вспомогательный метод для копирования каталога.
        /// </summary>
        /// <param name="begin_dir">Директория источник</param>
        /// <param name="end_dir">Директория приёмник.</param>
        internal void perebor_updates(string begin_dir, string end_dir)
        {
            System.IO.DirectoryInfo dir_inf = new System.IO.DirectoryInfo(begin_dir);
            try
            {
                foreach (System.IO.DirectoryInfo dir in dir_inf.GetDirectories())
                {
                    if (System.IO.Directory.Exists(end_dir + "\\" + dir.Name) != true)
                    {
                        System.IO.Directory.CreateDirectory(end_dir + "\\" + dir.Name);
                    }
                    perebor_updates(dir.FullName, end_dir + "\\" + dir.Name);
                }
            }
            catch { }

            try
            {
                foreach (string file in System.IO.Directory.GetFiles(begin_dir))
                {
                    string filik = file.Substring(file.LastIndexOf('\\'), file.Length - file.LastIndexOf('\\'));
                    System.IO.File.Copy(file, end_dir + "\\" + filik, true);
                }
            }
            catch { }
            if (Messang != null)
                Messang(this, new MyEvenArgs(string.Format("Каталог '{0}' был перемещен.", dirName)));
            System.IO.Directory.Delete(dirName);
        }

        /// <summary>
        /// Архивирует текущий каталог и сохраняет его по заданному пути.
        /// </summary>
        /// <param name="newName">Путь, куда сохранить.</param>
        public override void arhiving(string newName)
        {
            for (int i = 0; i < dirList.Count; i++)
            {
                ZipFile zf = new ZipFile(newName);
                zf.AddDirectory(dirList[i]);
                zf.Save();
                if (Messang != null)
                    Messang(this, new MyEvenArgs(string.Format("Каталог '{0}' был перемещен.", dirList[i])));
            }
        }

        /// <summary>
        /// Дезорхивирует текущий каталог и сохраняет его по заданному пути.
        /// </summary>
        /// <param name="newName">Путь, куда сохранить.</param>
        public override void desarhiving(string newName)
        {
            for (int i = 0; i < dirList.Count; i++)
            {
                ZipFile Arch = new ZipFile(dirList[i]);
                Arch.ExtractAll(newName);
                if (Messang != null)
                    Messang(this, new MyEvenArgs(string.Format("Каталог '{0}' был перемещен.", dirName)));
            }
        }

        /// <summary>
        /// Копирует текущий каталог по указанному пути.
        /// </summary>
        /// <param name="newName">Путь, куда скопировать.</param>
        public override void copyto(string newName)
        {
            for (int i = 0; i < dirList.Count; i++)
            {
                perebor_updates(dirList[i], newName);
            }
        }
        /// <summary>
        /// Вспомогательный метод для перемещения каталога.
        /// </summary>
        /// <param name="begin_dir">Директория источник</param>
        /// <param name="end_dir">Директория приёмник.</param>
        internal void peremech_updates(string begin_dir, string end_dir)
        {
            System.IO.DirectoryInfo dir_inf = new System.IO.DirectoryInfo(begin_dir);
            try
            {
                foreach (System.IO.DirectoryInfo dir in dir_inf.GetDirectories())
                {
                    if (System.IO.Directory.Exists(end_dir + "\\" + dir.Name) != true)
                    {
                        System.IO.Directory.CreateDirectory(end_dir + "\\" + dir.Name);
                    }
                    peremech_updates(dir.FullName, end_dir + "\\" + dir.Name);
                }
            }
            catch { }

            try
            {
                foreach (string file in System.IO.Directory.GetFiles(begin_dir))
                {
                    string filik = file.Substring(file.LastIndexOf('\\'), file.Length - file.LastIndexOf('\\'));
                    System.IO.File.Move(file, end_dir + "\\" + filik);
                }
            }
            catch { }

            if (Messang != null)
                Messang(this, new MyEvenArgs(string.Format("Каталог '{0}' был перемещен.", dirName)));
            try
            {
                System.IO.Directory.Delete(dirName);
            }
            catch
            {
                if (Messang != null)
                    Messang(this, new MyEvenArgs(string.Format("Каталог '{0}' не удалось переместить.", dirName)));
            }
        }

        /// <summary>
        /// Переименовывет текущий каталог.
        /// </summary>
        /// <param name="str">Новое имя каталога.</param>
        internal override void chengName(string str)
        {
            for (int i = 0; i < dirList.Count; i++)
            {
                peremech_updates(dirList[i], str.Substring('.', str.Length));
            }
        }

        #region Свойства

        /// <summary>
        /// Возвращает имя каталога.
        /// </summary>
        public override string getname
        {
            get { return (dirName); }
        }

        /// <summary>
        /// Возвращает размер каталога.
        /// </summary>
        public override long getsize
        {
            get
            {
                string[] z = System.IO.Directory.GetFiles(dirName);
                long s = 0;
                for (int i = 0; i < z.Length; i++)
                {
                    File exFile = new File(z[i]);
                    s = s + exFile.getsize;
                }
                return s;
            }
        }

        /// <summary>
        /// Возвращает существование каталога типа bool.
        /// </summary>
        public override bool getcreate
        {
            get
            {
                return (ClassDir.Exists(dirName));
            }


        }

        #endregion

        /// <summary>
        /// Получает информацию о текущем каталоге.
        /// </summary>
        /// <returns>Возвращает информацию о текущем каталоге.</returns>
        public override List<string> info()
        {
            System.IO.DirectoryInfo d = new System.IO.DirectoryInfo(dirName);
            List<string> info = new List<string>();
            info.Add(string.Format("Имя текущего каталога: " + d.Name.ToString()));
            info.Add(string.Format("Путь к текущему каталогу: " + d.FullName.ToString()));
            info.Add(string.Format("Атрибут текущего каталога: " + d.Attributes.ToString()));
            info.Add(string.Format("Последний доступ к текущему каталогу: " + d.LastAccessTime.ToString()));
            info.Add(string.Format("Каталог, в котором храниться текущий каталог: " + d.Parent.ToString()));
            info.Add(string.Format("Диск, на котором храниться текущий каталог: " + d.Root.ToString()));
            return info;
        }

        /// <summary>
        /// Возвращает содержимое текущего каталога.
        /// </summary>
        public override List<string> view()
        {
            List<string> newList = new List<string>();
            newList.Add(Convert.ToString(ClassDir.GetFiles(dirName)));
            newList.Add(Convert.ToString(ClassDir.GetDirectories(dirName)));
            return newList;
        }

        /// <summary>
        /// Сортирует текущий каталог.
        /// </summary>
        public override List<string> compareto()
        {
            List<string> f = new List<string>();
            string[] arrDir = System.IO.Directory.GetDirectories(dirName);
            string[] arrF = System.IO.Directory.GetFiles(dirName);
            Array.Sort(arrDir);
            Array.Sort(arrF);
            f.Add(arrDir.ToString());
            f.Add(arrF.ToString());
            return f;

        }
    }
}
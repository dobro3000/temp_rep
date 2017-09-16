using Ionic.Zip;
using System;
using System.Text;
using FileClass = System.IO.File;
using System.Collections.Generic;

namespace FilesDirs
{

    /// <summary>
    /// Содержит методы для работы с файлом.
    /// </summary>
    public class File : AbctractClass
    {

        /// <summary>
        /// Имя файла.
        /// </summary>
        private string fileName;

        /// <summary>
        /// Конструктор для класса Files.
        /// </summary>
        /// <param name="a">Массив файлов.</param>
        internal File(List<string> a)
        {
            for (int i = 0; i < a.Count; i++)
                fileList.Add(a[i]);
        }

        /// <summary>
        /// Иницилизирует экземпляр класса MyFile.
        /// </summary>
        /// <param name="fname">Полный путь к файлу.</param>
        public File(string fname)
        {

            fileList.Add(fname);
            fileName = fname;

        }

        /// <summary>
        /// Событие класса MyFile.
        /// </summary>
        public override event EventHandler<MyEvenArgs> Messang;

        /// <summary>
        /// Удаляет текущий файл.
        /// </summary>
        public override void delete()
        {
            for (int i = 0; i < fileList.Count; i++)
            {
                try
                {
                    System.IO.File.Delete(fileList[i]);
                    if (Messang != null)
                        Messang(this, new MyEvenArgs(string.Format("Файл '{0}' удален.", fileList[i])));
                }
                catch { }
                
            }
            fileList.Clear();
        }

        /// <summary>
        /// Создает текущий файл.
        /// </summary>
        public override void create()
        {
            for (int i = 0; i < fileList.Count; i++)
            {
                try
                {
                    System.IO.File.Create(fileList[i]);
                    if (Messang != null)
                        Messang(this, new MyEvenArgs(string.Format("Файл '{0}' создан.", fileList[i])));
                }
                catch { }
                
            }
        }

        /// <summary>
        /// Перемещает текущий файл по заданному пути.
        /// </summary>
        /// <param name="newName">Путь, куда переместить файл.</param>
        public override void moveto(string newName)
        {
            for (int i = 0; i < fileList.Count; i++)
            {
                try
                {
                    FileClass.Move(fileList[i], newName);
                    if (Messang != null)
                        Messang(this, new MyEvenArgs(string.Format("Файл '{0}' был перемещен.", fileList[i])));
                }
                catch { }
                
            }

        }

        /// <summary>
        /// Архивирует текущий файл и сохраняет его по заданному пути.
        /// </summary>
        /// <param name="newName">Путь, куда сохранить.</param>
        public override void arhiving(string newName)
        {
            for (int i = 0; i < fileList.Count; i++)
            {
                //Создание архива
                ZipFile zf = new ZipFile(newName);
                zf.AddFile(fileList[i]);
                zf.Save(); //Сохраняем архив.
                if (Messang != null)
                    Messang(this, new MyEvenArgs(string.Format("Файл '{0}' был перемещен.", fileList[i])));
            }

        }

        /// <summary>
        /// Дезархивирует текущий файла и сохраняет его по заданному пути.
        /// </summary>
        /// <param name="newName">Путь, куда сохранить.</param>
        public override void desarhiving(string newName)
        {
            for (int i = 0; i < fileList.Count; i++)
            {
                ZipFile Arch = new ZipFile(fileList[i]);
                Arch.ExtractAll(newName);
                if (Messang != null)
                    Messang(this, new MyEvenArgs(string.Format("Файл '{0}' был перемещен.", fileList[i])));
            }

        }

        /// <summary>
        /// Копирует текущий файл по заданному пути.
        /// </summary>
        /// <param name="newName">Путь, куда скопировать.</param>
        public override void copyto(string newName)
        {
            for (int i = 0; i < fileList.Count; i++)
            {
                try
                {
                    FileClass.Copy(fileList[i], newName);
                    if (Messang != null)
                        Messang(this, new MyEvenArgs(string.Format("Файл '{0}' был перемещен.", fileList[i])));
                }
                catch {
                    if (Messang != null)
                        Messang(this, new MyEvenArgs(string.Format("Файл '{0}' был перемещен.", fileList[i])));
                }
                
            }

        }

        /// <summary>
        /// Переименовывает текущее имя файла.
        /// </summary>
        /// <param name="str">Новое имя.</param>
        internal override void chengName(string str)
        {
            for (int i = 0; i < fileList.Count; i++)
            {
                try
                {
                    FileClass.Move(fileList[i], str + ".txt");
                    if (Messang != null)
                        Messang(this, new MyEvenArgs(string.Format("Структура файла '{0}' изменена.", fileList[i])));
                }
                catch { }
                
            }

        }

        #region Свойства

        /// <summary>
        /// Возвращает имя файла.
        /// </summary>
        public override string getname
        {
            get
            {
                return (fileName);
            }
        }

        /// <summary>
        /// Возвращает размер файла.
        /// </summary>
        public override long getsize
        {
            get { return stream.Length; }
        }

        /// <summary>
        /// Возвращает информацию о существовании файла типа bool. 
        /// </summary>
        public override bool getcreate
        {
            get
            {
                return (FileClass.Exists(fileName));
            }
        }

        #endregion

        /// <summary>
        /// Получает информацию о текущем файле.
        /// </summary>
        /// <returns>Возвращает информацию о текущем файле.</returns>
        public override List<string> info()
        {

            System.IO.FileInfo f = new System.IO.FileInfo(fileName);
            List<string> info = new List<string>();
            info.Add(string.Format("Имя текущего файла: " + f.Name.ToString()));
            info.Add(string.Format("Путь к текущему файлу: " + f.FullName.ToString()));
            info.Add(string.Format("Атрибут текущего файла: " + f.Attributes.ToString()));
            info.Add(string.Format("Последний доступ к текущему файлу: " + f.LastAccessTime.ToString()));
            info.Add(string.Format("Расширение текущего файла: " + f.Extension.ToString()));
            return info;
        }

        /// <summary>
        /// Получает содержиме текущего файла.
        /// </summary>
        public override List<string> view()
        {
            List<string> strList = new List<string>();
            try
            {
                string[] str = System.IO.File.ReadAllLines(fileName);
                strList.Add(str.ToString());
            }
            catch { }
            return strList;
        }

        /// <summary>
        /// Сортирует текущий файл по умолчанию.
        /// </summary>
        public override List<string> compareto()
        {
            List<string> sortList = new List<string>();
            try
            {
                string[] str = System.IO.File.ReadAllLines(fileName);
                sortList.Add(str.ToString());
                sortList.Sort();
            }
            catch { }
            return sortList;

        }



    }
}

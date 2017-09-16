using System.Collections.Generic;
using System.Collections;
using System.Threading.Tasks;
using System;

namespace FilesDirs
{
    /// <summary>
    /// Содержит методы для работы с каталогами.
    /// </summary>
  public  class Directories : Directory
    {
        /// <summary>
        /// Содержит имена каталога.
        /// </summary>
        private List<string> myListDir = new List<string>();

        /// <summary>
        /// Иницилизирует экземпляр класса Directories.
        /// </summary>
        /// <param name="a"></param>
        public Directories(List<string> a) : base(a)
        {
            myListDir = a;
        }

        #region Свойства

        /// <summary>
        /// Возвращает имя каталога.
        /// </summary>
        public override string getname
        {
            get { return myListDir.GetEnumerator().ToString(); }
        }

        /// <summary>
        /// Возвращает размер каталогов.
        /// </summary>
        public override long getsize
        {
            get 
            {
                long s = 0;
                for (int i = 0; i < myListDir.Count; i++)
                {
                    string[] fGet = System.IO.Directory.GetFiles(myListDir[i]);
                    for (int j = 0; j < fGet.Length; j++)
                    {
                        System.IO.FileInfo f = new System.IO.FileInfo(fGet[i]);
                    s+=f.Length;
                    }
                
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
                return true;
            }
        }

       
        #endregion

        /// <summary>
        /// Выводит содерживмое текущего массива каталогов.
        /// </summary>
        /// <returns>Возвращает содержимое текущего массива каталогов.</returns>
        public override List<string> view() 
        {
            return myListDir;
        }

        /// <summary>
        /// Сортирует текущий массив обьектов.
        /// </summary>
        public override List<string> compareto()
        {
            myListDir.Sort();
            return myListDir;
        }

        /// <summary>
      /// Выводит информацию о текущем массиве каталогов.
      /// </summary>
      /// <returns>Возвращает информацию о текущем массиве каталогов.</returns>
        public override List<string> info()
        {
            List<string> str = new List<string>();
            str.Add(string.Format("Каталогов: {0}", myListDir.Count));
            str.Add(string.Format("Размер массива: {0}", getsize));
            return str;
        }
    }
}

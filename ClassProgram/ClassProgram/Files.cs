using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Ionic.Zip;
using System.Collections;

namespace FilesDirs
{
   /// <summary>
   /// Содержит методы для работы с файломи.
   /// </summary>
  public  class Files : File
    {

      /// <summary>
      /// Содержит массив файлов.
      /// </summary>
       private List<string> myList = new List<string>();

        /// <summary>
        /// Иницилизирует экземпляр класса Files.
        /// </summary>
        /// <param name="a"></param>
        public Files(List<string> a) : base(a)
        {
            myList = a;
        }

        #region Свойства

        /// <summary>
        /// Возвращает имена файлов.
        /// </summary>
        public override string getname
        {

            get
            {

                return (myList.GetEnumerator().ToString());
            }
        }

        /// <summary>
        /// Возвращает размер файлов.
        /// </summary>
        public override long getsize
        {
            get
            {
                long s = 0;
                for (int i = 0; i < myList.Count; i++)
                {
                    FileInfo f = new FileInfo(myList[i]);
                    s += f.Length;
                }
                return s;
            }
        }

        /// <summary>
        /// Возвращает значение существует ли массив или нет.
        /// </summary>
        public override bool getcreate
        {
            get
            {
                if (!myList.Exists(null)) return true;
                else
                {
                    return false;
                }
            }
        }

        #endregion

        /// <summary>
        /// Просматривает текущий массив файлов.
        /// </summary>
        public override List<string> view()
        {
            return myList;
        }

        /// <summary>
        /// Сортирует текущий массив файлов.
        /// </summary>
        public override List<string> compareto()
        {
            myList.Sort();
            return myList;
        }

        /// <summary>
      /// Выводит информацию о текущем массиве файлов.
      /// </summary>
      /// <returns>Возвращает информацию о текущем массиве файлов.</returns>
        public override List<string> info()
        {
            List<string> str = new List<string>();
            str.Add(string.Format("Файлов: {0}", myList.Count));
            str.Add(string.Format("Раазмер массива: ", getsize));
            return str;
        }
    }
}

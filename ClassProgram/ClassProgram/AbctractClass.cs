using System;
using System.Collections.Generic;
using System.Text;

namespace FilesDirs
{
    /// <summary>
    /// Содержит общие методы для работы с файлом и каталогом.
    /// </summary>
    public abstract class AbctractClass :  IPersonalManager
    {
        /// <summary>
        /// Массив файлов.
        /// </summary>
        public List<string> fileList = new List<string>();

        /// <summary>
        /// Переменная, хранящая поток файла.
        /// </summary>
        public System.IO.FileStream stream { get; set; }

        /// <summary>
        /// Событие класса AbctractClass.
        /// </summary>
        public virtual event EventHandler<MyEvenArgs> Messang;

        #region Методы, реализующиеся в классах наследниках

        /// <summary>
        /// Удаляет текущий обект.
        /// </summary>
        public abstract void delete();

        /// <summary>
        /// Создает текущий обьект.
        /// </summary>
        public abstract void create();

        /// <summary>
        /// Перемещает текущий обект.
        /// </summary>
        /// <param name="newName"></param>
        public abstract void moveto(string newName);

        /// <summary>
        /// Архивирует текущий обьект по заданному пути.
        /// </summary>
        /// <param name="newName">Путь, куда переместить.</param>
        public abstract void arhiving(string newName);

        /// <summary>
        /// Разархивирует текущий обьект и сохраняет егшо по заданному пути.
        /// </summary>
        /// <param name="newName">Путь, куда сохранить.</param>
        public abstract void desarhiving(string newName);

        /// <summary>
        /// Копирует текущий обьект по заданному пути.
        /// </summary>
        /// <param name="newName">Путь, куда скопировать.</param>
        public abstract void copyto(string newName);

        /// <summary>
        /// Переименовывает текущий обьект.
        /// </summary>
        public void rename()
        {
            for (int i = 0; i < fileList.Count; i++)
            {
                string str = string.Empty;
                System.IO.FileInfo fname = new System.IO.FileInfo(fileList[i]);
                str = fileList[i].Replace(fname.Name, System.IO.Path.GetRandomFileName());
                chengName(str);
            }
        }
        /// <summary>
        /// Вспомогательные метод для переименования обьекта.
        /// </summary>
        /// <param name="str">Новое имя.</param>
        internal abstract void chengName(string str);

        /// <summary>
        /// Выводит информацию об объекте.
        /// </summary>
        /// <returns>Возвращает информацию об объекте</returns>
        public abstract List<string> info();

        /// <summary>
        /// Выводит содержимое обьекта.
        /// </summary>
        /// <returns>Возвращает содержимое обьекта.</returns>
        public abstract List<string> view();

        /// <summary>
        /// Сортирует текущий обьект.
        /// </summary>
        public abstract List<string> compareto();

        #endregion

        #region Свойства


        /// <summary>
        /// Возвращает имя обьекта.
        /// </summary>
        public abstract string getname { get; }

        /// <summary>
        /// Возвращает размер обьекта.
        /// </summary>
        public abstract long getsize { get; }

        /// <summary>
        /// Возвращает значение типа bool осуществовании обьекта.
        /// </summary>
        public abstract bool getcreate { get; }

        #endregion

        #region Общие методы для классов наследников

        /// <summary>
        /// Редактирование обьекта.
        /// </summary>
        public void editing()
        {
            for (int i = 0; i < fileList.Count; i++)
            {
                System.IO.FileStream stream = fileStream(fileList[i]);
                char a = 'a';
                char b = '!';
                {
                    byte[] buffer = new byte[4096];

                    while (stream.Position < stream.Length)
                    {
                        int count = stream.Read(buffer, 0, buffer.Length);

                        for (int j = 0; j < count; j++)
                        {
                            if (buffer[j] == (byte)a)
                            {
                                buffer[j] = (byte)b;
                            }
                        }
                        stream.Write(buffer, 0, buffer.Length);
                        stream.Flush();
                    }
                }
                if (Messang != null)
                    Messang(this, new MyEvenArgs(string.Format("Объект '{0}' был изменен", fileList[i])));
                stream.Close();
            }
        }

        /// <summary>
        /// Кодирует обьект по умолчанию в кодировке ASCII.
        /// </summary>
        public void changingthecoding()
        {
            for (int i = 0; i < fileList.Count; i++)
            {
                System.IO.FileStream stream = fileStream(fileList[i]);

                byte[] buffer = new byte[4096];
                byte[] newBuffer = new byte[4096];

                while (stream.Position < stream.Length)
                {
                    int count = stream.Read(buffer, 0, buffer.Length);

                    for (int j = 0; j < count - 1; j++)
                    {
                        newBuffer = Encoding.ASCII.GetBytes(buffer[j] + " ");

                    }
                    stream.Write(newBuffer, 0, newBuffer.Length);
                    stream.Flush();
                }

                if (Messang != null)
                    Messang(this, new MyEvenArgs(string.Format("Объект '{0}' был изменен", fileList[i])));
                stream.Close();
            }
        }

        /// <summary>
        /// Кодирует обьект в заданой кодировке.
        /// </summary>
        /// <param name="a">Название кодировки.</param>
        public void changingthecoding(string a)
        {
            Encoding e;
            for (int i = 0; i < fileList.Count; i++)
            {
                System.IO.FileStream stream = fileStream(fileList[i]);

                switch (a.ToLower())
                {
                    case "unicode": e = Encoding.Unicode; break;
                    case "ascii": e = Encoding.ASCII; break;
                    case "default": e = Encoding.Default; break;
                    case "utf32": e = Encoding.UTF32; break;
                    case "utf7": e = Encoding.UTF7; break;
                    case "utf8": e = Encoding.UTF8; break;
                    default: throw new Exception(string.Format("Данная кодировка отсутствует."));
                }


                byte[] buffer = new byte[4096];
                byte[] newBuffer = new byte[4096];

                while (stream.Position < stream.Length)
                {
                    int count = stream.Read(buffer, 0, buffer.Length);

                    for (int j = 0; j < count - 1; j++)
                    {
                        newBuffer = e.GetBytes(buffer[j] + " ");

                    }
                    stream.Write(newBuffer, 0, newBuffer.Length);
                    stream.Flush();
                }

                if (Messang != null)
                    Messang(this, new MyEvenArgs(string.Format("Объект '{0}' был изменен", fileList[i])));
                stream.Close();
            }
        }

        /// <summary>
        /// Шифрует обьект по умолчанию.
        /// </summary>
        public void encod()
        {
            for (int i = 0; i < fileList.Count; i++)
            {
                try
                {
                    System.IO.File.Encrypt(fileList[i]);

                    if (Messang != null)
                        Messang(this, new MyEvenArgs(string.Format("Объект '{0}' был изменен.", fileList[i])));
                }
                catch { }
            }
        }

        /// <summary>
        /// Дешефрует обьект по умолчанию.
        /// </summary>
        public void uncod()
        {
            for (int i = 0; i < fileList.Count; i++)
            {
                try
                {
                    System.IO.File.Decrypt(fileList[i]);
                    if (Messang != null)
                    { Messang(this, new MyEvenArgs(string.Format("Объект '{0}' был изменен.", fileList[i]))); }
                }
                catch { }
            }
        }

        /// <summary>
        /// Открывает поток.
        /// </summary>
        /// <param name="a">Файл, который нужно открыть.</param>
        /// <returns>Возвращает поток.</returns>
        internal System.IO.FileStream fileStream(string a)
        {

            if (System.IO.File.Exists(a))
                try
                {
                    stream = System.IO.File.Open(a, System.IO.FileMode.Open, System.IO.FileAccess.ReadWrite, System.IO.FileShare.ReadWrite);
                }
                catch (System.IO.IOException exc)
                {
                    throw exc;
                }
                catch (UnauthorizedAccessException exc)
                {
                    throw exc;
                }
            else
            {
                throw new MyException();
            }
            return stream;
        }

        #endregion




    }
}

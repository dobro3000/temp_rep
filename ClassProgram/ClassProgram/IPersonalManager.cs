using System;

namespace FilesDirs
{

    /// <summary>
    /// Описывает перегрузки и свойства интерфейса IManager.
    /// </summary>
   public interface IPersonalManager : IManager
    {
        /// <summary>
        /// Кодирует обьект в заданой кодировке.
        /// </summary>
        /// <param name="a">Название кодировки.</param>
        void changingthecoding(string a);

        /// <summary>
        /// Возвращает имя обьекта.
        /// </summary>
        string getname { get; }

        /// <summary>
        /// Возвращает размер обьекта.
        /// </summary>
        long getsize { get; }

        /// <summary>
        /// Возвращает информацию типа bool о существовании обьекта. 
        /// </summary>
        bool getcreate { get; }

        /// <summary>
        /// Событие класса AbctractClass.
        /// </summary>
        event EventHandler<MyEvenArgs> Messang;

    }
}

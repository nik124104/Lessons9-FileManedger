using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrary1
{
    public static class MN1
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="a">длина</param>
        /// <param name="b">Строка</param>
        public static void MNKaidak(int a, int b)
        {
            Console.SetCursorPosition(a / 2 - 8, b);

            Console.Write("***MNKaidak***");

        }


        /// <summary>
        /// Запись в лог
        /// </summary>
        /// <param name="str">Строка записи </param>
        public static void Log(string str)
        {
           
            File.AppendAllText("Log.txt", $" {Convert.ToString(new DateTime())} - {str} ; ");
        }

        /// <summary>
        /// Текущая позиция курсора
        /// </summary>
        /// <returns></returns>
        public static (int left, int top) GetCursorPosition()
        {
            return (Console.CursorLeft, Console.CursorTop);
        }


    }

    public static class API
    {

        public const uint MAX_PATH = 255;

        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
      ///Не понял как он работает
        public static extern uint GetShortPathName([MarshalAs(UnmanagedType.LPWStr)]string lpszLongPath, 
            [MarshalAs(UnmanagedType.LPArray)] StringBuilder lpszShortPath,
            uint cchBuffer);
    }

}

using MyLibrary1;
using System;

namespace Lessons9_FileManedger
{


    class Program
    {

        const int A = 150;
        const int B = 50;
        const int b1 = 26;
        const int b2 = 8;
        const int b3 = 3;

        static void Main(string[] args)
        {
            Console.Title = "FileMenedger";
            //test
            Console.SetWindowSize(A, B);
            Console.SetBufferSize(A, B);

            DesingWin1(0, 0, A, b1);
            DesingWin1(0, b1+1, A, b2); 
            DesingWin1(0, b1+b2+2, A, b3);
            //MyLibrary1.MN1. (A, b1 + b2 + b3 + 3);
            MN1.MNKaidak(A, b1 + b2 + b3 + 3);
        }

        /// <summary>
        /// окно меню
        /// </summary>
        /// <param name="x"> первая координата </param>
        /// <param name="y">вторая координата</param>
        /// <param name="a"> длина</param>
        /// <param name="b">высота</param>
        static void DesingWin1(int x, int y, int a, int b)
        {
            Console.SetCursorPosition(x, y); 
            Console.Write("╓");
            for (int i = 0; i < a - 2; i++)
                Console.Write("─");
            Console.WriteLine("╖");

            for (int j=1; j < b; j++)
            {
                
                Console.Write("║");
                for (int i = 1; i < a - 1; i++)
                    Console.Write(" ");
                Console.WriteLine("║");
            }

            Console.Write("╙");
            for (int i = 0; i < a - 2; i++)
                Console.Write("─");
            Console.WriteLine("╜");

        }
    }
}

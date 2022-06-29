using MyLibrary1;
using System;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace Lessons9_FileManedger
{


    class Program
    {

        const int A = 150;
        const int B = 50;
        const int b1 = 26;
        const int b2 = 8;
        const int b3 = 5;
        private static string Dir = Directory.GetCurrentDirectory();
        

        static void Main(string[] args)
        {
            Console.Title = "FileMenedger";
            MN1.Log("Console.Title = FileMenedger");
            //test
            Console.SetWindowSize(A, B);
            Console.SetBufferSize(A, B);

            DesingWin1(0, 0, A, b1);
            MN1.Log($"Отрисовка  окна 0,0,{A},{b1}");
            DesingWin1(0, b1+1, A, b2);
            MN1.Log($"Отрисовка  окна 0,{b1+1},{A},{b1}");
            DesingWin1(0, b1+b2+2, A, b3);
            MN1.Log($"Отрисовка  окна 0,{b1 + b2 + 2},{A},{b1}");
            //MyLibrary1.MN1. (A, b1 + b2 + b3 + 3);
            MN1.MNKaidak(A, b1 + b2 + b3 + 3);

            //WRConsole(GetShortPath(Dir), b1 + b2 + 2); //Выбивает исключение
            WRConsole(Dir, b1 + b2 + 2);
            RDConsole(b1 + b2 + 2);
            Console.ReadKey();
            
        }


        /// <summary>
        /// Читаем из консоли
        /// </summary>
        /// <param name="x"></param>
        static void RDConsole(int x)
        {
            //string str = Console.ReadLine();
            (int left, int top) = MN1.GetCursorPosition();
            StringBuilder comands = new StringBuilder();
            ConsoleKeyInfo keyInfo;
            char key;
            int i = 0;
            
            do
            {
                keyInfo = Console.ReadKey();
                key = keyInfo.KeyChar;

                if(keyInfo.Key!=ConsoleKey.Enter && keyInfo.Key != ConsoleKey.Backspace && keyInfo.Key != ConsoleKey.UpArrow){
                    comands.Append(key);
                }

                ( int left1, int top1) = MN1.GetCursorPosition();

                if(left1 == A - 2) {
                    i++;
                    if (i < 4) {
                        Console.SetCursorPosition(1, top1 + 1);
                    }
                    else {
                        Console.SetCursorPosition(left1 - 1, top1);
                        Console.Write(" ");
                        Console.SetCursorPosition(left1 - 1, top1);
                    }
                }
                if(keyInfo.Key == ConsoleKey.Backspace)
                {
                    if (comands.Length > 0)
                    {
                        comands.Remove(comands.Length - 1,1);
                    }


                    if (left1 >= left && top1==top )
                    {
                        
                        Console.SetCursorPosition(left1 , top1);
                        Console.Write(" ");
                        Console.SetCursorPosition(left1 , top1);
                    }
                    if(top1 > top)
                    {
                        if (left1 > 1)
                        {
                            Console.SetCursorPosition(left1, top1);
                            Console.Write(" ");
                            Console.SetCursorPosition(left1, top1);
                        }
                        else
                        {
                            Console.SetCursorPosition(left1, top1);
                            Console.Write(" ");
                            Console.SetCursorPosition(A - 2, top1 - 1);
                        }
                    }
                    if(left1<left && top1==top) { 
                        Console.SetCursorPosition(left, top);
                        comands.Clear();
                    }
                }


            }
            while (keyInfo.Key != ConsoleKey.Enter);

            CommandsStr(comands.ToString());
            
        }


        /// <summary>
        /// Команды
        /// </summary>
        /// <param name="command"></param>
        static void CommandsStr(string command)
        {
            string[] commands = command.ToLower().Split(" ");


            //for(int i=0; i < commands.Length ; i++)
            //{
            //    if(commands[i]=="")
            //    {
            //        for(int j=i+1; j < commands.Length - 1; j++)
            //        {
            //            commands[j - 1] = commands[j];
            //            if (j == commands.Length)
            //            {
            //                commands[j] = "";
            //            }
            //        }


            //    }


            if( commands.Length > 0)
            {
                switch (commands[0])
                {
                    case "cd":
                        if( commands.Length > 1)
                        {
                            if (Directory.Exists(commands[1]))
                            {
                                Dir = commands[1];
                            }
                        }
                        break;
                    case "ls":
                        if (commands.Length > 1 && Directory.Exists(commands[1]))
                        {
                            if (commands.Length>3 && commands[2]=="-p"&& int.TryParse(commands[3], out int n))
                            {
                                DravTree(new DirectoryInfo(commands[1]),n);
                            }
                            else
                            {
                                DravTree(new DirectoryInfo(commands[1]), 1);
                            }
                        }

                        break;
                    case "op":
                        if (commands.Length > 1 && Directory.Exists(commands[1]))
                        {
                            Process.Start(commands[1]);
                        }
                        break;
                    case "info":
                        if (commands.Length > 1 && Directory.Exists(commands[1]))
                        {
                            GetInfo(commands[1]);
                        }
                        break;
                    //case "cp":

                    //    if (commands.Length > 1 && Directory.Exists(commands[1])) //хочу проверить наличие файла     //  
                    //    {
                    //        if (commands.Length > 3 && commands[2] == "-p" && int.TryParse(commands[3], out int n))
                    //        {
                    //            DravTree(new DirectoryInfo(commands[1]), n);
                    //        }
                            
                    //    }
                    //    else
                    //    {
                    //        //DesingWin1(0, b1 + 1, A, b2);
                    //        //Console.SetCursorPosition(50, b1 + 3);
                    //        //Console.Write("Введены не коректные даннные");



                    //        try
                    //        {
                    //            File.Copy(commands[1], commands[1]+"1");
                    //        }
                    //        catch
                    //        {

                    //            DesingWin1(0, b1 + 1, A, b2);
                    //            Console.SetCursorPosition(50, b1 + 3);
                    //            Console.Write("Введены не коректные даннные");
                    //            Console.SetCursorPosition(1, b1 + 4);
                    //            //Console.Write(copyError.Message);
                    //        }
                            
                    //    }
                        

                    //    break;


                        
                }

            }
            
            WRConsole(Dir, b1 + b2 + 2);
            RDConsole(b1 + b2 + 2);
        }
        static void GetInfo(string name)
        {
            MN1.Log("GetInfo = {name}");
            DirectoryInfo dir = new DirectoryInfo(name);

            DesingWin1(0, b1 + 1, A, b2);
            Console.SetCursorPosition(58, b1 + 2);
            Console.WriteLine("***** Информация о каталоге *****");

            
            Console.WriteLine("║ Полный путь: {0}\n║ Название папки: {1}\n║ Родительский каталог: {2}\n║  Время создания: {3}\n║ Атрибуты: {4}\n║ Корневой каталог: {5}",
                         dir.FullName, dir.Name, dir.Parent, dir.CreationTime, dir.Attributes, dir.Root);
            
        }

        static string GetShortPath(string path)
        {
            StringBuilder shortPathName = new StringBuilder((int)API.MAX_PATH);

            API.GetShortPathName(path, shortPathName, API.MAX_PATH);
            return shortPathName.ToString();
        }

        /// <summary>
        /// Вывод директории
        /// </summary>
        /// <param name="dir"></param>
        /// <param name="x"></param>
        static void WRConsole(string dir, int x )
        {
            DesingWin1(0, b1 + b2 + 2, A, b3);
            Console.SetCursorPosition(1, x + 1);
            Console.Write($"{dir}>");

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


        static void DravTree(DirectoryInfo dir, int page)
        {
            StringBuilder tree = new StringBuilder();
            GetTree(tree, dir, "", true);
            DesingWin1(0, 0, A, b1);
            //(int currentLeft, int currentTop) = MN1.GetCursorPosition();
            int pageLines = b1 - 2;
            string[] lines = tree.ToString().Split( '\n' );
            int pageTols = (pageLines + lines.Length - 1) / pageLines;

            if (page > pageTols)
            {
                page = pageTols;
            }
            Console.SetCursorPosition(0, 1);
            for(int i=(page-1)*pageLines; i<page*pageLines; i++)
            {
                if (i < lines.Length - 1)
                {

                    Console.Write("║");
                Console.WriteLine(lines[i]);
                }
            }
            Console.SetCursorPosition(A - 15, b1 - 1);
            Console.Write($"*{page} из {pageTols}*");

        }


        /// <summary>
        /// Подготовка к выводу дерева с папками и файлами
        /// </summary>
        /// <param name="tree"></param>
        /// <param name="dir"></param>
        /// <param name="indent"></param>
        /// <param name="lastDir"></param>
        static void GetTree( StringBuilder tree, DirectoryInfo dir, string indent, bool lastDir)
        {
            tree.Append(indent);
            if (lastDir)
            {
                tree.Append("└");
                indent += " ";

            }
            else
            {
                tree.Append("├");
                indent += "│";
            }
            tree.Append($"{dir.Name}\n");

            FileInfo[] subFiles = dir.GetFiles();
            for(int i=0; i<subFiles.Length; i++)
            {
                if (i == subFiles.Length - 1)
                {
                    tree.Append($"{indent}└{subFiles[i].Name}\n");
                }
                else
                {
                    tree.Append($"{indent}├{subFiles[i].Name}\n");

                }

            }

            DirectoryInfo[] subDirects = dir.GetDirectories();
            for (int i = 0; i<subDirects.Length; i++)
            {
                GetTree(tree, subDirects[i], indent, i == subDirects.Length - 1);
            }
        }
    }


}

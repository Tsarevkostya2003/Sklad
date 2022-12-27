using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sklad
{
    internal class Strelka
    {
        int minimum;
        int maximum;
        int positionmenu;

        public Strelka(int a, int b)
        {
            minimum = a;
            maximum = b;
        }

        public void Draw(int i)
        {
            Console.SetCursorPosition(0, i);
            Console.WriteLine("->");
        }
        public int Pos()
        {
            return positionmenu;
        }
        public int Mini()
        {
            return minimum;
        }

        public int Max()
        {
            return maximum;
        }

        public void Del(int i)
        {
            Console.SetCursorPosition(0, i);
            Console.WriteLine("  ");
        }
        public ConsoleKey MovemenuAdm(int position)
        {
            ConsoleKeyInfo key;
            while (true)
            {
                Draw(position);
                key = Console.ReadKey(); // нажали клавишу

                if (key.Key == ConsoleKey.UpArrow)
                {
                    if (position > Mini())
                    {
                        Del(position);
                        position--;
                        Draw(position);
                        positionmenu = position;
                    }
                }
                else if (key.Key == ConsoleKey.DownArrow)
                {
                    if (position < Max())
                    {
                        Del(position);
                        position++;
                        positionmenu = position;
                        Draw(position);
                    }
                }
                else if (key.Key == ConsoleKey.Escape || key.Key == ConsoleKey.F2 || key.Key == ConsoleKey.F1 || key.Key == ConsoleKey.F3 || key.Key == ConsoleKey.F4 || key.Key == ConsoleKey.F5)
                {
                    positionmenu= position;
                    return key.Key;
                    
                }

                
            }

        }

        public ConsoleKey Movesearch(int position)
        {
            ConsoleKeyInfo key;
            while (true)
            {
                Draw(position);
                key = Console.ReadKey(); // нажали клавишу

                if (key.Key == ConsoleKey.UpArrow)
                {
                    if (position > Mini())
                    {
                        Del(position);
                        position--;
                        Draw(position);
                        positionmenu = position;
                    }
                }
                else if (key.Key == ConsoleKey.DownArrow)
                {
                    if (position < Max())
                    {
                        Del(position);
                        position++;
                        positionmenu = position;
                        Draw(position);
                    }
                }
                else if (key.Key == ConsoleKey.Enter || key.Key==ConsoleKey.Escape)
                {
                    positionmenu = position;
                    return key.Key;
                }



            }

        }


    }
}
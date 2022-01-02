using System;
using System.Diagnostics;
using System.Threading;

namespace bojovnik_arena
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.SetWindowSize(100, 50);
            Console.SetBufferSize(100, 50);
            Arena arena = new Arena();
            bool volba = true;
            while (volba)
            {
                arena.Turnaj(arena.CreateListOfWarriors());
                Console.Write("----------------------------------------------------\n");
                Console.Write("To byla ale hra!\n");
                Console.Write("Přeješ si otevřít textový soubor s podrobnostmi? [y]\n> ");
                char vo = Console.ReadKey().KeyChar;
                if (vo == 'y')
                {
                    Process.Start("notepad.exe", Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\bojovnik-arena.txt");
                }
                Console.Write("\n----------------------------------------------------\n");
                Console.Write("Pokud chceš hrát znovu, stiskni klávesu [y]\n> ");
                char vol = Console.ReadKey().KeyChar;
                if (vol == 'y')
                {
                    volba = true;
                }
                else
                {
                    Console.Write("\nTak zas příště!");
                    Thread.Sleep(1000);
                    volba = false;
                }
            }
        }
    }
}

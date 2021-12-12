using System;
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
                Console.Write("--------------------------------------------------\n");
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

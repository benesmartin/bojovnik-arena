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
            arena.Turnaj(arena.CreateListOfWarriors());
            Console.ReadLine();
        }
    }
}

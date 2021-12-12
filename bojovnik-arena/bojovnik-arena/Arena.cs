using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bojovnik_arena
{
    public class Arena
    {
        private int pocetBoj; private static Random rng = new Random(); private Bojovnik bojovnik;
        public void Turnaj(List<Bojovnik> warriors)
        {
            Console.Clear();
            Console.WriteLine("-------------------------------------\n");
            Extensions.Shuffle(warriors);
            var warriorsCount = warriors.Count();           
            for (int i = 0; i < warriorsCount; i++)
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.Write(i+1);
                Console.ResetColor();
                Console.Write(". " + warriors[i].Name + " -> HP: ");
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.Write(warriors[i].HP);
                Console.ResetColor();
                Console.Write(" DMG: ");
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write(warriors[i].DMG);
                Console.ResetColor();
                Console.WriteLine("\n");
            }
            Console.Write("-------------------------------------");
        }
        public List<Bojovnik> CreateListOfWarriors()
        {
            List<Bojovnik> bojovnici = new List<Bojovnik>();
            while (true)
            {
                Console.Clear();
                Console.Write("Vyber si počet bojovníků (2 - 4 - 8 - 16)\n> ");
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                string pocet = Console.ReadLine();
                Console.ResetColor();
                pocetBoj = Convert.ToInt32(pocet);
                if (pocetBoj == 2 || pocetBoj == 4 || pocetBoj == 8 || pocetBoj == 16)
                    break;
            }
            for (int i = 0; i < pocetBoj; i++)
            {
                var randomHP = rng.Next(50, 101);
                var randomDMG = rng.Next(25, 51);
                var randomChance = rng.Next(10, 51);
                var randomChoice = rng.Next(0, 4);
                if (randomChoice == 0)
                    bojovnik = new Berserker(randomHP, randomDMG, 0, 0, randomChance, "Berserker [" + (i + 1) + "]");
                if (randomChoice == 1)
                    bojovnik = new Mage(randomHP, randomDMG, 0, 0, 0, "Mág [" + (i + 1) + "]");
                if (randomChoice == 2)
                    bojovnik = new Warrior(randomHP, randomDMG, 0, randomChance, 0, "Bojovník [" + (i + 1) + "]");
                if (randomChoice == 3)
                    bojovnik = new Archer(randomHP, randomDMG, randomChance, 0, 0, "Lukostřelec [" + (i + 1) + "]");
                bojovnici.Add(bojovnik);
            }
            return bojovnici;
        }
    }
}

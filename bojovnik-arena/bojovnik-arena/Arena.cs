﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bojovnik_arena
{
    public class Arena
    {
        private int pocetBoj; private static Random rng = new Random(); private Bojovnik bojovnik; bool game, main;
        public void Turnaj(List<Bojovnik> warriors)
        {
            DateTime dateTime = DateTime.UtcNow.Date;
            List<Bojovnik> winners = new();
            List<Bojovnik> warriorsD = new();
            main = true;
            while (main)
            {
                game = true;
                Extensions.Shuffle(warriors);
                PrintInfo();
                PrintWarriors(warriors);
                if (warriors.Count == 1)
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.Write(warriors[0].Name);
                    Console.ResetColor();
                    Console.Write(" je vítězem turnaje ze dne ");
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.Write(dateTime.ToString("dd/MM/yyyy"));
                    Console.ResetColor();
                    Console.WriteLine("!");
                    break;
                }
                while (game)
                {
                    if (warriors.Count == 0)
                    {
                        foreach (var item in winners)
                        {
                            warriors.Add(item);
                        }
                        winners.Clear();
                        game = false;
                    }
                    else if (warriors.Count >= 2)
                    {
                        Game(warriors, winners, warriorsD);
                        Remove(warriors, warriorsD);
                        game = false;
                    }
                }
            }
            
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
        public void PrintWarriors(List<Bojovnik> warriors)
        {
            for (int i = 0; i < warriors.Count(); i++)
            {
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.Write(i + 1);
                Console.ResetColor();
                Console.Write(". " + warriors[i].Name + " -> HP: ");
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.Write(warriors[i].HP);
                Console.ResetColor();
                Console.Write(" DMG: ");
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write(warriors[i].DMG);
                Console.ResetColor();

                if (warriors[i] is Warrior)
                {
                    Console.Write(" BC: ");
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.Write(warriors[i].BlockChance);
                    Console.ResetColor();
                }

                if (warriors[i] is Archer)
                {
                    Console.Write(" DC: ");
                    Console.ForegroundColor = ConsoleColor.DarkMagenta;
                    Console.Write(warriors[i].DodgeChance);
                    Console.ResetColor();
                }

                if (warriors[i] is Berserker)
                {
                    Console.Write(" DAC: ");
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.Write(warriors[i].DoubleAttackChance);
                    Console.ResetColor();
                }

                Console.WriteLine("\n");
            }
            Console.Write("--------------------------------------------------");
        }
        public void PrintInfo()
        {
            Console.Clear();
            Console.WriteLine("--------------------------------------------------");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Write("HP");
            Console.ResetColor();
            Console.Write(" - životy");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write("DMG");
            Console.ResetColor();
            Console.Write(" - síla útoku");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write("BC");
            Console.ResetColor();
            Console.Write(" - šance na zablokování útoku (Bojovník)");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.Write("DC");
            Console.ResetColor();
            Console.Write(" - šance na vyhnutí se útoku (Lukostřelec)");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.Write("DAC");
            Console.ResetColor();
            Console.Write(" - šance na dvojnásobný útok (Berserker)\n");
            Console.WriteLine("--------------------------------------------------");
        }
        public void Game(List<Bojovnik> warriors, List<Bojovnik> winners, List<Bojovnik> warriorsD)
        {
            Console.WriteLine("\nNásleduje: \n");
            Console.WriteLine(warriors[0].Name + " vs " + warriors[1].Name);
            Console.WriteLine("\nStiskni libovolnou klávesu pro pokračování...");
            Console.Write("--------------------------------------------------\n");
            Console.ReadLine();
            var w0hp = warriors[0].HP;
            var w1hp = warriors[1].HP;
            while (warriors[0].isAlive() && warriors[1].isAlive())
            {
                Console.Clear();
                Console.Write("\t\t[" + warriors[0].Name + " útočí]\n");
                Console.Write("--------------------------------------------------\n");
                warriors[0].Attack(warriors[1]);
                Console.Write("--------------------------------------------------\n");
                Console.WriteLine("HP " + warriors[0].Name + ": " + warriors[0].HP + " / " + w0hp);
                Console.WriteLine("HP " + warriors[1].Name + ": " + warriors[1].HP + " / " + w1hp);
                Console.Write("--------------------------------------------------");
                Console.ReadLine();
                if (warriors[1].isAlive())
                {
                    Console.Clear();
                    Console.Write("\t\t[" + warriors[1].Name + " útočí]\n");
                    Console.Write("--------------------------------------------------\n");
                    warriors[1].Attack(warriors[0]);
                    Console.Write("--------------------------------------------------\n");
                    Console.WriteLine("HP " + warriors[0].Name + ": " + warriors[0].HP + " / " + w0hp);
                    Console.WriteLine("HP " + warriors[1].Name + ": " + warriors[1].HP + " / " + w1hp);
                    Console.Write("--------------------------------------------------");
                    Console.ReadLine();
                }
            }
            if (warriors[0].isAlive())
            {
                Console.WriteLine("Vítězem se stává " + warriors[0].Name + "!");
                winners.Add(warriors[0]);
                warriorsD.Add(warriors[1]);
                warriorsD.Add(warriors[0]);
            }
            if (warriors[1].isAlive())
            {
                Console.WriteLine("Vítězem se stává " + warriors[1].Name + "!");
                winners.Add(warriors[1]);
                warriorsD.Add(warriors[1]);
                warriorsD.Add(warriors[0]);
            }
            Console.Write("--------------------------------------------------");
            Console.ReadLine();
        }
        public void Remove(List<Bojovnik> warriors, List<Bojovnik> warriorsD)
        {
            foreach (var item in warriorsD)
            {
                warriors.Remove(item);
            }
        }
    }
}

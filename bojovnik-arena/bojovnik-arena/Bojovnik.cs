﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bojovnik_arena
{
    public abstract class Bojovnik
    {
        public int HP { get; set; }
        public int DMG { get; set; }
        public int DodgeChance { get; set; }
        public int BlockChance { get; set; }
        public string Name { get; set; }
        protected Bojovnik(int hp, int dmg, int dodgechance, int blockchance, string name)
        {
            HP = hp;
            DMG = dmg;
            DodgeChance = dodgechance;
            BlockChance = blockchance;
            Name = name;
        }
        public int damageIncoming(int damage)
        {
            return HP -= damage;
        }
        public int Attack(Bojovnik bojovnik)
        {
            return bojovnik.damageIncoming(DMG);
        }
        public bool isAlive()
        {
            return HP > 0;
        }
    }
}

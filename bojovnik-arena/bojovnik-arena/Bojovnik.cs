using System;
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
        protected Bojovnik(int hp, int dmg, int dodgechance, int blockchance)
        {
            HP = hp;
            DMG = dmg;
            DodgeChance = dodgechance;
            BlockChance = blockchance;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bojovnik_arena
{
    public class Archer : Bojovnik
    {
        private int dc; private static Random rng = new Random();
        public Archer(int hp, int dmg, int dodgechance, int blockchance, int doubleattackchance, string name) : base(hp, dmg, dodgechance, blockchance, doubleattackchance, name)
        {
            if (blockchance != 0)
                blockchance = 0;
            else if (doubleattackchance != 0)
                doubleattackchance = 0;
            dc = dodgechance;
        }
        public override int damageIncoming(int damage)
        {
            int chance = rng.Next(0, 101);
            if (chance <= dc)
                return HP;
            else
                return HP -= damage;
        }
    }
}

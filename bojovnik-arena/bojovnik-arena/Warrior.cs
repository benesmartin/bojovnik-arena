using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bojovnik_arena
{
    public class Warrior : Bojovnik
    {
        private int bc; private static Random rng = new Random();
        public Warrior(int hp, int dmg, int dodgechance, int blockchance, int doubleattackchance, string name) : base(hp, dmg, dodgechance, blockchance, doubleattackchance, name)
        {
            if (dodgechance != 0)
                dodgechance = 0;
            else if (doubleattackchance != 0)
                doubleattackchance = 0;
            bc = blockchance;
        }
        public override int damageIncoming(int damage)
        {
            int chance = rng.Next(0, 101);
            if(chance <= bc)
                return HP;
            else
                return HP -= damage;
        }
    }
}

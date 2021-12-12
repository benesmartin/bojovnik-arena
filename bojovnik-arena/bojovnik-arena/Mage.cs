using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bojovnik_arena
{
    public class Mage : Bojovnik
    {
        public Mage(int hp, int dmg, int dodgechance, int blockchance, int doubleattackchance, string name) : base(hp, dmg, dodgechance, blockchance, doubleattackchance, name)
        {
            if (dodgechance != 0)
                dodgechance = 0;
            else if (blockchance != 0)
                blockchance = 0;
            else if (doubleattackchance != 0)
                doubleattackchance = 0;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bojovnik_arena
{
    public class Mage : Bojovnik
    {
        public Mage(int hp, int dmg, int dodgechance, int blockchance, string name) : base(hp, dmg, dodgechance, blockchance, name)
        {
        }
    }
}

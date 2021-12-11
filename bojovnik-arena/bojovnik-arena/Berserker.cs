using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bojovnik_arena
{
    public class Berserker : Bojovnik
    {
        public Berserker(int hp, int dmg, int dodgechance, int blockchance) : base(hp, dmg, dodgechance, blockchance)
        {
        }
    }
}

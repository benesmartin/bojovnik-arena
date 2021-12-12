using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bojovnik_arena
{
    public class Berserker : Bojovnik
    {
        private int dac; private static Random rng = new Random();
        public Berserker(int hp, int dmg, int dodgechance, int blockchance, int doubleattackchance, string name) : base(hp, dmg, dodgechance, blockchance, doubleattackchance, name)
        {
            if (dodgechance != 0)
                dodgechance = 0;
            else if (blockchance != 0)
                blockchance = 0;
            dac = doubleattackchance;
        }
        public override void Attack(Bojovnik bojovnik)
        {
            int chance = rng.Next(0, 101);
            if (chance <= dac)
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine(Name + " provedl svůj útok dvakrát!");
                Console.ResetColor();
                bojovnik.damageIncoming(2 * DMG);
            }
                
            else
                bojovnik.damageIncoming(DMG);
        }
    }
}

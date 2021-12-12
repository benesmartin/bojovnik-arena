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
        public override void damageIncoming(int damage)
        {
            int chance = rng.Next(0, 101);
            if(chance <= bc)
            {
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine(Name + " zablokoval útok!");
                Console.ResetColor();
                HP = HP;
            }

            else
            {
                Console.Write(Name + " utrpěl poškození ");
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.Write(damage);
                Console.ResetColor();
                Console.Write("!\n");
                HP -= damage;
            }
            if (HP <= 0)
            {
                Console.WriteLine(Name + " zemřel.");
            }

        }
    }
}

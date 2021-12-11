using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bojovnik_arena
{
    public class Arena
    {
        public void Turnaj(List<Bojovnik> warriors)
        {
            Extensions.Shuffle(warriors);
            var warriorsCount = warriors.Count();
            for (int i = 0; i < warriorsCount; i++)
            {
                Console.WriteLine(i+1 + ". bojovník je: " + warriors[i].Name);
            }
        }
    }
}

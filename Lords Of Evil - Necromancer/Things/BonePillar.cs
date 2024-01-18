using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lords_Of_Evil___Necromancer.Things
{
    public class BonePillar : Thing
    {
        public BonePillar(string name, Map map) : base(name, map)
        {
            row = map.player.row;
            col = map.player.col;
        }

        public override void usesThing()
        {
            //create a bone pile that over times degrades the terrain
            map.updateXY();
        }
    }
}

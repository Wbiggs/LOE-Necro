using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lords_Of_Evil___Necromancer.Things
{
    public class WanderingSpirit : Thing
    {
        //wandering spirit should move around the map and collect magic and can be absorbed later
        public int magicCollected;
        public WanderingSpirit(string name, Map map) : base(name, map)
        {
            row = map.player.row;
            col = map.player.col;
            magicCollected = 1;
        }

        public override void usesThing()
        {
            bool location;  //this checks the players location vs the bone pile location to make sure they're the same
            if (map.player.row == row && map.player.col == col)
            {
                location = true;
            }
            else
            {
                location = false;
            }

            if (map.player.move > 0 && location) 
            {
                map.player.magicCollected= map.player.magicCollected+magicCollected;
            }
            map.updateXY();
        }
    }
}

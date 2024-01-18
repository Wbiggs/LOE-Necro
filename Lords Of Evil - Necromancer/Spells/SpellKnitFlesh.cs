using Lords_Of_Evil___Necromancer.Things;
using Microsoft.Maui.ApplicationModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Lords_Of_Evil___Necromancer.Spells
{
    public class SpellKnitFlesh:Spell
    {
        public SpellKnitFlesh(Player player, Map map) : base(player, map)
        {
            name = "Knit Flesh";
            movesToCast = 1;
            fleshcost = 4;
            this.map = map;
        }

        public override void useSpell()
        {
            if (player.fleshCollected > 3)
            {
                player.fleshCollected--;
                player.fleshCollected--;
                player.fleshCollected--;
                player.fleshCollected--;
                player.ArmyRising.Add(new Forces.ForcesFleshPile());
                map.alterPlayerMoves();
                map.updateXY();

            }
        }
    }
}

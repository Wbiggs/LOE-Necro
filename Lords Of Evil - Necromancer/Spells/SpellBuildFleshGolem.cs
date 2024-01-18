using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lords_Of_Evil___Necromancer.Things;

namespace Lords_Of_Evil___Necromancer.Spells
{
    public class SpellBuildFleshGolem:Spell
    {
        public SpellBuildFleshGolem(Player player, Map map) : base(player, map)
        {
            name = "Flesh Golem";
            movesToCast = 1;
            bonecost = 2;
            fleshcost= 2;
            magiccost= 1;
            this.map = map;
        }

        public override void useSpell()
        {
            if (player.bonesCollected > 1 && player.fleshCollected>1 && player.magicCollected>0)
            {
                player.bonesCollected--;
                player.bonesCollected--;
                player.fleshCollected--;
                player.fleshCollected--;
                player.magicCollected--;
                player.ArmyRising.Add(new Forces.ForcesFleshGolem());
                map.alterPlayerMoves();
                map.updateXY();

            }
        }
    }
}

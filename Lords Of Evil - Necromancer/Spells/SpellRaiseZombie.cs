using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lords_Of_Evil___Necromancer.Things;

namespace Lords_Of_Evil___Necromancer.Spells
{
    public class SpellRaiseZombie : Spell
    {
        public SpellRaiseZombie(Player player, Map map) : base(player, map)
        {
            name = "Raise Zombie";
            movesToCast = 1;
            bonecost = 1;
            fleshcost = 1;
            this.map = map;
        }

        public override void useSpell()
        {
            if (player.bonesCollected > 0 && player.fleshCollected > 0)
            {
                player.bonesCollected--;
                player.fleshCollected--;
                player.ArmyRising.Add(new Forces.ForcesZombie());
                map.alterPlayerMoves();
                map.updateXY();

            }
        }
    }
}

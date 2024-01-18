using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lords_Of_Evil___Necromancer.Things;

namespace Lords_Of_Evil___Necromancer.Spells
{
    public class SpellDanseMacabre : Spell
    {

        public SpellDanseMacabre(Player player, Map map) : base(player, map)
        {
            name = "Danse Macabre";
            movesToCast = 1;
            bonecost= 1;
            this.map = map;
        }

        public override void useSpell()
        {
            if (player.bonesCollected > 0)
            {
                player.bonesCollected--;
                player.ArmyRising.Add(new Forces.ForcesSkeleton());
                map.alterPlayerMoves();
                map.updateXY();

            }
        }
    }
}

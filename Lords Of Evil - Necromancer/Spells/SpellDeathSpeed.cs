using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lords_Of_Evil___Necromancer.Things;

namespace Lords_Of_Evil___Necromancer.Spells
{
    public class SpellDeathSpeed : Spell
    {

        public SpellDeathSpeed(Player player, Map map) : base(player, map)
        {
            name = "Speed of Death";
            movesToCast = 0;
            magiccost = 1;
        }

        public override void useSpell()
        {
            if (player.magicCollected > 0)
            {
                player.move = player.move + 2;
                player.magicCollected = player.magicCollected - magiccost;

            }
        }

    }
}

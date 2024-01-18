using Lords_Of_Evil___Necromancer.Things;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lords_Of_Evil___Necromancer.Spells
{
    public class SpellSummonHaunt : Spell
    {
        public SpellSummonHaunt(Player player, Map map) : base(player, map)
        {
            name = "Summon 3 Haunts";
            movesToCast = 1;
            magiccost = 2;
            this.map = map;
        }
        public override void useSpell()
        {
            if (player.magicCollected > 1 && player.move > 0)
            {
                player.ArmyRising.Add(new Forces.ForcesHaunt());
                player.ArmyRising.Add(new Forces.ForcesHaunt());
                player.ArmyRising.Add(new Forces.ForcesHaunt());
                map.allLocations[player.row, player.col].listBox.ItemsSource = null;
                map.allLocations[player.row, player.col].listBox.ItemsSource = map.allLocations[player.row, player.col].Things;
                map.player.magicCollected--;
                map.player.magicCollected--;
                map.player.move--;

            }
        }
    }
}

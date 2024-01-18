using Lords_Of_Evil___Necromancer.Things;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lords_Of_Evil___Necromancer.Spells
{
    public class SpellBonePile : Spell
    {
        //This spell places a pile of bones Thing on the map
        public SpellBonePile(Player player, Map map) : base(player, map)
        {

            name = "Bone Pile";
            movesToCast = 3;
            magiccost = 2;
            this.map = map;
        }

        public override void useSpell()
        {
            if (player.magicCollected > 1 && player.move > 2 )
            {
                map.allLocations[player.row, player.col].Things.Add(new BonePile("Bone Pile",map));
                map.allLocations[player.row, player.col].listBox.ItemsSource = null;
                map.allLocations[player.row, player.col].listBox.ItemsSource = map.allLocations[player.row, player.col].Things;
                map.player.magicCollected--;
                map.player.magicCollected--;

            }


        }
    }
}

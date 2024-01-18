using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lords_Of_Evil___Necromancer.Things;

namespace Lords_Of_Evil___Necromancer.Spells
{
    //To add a force must create a spell, add the spell result to MenuPopUp LVSpells_ItemTapped, then add it to the player's List<Spells>
    public abstract class Spell
    {
        public string name { get; set; }
        public int movesToCast { get; set; }
        public Player player { get; set; }
        public int bonecost { get; set; }
        public int fleshcost { get; set; }
        public int orecost { get; set; }
        public int magiccost { get; set; }
        public Map map { get; set; }
        public Spell(Player player, Map map)
        {
            this.map= map;
            this.player = player;
        }

        public abstract void useSpell();
        
    }
}

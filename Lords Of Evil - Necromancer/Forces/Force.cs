using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lords_Of_Evil___Necromancer.Forces
{
    //To add a force must create a spell, add the spell result to MenuPopUp LVSpells_ItemTapped, then add it to the player's List<Spells>
    public abstract class Force
    {
        public string name { get; set; }
        public int health { get; set; }
        public int maxHealth { get; set; }
        public bool armor { get; set; }
        public bool weapon { get; set; }
        public int minDamage { get; set; }
        public int maxDamage { get; set; }

        public Force()
        {

        }

        public abstract void improve(bool armor, bool weapon);

    }
}

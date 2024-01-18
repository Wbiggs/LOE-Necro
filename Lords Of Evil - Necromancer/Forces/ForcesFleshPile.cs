using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Lords_Of_Evil___Necromancer.Forces
{
    public  class ForcesFleshPile :Force
    {
        public ForcesFleshPile()
        {
            name = "Flesh Pile";
            health = 8;
            maxHealth = 8;
            armor = false;
            weapon = false;
            minDamage = 2;
            maxDamage = 2;
        }

        /// <summary>
        /// First bool is for armor, set it true to arm them, second bool is for weapon set it true to arm them
        /// </summary>
        /// <param name="armor">default false AKA none, true to arm</param>
        /// <param name="weapon">default false AKA none, true to arm</param>
        public override void improve(bool armor, bool weapon)
        {

            if (!this.weapon)
            {
                this.weapon = weapon;
                if (weapon)
                {
                    minDamage = 2;
                    maxDamage = 3;
                }

            }
        }
    }
}

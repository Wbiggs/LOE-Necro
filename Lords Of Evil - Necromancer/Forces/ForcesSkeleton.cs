using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lords_Of_Evil___Necromancer.Forces
{
    public class ForcesSkeleton : Force
    {
        public ForcesSkeleton() 
        {
            name = "Skeleton";
            health= 1;
            maxHealth= 1;
            armor = false; 
            weapon = false;
            minDamage= 1;
            maxDamage= 3;
        }

        /// <summary>
        /// First bool is for armor, set it true to arm them, second bool is for weapon set it true to arm them
        /// </summary>
        /// <param name="armor">default false AKA none, true to arm</param>
        /// <param name="weapon">default false AKA none, true to arm</param>
        public override void improve(bool armor,bool weapon)
        {
            if (!this.armor) 
            {
                this.armor = armor;
                if (armor) 
                {
                    health ++; 
                    health ++; 
                    maxHealth++;
                    maxHealth++;
                }

            }
            if (!this.weapon) 
            {
                this.weapon = weapon;
                if(weapon) 
                {
                    minDamage = 3;
                    maxDamage = 4;
                }

            }
        }
    }
}

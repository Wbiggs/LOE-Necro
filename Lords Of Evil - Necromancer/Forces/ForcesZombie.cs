using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Lords_Of_Evil___Necromancer.Forces
{
    public  class ForcesZombie:Force
    {
        public ForcesZombie()
        {
            name = "Zombie";
            health = 3;
            maxHealth = 3;
            armor = false;
            weapon = false;
            minDamage = 1;
            maxDamage = 3;
        }

        public override void improve(bool armor, bool weapon)
        {
            if (!this.armor)
            {
                this.armor = armor;
                if (armor)
                {
                    health++;
                    health++;
                    maxHealth++;
                    maxHealth++;
                }

            }
            if (!this.weapon)
            {
                this.weapon = weapon;
                if (weapon)
                {
                    minDamage = 3;
                    maxDamage = 6;
                }

            }
        }
    }
}

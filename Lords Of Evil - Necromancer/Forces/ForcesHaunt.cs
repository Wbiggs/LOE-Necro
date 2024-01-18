using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lords_Of_Evil___Necromancer.Forces
{
    internal class ForcesHaunt : Force
    {
        public ForcesHaunt()
        {
            name = "Haunt";
            health = 1;
            maxHealth = 1;
            armor = false;
            weapon = false;
            minDamage = 1;
            maxDamage = 1;
        }
        public override void improve(bool armor, bool weapon)
        {
            throw new NotImplementedException();
        }
    }
}

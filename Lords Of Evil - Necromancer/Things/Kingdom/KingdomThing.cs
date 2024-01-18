using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lords_Of_Evil___Necromancer.Things.Kingdom
{
    public abstract class KingdomThing : Thing
    {
        public List<LocationInfo> location;
        public List<LocationInfo> locationPrioritization;

        public int health { get; set; }
        public int maxHealth { get; set; }
        public int minDamage { get; set; }
        public int maxDamage { get; set; }

        public KingdomThing(string name, Map map) : base(name, map)
        {
            
        }

        public abstract void endOfTurnActions();

    }
}

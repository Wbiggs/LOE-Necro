using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lords_Of_Evil___Necromancer.Things
{
    //This is objects that exist on the main map, create a spell, add spell to player, add spell to menupop up
    public abstract class Thing
    {

        public int row;
        public int col;
        public string name { get; set; }
        public Map map { get; set; }

        public Thing(string name, Map map)
        {
            this.name = name;
            this.map = map;
        }

        public abstract void usesThing();


    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lords_Of_Evil___Necromancer.Things.Kingdom
{

    public class KingdomSpearman : KingdomThing
    {
        Random random;
        
        public KingdomSpearman(string name, Map map,int row,int col) : base(name, map)
        {
            health = 6;
            maxHealth = 6;
            minDamage=2; 
            maxDamage=4;
            this.row = row;
            this.col = col;

            random = new Random();
            location = new List<LocationInfo>();
            locationPrioritization = new List<LocationInfo>();
        }

        public override void endOfTurnActions()
        {
            location.Clear();
            int sight = 1;
            //this should itterate through all locations and only grab the ones withing X distance
            foreach (LocationInfo loc in map.allLocations)
            {

                if (loc.row >= row - sight && loc.row <= row + sight)  
                {
                    if (loc.column >= col - sight && loc.column <= col + sight)
                    {
                        location.Add(loc);
                    }
                }
            }

            //The idea is this, each location starts with 2 prioritization, this can be reduced or added to
            foreach (LocationInfo loc in location)
            {
                locationPrioritization.Add(loc);
                locationPrioritization.Add(loc);
            }

            //x2-x1,y2-y1, take the largest of the two.  That's the distance to the desired location

            int x = location.Count;
            int chance = random.Next(0, location.Count-1);
            map.allLocations[location[chance].row, location[chance].column].Things.Add(this);
            map.allLocations[row, col].Things.Remove(this);


            map.allLocations[row, col].listBox.ItemsSource = null;
            map.allLocations[row, col].listBox.ItemsSource = map.allLocations[row, col].Things;


            map.allLocations[location[chance].row, location[chance].column].listBox.ItemsSource = null;
            map.allLocations[location[chance].row, location[chance].column].listBox.ItemsSource = map.allLocations[location[chance].row, location[chance].column].Things;

            row = location[chance].row;
            col = location[chance].column;
            /*if (chance < 3 && row >0) //This is a random motion
            {

                map.allLocations[row, col].Things.Remove(this);
                map.allLocations[row, col].listBox.ItemsSource = null;
                map.allLocations[row, col].listBox.ItemsSource = map.allLocations[row, col].Things;
                row --;
                map.allLocations[row,col].Things.Add(this);
                map.allLocations[row, col].listBox.ItemsSource = null;
                map.allLocations[row, col].listBox.ItemsSource = map.allLocations[row, col].Things;

            }*/

        }

        public override void usesThing()
        {
            throw new NotImplementedException();
        }


    }
}

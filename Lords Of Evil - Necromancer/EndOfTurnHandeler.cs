using Lords_Of_Evil___Necromancer.Things.Kingdom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lords_Of_Evil___Necromancer
{
    public class EndOfTurnHandeler
    {
        Map map;
        public List<KingdomThing> theKingdom;
        //public LocationInfo[,] Locations;
        public EndOfTurnHandeler(Map map) 
        {
            this.map = map;
            //Locations = new LocationInfo[map.r, map.c]; 
            theKingdom= new List<KingdomThing>();
        }

        public void nextTurn()
        {
            theKingdom.Clear(); //gets rid of all kingdom guys in list
            //this will look in each list on the map and run through their end of turn actions
            foreach (LocationInfo loc in map.allLocations) 
            {
                //int temprow = loc.row;
                //int tempcol = loc.column;
                foreach(Things.Thing character in loc.Things) 
                {
                    //int cnt = loc.Things.IndexOf(character);

                    if (character is Things.Kingdom.KingdomThing) //Takes care of all kingdom guys on map
                    {

                        /*map.allLocations[temprow-1, tempcol].Things.Add(character);
                        map.allLocations[temprow, tempcol].Things.RemoveAt(cnt);
                        Things.Kingdom.KingdomThing standin = (Things.Kingdom.KingdomThing)character;
                        Things.Kingdom.KingdomThing thmb = (Things.Kingdom.KingdomThing)map.allLocations[temprow, tempcol].Things[cnt];
                        thmb.endOfTurnActions();*/
                        theKingdom.Add((Things.Kingdom.KingdomThing)character);
                    }
                    
                }
            }  //This fails because it's altering the loop it's in

            foreach (KingdomThing character in theKingdom) 
            {
                character.endOfTurnActions();
            }
            
        }
    }
}

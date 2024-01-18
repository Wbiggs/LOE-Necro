using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lords_Of_Evil___Necromancer.Forces;
using Lords_Of_Evil___Necromancer.Spells;

namespace Lords_Of_Evil___Necromancer.Things
{
    public class Player : Thing
    {
        public int bonesCollected { get; set; }
        public int fleshCollected { get; set; }
        public int oreCollected { get; set; }
        public int magicCollected { get; set; }
        public int turn { get; set; }
        public int move { get; set; }
        public int maxMove { get; set; }
        //public LocationInfo li { get; set; }//I don't think this is necessary right now
        public List<Spell> spells { get; set; }
        public List<Force> ArmyRising { get; set; }


        Map thisMap;

        public Player(string name, Map thisMap) : base(name, thisMap)
        {
            this.thisMap = thisMap;
            turn = 0;
            maxMove = 3;
            move = maxMove;
            bonesCollected = 0;
            fleshCollected = 0;
            oreCollected = 0;
            magicCollected = 0;

            //add spell to menupopup
            spells = new List<Spell>();
            spells.Add(new SpellDeathSpeed(this, thisMap));
            spells.Add(new SpellDanseMacabre(this, thisMap));
            spells.Add(new SpellRaiseZombie(this, thisMap));
            spells.Add(new SpellKnitFlesh(this, thisMap));
            spells.Add(new SpellBuildFleshGolem(this, thisMap));
            spells.Add(new SpellBonePile(this, thisMap));
            spells.Add(new SpellSummonWanderingSpiritcs(this, thisMap));
            spells.Add(new SpellSummonHaunt(this, thisMap));

            ArmyRising = new List<Force>();
        }

        public override void usesThing()
        {
            thisMap.menuPopUp.row = row;
            thisMap.menuPopUp.col = col;
            thisMap.updateXY();
            thisMap.menuPopUp.populateScreen();
            MauiPopup.PopupAction.DisplayPopup(thisMap.menuPopUp);
        }



        enum keyPress
        {
            W,
            A,
            S,
            D
        }


    }
}

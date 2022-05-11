using DIKUArcade.Entities;
using DIKUArcade.Graphics;
using System.Collections.Generic;
using System.IO;

namespace Breakout.Blocks{
    public class HealableBlock : BreakoutBlock {
        public DynamicShape shape;
        public HealableBlock(DynamicShape Shape, IBaseImage image) : base(Shape, image) {
            hitPoints = 10;
            value = 200;
            shape = Shape;
        }
        public int GetHP(){
            return hitPoints;
        }
        public override void Hit() {
           hitPoints -= 5;
        }
        public override bool Dead() {
            if (hitPoints <= 0) {
              //  score = score + value;
                return true;
            } else {return false;}
        }
        public void iterateHeal() {
            //healEvent = new TimedGameEvent.HasExpired(); //Figure it out later
            //if (healEvent == true){hitPoints += 2;}
            //if TimeGameEvent has expired then increment hp
        }
    }
}
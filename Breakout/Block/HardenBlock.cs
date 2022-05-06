/*using DIKUArcade.Entities;
using DIKUArcade.Graphics;
using System.Collections.Generic;
using System.IO;

namespace Breakout.Blocks{
    public class HardenBlock : BreakoutBlock {
        public override int hitPoints {get {return hitPoints;} }
        public override int value {get {return value;} }
        public override void Hit() {
            hitPoints -= 1; 
        }
        public override void Dead() {
            if(hitPoints <= 0) {return true;}
            return false; 
        }
        public void Broken() {
            if (hitPoints < maxHitPoints/2) {return true;}
            return false; 
        }
        public HardenBlock(DynamicShape Shape, IBaseImage image) : base(Shape, image) {}
    }
}*/
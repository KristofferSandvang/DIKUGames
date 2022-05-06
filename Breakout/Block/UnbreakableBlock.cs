using DIKUArcade.Entities;
using DIKUArcade.Graphics;
using System.Collections.Generic;
using System.IO;

namespace Breakout.Blocks{
    public class UnbreakableBlock : BreakoutBlock {
        public override int hitPoints {get {return hitPoints;} }
        public override int value {get {return value;} }
        public override void Hit() {
            //If can be broken once every other block gone, implement if statement
        }
        public override void Dead() {
            if(hitPoints <= 0) {} 
            //add score
            //remove from entity container
        }
        public UnbreakableBlock(DynamicShape Shape, IBaseImage image) : base(Shape, image) {}
    }
}
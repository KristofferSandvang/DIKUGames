using DIKUArcade.Entities;
using DIKUArcade.Graphics;
using System.Collections.Generic;
using System.IO;
#pragma warning disable 414
namespace Breakout.Blocks {
    public class StandardBlock : BreakoutBlock {
        public DynamicShape shape;
        public StandardBlock(DynamicShape Shape, IBaseImage image) : base(Shape, image) {
            hitPoints = 10;
            value = 100;
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
                return true;
            } else {return false;}
        }

        
    }
}

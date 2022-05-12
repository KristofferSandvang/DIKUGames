using DIKUArcade.Entities;
using DIKUArcade.Graphics;
using System.Collections.Generic;
using System.IO;
#pragma warning disable 414
namespace Breakout.Blocks {
    public class HungryBlock : BreakoutBlock {
        public DynamicShape shape;
        public HungryBlock(DynamicShape Shape, IBaseImage image) : base(Shape, image) {
            hitPoints = 10;
            value = 500;
            shape = Shape;
        }
        public int GetHP(){
            return hitPoints;
        }
        public override void Hit() {
           hitPoints -= 5;
           Ball.DeleteEntity();
           
        }
        public override bool Dead() {
            if (hitPoints <= 0) {
                Score.AddScore(value);
                return true;
            } else {return false;}
        }

        
    }
}

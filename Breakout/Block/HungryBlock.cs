/*using DIKUArcade.Entities;
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
        /// <summary>
        /// Determines what happens with a block when hit.
        /// </summary>
        public override void Hit() {
           hitPoints -= 5;
           Ball.DeleteEntity();
           
        }
        /// <summary>
        /// Determines whether the ball is dead or not
        /// </summary>
        /// <returns>
        /// Returns true if the block is dead and false if not.
        /// </returns> 
        public override bool Dead() {
            if (hitPoints <= 0) {
                Score.AddScore(value);
                return true;
            } else {return false;}
        }

        
    }
}
*/
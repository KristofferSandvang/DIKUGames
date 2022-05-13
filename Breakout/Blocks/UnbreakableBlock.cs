using DIKUArcade.Entities;
using DIKUArcade.Graphics;
using System.Collections.Generic;
using System.IO;

namespace Breakout.Blocks{
    public class UnbreakableBlock : BreakoutBlock {
        /// <summary>
        /// Determines what happens with a block when hit.
        /// </summary>
        public override void Hit() {
        }
        /// <summary>
        /// Determines whether the ball is dead or not
        /// </summary>
        /// <returns>
        /// Returns true if the block is dead and false if not.
        /// </returns> 
        public override bool IsDead() {
            return false;
        }
        public UnbreakableBlock(DynamicShape Shape, IBaseImage image) : base(Shape, image) {
            hitPoints = 10;
            value = 0;
            shape = Shape;
        }
    }
}
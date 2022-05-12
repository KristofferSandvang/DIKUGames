using DIKUArcade.Entities;
using DIKUArcade.Graphics;
using System.Collections.Generic;
using System.IO;

namespace Breakout.Blocks {
    public abstract class BreakoutBlock : Entity {
        public DynamicShape shape;
        /// <summary>
        /// Determines what happens with a block when hit.
        /// </summary>
        public abstract void Hit();
        /// <summary>
        /// Determines whether the ball is dead or not
        /// </summary>
        /// <returns>
        /// Returns true if the block is dead and false if not.
        /// </returns> 
        public abstract bool Dead();
        public int value {get; protected set;}
        public int hitPoints {get; protected set; }
        public BreakoutBlock(DynamicShape Shape, IBaseImage image) : base(Shape, image) {
            shape = Shape;
        }
    }
}

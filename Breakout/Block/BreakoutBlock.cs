using DIKUArcade.Entities;
using DIKUArcade.Graphics;
using System.Collections.Generic;
using System.IO;

namespace Breakout.Blocks {
    public abstract class BreakoutBlock : Entity {
        public DynamicShape shape;
        public abstract void Hit();
        public abstract bool Dead();
        public int value {get; protected set;}
        public int hitPoints {get; protected set; }
        public BreakoutBlock(DynamicShape Shape, IBaseImage image) : base(Shape, image) {
            shape = Shape;
        }
    }
}

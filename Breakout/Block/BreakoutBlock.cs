using DIKUArcade.Entities;
using DIKUArcade.Graphics;
using System.Collections.Generic;
using System.IO;

namespace Breakout.Blocks {
    public abstract class BreakoutBlock : Entity {
        public abstract void Hit();
        public abstract void Dead();
        public abstract int value {get;}
        public abstract int hitPoints {get;}
        public BreakoutBlock(DynamicShape Shape, IBaseImage image) : base(Shape, image) {}
    }
}

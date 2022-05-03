using DIKUArcade.Entities;
using DIKUArcade.Graphics;
using System.Collections.Generic;
using System.IO;

namespace Breakout.Blocks {
    public abstract class BreakoutBlock : Entity {
        public abstract void Hit();
        public abstract void Dead();
        public abstract int value { get; private set;}
        public abstract int hitPoints { get; private set; }
        public Block(DynamicShape Shape, IBaseImage image) : base(Shape, image) {}
    }
}

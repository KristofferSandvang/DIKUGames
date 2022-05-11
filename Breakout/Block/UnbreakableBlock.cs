using DIKUArcade.Entities;
using DIKUArcade.Graphics;
using System.Collections.Generic;
using System.IO;

namespace Breakout.Blocks{
    public class UnbreakableBlock : BreakoutBlock {
        public override void Hit() {
        }
        public override bool Dead() {
            return false;
        }
        public UnbreakableBlock(DynamicShape Shape, IBaseImage image) : base(Shape, image) {
            hitPoints = 10;
            value = 200;
            shape = Shape;
        }
    }
}
using DIKUArcade.Entities;
using DIKUArcade.Graphics;
using System.Collections.Generic;
using System.IO;

namespace Breakout{
    public class Block : Entity {
        public Block(DynamicShape Shape, IBaseImage image) : base(Shape, image) {}
    }
}

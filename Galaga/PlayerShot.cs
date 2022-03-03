using DIKUArcade.Entities;
using DIKUArcade.Math;
using DIKUArcade.Graphics;

namespace Galaga {
    class PlayerShot : Entity {
        private static Vec2F extent = new Vec2F(0.008f, 0.021f);
        private static Vec2F direction = new Vec2F(0.0f, 0.1f);
        private Vec2F position;
        public PlayerShot(Vec2F pos, IBaseImage image) : base(new DynamicShape(pos, extent), image) {
            position = pos;
        }
    }
}
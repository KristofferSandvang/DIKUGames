using DIKUArcade.Math;
using Breakout.PowerUps;
using DIKUArcade.Graphics;
using DIKUArcade.Entities;

namespace Breakout.Blocks.PowerUpFactories {
    public class MoreTimeFactory : PowerUpFactory {
        public override PowerUp CreatePowerUp(Vec2F pos) {
            return new MoreTime(new DynamicShape(pos, new Vec2F(0.025f, 0.025f)), extraLifeImg);
        }
    }
}
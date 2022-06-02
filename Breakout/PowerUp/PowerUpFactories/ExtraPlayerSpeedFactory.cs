using DIKUArcade.Math;
using Breakout.PowerUps;
using DIKUArcade.Graphics;
using DIKUArcade.Entities;

namespace Breakout.PowerUps.PowerUpFactories {
    public class ExtraPlayerSpeedFactory : PowerUpFactory {
        public override PowerUp CreatePowerUp(Vec2F pos) {
            return new ExtraPlayerSpeed(new DynamicShape(pos, new Vec2F(0.025f, 0.025f)), extraSpeedImg);
        }
    }
}
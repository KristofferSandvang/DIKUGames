using DIKUArcade.Math;
using Breakout.PowerUps;
using DIKUArcade.Graphics;
using DIKUArcade.Entities;

namespace Breakout.PowerUps.PowerUpFactories {
    public class ExtraWidthFactory : PowerUpFactory {
        /// <summary>
        /// Creates a PowerUP
        /// </summary>
        /// <returns>
        /// A PowerUP
        /// </returns>
        public override PowerUp CreatePowerUp(Vec2F pos) {
            return new ExtraWidth(new DynamicShape(pos, new Vec2F(0.05f, 0.05f)), extraWidthImg);
        }
    }
}
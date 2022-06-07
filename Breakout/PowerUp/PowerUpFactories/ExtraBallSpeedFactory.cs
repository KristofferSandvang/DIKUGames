using DIKUArcade.Math;
using DIKUArcade.Entities;

namespace Breakout.PowerUps.PowerUpFactories {
    /// <summary>
    /// A factory that creates the ExtraBallSpeed
    /// </summary>
    public class ExtraBallSpeedFactory : PowerUpFactory {
        /// <summary>
        /// Creates a PowerUP
        /// </summary>
        /// <returns>
        /// A PowerUP
        /// </returns>
        public override PowerUp CreatePowerUp(Vec2F pos) {
            return new ExtraBallSpeed(new DynamicShape(pos, new Vec2F(0.05f, 0.05f)), ballSpeedImg);
        }
    }
}
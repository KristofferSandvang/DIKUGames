using DIKUArcade.Math;
using DIKUArcade.Entities;

namespace Breakout.PowerUps.PowerUpFactories {
    /// <summary>
    /// A factory that creates the ExtraPlayerSpeed Powerup
    /// </summary>
    public class ExtraPlayerSpeedFactory : PowerUpFactory {
        /// <summary>
        /// Creates a PowerUP
        /// </summary>
        /// <returns>
        /// A PowerUP
        /// </returns>
        public override PowerUp CreatePowerUp(Vec2F pos) {
            return new ExtraPlayerSpeed(new DynamicShape(pos, new Vec2F(0.025f, 0.025f)), extraSpeedImg);
        }
    }
}
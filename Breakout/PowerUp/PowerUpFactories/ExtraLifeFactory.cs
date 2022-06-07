using DIKUArcade.Math;
using DIKUArcade.Entities;

namespace Breakout.PowerUps.PowerUpFactories {
    /// <summary>
    /// A factory that creates the ExtraLife Powerup
    /// </summary>
    public class ExtraLifeFactory : PowerUpFactory {
        /// <summary>
        /// Creates a PowerUP
        /// </summary>
        /// <returns>
        /// A PowerUP
        /// </returns>
        public override PowerUp CreatePowerUp(Vec2F pos) {
            return new ExtraLife(new DynamicShape(pos, new Vec2F(0.025f, 0.025f)), extraLifeImg);
        }
    }
}
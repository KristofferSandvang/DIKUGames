using DIKUArcade.Math;
using DIKUArcade.Graphics;
using DIKUArcade.Utilities;

namespace Breakout.PowerUps.PowerUpFactories {
    /// <summary>
    /// PowerUpFactory is the abstract class that all factories creating powerups inherit from. 
    /// </summary>
    public abstract class PowerUpFactory {
        protected IBaseImage extraLifeImg = new Image (
            Path.Combine(FileIO.GetProjectPath(), "Assets", "Images", "LifePickUp.png"));
        protected IBaseImage extraTimeImg = new Image (
            Path.Combine(FileIO.GetProjectPath(), "Assets", "Images", "ClockPickUp.png"));
        protected IBaseImage extraWidthImg = new Image (
            Path.Combine(FileIO.GetProjectPath(), "Assets", "Images", "WidePowerUp.png"));
        protected IBaseImage extraSpeedImg = new Image (
            Path.Combine(FileIO.GetProjectPath(), "Assets", "Images", "DoubleSpeedPowerUp.png"));
        protected IBaseImage ballSpeedImg = new Image (
            Path.Combine(FileIO.GetProjectPath(), "Assets", "Images", "BallSpeedier.png"));
        /// <summary>
        /// Creates a PowerUP
        /// </summary>
        /// <returns>
        /// A PowerUP
        /// </returns>
        public abstract PowerUp CreatePowerUp (Vec2F pos);
    }
}
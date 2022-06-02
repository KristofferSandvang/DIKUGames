using DIKUArcade.Math;
using Breakout.PowerUps;
using DIKUArcade.Graphics;
using DIKUArcade.Utilities;

namespace Breakout.PowerUps.PowerUpFactories {
    public abstract class PowerUpFactory {
        protected IBaseImage extraLifeImg = new Image (
            Path.Combine(FileIO.GetProjectPath(), "Assets", "Images", "LifePickUp.png"));
        protected IBaseImage extraTimeImg = new Image (
            Path.Combine(FileIO.GetProjectPath(), "Assets", "Images", "ClockPickUp.png"));
        protected IBaseImage extraWidthImg = new Image (
            Path.Combine(FileIO.GetProjectPath(), "Assets", "Images", "WidePowerUp.png"));
        protected IBaseImage extraSpeedImg = new Image (
            Path.Combine(FileIO.GetProjectPath(), "Assets", "Images", "DoubleSpeedPowerUp.png"));
        public abstract PowerUp CreatePowerUp (Vec2F pos);
    }
}
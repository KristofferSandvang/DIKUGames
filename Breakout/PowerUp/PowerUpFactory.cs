using System.IO;
using DIKUArcade.Entities;
using DIKUArcade.Graphics;
using DIKUArcade.Utilities;
using DIKUArcade.Math;
using Breakout.Blocks;

namespace Breakout.PowerUps {
    public static class PowerUpFactory1 {
        private static IBaseImage extraLifeImg = new Image (
            Path.Combine(FileIO.GetProjectPath(), "Assets", "Images", "LifePickUp.png"));
        private static IBaseImage extraTimeImg = new Image (
            Path.Combine(FileIO.GetProjectPath(), "Assets", "Images", "ClockPickUp.png"));
        private static IBaseImage extraWidthImg = new Image (
            Path.Combine(FileIO.GetProjectPath(), "Assets", "Images", "WidePowerUp.png"));
        public static PowerUp SpawnPowerUp(Vec2F pos, PowerUpType powerUpType) {
            switch (powerUpType) {
                case PowerUpType.ExtraLife: 
                    PowerUp powerUp = new ExtraLife(
                        new DynamicShape(pos, new Vec2F(0.025f, 0.025f)),
                        PowerUpFactory1.extraLifeImg);
                    return powerUp;
                case PowerUpType.ExtraTime:
                    PowerUp MoreTime = new MoreTime(
                        new DynamicShape(pos, new Vec2F(0.05f, 0.05f)),
                        PowerUpFactory1.extraTimeImg);
                    return MoreTime;
                case PowerUpType.ExtraWidth:
                    PowerUp ExtraWidth = new ExtraWidth(
                        new DynamicShape(pos, new Vec2F(0.05f, 0.05f)),
                        PowerUpFactory1.extraWidthImg);
                    return ExtraWidth;
                default: 
                    PowerUp fjol = new ExtraLife(
                        new DynamicShape(pos, new Vec2F(0.025f, 0.025f)),
                        PowerUpFactory1.extraLifeImg);
                    return fjol;
            }
            
        }
    }
}

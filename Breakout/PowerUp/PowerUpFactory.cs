using System.IO;
using DIKUArcade.Entities;
using DIKUArcade.Graphics;
using DIKUArcade.Utilities;
using DIKUArcade.Math;
using Breakout.Blocks;

namespace Breakout.PowerUps {
    public class PowerUpFactory {
        private static IBaseImage extraLifeImg = new Image (
            Path.Combine(FileIO.GetProjectPath(), "Assets", "Images", "LifePickUp.png"));
        public static PowerUp SpawnPowerUp(BreakoutBlock block) {
            Vec2F pos = block.shape.Position;
            pos.X = block.shape.Position.X + 0.5f * block.shape.Extent.X;
            ExtraLife powerUp = new ExtraLife(
                new DynamicShape(pos, new Vec2F(0.05f, 0.05f)),
                PowerUpFactory.extraLifeImg);
            return powerUp;
        }
    }
}

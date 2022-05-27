using DIKUArcade.Entities;
using DIKUArcade.Graphics;
using System.Collections.Generic;
using System.IO;
using DIKUArcade.Math;
using DIKUArcade.Utilities;
using Breakout.PowerUps;
namespace Breakout.Blocks {
    public class BreakoutBlockFactory {
        public BreakoutBlockFactory() {}

        public static BreakoutBlock Create(BlockType blockType, string imgName, Vec2F pos, bool PowerUp) {
            string fileName = Path.Combine(FileIO.GetProjectPath(), "Assets", "Images", imgName);
            switch (blockType) {
                case BlockType.Hardened:
                    int index = imgName.IndexOf('.');
                    string broken = Path.Combine(FileIO.GetProjectPath(), "Assets", 
                                            "Images", imgName.Insert(index, "-damaged"));
                    BreakoutBlock HardenedBlock = new HardenedBlock (
                        new DynamicShape((pos), new Vec2F(0.08f, 0.04f)),
                        new Image(fileName), new Image(broken), PowerUp);
                    return HardenedBlock;

                case BlockType.Unbreakable:
                    BreakoutBlock UnbreakableBlock = new UnbreakableBlock (
                        new DynamicShape((pos), new Vec2F(0.08f, 0.04f)),
                        new Image(fileName), PowerUp);
                    return UnbreakableBlock;

                default:
                    BreakoutBlock StandardBlock = new StandardBlock (
                        new DynamicShape((pos), new Vec2F(0.08f, 0.04f)),
                        new Image(imgName), PowerUp);
                    return StandardBlock;
            }
        }
    }
}

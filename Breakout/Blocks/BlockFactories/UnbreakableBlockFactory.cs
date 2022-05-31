using DIKUArcade.Entities;
using DIKUArcade.Math;
using DIKUArcade.Graphics;
using DIKUArcade.Utilities;
namespace Breakout.Blocks.BlockFactories {
    public class UnbreakableBlockFactory : BlockFactory {
        
        public override BreakoutBlock CreateBlock(string imgName,  Vec2F pos, bool PowerUp) {
            string fileName = Path.Combine(FileIO.GetProjectPath(), "Assets", "Images", imgName);

            BreakoutBlock temp = new UnbreakableBlock(new DynamicShape(pos, new Vec2F(0.08f, 0.04f)), 
                new Image(fileName), PowerUp);
                
            return temp;
        }
    }
}
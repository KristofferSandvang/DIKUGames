using DIKUArcade.Entities;
using DIKUArcade.Math;
using DIKUArcade.Graphics;
using DIKUArcade.Utilities;
namespace Breakout.Blocks.BlockFactories {
    public class HealAbleBlockFactory : BlockFactory {
        
        public override BreakoutBlock CreateBlock(string imgName,  Vec2F pos, bool PowerUp) {
            string fileName = Path.Combine(FileIO.GetProjectPath(), "Assets", "Images", imgName);

            BreakoutBlock Healable = new HealableBlock (new DynamicShape(pos, new Vec2F(0.08333334f, 0.028f)), 
                new Image(fileName), PowerUp);
                
            return Healable;
        }
    }
}
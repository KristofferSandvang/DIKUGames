using DIKUArcade.Entities;
using DIKUArcade.Graphics;
using DIKUArcade.Math;
using DIKUArcade.Utilities;

namespace Breakout.Blocks.BlockFactories {
    
    public class HardenedBlockFactory : BlockFactory {
        
        public override BreakoutBlock CreateBlock(string imgName,  Vec2F pos, bool PowerUp) {
            int index = imgName.IndexOf('.');
            string broken = Path.Combine(FileIO.GetProjectPath(), "Assets", 
                "Images", imgName.Insert(index, "-damaged"));
                
            BreakoutBlock HardenedBlock = new HardenedBlock (
                new DynamicShape((pos), new Vec2F(0.08333334f, 0.028f)),
                new Image(imgName), new Image(broken), PowerUp);
            return HardenedBlock; 
        }
    }
}
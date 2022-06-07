using DIKUArcade.Entities;
using DIKUArcade.Graphics;
using DIKUArcade.Math;
using DIKUArcade.Utilities;

namespace Breakout.Blocks.BlockFactories {
        /// <summary>
        /// The HardenedBlockFactory will instansiate the HardenedBlock Type.
        /// </summary>
    public class HardenedBlockFactory : BlockFactory {
        /// <summary>
        /// Creates a BreakoutBlock
        /// </summary>
        /// <returns>
        /// A BreakoutBlock 
        /// </returns> 
        public override BreakoutBlock CreateBlock(string imgName,  Vec2F pos, bool PowerUp) {
            string nonBroken = Path.Combine(FileIO.GetProjectPath(), "Assets", 
                "Images", imgName);

            int index = imgName.IndexOf('.');
            string broken = Path.Combine(FileIO.GetProjectPath(), "Assets", 
                "Images", imgName.Insert(index, "-damaged"));
                
            BreakoutBlock HardenedBlock = new HardenedBlock (
                new DynamicShape((pos), new Vec2F(0.08333334f, 0.028f)),
                new Image(nonBroken), new Image(broken), PowerUp);
            return HardenedBlock; 
        }
    }
}
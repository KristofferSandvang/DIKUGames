using DIKUArcade.Entities;
using DIKUArcade.Math;
using DIKUArcade.Graphics;
using DIKUArcade.Utilities;

namespace Breakout.Blocks.BlockFactories {
            /// <summary>
            /// The UnbreakableBlockFactory will instansiate the UnbreakableBlock Type.
            /// </summary>
    public class UnbreakableBlockFactory : BlockFactory {
        /// <summary>
        /// Creates a BreakoutBlock
        /// </summary>
        /// <returns>
        /// A BreakoutBlock 
        /// </returns> 
        public override BreakoutBlock CreateBlock(string imgName,  Vec2F pos, bool PowerUp) {
            string fileName = Path.Combine(FileIO.GetProjectPath(), "Assets", "Images", imgName);

            BreakoutBlock temp = new UnbreakableBlock(new DynamicShape(pos, new Vec2F(0.08333334f, 0.028f)), 
                new Image(fileName), PowerUp);
                
            return temp;
        }
    }
}
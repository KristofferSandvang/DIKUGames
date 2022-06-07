using DIKUArcade.Entities;
using DIKUArcade.Math;
using DIKUArcade.Graphics;
using DIKUArcade.Utilities;

namespace Breakout.Blocks.BlockFactories {
            /// <summary>
            /// The SwitchBlockFactory will instansiate the SwitchBlock Type.
            /// </summary>
    public class SwitchBlockFactory : BlockFactory {
        /// <summary>
        /// Creates a BreakoutBlock
        /// </summary>
        /// <returns>
        /// A BreakoutBlock 
        /// </returns> 
        public override BreakoutBlock CreateBlock(string imgName,  Vec2F pos, bool PowerUp) {
            string fileName = Path.Combine(FileIO.GetProjectPath(), "Assets", "Images", imgName);

            SwitchBlock temp = new SwitchBlock(new DynamicShape(pos, new Vec2F(0.08333334f, 0.028f)), 
                new Image(fileName), PowerUp);
                
                
            return temp;
        }
    }
}
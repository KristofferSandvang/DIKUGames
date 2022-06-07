using DIKUArcade.Entities;
using DIKUArcade.Math;
using DIKUArcade.Graphics;
using DIKUArcade.Utilities;
using Breakout.Blocks; 
using System.Collections.Generic;

namespace Breakout.Blocks.BlockFactories {
    public class SwitchRecieverBlockFactory : BlockFactory {
        /// <summary>
        /// Creates a BreakoutBlock
        /// </summary>
        /// <returns>
        /// A BreakoutBlock 
        /// </returns> 
        public override BreakoutBlock CreateBlock(string imgName,  Vec2F pos, bool PowerUp) {
            string fileName = Path.Combine(FileIO.GetProjectPath(), "Assets", "Images", imgName);

            SwitchRecieverBlock Reciever = new SwitchRecieverBlock(new DynamicShape(pos, new Vec2F(0.08334f, 0.028f)), 
                new Image(fileName), PowerUp);

            SwitchBlock.switchRecieverList.Add(Reciever);
            return Reciever;
        }
    }
}
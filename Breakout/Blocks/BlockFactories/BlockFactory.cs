using Breakout.Blocks;
using DIKUArcade.Math;

namespace Breakout.Blocks.BlockFactories {
    public abstract class BlockFactory {
        /// <summary>
        /// Creates a BreakoutBlock
        /// </summary>
        /// <returns>
        /// A BreakoutBlock 
        /// </returns> 
        public abstract BreakoutBlock CreateBlock(string imgName,  Vec2F pos, bool PowerUp);
    }
}
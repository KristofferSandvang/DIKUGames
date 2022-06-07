using DIKUArcade.Entities;
using DIKUArcade.Graphics;


namespace Breakout.Blocks{
    /// <summary>
    /// The SwitchRecieverBlock is a type of block that will not take damage from a ball collission
    /// The SwitchRecieverBlock can only die by a signal from the SwitchBlock and can never die from a ball collission
    /// </summary>
    public class SwitchRecieverBlock : BreakoutBlock {
        /// <summary>
        /// Determines what happens with a block when hit.
        /// </summary>
        public override void Hit() {
        }
        /// <summary>
        /// Determines whether the ball is dead or not
        /// </summary>
        /// <returns>
        /// Returns true if the block is dead and false if not.
        /// </returns> 
        public override bool IsDead() {
            return false;
        }
        public SwitchRecieverBlock(DynamicShape Shape, IBaseImage image, bool powerUp) : base(Shape, image, powerUp) {
            hitPoints = 10;
            value = 100;
            SwitchBlock.switchRecieverList.AddEntity(this);
        }
    }  
}

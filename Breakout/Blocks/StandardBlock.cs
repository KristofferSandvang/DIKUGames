using DIKUArcade.Entities;
using DIKUArcade.Graphics;
using DIKUArcade.Events;

namespace Breakout.Blocks {
    /// <summary>
    /// The StandardBlock is the standard block type, which will be deleted, when enough damage is taken
    /// </summary>
    public class StandardBlock : BreakoutBlock {

        public StandardBlock(DynamicShape Shape, IBaseImage image, bool powerUp) : base(Shape, image, powerUp) {
            hitPoints = 10;
            value = 100;
        }
        /// <summary>
        /// Determines whether the block is dead or not and adds its value to the score. 
        /// </summary>
        public override bool IsDead(){
             if (hitPoints <= 0) {
                BreakoutBus.GetBus().RegisterEvent(
                    new GameEvent{
                        EventType = GameEventType.StatusEvent,
                        Message = "AddPoints",
                        IntArg1 = value,
                    });
                return true;
            } else {return false;}
        }
        /// <summary>
        /// Determines what happens with a block when hit.
        /// </summary>
        public override void Hit() {
           hitPoints -= 10;
        }
    }
}

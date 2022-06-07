using DIKUArcade.Entities;
using DIKUArcade.Graphics;
using DIKUArcade.Events;

namespace Breakout.Blocks{
    /// <summary>
    /// The Unbreakable is a type of block that can never be destroyed
    /// </summary>
    public class UnbreakableBlock : BreakoutBlock {
        public override void Hit() {}
        
        /// <summary>
        /// Determines what happens with a block when hit.
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
        public UnbreakableBlock(DynamicShape Shape, IBaseImage image, bool powerUp) 
                : base(Shape, image, powerUp) {
            hitPoints = 10;
            value = 100;
            shape = Shape;
        }
    }
}
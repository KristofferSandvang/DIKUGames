using DIKUArcade.Entities;
using DIKUArcade.Graphics;
using DIKUArcade.Events;

namespace Breakout.Blocks{
    /// <summary>
    /// The SwitchBlock is a type of block that deletes all the SwitchRecieverBlocks, when a ball collission occured.
    /// </summary>
    public class SwitchBlock : BreakoutBlock{
        public static EntityContainer<SwitchRecieverBlock> switchRecieverList =
            new EntityContainer<SwitchRecieverBlock>(); 
        /// <summary>
        /// Determines what happens with a block when hit.
        /// </summary>
        public override void Hit() {
            hitPoints -= 10;
            switchRecieverList.Iterate(block => block.DeleteEntity());
        }
        /// <summary>
        /// Determines whether the block is dead or not and adds its value to the score. 
        /// </summary>
        public override bool IsDead() {
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

       public SwitchBlock(DynamicShape Shape, IBaseImage image, bool powerUp) : base(Shape, image, powerUp) {
            hitPoints = 10;
            value = 200;
            shape = Shape;
        }
    } 
} 
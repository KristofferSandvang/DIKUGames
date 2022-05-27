using DIKUArcade.Entities;
using DIKUArcade.Graphics;
using DIKUArcade.Events;
using System.Collections.Generic;
using System.IO;

namespace Breakout.Blocks{
    public class UnbreakableBlock : BreakoutBlock {
        /// <summary>
        /// Determines what happens with a block when hit.
        /// </summary>
        public override void Hit() {}
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
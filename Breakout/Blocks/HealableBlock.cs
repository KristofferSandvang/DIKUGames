using DIKUArcade.Timers;
using static DIKUArcade.Events.TimedGameEvent;
using DIKUArcade.Entities;
using DIKUArcade.Graphics;
using System.Collections.Generic;
using System.IO;
using DIKUArcade.Events;

namespace Breakout.Blocks{
    public class HealableBlock : BreakoutBlock {

        public HealableBlock(DynamicShape Shape, IBaseImage image, bool power) : base(Shape, image, power) {
            hitPoints = 15;
            value = 200;
        }
        /// <summary>
        /// Determines what happens with a block when hit.
        /// </summary>
        public override void Hit() {
           hitPoints -= 5;
           IterateHeal();
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
        /// Heals the blocks, by changing its hitpoints to 10. 
        /// </summary>
        private void Heal() {
            hitPoints = 10;
        }
        /// <summary>
        /// Heals the block if 3 seconds has passed. 
        /// </summary>
        public void IterateHeal() {
        var Timer = StaticTimer.GetElapsedSeconds();
        if (Timer % 3.0 == 0.0) {Heal(); }  
        }
    }
}


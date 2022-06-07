using DIKUArcade.Entities;
using DIKUArcade.Graphics;
using DIKUArcade.Events;

namespace Breakout.Blocks{
    /// <summary>
    /// The HealableBlock is a type of block that will heal with 2 hitpoints every 3rd second, if the health is lover than the max health
    /// </summary>
    public class HealableBlock : BreakoutBlock {
        private static int lastHeal = 0;
        public HealableBlock(DynamicShape Shape, IBaseImage image, bool power) : base(Shape, image, power) {
            hitPoints = 15;
            value = 200;
        }
        /// <summary>
        /// Determines what happens with a block when hit.
        /// </summary>
        public override void Hit() {
           hitPoints -= 5;
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
            if (hitPoints + 5 <= 10) {
                System.Console.WriteLine("HEAL");
                hitPoints += 5;
            }
        }
        /// <summary>
        /// Heals the block if 3 seconds has passed. 
        /// </summary>
        public void IterateHeal(GameTime time) {
            if (AllowedToHeal(time)) {
                Heal();
                lastHeal = (int) time.timeRemaining;
            }  
        }
        public bool AllowedToHeal(GameTime time) {
            if (lastHeal - 10 < Math.Floor(time.timeRemaining) &&
                Math.Floor(time.timeRemaining) < lastHeal) {
                return false;
            } else {return true;}
        }
    }   
}


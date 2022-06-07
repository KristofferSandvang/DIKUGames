using DIKUArcade.Entities;
using DIKUArcade.Graphics;
using DIKUArcade.Events;


namespace Breakout.Blocks{
    public class HardenedBlock : BreakoutBlock {
        private IBaseImage Broken;
        private int maxHP;
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
            hitPoints -= 2; 
            if (hitPoints < maxHP * 0.5) {Image = Broken;}
        }
        public HardenedBlock(DynamicShape Shape, IBaseImage image, IBaseImage brokenImage, bool powerUp) : base(Shape, image, powerUp) {
            hitPoints = 10;
            value = 400;
            Broken = brokenImage;
            maxHP = hitPoints;
        }
    }
}
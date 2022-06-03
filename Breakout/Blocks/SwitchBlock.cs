using DIKUArcade.Entities;
using DIKUArcade.Graphics;
using DIKUArcade.Events;
using System.Collections.Generic;
using System.IO;

namespace Breakout.Blocks{
    public class SwitchBlock : BreakoutBlock{
        public static List<SwitchRecieverBlock> switchRecieverList = new List<SwitchRecieverBlock>(); 
        public override void Hit() {
            hitPoints -= 5;
            foreach(SwitchRecieverBlock b in switchRecieverList) {
                b.DeleteEntity(); 
            }
        }
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
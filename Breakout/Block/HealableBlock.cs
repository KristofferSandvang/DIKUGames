using DIKUArcade.Entities;
using DIKUArcade.Graphics;
using System.Collections.Generic;
using System.IO;
using DIKUArcade.Timers;
using DIKUArcade.Events.TimedGameEvent;
#pragma warning disable 0108

namespace Breakout.Blocks{
    public class HealableBlock : BreakoutBlock {
        public DynamicShape shape;

        public HealableBlock(DynamicShape Shape, IBaseImage image) : base(Shape, image) {
            hitPoints = 10;
            value = 200;
            shape = Shape;
        }
        public int GetHP(){
            return hitPoints;
        }
        public override void Hit() {
           hitPoints -= 5;
        }
        public override bool Dead() {
            if (hitPoints <= 0) {
                Score.AddScore(value);
                return true;
            } else {return false;}
        }

        public void iterateHeal() {
            initiateGameEvent = new GameEvent();
            setExpireTime = new initiateGameEvent.TimedGameEvent(0, 5);
            eventExpired = new initiateGameEvent.TimedGameEvent.HasExpired();
            if (eventExpired){hitPoints += hitPoints;}
            //if TimeGameEvent has expired then increment hp
        }
    }
}
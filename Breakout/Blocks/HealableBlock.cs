/*using DIKUArcade.Timers;
using static DIKUArcade.Events.TimedGameEvent;
using DIKUArcade.Entities;
using DIKUArcade.Graphics;
using System.Collections.Generic;
using System.IO;
*/

/*#pragma warning disable 0108

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
        /// <summary>
        /// Determines what happens with a block when hit.
        /// </summary>
        public override void Hit() {
           hitPoints -= 5;
        }
        /// <summary>
        /// Determines whether the ball is dead or not
        /// </summary>
        /// <returns>
        /// Returns true if the block is dead and false if not.
        /// </returns> 
        public override bool IsDead() {
            if (hitPoints <= 0) {
                Score.AddScore(value);
                return true;
            } else {return false;}
        }
/*
        public void iterateHeal() {
            initiateGameEvent = new GameEvent();
            setExpireTime = new initiateGameEvent.TimedGameEvent(0, 5);
            eventExpired = new initiateGameEvent.TimedGameEvent.HasExpired();
            if (eventExpired){hitPoints += hitPoints;}
            //if TimeGameEvent has expired then increment hp
        }*/


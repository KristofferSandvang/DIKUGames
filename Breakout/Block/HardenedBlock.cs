using DIKUArcade.Entities;
using DIKUArcade.Graphics;
using System.Collections.Generic;
using System.IO;

namespace Breakout.Blocks{
    public class HardenedBlock : BreakoutBlock {
        private IBaseImage Broken;
        private int maxHP;
        /// <summary>
        /// Determines what happens with a block when hit.
        /// </summary>
        public override void Hit() {
            hitPoints -= 2; 
            if (hitPoints < maxHP * 0.5) {Image = Broken;}
        }
        /// <summary>
        /// Determines whether the ball is dead or not
        /// </summary>
        /// <returns>
        /// Returns true if the block is dead and false if not.
        /// </returns> 
        public override bool Dead() {
            if(hitPoints <= 0) {
                //Score.AddScore(value);
                return true;
            }
            return false;
        }
        /*public void Broken() {
            if (hitPoints < maxHitPoints/2) {return true;}
            return false; 
        }*/
        public HardenedBlock(DynamicShape Shape, IBaseImage image, IBaseImage brokenImage) : base(Shape, image) {
            hitPoints = 10;
            value = 200;
            Broken = brokenImage;
            maxHP = hitPoints;
        }
    }
}
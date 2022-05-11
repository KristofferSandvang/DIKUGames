using DIKUArcade.Entities;
using DIKUArcade.Graphics;
using System.Collections.Generic;
using System.IO;

namespace Breakout.Blocks{
    public class HardenedBlock : BreakoutBlock {
        public override void Hit() {
            hitPoints -= 1; 
            //ændr image
        }
        public override bool Dead() {
            if(hitPoints <= 0) {
                Score.AddScore(value);
                return true;
            }
            return false;
        }
        /*public void Broken() {
            if (hitPoints < maxHitPoints/2) {return true;}
            return false; 
        }*/
        public HardenedBlock(DynamicShape Shape, IBaseImage image, IBaseImage brokenImage) : base(Shape, image) {

        }
    }
}
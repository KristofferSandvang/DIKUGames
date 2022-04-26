using DIKUArcade.Entities;
using DIKUArcade.Graphics;
using System.Collections.Generic;
using System.IO;

namespace Breakout{
    public class Block : Entity {
        private int hitPoints;
        public bool hardened;
        public bool unbreakable;
        public Block(DynamicShape Shape, IBaseImage image) : base(Shape, image) {
            hitPoints = 10;
            hardened = false;
            unbreakable = false;
        }

        
        public int getHP(){
            return hitPoints;
        }

       /* public void isHit() {
           /* hitPoints -= 2;
            if (hitPoints <= 4) {
                Image = "broken";
               
            } 
        }*/
        public bool isDead() {
            if (hitPoints <= 0) {
                return true;
            }
            else return false;
        }

        
    }
}

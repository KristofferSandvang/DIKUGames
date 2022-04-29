using DIKUArcade.Entities;
using DIKUArcade.Graphics;
using System.Collections.Generic;
using System.IO;
#pragma warning disable 414
namespace Breakout{
    public class Block : Entity {
        private int hitPoints;
        private bool hardened;
        private bool unbreakable;
        private int value;
        public Block(DynamicShape Shape, IBaseImage image, bool hard, bool unbreak) 
            : base(Shape, image) {
            hitPoints = 10;
            value = 100;
            hardened = hard;
            unbreakable = unbreak;
        }
        public int GetHP(){
            return hitPoints;
        }
       public void Hit() {
           if (unbreakable) {
               return;
           } else if (hardened) {
               hitPoints -= 1;
           } else {
               hitPoints -= 2;
           }
           
        }
        public bool IsDead() {
            if (hitPoints <= 0) {
                return true;
            }
            else return false;
        }

        
    }
}

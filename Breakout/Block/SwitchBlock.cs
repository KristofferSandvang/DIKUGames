using DIKUArcade.Entities;
using DIKUArcade.Graphics;
using System.Collections.Generic;
using System.IO;

namespace Breakout.Blocks{
    /*public class SwitchBlock : BreakoutBlock {
        public override int hitPoints {get {return hitPoints;} }
        public override int value {get {return value;} }
        private SwitchRecieverBlock[] SwitchRecieverList; 
        public override void Hit() {
            hitPoints -= 2;
            foreach (SwitchRecieverBlock b in SwitchRecieverList) {
                b.delete;
                //Skal der tilføjes score når de dør? 
            }
        }
        public override void Dead() {
            if(hitPoints <= 0) {
                this.delete; 
                //Removes from entity container
                //[Metode der tilføjer score?]
            }
        }
        public void AddRecievers(EntityContainer<SwitchRecieverBlock> e) {
            foreach (SwitchRecieverBlock b in e) {
                SwitchRecieverList.Add(b); 
            }
        }

       public SwitchBlock(DynamicShape Shape, IBaseImage image) : base(Shape, image) {}
       
    } */
}
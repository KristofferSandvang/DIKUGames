using DIKUArcade.Entities;
using DIKUArcade.Graphics;
using System.Collections.Generic;
using System.IO;

namespace Breakout.Blocks{
    public class SwitchBlock : BreakoutBlock{
        private SwitchRecieverBlock[] SwitchRecieverList; 
        public override void Hit() {
            hitPoints -= 2;
            foreach (SwitchRecieverBlock b in SwitchRecieverList) {
                b.DeleteEntity();
                Score.AddScore(b.value);

                //Skal der tilføjes score når de dør? 
            }
        }
        public override bool Dead() {
            if(hitPoints <= 0) {
                Score.AddScore(value);
                return true;
            }
            return false; 
        }
        public void AddRecievers(EntityContainer<SwitchRecieverBlock> e) {
            foreach (SwitchRecieverBlock b in e) {
            //    SwitchRecieverList.Add(b); 
            }
        }

       public SwitchBlock(DynamicShape Shape, IBaseImage image) : base(Shape, image) {
            hitPoints = 10;
            value = 100;
            shape = Shape;
        }
    } 
}
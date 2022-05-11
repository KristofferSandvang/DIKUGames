using DIKUArcade.Entities;
using DIKUArcade.Graphics;
using System.Collections.Generic;
using System.IO;

namespace Breakout.Blocks{
    public class SwitchRecieverBlock : BreakoutBlock {
        public override void Hit() {
        }
        public override bool Dead() {
            return false;
        }
        public SwitchRecieverBlock(DynamicShape Shape, IBaseImage image) : base(Shape, image) {}
    
    }  
    //Den her class eksisterer så Switch er sikker på at få en liste af blocks der 
    //1. ikke tager skade 2. er dem der skal slettes når Switch bliver ramt
}

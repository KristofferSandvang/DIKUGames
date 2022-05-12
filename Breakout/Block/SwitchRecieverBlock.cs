using DIKUArcade.Entities;
using DIKUArcade.Graphics;
using System.Collections.Generic;
using System.IO;

namespace Breakout.Blocks{
    public class SwitchRecieverBlock : BreakoutBlock {
        /// <summary>
        /// Determines what happens with a block when hit.
        /// </summary>
        public override void Hit() {
        }
        /// <summary>
        /// Determines whether the ball is dead or not
        /// </summary>
        /// <returns>
        /// Returns true if the block is dead and false if not.
        /// </returns> 
        public override bool Dead() {
            return false;
        }
        public SwitchRecieverBlock(DynamicShape Shape, IBaseImage image) : base(Shape, image) {}
    
    }  
    //Den her class eksisterer så Switch er sikker på at få en liste af blocks der 
    //1. ikke tager skade 2. er dem der skal slettes når Switch bliver ramt
}

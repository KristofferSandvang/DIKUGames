using DIKUArcade.Entities;
using DIKUArcade.Graphics;
using Breakout.PowerUps;
using DIKUArcade.Events;
using System.Collections.Generic;
using System.IO;

namespace Breakout.Blocks {
    public abstract class BreakoutBlock : Entity {
        public DynamicShape shape;
        public int value {get; protected set;}
        public int hitPoints {get; protected set; }
        public bool powerUp {get; protected set; }
        /// <summary>
        /// Determines what happens with a block when hit.
        /// </summary>
        public abstract void Hit();

        /// <summary>
        /// Determines whether the block is dead or not
        /// </summary>
        public abstract bool IsDead();
        /// <summary>
        /// Gets the block's HP
        /// </summary>
        public int GetHP() {
            return hitPoints; 
        }
        /// <summary>
        /// Deletes the block. 
        /// </summary>
        public void Dead() {
            if (IsDead()) {
                DeleteEntity();
                if (powerUp) {
                    PowerUpFactory.SpawnPowerUp(this);
                }
            }
        }
        public BreakoutBlock(DynamicShape Shape, IBaseImage image, bool PowerUp) : base(Shape, image) {
            shape = Shape;
            powerUp = PowerUp;
        }
    }
}

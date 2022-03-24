using DIKUArcade.Entities;
using DIKUArcade.Graphics;
using System.Collections.Generic;
using System.IO;


namespace Galaga {
    /// <summary>
    /// A subclass of Entity, containing information about Enemy.
    /// </summary>
    public class Enemy : Entity {
        private int hitPoints = 10;
        private float speed = 0.001f;
        public float startX;
        public float startY;
        private IBaseImage red;
        public Enemy(DynamicShape Shape, IBaseImage image) : base(Shape, image) {
            red = new ImageStride(60, ImageStride.CreateStrides(2, Path.Combine("Assets",
            "Images", "RedMonster.png")));
            startY = Shape.Position.Y;
            startX = Shape.Position.X;
        }
        /// <summary>
        /// Determines if the Enemy is dead or not.
        /// </summary>
        public bool isDead() {
            if (hitPoints <= 0) {
                return true;
            }
            else return false;
        }
        /// <summary>
        /// Decreases the hit points of the enemy and enrages it if allowed.
        /// </summary>
        public void isHit() {
            hitPoints -= 2;
            if (hitPoints <= 4) {
                Image = red;
                speed += 0.0005f; 
            }
        }
        /// <summary>
        /// Gets the speed of the enemey
        /// </summary>
        public float getSpeed() {
            return speed;
        }
        /// <summary>
        /// Gets the hitpoints of the enemy
        /// </summary>
        public int getHP(){
            return hitPoints;
        }
        /// <summary>
        /// Increases the speed of the enemy
        /// </summary>
        public void speedier(float newSpeed) {
            speed += newSpeed;
        }
    }
}

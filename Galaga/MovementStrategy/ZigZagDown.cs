using DIKUArcade.Entities;
using System;
using DIKUArcade.Math;
namespace Galaga.MovementStrategy{
    /// <summary>
    /// A movement Strategy that moves the enemy down in a ZigZag fashion 
    /// </summary>
    public class ZigZagDown : IMovementStrategy {
        /// <summary>
        /// Moves the enemy down in a ZigZag fashion 
        /// </summary>
        /// <param name='enemy'>
        /// the enemy that you wish to move
        /// </param>
        public void MoveEnemy(Enemy enemy) {
            float s = - enemy.getSpeed();
            float p = 0.045f;
            float a = 0.05f;
            float y = enemy.Shape.Position.Y;
            float x = enemy.Shape.Position.X;
            float pi = (float) Math.PI;

            float yI = y + s;
            float xI = enemy.startX + a * sin((2 * pi *(enemy.startY-yI)) / p );
            enemy.Shape.SetPosition(new Vec2F(xI, yI));
        }
        /// <summary>
        /// Moves all enemies down in a ZigZag fashion 
        /// </summary>
        /// <param name='enemies'>
        /// The EntityContainer that contains the enemies that you wish to move
        /// </param>
        public void MoveEnemies(EntityContainer<Enemy> enemies) {
            enemies.Iterate(enemy => MoveEnemy(enemy));
        /// <summary>
        /// Calculates the sinus of a float
        /// </summary>
        }
        private float sin(float val){
            return (float) Math.Sin(val);
        }
    }
}

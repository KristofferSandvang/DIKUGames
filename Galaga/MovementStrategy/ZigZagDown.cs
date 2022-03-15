using DIKUArcade.Entities;
using System;
using DIKUArcade.Math;
namespace Galaga.MovementStrategy{
    class ZigZigDown : IMovementStrategy {
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
        public void MoveEnemies(EntityContainer<Enemy> enemies) {
            enemies.Iterate(enemy => MoveEnemy(enemy));
        }
        private float sin(float val){
            return (float) Math.Sin(val);
        }
    }
}

using DIKUArcade.Entities;
namespace Galaga.MovementStrategy{
    public class Down : IMovementStrategy {
        public void MoveEnemy(Enemy enemy) {
            float y = - enemy.getSpeed();
            enemy.Shape.MoveY(y);
        }
        public void MoveEnemies(EntityContainer<Enemy> enemies) {
            enemies.Iterate(enemy => MoveEnemy(enemy));
        }
    }
}

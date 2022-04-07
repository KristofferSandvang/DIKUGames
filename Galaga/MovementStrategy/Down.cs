using DIKUArcade.Entities;

namespace Galaga.MovementStrategy{
    /// <summary>
    /// A movement Strategy that moves the enemy down
    /// </summary>
    public class Down : IMovementStrategy {
        /// <summary>
        /// Moves the enemy down
        /// </summary>
        /// <param name='enemy'>
        /// the enemy that you wish to move
        /// </param>
        public void MoveEnemy(Enemy enemy) {
            float y = - enemy.getSpeed();
            enemy.Shape.MoveY(y);
        }
        /// <summary>
        /// Moves all enemies down
        /// </summary>
        /// <param name='enemies'>
        /// The EntityContainer that contains the enemies that you wish to move
        /// </param>
        public void MoveEnemies(EntityContainer<Enemy> enemies) {
            enemies.Iterate(enemy => MoveEnemy(enemy));
        }
    }
}

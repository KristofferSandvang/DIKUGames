using DIKUArcade.Entities;

namespace Galaga.MovementStrategy{
    /// <summary>
    /// A movement Strategy where the enemies don't move
    /// </summary>
    public class NoMove : IMovementStrategy {
        /// <summary>
        /// Does not move the enemy
        /// </summary>
        /// <param name='enemy'>
        /// the enemy that you wish to move
        /// </param>
        public void MoveEnemy(Enemy enemy) {}
        /// <summary>
        /// Does not move the enemy
        /// </summary>
        /// <param name='enemy'>
        /// The EntityContainer that contains the enemies that you wish to move
        /// </param>
        public void MoveEnemies(EntityContainer<Enemy> enemies) {}
    }
}

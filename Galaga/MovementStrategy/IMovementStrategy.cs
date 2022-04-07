using DIKUArcade.Entities;

namespace Galaga.MovementStrategy {
    /// <summary>
    /// Determines if the Enemy is dead or not.
    /// </summary>
    public interface IMovementStrategy {
        /// <summary>
        /// Determines if the Enemy is dead or not.
        /// </summary>
        void MoveEnemy (Enemy enemy);
        /// <summary>
        /// Determines if the Enemy is dead or not.
        /// </summary>
        void MoveEnemies (EntityContainer<Enemy> enemies);
    }
}
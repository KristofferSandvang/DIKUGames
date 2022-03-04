using DIKUArcade.Entities;
using DIKUArcade.Graphics;

namespace Galaga {
    /// <summary>
    /// A subclass of Entity, containing information about Enemy.
    /// </summary>
    public class Enemy : Entity {
        public Enemy(DynamicShape Shape, IBaseImage image) : base(Shape, image) {}
        
    }
}

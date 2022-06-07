using DIKUArcade.Entities;
using DIKUArcade.Graphics;

namespace Breakout.PowerUps {
    public abstract class PowerUp : Entity {
        protected DynamicShape shape;

        /// <summary>
        /// Determines what happens when the powerUp is collected by the player
        /// </summary>
        /// <param name='player'>
        /// The player that has to collect the powerUp
        /// </param>
        public abstract void Collected(Player player);
        /// <summary>
        /// Moves the PowerUp
        /// </summary>
        public void Move() {
            shape.Move();
            if (shape.Position.Y < 0.0f) {
                DeleteEntity();
            }
        }
        /// <summary>
        /// Renders the powerup
        /// </summary>
        public void Render(){
            RenderEntity();
        }
        /// <summary>
        /// gets the shape of the PowerUp
        /// </summary>
        public DynamicShape GetShape() {
            return shape;
        } 
        public PowerUp(DynamicShape Shape, IBaseImage image) : base(Shape, image){
            shape = Shape;
            shape.Direction.X = 0.0f;
            shape.Direction.Y = -0.005f;
        }
    }
}
using DIKUArcade.Entities;
using DIKUArcade.Graphics;
namespace Galaga {
    public class Player {

        private float moveLeft = 0.0f; 
        private float moveRight = 0.0f; 
        private float moveSpeed = 0.1f;
        private Entity entity;
        private DynamicShape shape;
        public Player(DynamicShape shape, IBaseImage image) {
            entity = new Entity(shape, image);
            this.shape = shape;
        }
        
        public void SetMoveLeft(bool val) {
            if (val) {
            moveLeft = -moveSpeed;
            updateDirection();
            } else moveLeft = 0.0f;
        }
        
        public void SetMoveRight(bool val) {
            if (val) {
                moveLeft = +moveSpeed;
                updateDirection();
            } else moveRight = 0.0f;
        }

        
        private void updateDirection() {
            shape.Direction.X = (moveLeft + moveRight);
        }

        public void move() {
            if(shape.Position.X + moveSpeed > 1  && shape.Position.X - moveSpeed < 0) {
                shape.Move(); 
            } 
        }
        public void Render() {
            entity.RenderEntity();
        }
    }
}
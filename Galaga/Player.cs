using DIKUArcade.Entities;
using DIKUArcade.Graphics;
using DIKUArcade.Math;
namespace Galaga {
    public class Player {

        private float moveLeft = 0.0f; 
        private float moveRight = 0.0f; 
        private float moveSpeed = 0.01f;
        private Entity entity;
        private DynamicShape shape;
        public Player(DynamicShape shape, IBaseImage image) {
            entity = new Entity(shape, image);
            this.shape = shape;
        }
        
        public void SetMoveLeft(bool val) {
            if (val) {
                moveLeft = -moveSpeed;
            } else
                moveLeft = 0.0f;
            updateDirection();
        }
        
        public void SetMoveRight(bool val) {
            if (val) {
                moveLeft = moveSpeed;
            } else
                moveRight = 0.0f;
            updateDirection();
        }

        private void updateDirection() {
            float moveSum = moveLeft + moveRight;
            shape.ChangeDirection(new Vec2F (moveSum, 0.0f));
        }

        public void move() {
            float moveSum = moveLeft + moveRight;
            float upperBounds = shape.Position.X + moveSum + shape.Extent.X;
            float lowerBounds = shape.Position.X + moveSum;
 
            if (0.0f <= lowerBounds && upperBounds <= 1.0f) {
                shape.Move(); 
            } 
        }
        public Vec2F getPosition() {
            return shape.Position;
        }
        public void Render() {
            entity.RenderEntity();
        }
    }
}

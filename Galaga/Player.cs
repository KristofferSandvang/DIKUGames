using DIKUArcade.Entities;
using DIKUArcade.Graphics;
using DIKUArcade.Math;
using DIKUArcade.Events;
namespace Galaga {
    /// <summary>
    /// A subclass of Entity, containing information about Player.
    /// </summary>
    public class Player : IGameEventProcessor{
        private float moveLeft = 0.0f; 
        private float moveRight = 0.0f; 
        private float moveSpeed = 0.01f;
        private Entity entity;
        private DynamicShape shape;
        public Player(DynamicShape shape, IBaseImage image) {
            entity = new Entity(shape, image);
            this.shape = shape;
        }
        /// <summary>
        /// If true, sets moveLeft to -movespeed 
        ///(moving left at moveSpeed speed), else to 0.0f
        /// </summary>
        private void SetMoveLeft(bool val) {
            if (val) {
                moveLeft = -moveSpeed;
            } else
                moveLeft = 0.0f;
            updateDirection();
        }
        /// <summary>
        /// If true, sets moveRight to movespeed 
        ///(moving right at moveSpeed speed), else to 0.0f
        /// </summary>
        private void SetMoveRight(bool val) {
            if (val) {
                moveRight = moveSpeed;
            } else
                moveRight = 0.0f;
            updateDirection();
        }
        /// <summary>
        /// Updates the direction on the Player's shape
        /// </summary>
        private void updateDirection() {
            float moveSum = moveLeft + moveRight;
            shape.ChangeDirection(new Vec2F (moveSum, 0.0f));
        }
        /// <summary>
        /// Moves the player after first checking if it has hit either of the vertical walls.
        /// </summary>
        public void move() {
            float moveSum = moveLeft + moveRight;
            float upperBounds = shape.Position.X + moveSum + shape.Extent.X;
            float lowerBounds = shape.Position.X + moveSum;
 
            if (0.0f <= lowerBounds && upperBounds <= 1.0f) {
                shape.Move(); 
            } 
        }
        /// <summary>
        /// Processes a GameEvent based on the GameEvent.Message
        /// </summary>
        /// <param name='gameEvent'>
        /// A GameEvent
        /// </param>
        public void ProcessEvent(GameEvent gameEvent) {
            if (gameEvent.EventType == GameEventType.PlayerEvent) {
                switch (gameEvent.Message) {
                    case "moveLeft":
                        SetMoveLeft(true);
                        break;
                    case "moveRight":
                        SetMoveRight(true);
                        break;
                    case "stopMoveLeft":
                        SetMoveLeft(false);
                        break;
                    case "stopMoveRight":
                        SetMoveRight(false);
                        break;
                }
            }
        }        
        /// <summary>
        /// Returns position of Player
        /// </summary>
        public Vec2F shotPosition() {
            float x = shape.Position.X + (0.5f * shape.Extent.X);
            float y = shape.Position.Y;
            return new Vec2F(x, y);
        }
        /// <summary>
        /// Renders the player.
        /// </summary>
        public void Render() {
            entity.RenderEntity();
        }
    }
}

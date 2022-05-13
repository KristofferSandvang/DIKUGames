using DIKUArcade.Entities;
using DIKUArcade.Math;
using DIKUArcade.Graphics;
using Breakout.Blocks;
using DIKUArcade.Physics;
using System;
namespace Breakout {

    public class Ball : Entity {
        private DynamicShape shape;
        private Random rand;
        public Ball(DynamicShape Shape, IBaseImage image) : base(Shape, image) {
            shape = Shape;
            rand = new Random();
        } 
        /// <summary>   
        /// Checks if the Ball collides with anything
        /// </summary>   
        ///<param name="blocks"> An EntityContainer of blocks that exists within the game </param>
        ///<param name="player"> a Player that exists within the game </param>
        public void Collide(EntityContainer<BreakoutBlock> blocks, Player player) {
            Remove();
            CollideBlock(blocks);
            CollidePlayer(player);
            CollideWall();
            CollideRoof();
        }
        /// <summary>   
        /// Changes the balls direction based on whether it hits the wall or not
        /// </summary>   
        private void CollideWall() {
            if (shape.Position.X <= 0.0f || shape.Position.X >= 1.0f) {
                shape.Direction.X = shape.Direction.X * -1.0f;
            }
        }
        /// <summary>   
        /// Changes the balls direction based on whether it hits the roof or not
        /// </summary>   
        private void CollideRoof() {
            if (shape.Position.Y >= 1.0f) {
                float noise = (float) rand.NextDouble() / 1000.0f;
                shape.Direction.Y = shape.Direction.Y * -1.0f;
                shape.Direction.X = shape.Direction.X + noise;
            }
        }
        /// <summary>   
        /// Handles what happens when a Ball collides with a block
        /// </summary>  
        ///<param name="blocks"> An EntityContainer of blocks that exists within the game </param>
        private void CollideBlock(EntityContainer<BreakoutBlock> blocks)  {
            blocks.Iterate( (EntityContainer<BreakoutBlock>.IteratorMethod)(block => {
                if (CollisionDetection.Aabb(shape.AsDynamicShape(), block.shape).Collision) {
                    block.Hit();
                    block.Dead();
                    float noise = (float)rand.NextDouble() / 1000.0f;
                    shape.Direction.Y = shape.Direction.Y * -1.0f;
                    shape.Direction.X = shape.Direction.X + noise;
                }
            }));
        }
        /// <summary>   
        /// Handles what happens when a Ball collides with a player
        /// </summary>  
        ///<param name="player"> a Player that exists within the game </param>
        private void CollidePlayer(Player player) {
            if (CollisionDetection.Aabb(shape.AsDynamicShape(), player.shape).Collision) {
                float noise = (float) rand.NextDouble() / 10000.0f;
                shape.Direction.X = player.BounceDirection() + noise;
                shape.Direction.Y = shape.Direction.Y * -1.0f;
            }
        }
        /// <summary>   
        /// Removes the ball if its Y position is less that 0.0f
        /// </summary>  
        private void Remove() {
            if (shape.Position.Y <= 0.0f) {
                DeleteEntity();
            }
        }
        /// <summary>   
        /// Moves the ball, by calling all of the collide functions
        /// </summary>  
        public void Move(EntityContainer<BreakoutBlock> blocks, Player player) {
            Collide(blocks, player);
            shape.Move();
        }
    }
}
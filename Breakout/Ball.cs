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
        public void Collide(EntityContainer<BreakoutBlock> blocks, Player player) {
            Remove();
            CollideBlock(blocks);
            CollidePlayer(player);
            CollideWall();
            CollideRoof();
        }
        private void CollideWall() {
            if (shape.Position.X <= 0.0f || shape.Position.X >= 1.0f) {
                shape.Direction.X = shape.Direction.X * -1.0f;
            }
        }
        private void CollideRoof() {
            if (shape.Position.Y >= 1.0f) {
                float noise = (float) rand.NextDouble() / 1000.0f;
                shape.Direction.Y = shape.Direction.Y * -1.0f;
                shape.Direction.X = shape.Direction.X + noise;
            }
        }
        private void CollideBlock(EntityContainer<BreakoutBlock> blocks)  {
            blocks.Iterate( block => {
                if (CollisionDetection.Aabb(shape.AsDynamicShape(), block.shape).Collision) {
                    block.Hit();
                    if (block.Dead()) {
                        block.DeleteEntity();
                    }
                    float noise = (float) rand.NextDouble() / 1000.0f;
                    shape.Direction.Y = shape.Direction.Y * -1.0f;
                    shape.Direction.X = shape.Direction.X + noise;
                }
            });
        }
        private void CollidePlayer(Player player) {
            if (CollisionDetection.Aabb(shape.AsDynamicShape(), player.shape).Collision) {
                float noise = (float) rand.NextDouble() / 10000.0f;
                shape.Direction.X = player.BounceDirection() + noise;
                shape.Direction.Y = shape.Direction.Y * -1.0f;
            }
        }
        private void Remove() {
            if (shape.Position.Y <= 0.0f) {
                DeleteEntity();
            }
            //if y<0, remove ball
            //Hungry block?
        }
        public void Move(EntityContainer<BreakoutBlock> blocks, Player player) {
            Collide(blocks, player);
            shape.Move();
        }
    }
}
using DIKUArcade.Entities;
using DIKUArcade.Math;
using DIKUArcade.Graphics;
using Breakout.Blocks;
using System;
namespace Breakout{

    public class Ball : Entity {
        private static Vec2F extent = new Vec2F(0.008f, 0.021f);
        private DynamicShape shape;

        private Random rand;
        public Ball(DynamicShape Shape, IBaseImage image) : base(Shape, image) {
            shape = Shape;
            rand = new Random();
        } 

        public void Collide(EntityContainer<BreakoutBlock> blocks) {
                
            }
        public void CollideWall() {
            if (shape.Position.X <= 0.0f || shape.Position.X >= 1.0f) {
                shape.Direction.X = shape.Direction.X * -1.0f;
            }
        }
        public void CollideRoof() {
            if (shape.Position.Y >= 1.0f) {
                float noise = (float) rand.NextDouble() / 100.0f;
                shape.Direction.Y = shape.Direction.Y * -1.0f;
                shape.Direction.X = shape.Direction.X + noise;
            }
        }
        
        public void CollidePlayer() {

        }
        public void CollideBlock() {
            //send "hit" to block
            //caculate vector from direction vector
            //update direction
            //go
        }
        public void Remove() {
            //if y<0, remove ball
            //Hungry block?
        }
        public void Move() {
            CollideRoof();
            CollideWall();
            shape.Move();
        }
    }
}
using DIKUArcade.Entities;
using DIKUArcade.Math;
using DIKUArcade.Graphics;

namespace Breakout{

    public class Ball  {
    private static Vec2F extent = new Vec2F(0.008f, 0.021f);
    private Vec2F direction = new Vec2F(0.0f, 0.1f);
    
    public void Collide() {
        }
    public void CollideWall() {

    }
    public void CollidePlayer() {
        
    }
    public void CollideBlock() {
        //send "hit" to block
        //caculate vector from direction vector
        //update direction
        //Stop lige med at skrive,vi skal compile
        //Det stopper den da ikke fra at compile
    }
    public void Remove() {
        //if y<0, remove ball
        //Hungry block?
    }
    
    }
}
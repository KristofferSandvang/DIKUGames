/*using Breakout.Blocks;
using Breakout;
using NUnit.Framework;
using DIKUArcade;
using DIKUArcade.Math;
using DIKUArcade.Graphics;
using DIKUArcade.GUI;
using DIKUArcade.Entities;
using System.IO;



namespace breakoutTests;
    public class BallTest {

        private Ball dummy;
        private Ball tester;
        
        
    [SetUp]
    public void InitalizeTests() {
        Window.CreateOpenGLContext();
        dummy = new Ball(
        new DynamicShape(new Vec2F(0.425f, 0.1f), new Vec2F(0.15f, 0.03f), new Vec2F(0.0f, 0.02f)),
        new Image(Path.Combine("Assets", "Images", "ball.png")));

        tester = new Ball(
        new DynamicShape(new Vec2F(0.425f, 0.1f), new Vec2F(0.15f, 0.03f), new Vec2F(0.0f, 0.02f)),
        new Image(Path.Combine("Assets", "Images", "ball.png")));
    }

    [Test]
    public void MoveTest(){
        Player player = new Player(
                     new DynamicShape(new Vec2F(0.435f, 0.1f), new Vec2F(0.15f, 0.03f)),
                     new Image(Path.Combine("Assets", "Images", "player.png")));
        EntityContainer<BreakoutBlock> blocks = new EntityContainer<BreakoutBlock>();
        tester.Move(blocks, player);
        Assert.Greater(tester.GetShape().Position.Y, dummy.GetShape().Position.Y);
    }

    [Test]
    public void BallCollideRightWall() {
        Player player = new Player(
                     new DynamicShape(new Vec2F(0.435f, 0.1f), new Vec2F(0.15f, 0.03f)),
                     new Image(Path.Combine("Assets", "Images", "player.png")));
        EntityContainer<BreakoutBlock> blocks = new EntityContainer<BreakoutBlock>();

        tester.GetShape().Direction = new Vec2F(1.0f, 0.0f);

        while (tester.GetShape().Position.X <= 1.0f) {
           tester.Move(blocks, player); 
        }
        Assert.Less(tester.GetShape().Direction.X, dummy.GetShape().Direction.X);
    }

    [Test]
    public void BallCollideLeftWall() {
        Player player = new Player(
                     new DynamicShape(new Vec2F(0.435f, 0.1f), new Vec2F(0.15f, 0.03f)),
                     new Image(Path.Combine("Assets", "Images", "player.png")));
        EntityContainer<BreakoutBlock> blocks = new EntityContainer<BreakoutBlock>();

        tester.GetShape().Direction = new Vec2F(-1.0f, 0.0f);

        while (tester.GetShape().Position.X >= 0.0f) {
           tester.Move(blocks, player); 
        }

        Assert.Greater(tester.GetShape().Direction.X, dummy.GetShape().Direction.X);
    }

    [Test]
    public void BallCollideRoof() {
        Player player = new Player(
                     new DynamicShape(new Vec2F(0.435f, 0.1f), new Vec2F(0.15f, 0.03f)),
                     new Image(Path.Combine("Assets", "Images", "player.png")));
        EntityContainer<BreakoutBlock> blocks = new EntityContainer<BreakoutBlock>();

        tester.GetShape().Direction = new Vec2F(0.0f, 1.0f);

        while (tester.GetShape().Position.Y <= 1.0f) {
           tester.Move(blocks, player); 
        }

        Assert.Less(tester.GetShape().Direction.Y, dummy.GetShape().Direction.Y);
    }

    [Test]
    public void () {
        Player player = new Player(
                     new DynamicShape(new Vec2F(0.435f, 0.1f), new Vec2F(0.15f, 0.03f)),
                     new Image(Path.Combine("Assets", "Images", "player.png")));
        EntityContainer<BreakoutBlock> blocks = new EntityContainer<BreakoutBlock>();
        EntityContainer<Ball> balls = new EntityContainer<Ball>(); 

        tester.GetShape().Direction = new Vec2F(0.0f, -1.0f);
        balls.AddEntity(tester); 
        
        int beforeMove = balls.CountEntities();
        while (tester.GetShape().Position.Y >= 0.0f) {
           balls.Iterate(ball => ball.Move(blocks, player));
        } 
        int afterMove = balls.CountEntities();
        Assert.Less(afterMove, beforeMove);
    }
 */
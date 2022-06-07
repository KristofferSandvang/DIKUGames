using NUnit.Framework;
using DIKUArcade.Physics;
using DIKUArcade.Entities;
using DIKUArcade.Graphics;
using DIKUArcade.Math;
using DIKUArcade.GUI;
using DIKUArcade.Events;
using DIKUArcade.Utilities;
using System.IO;
using System.Collections.Generic;
using Breakout;
using Breakout.PowerUps;
using Breakout.Blocks; 

namespace BreakoutTests.PowerUpTests;

public class ExtraBallSpeedTest {
    private Ball dummy;
    private Ball tester;
    private Player player; 
    private ExtraBallSpeed powerUp; 
    private ExtraBallSpeed powerUpDummy; 
    private EntityContainer<BreakoutBlock> entityContainer; 

    public ExtraBallSpeedTest() {
        Window.CreateOpenGLContext();
        dummy = new Ball(
        new DynamicShape(new Vec2F(0.425f, 0.1f), new Vec2F(0.15f, 0.03f), new Vec2F(0.0f, 0.02f)),
        new Image(Path.Combine("Assets", "Images", "ball.png")));

        tester = new Ball(
        new DynamicShape(new Vec2F(0.425f, 0.1f), new Vec2F(0.15f, 0.03f), new Vec2F(0.0f, 1.0f)),
        new Image(Path.Combine("Assets", "Images", "ball.png")));
        
        player = new Player(new DynamicShape(new Vec2F(0.1f, 0.1f), new Vec2F(1.0f, 0.1f)),
            new Image(Path.Combine(FileIO.GetProjectPath(), "Assets", "Images", "player.png")));

        powerUp = new ExtraBallSpeed(
            new DynamicShape(new Vec2F(0.1f, 0.2f), new Vec2F(0.1f, 0.1f)),
            new Image(Path.Combine(FileIO.GetProjectPath(), "Assets", "Images", "SpeedPickUp.png")));

        powerUpDummy = new ExtraBallSpeed(new DynamicShape(new Vec2F(0.1f, 0.2f), new Vec2F(0.1f, 0.1f)),
            new Image(Path.Combine(FileIO.GetProjectPath(), "Assets", "Images",
                "SpeedPickUp.png")));
        entityContainer = new EntityContainer<BreakoutBlock>();     
    }

    [OneTimeSetUp]
    public void InitalizeBreakoutBus() {
        BreakoutBus.GetBus().InitializeEventBus(new List<GameEventType> { GameEventType.MovementEvent } );
    }
    
    [OneTimeTearDown]
    public void ResetBreakoutBus() {
        BreakoutBus.ResetBus();
    }

    [SetUp]
    public void Initialize() {
        Window.CreateOpenGLContext();
        dummy = new Ball(
        new DynamicShape(new Vec2F(0.425f, 0.1f), new Vec2F(0.15f, 0.03f), new Vec2F(0.0f, 0.02f)),
        new Image(Path.Combine("Assets", "Images", "ball.png")));

        tester = new Ball(
        new DynamicShape(new Vec2F(0.425f, 0.1f), new Vec2F(0.15f, 0.03f), new Vec2F(0.0f, 1.0f)),
        new Image(Path.Combine("Assets", "Images", "ball.png")));
        
        player = new Player(new DynamicShape(new Vec2F(0.1f, 0.1f), new Vec2F(1.0f, 0.1f)),
            new Image(Path.Combine(FileIO.GetProjectPath(), "Assets", "Images", "player.png")));

        powerUp = new ExtraBallSpeed(
            new DynamicShape(new Vec2F(0.1f, 0.2f), new Vec2F(0.1f, 0.1f)),
            new Image(Path.Combine(FileIO.GetProjectPath(), "Assets", "Images", "SpeedPickUp.png")));

        powerUpDummy = new ExtraBallSpeed(new DynamicShape(new Vec2F(0.1f, 0.2f), new Vec2F(0.1f, 0.1f)),
            new Image(Path.Combine(FileIO.GetProjectPath(), "Assets", "Images",
                "SpeedPickUp.png")));
        entityContainer = new EntityContainer<BreakoutBlock>();     
        BreakoutBus.GetBus().Subscribe(GameEventType.MovementEvent, tester);    
    }

    //Test that the PowerUp moves. 
    [Test]
    public void ExtraSpeedPowerUpMoves() {
        powerUp.Move();
        Assert.Less(powerUp.GetShape().Position.Y, powerUpDummy.GetShape().Position.Y);
    }

    //Tests that the Ball moves faster than normal after ExtraBallSpeed PowerUp
    [Test]
    public void ExtraSpeedTest() {
        while (!(CollisionDetection.Aabb(powerUp.GetShape().AsDynamicShape(), player.shape).Collision)) {
            powerUp.Move();
        }
        powerUp.Collected(player);

        BreakoutBus.GetBus().ProcessEventsSequentially();

        tester.Move(entityContainer, player); 
        dummy.Move(entityContainer, player); 
        Assert.Greater(tester.Shape.Position.Y,dummy.Shape.Position.Y);
        
    }
}

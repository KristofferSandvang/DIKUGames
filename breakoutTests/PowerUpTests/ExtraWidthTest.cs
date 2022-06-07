using NUnit.Framework;
using DIKUArcade.Entities;
using DIKUArcade.Graphics;
using DIKUArcade.Math;
using DIKUArcade.GUI;
using DIKUArcade.Events;
using DIKUArcade.Utilities;
using DIKUArcade.Physics;
using System.IO;
using System.Collections.Generic;
using Breakout;
using Breakout.PowerUps;

namespace BreakoutTests.PowerUpTests;

    public class ExtraWidthTest {
    private ExtraWidth powerUp;
    private Player dummy; 
    private Player tester;
    
    public ExtraWidthTest() {
        Window.CreateOpenGLContext();
        powerUp = new ExtraWidth(new DynamicShape(new Vec2F(0.1f, 0.2f), new Vec2F(0.1f, 0.1f)),
            new Image(Path.Combine(FileIO.GetProjectPath(), "Assets", "Images", "LifePickUp.png")));

        dummy = new Player(new DynamicShape(new Vec2F(0.1f, 0.2f), new Vec2F(0.1f, 0.1f)),
            new Image(Path.Combine(FileIO.GetProjectPath(), "Assets", "Images", "player.png")));

        tester = new Player(new DynamicShape(new Vec2F(0.1f, 0.1f), new Vec2F(1.0f, 0.1f)),
            new Image(Path.Combine(FileIO.GetProjectPath(), "Assets", "Images", "player.png")));
    }

    [OneTimeSetUp]
    public void InitalizeBreakoutBus() {
        BreakoutBus.GetBus().InitializeEventBus(new List<GameEventType> { GameEventType.PlayerEvent } );
    }
    [OneTimeTearDown]
    public void ResetBreakoutBus() {
        BreakoutBus.ResetBus();
    }
    [SetUp]
    public void Initalise() {
        Window.CreateOpenGLContext();
        powerUp = new ExtraWidth(new DynamicShape(new Vec2F(0.1f, 0.2f), new Vec2F(0.1f, 0.1f)),
            new Image(Path.Combine(FileIO.GetProjectPath(), "Assets", "Images", "LifePickUp.png")));

        dummy = new Player(new DynamicShape(new Vec2F(0.1f, 0.2f), new Vec2F(0.1f, 0.1f)),
            new Image(Path.Combine(FileIO.GetProjectPath(), "Assets", "Images", "player.png")));

        tester = new Player(new DynamicShape(new Vec2F(0.1f, 0.1f), new Vec2F(1.0f, 0.1f)),
            new Image(Path.Combine(FileIO.GetProjectPath(), "Assets", "Images", "player.png")));

        BreakoutBus.GetBus().Subscribe(GameEventType.PlayerEvent, tester);
    }
    //Test that the PowerUp moves. 
    [Test]
    public void TestPowerUpMoves() {
        powerUp.Move();
        Assert.Less(powerUp.GetShape().Position.Y, 0.2f);
    }
    //Tests that a player can gain a life, by collecting the power up. 
    [Test]
    public void TestWidthGain() {
        while (!(CollisionDetection.Aabb(powerUp.GetShape().AsDynamicShape(), tester.shape).Collision)) {
        powerUp.Move();
    }
        powerUp.Collected(tester);
        BreakoutBus.GetBus().ProcessEventsSequentially();
        Assert.Greater(tester.shape.Extent.X, dummy.shape.Extent.X);
    }
}
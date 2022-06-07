using NUnit.Framework;
using DIKUArcade.Entities;
using DIKUArcade.Graphics;
using DIKUArcade.Math;
using DIKUArcade.Physics;
using DIKUArcade.GUI;
using System.Collections.Generic;
using DIKUArcade.Events;
using DIKUArcade.Utilities;
using System.IO;
using Breakout;
using Breakout.PowerUps;


namespace BreakoutTests.PowerUpTests;

public class ExtraLifeTest {
    private ExtraLife powerUp;
    private Player dummy; 
    private Player tester;

    public ExtraLifeTest() {
        Window.CreateOpenGLContext();
        powerUp = new ExtraLife(new DynamicShape(new Vec2F(0.1f, 0.2f), new Vec2F(0.1f, 0.1f)),
            new Image(Path.Combine(FileIO.GetProjectPath(), "Assets", "Images",
                "LifePickUp.png")));
        dummy = new Player(new DynamicShape(new Vec2F(0.0f, 0.0f), new Vec2F(0.1f, 0.1f)),
            new Image(Path.Combine(FileIO.GetProjectPath(), "Assets", "Images", "player.png")));
        tester = new Player(new DynamicShape(new Vec2F(0.1f, 0.1f), new Vec2F(1.1f, 0.1f)),
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
        powerUp = new ExtraLife(new DynamicShape(new Vec2F(0.1f, 0.2f), new Vec2F(0.1f, 0.1f)),
            new Image(Path.Combine(FileIO.GetProjectPath(), "Assets", "Images",
                "LifePickUp.png")));
        dummy = new Player(new DynamicShape(new Vec2F(0.0f, 0.0f), new Vec2F(0.1f, 0.1f)),
            new Image(Path.Combine(FileIO.GetProjectPath(), "Assets", "Images", "player.png")));
        tester = new Player(new DynamicShape(new Vec2F(0.1f, 0.1f), new Vec2F(1.1f, 0.1f)),
            new Image(Path.Combine(FileIO.GetProjectPath(), "Assets", "Images", "player.png")));
        BreakoutBus.GetBus().Subscribe(GameEventType.PlayerEvent, tester);
    }

    //Test that the PowerUp moves. 
    [Test]
    public void PowerUpMoves() {
        powerUp.Move();
        Assert.Less(powerUp.GetShape().Position.Y, 0.2f);
    }
    //Tests that a player can gain a life, by collecting the power up. 
    [Test]
    public void GainLife() {
         while (!(CollisionDetection.Aabb(powerUp.GetShape().AsDynamicShape(), tester.shape).Collision)) {
            powerUp.Move();
        }
        powerUp.Collected(tester);

        BreakoutBus.GetBus().ProcessEventsSequentially();
        Assert.Greater(tester.Lives.LivesLeft(), dummy.Lives.LivesLeft());
    }
}

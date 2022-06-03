using NUnit.Framework;

using DIKUArcade.Entities;
using DIKUArcade.Graphics;
using DIKUArcade.Math;
using DIKUArcade.GUI;
using DIKUArcade.Events;
using DIKUArcade.Utilities;
using System.IO;
using Breakout;
using Breakout.PowerUps;

namespace breakoutTests;

public class ExtraLifeTest {
private ExtraLife powerUp;
private Player dummy; 
private Player tester;


[SetUp]
    public void Initalise() {
        Window.CreateOpenGLContext();
        powerUp = new ExtraLife(new DynamicShape(new Vec2F(0.0f, 0.0f), new Vec2F(0.1f, 0.1f)),
            new Image(Path.Combine(FileIO.GetProjectPath(), "Assets", "Images",
                "LifePickUp.png")));
        dummy = new Player(new DynamicShape(new Vec2F(0.0f, 0.0f), new Vec2F(0.1f, 0.1f)),
            new Image(Path.Combine(FileIO.GetProjectPath(), "Assets", "Images", "player.png")));
        tester = new Player(new DynamicShape(new Vec2F(0.0f, 0.0f), new Vec2F(0.1f, 0.1f)),
            new Image(Path.Combine(FileIO.GetProjectPath(), "Assets", "Images", "player.png")));
        BreakoutBus.GetBus().Subscribe(GameEventType.PlayerEvent, tester);
    }
    //Test that the PowerUp moves. 
    [Test]
    public void PowerUpMoves() {
        tester.Move();
        Assert.Less(tester.shape.Position.Y, dummy.shape.Position.Y);
    }
    //Tests that a player can gain a life, by collecting the power up. 
    [Test]
    public void GainLife() {
        powerUp.Collected(tester);
        BreakoutBus.GetBus().ProcessEventsSequentially();
        Assert.Greater(tester.Lives.LivesLeft(), dummy.Lives.LivesLeft());
    }
}

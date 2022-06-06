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

#pragma warning disable 8618
#pragma warning disable 0169

namespace breakoutTests;

public class ExtraTimeTest {
    private MoreTime powerUp;
    private MoreTime powerUpDummy; 
    private GameTime Time;
    private GameTime TimeTester;
    private Player player;

    [OneTimeSetUp]
    public void InitalizeBreakoutBus() {
        BreakoutBus.GetBus().InitializeEventBus(new List<GameEventType> { GameEventType.ControlEvent } );
    }
    [OneTimeTearDown]
    public void ResetBreakoutBus() {
        BreakoutBus.ResetBus();
    }

    [SetUp]
    public void Initalise() {
        Window.CreateOpenGLContext();

        powerUp = new MoreTime(new DynamicShape(new Vec2F(0.1f, 0.2f), new Vec2F(0.1f, 0.1f)),
            new Image(Path.Combine(FileIO.GetProjectPath(), "Assets", "Images",
                "ClockPickUp.png")));

        powerUpDummy = new MoreTime(new DynamicShape(new Vec2F(0.1f, 0.2f), new Vec2F(0.1f, 0.1f)),
            new Image(Path.Combine(FileIO.GetProjectPath(), "Assets", "Images",
                "ClockPickUp.png")));
                
        player = new Player(new DynamicShape(new Vec2F(0.1f, 0.1f), new Vec2F(1.0f, 0.1f)),
            new Image(Path.Combine(FileIO.GetProjectPath(), "Assets", "Images", "player.png")));
            
        TimeTester = new GameTime(60.0);

        BreakoutBus.GetBus().Subscribe(GameEventType.ControlEvent, TimeTester);
    }

    

    //Test that the PowerUp moves. 
    [Test]
    public void ExtraTimePowerUpMoves() {
        powerUp.Move();
        Assert.Less(powerUp.GetShape().Position.Y, powerUpDummy.GetShape().Position.Y);
    }
    //Tests that a player can gain Time, by collecting the power up. 
    [Test]
    public void GainTime() {
        
        while (!(CollisionDetection.Aabb(powerUp.GetShape().AsDynamicShape(), player.shape).Collision)) {
            powerUp.Move();
        }

        powerUp.Collected(player);

        var before = TimeTester.GetTime();
        BreakoutBus.GetBus().ProcessEventsSequentially();
        var after = TimeTester.GetTime();
        Assert.Greater(after, before);
    }
}
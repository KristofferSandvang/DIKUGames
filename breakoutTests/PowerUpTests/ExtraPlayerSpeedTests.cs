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

namespace breakoutTests;

public class PlayerSpeedTest {
    private ExtraPlayerSpeed powerUp;
    private ExtraPlayerSpeed powerUpDummy; 
    private Player player;

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

        powerUp = new ExtraPlayerSpeed(new DynamicShape(new Vec2F(0.1f, 0.2f), new Vec2F(0.1f, 0.1f)),
            new Image(Path.Combine(FileIO.GetProjectPath(), "Assets", "Images",
                "ClockPickUp.png")));

        powerUpDummy = new ExtraPlayerSpeed(new DynamicShape(new Vec2F(0.1f, 0.2f), new Vec2F(0.1f, 0.1f)),
            new Image(Path.Combine(FileIO.GetProjectPath(), "Assets", "Images",
                "ClockPickUp.png")));
                
        player = new Player(new DynamicShape(new Vec2F(0.1f, 0.1f), new Vec2F(1.0f, 0.1f)),
            new Image(Path.Combine(FileIO.GetProjectPath(), "Assets", "Images", "player.png")));
            

        BreakoutBus.GetBus().Subscribe(GameEventType.PlayerEvent, player);
    }

    

    //Test that the PowerUp moves. 
    [Test]
    public void ExtraPlayerPowerUpMoves() {
        powerUp.Move();
        Assert.Less(powerUp.GetShape().Position.Y, powerUpDummy.GetShape().Position.Y);
    }
    //Tests that a player can gain Time, by collecting the power up. 
    
    [Test]
    public void GainPlayerSpeed() {
        
        while (!(CollisionDetection.Aabb(powerUp.GetShape().AsDynamicShape(), player.shape).Collision)) {
            powerUp.Move();
        }
        var before = player.GetSpeed();
        powerUp.Collected(player);
        BreakoutBus.GetBus().ProcessEventsSequentially();
        var after = player.GetSpeed();
        Assert.Greater(after, before);
    }
}
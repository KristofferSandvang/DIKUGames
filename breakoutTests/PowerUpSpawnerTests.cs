using Breakout;
using Breakout.Blocks;

using DIKUArcade.GUI;
using DIKUArcade.Events;
using DIKUArcade.Entities;
using DIKUArcade.Graphics;
using DIKUArcade.Math;
using DIKUArcade.Utilities;

using System.IO;
using System.Collections.Generic;
using NUnit.Framework;


namespace BreakoutTests;
public class PowerUpSpawnerTests {
    private PowerUpSpawner powerUpSpawner;
    private EntityContainer<BreakoutBlock> powerUpBlocks;
    private EntityContainer<BreakoutBlock> noPowerUpBlocks;

    public PowerUpSpawnerTests() {
        Window.CreateOpenGLContext();
        powerUpSpawner = new PowerUpSpawner();
        powerUpBlocks = new EntityContainer<BreakoutBlock>();
        powerUpBlocks.AddEntity(new StandardBlock(
            new DynamicShape(new Vec2F(1.0f, 1.0f), new Vec2F(0.1f, 0.1f)),
            new Image(Path.Combine(FileIO.GetProjectPath(), "Assets", "Images", "red-block.png")),
            true));

        noPowerUpBlocks = new EntityContainer<BreakoutBlock>();
        noPowerUpBlocks.AddEntity(new StandardBlock(
            new DynamicShape(new Vec2F(1.0f, 1.0f), new Vec2F(0.1f, 0.1f)),
            new Image(Path.Combine(FileIO.GetProjectPath(), "Assets", "Images", "red-block.png")),
            false));
    }

    [OneTimeSetUp]
    public void InitializeEventBus() {
        BreakoutBus.GetBus().InitializeEventBus(new List<GameEventType> { GameEventType.InputEvent,
            GameEventType.PlayerEvent, GameEventType.GameStateEvent, GameEventType.StatusEvent,
            GameEventType.ControlEvent, GameEventType.MovementEvent } );
    }

    [OneTimeTearDown]
    public void ResetEventbus() {
        BreakoutBus.ResetBus();
    }

    [SetUp]
    public void InitalizeTests() {
        Window.CreateOpenGLContext();
        powerUpSpawner = new PowerUpSpawner();
        BreakoutBus.GetBus().Subscribe(GameEventType.ControlEvent, powerUpSpawner);

        powerUpBlocks = new EntityContainer<BreakoutBlock>();
        powerUpBlocks.AddEntity(new StandardBlock(
            new DynamicShape(new Vec2F(1.0f, 1.0f), new Vec2F(0.1f, 0.1f)),
            new Image(Path.Combine(FileIO.GetProjectPath(), "Assets", "Images", "red-block.png")),
            true));

        noPowerUpBlocks = new EntityContainer<BreakoutBlock>();
        noPowerUpBlocks.AddEntity(new StandardBlock(
            new DynamicShape(new Vec2F(1.0f, 1.0f), new Vec2F(0.1f, 0.1f)),
            new Image(Path.Combine(FileIO.GetProjectPath(), "Assets", "Images", "red-block.png")),
            false));
    }
    //Tests that it can process an event thus spawning a powerUp. 
    [Test]
    public void TestSpawnPowerUp() {
        BreakoutBus.GetBus().RegisterEvent(
            new GameEvent {
                EventType = GameEventType.ControlEvent,
                Message = "SpawnPowerUp",
                ObjectArg1 = new StandardBlock(
                    new DynamicShape(new Vec2F(1.0f, 1.0f), new Vec2F(0.1f, 0.1f)),
                    new Image(Path.Combine(FileIO.GetProjectPath(), "Assets", "Images", "red-block.png")),
                    true),
            }
        );
        BreakoutBus.GetBus().ProcessEventsSequentially();

        Assert.Greater(powerUpSpawner.GetPowerUps().CountEntities(), 0);
    }
    //Tests the spawning of PowerUps when a block, that contains a powerUp, dies
    [Test]
    public void TestSpawnPowerUp_Block() {
        for (int i = 0; i < 10; i++) {
            powerUpBlocks.Iterate(block => {
                block.Hit();
                block.Dead();
            } );
        }
        BreakoutBus.GetBus().ProcessEventsSequentially();
        Assert.Greater(powerUpSpawner.GetPowerUps().CountEntities(), 0);
    }
    //Tests that no power up will spawn when a block, that doesn't contain a powerUp dies. 
    [Test]
    public void TestNoSpawnPower_Block() {
        for (int i = 0; i < 10; i++) {
            noPowerUpBlocks.Iterate(block => {
                block.Hit();
                block.Dead();
            } );
        }
        BreakoutBus.GetBus().ProcessEventsSequentially();
        Assert.AreEqual(powerUpSpawner.GetPowerUps().CountEntities(), 0);
    }
}
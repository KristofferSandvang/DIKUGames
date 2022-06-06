using Breakout;
using Breakout.BreakoutStates;
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


#pragma warning disable 8618

namespace breakoutTests;
public class GameControlTest {
    private StateMachine stateMachine;
    private GameControl gameControl;
    private Player player;
    private GameTime gameTime;
    private EntityContainer<BreakoutBlock> blocks;

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

        stateMachine = new StateMachine();
        gameControl = new GameControl();
        gameTime = new GameTime(1);
        player = new Player(
                 new DynamicShape(new Vec2F(0.435f, 0.1f), new Vec2F(0.15f, 0.03f)),
                 new Image(Path.Combine("Assets", "Images", "player.png")));

        blocks = new EntityContainer<BreakoutBlock>();
        blocks.AddEntity(new StandardBlock(
            new DynamicShape(new Vec2F(1.0f, 1.0f), new Vec2F(0.1f, 0.1f)),
            new Image(Path.Combine(FileIO.GetProjectPath(), "Assets", "Images", "red-block.png")),
            true));
    
        BreakoutBus.GetBus().Subscribe(GameEventType.PlayerEvent, player);
        BreakoutBus.GetBus().Subscribe(GameEventType.GameStateEvent, stateMachine);
        BreakoutBus.GetBus().Subscribe(GameEventType.ControlEvent, gameControl);
    }
    //Tests that you can lose the game by having no lives. 
    [Test]
    public void TestGameOver_NoLives() {
        for (int i = 0; i < 3; i++) {
            BreakoutBus.GetBus().RegisterEvent(
                new GameEvent {
                    EventType = GameEventType.PlayerEvent,
                    Message = "LoseLife",
                }
            );
        }

        BreakoutBus.GetBus().ProcessEventsSequentially();
        gameControl.GameOver(gameTime, player, blocks);
        BreakoutBus.GetBus().ProcessEventsSequentially();

        Assert.IsInstanceOf<GameOver>(stateMachine.ActiveState);
    }
    //Tests that you can lose the game by running out of time. 
    [Test]
    public void TestGameOver_NoTime() {
        System.Threading.Thread.Sleep(1500);
        gameTime.Update();

        gameControl.GameOver(gameTime, player, blocks);
        BreakoutBus.GetBus().ProcessEventsSequentially();

        Assert.IsInstanceOf<GameOver>(stateMachine.ActiveState);
    }
    //Tests that you can win the game by destroying all blocks.
    [Test]
    public void TestGameWin_NoBlocks() {
        for (int i = 0; i < 10; i++) {
            blocks.Iterate(block => {
                block.Hit();
                block.Dead();
            } );
        }
        gameControl.GameOver(gameTime, player, blocks);
        BreakoutBus.GetBus().ProcessEventsSequentially();

        Assert.IsInstanceOf<GameWin>(stateMachine.ActiveState);
    }
    //Tests the spawning of PowerUps
    [Test]
    public void TestSpawnPowerUp() {
        for (int i = 0; i < 10; i++) {
            blocks.Iterate(block => {
                block.Hit();
                block.Dead();
            } );
        }

        BreakoutBus.GetBus().ProcessEventsSequentially();
        Assert.Greater(gameControl.GetPowerUps().CountEntities(), 0);
    }
}

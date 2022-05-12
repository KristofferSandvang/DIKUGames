using System;
using System.IO;
using DIKUArcade;
using DIKUArcade.GUI;
using DIKUArcade.Input;
using DIKUArcade.Entities;
using DIKUArcade.Graphics;
using DIKUArcade.Math;
using DIKUArcade.Physics;
using System.Security.Principal;
using System.Collections.Generic;
using DIKUArcade.Events;
using DIKUArcade.State;
using Breakout;
using Breakout.Levels;

namespace Breakout.BreakoutStates {
    /// <summary>
    /// A class of GameRunning, that contains all information needed for the game to run.
    /// </summary>
    public class GameRunning : IGameState {
        private static GameRunning? instance = null;
        private Player player;
        private static Level level = levelLoaders[0].CreateLevel();
        private static LevelLoader[] levelLoaders = {
            new LevelLoader("test.txt"),
            new LevelLoader("level2.txt"),
            new LevelLoader("level3.txt"),
        };       
        private EntityContainer<Ball> balls;
        private Score score; 
        /// <summary>
        /// Gets the instance of GameRunning
        /// </summary>
        public static GameRunning GetInstance() {
            if (instance == null) {
                GameRunning.instance = new GameRunning();
                GameRunning.instance.InitializeGameState();
            }
            return GameRunning.instance;
        }
        
        public GameRunning() {
            player = new Player(
                     new DynamicShape(new Vec2F(0.435f, 0.1f), new Vec2F(0.15f, 0.03f)),
                     new Image(Path.Combine("Assets", "Images", "player.png")));
            score = new Score(new Vec2F(0.05f, 0.7f), new Vec2F(0.3f, 0.3f));
            BreakoutBus.GetBus().Subscribe(GameEventType.PlayerEvent, player);
            balls = new EntityContainer<Ball>();
        }
        /// <summary>
        /// Initializes the GameRunning GameState
        /// </summary>
        public void InitializeGameState() {
            player = new Player(
                     new DynamicShape(new Vec2F(0.435f, 0.1f), new Vec2F(0.15f, 0.03f)),
                     new Image(Path.Combine("Assets", "Images", "player.png")));
            BreakoutBus.GetBus().Subscribe(GameEventType.PlayerEvent, player);
            balls = new EntityContainer<Ball>();
        }
        /// <summary>
        /// Resets the GameState
        /// </summary>
        public void ResetState() {
            InitializeGameState();
        }
        /// <summary>
        /// Updates the elements
        /// </summary>
        public void UpdateState() {
            player.Move();
            balls.Iterate(ball => {ball.Move(level.GetEC(), player);}); 
        }
        /// <summary>
        /// Renders the elements
        /// </summary>
        public void RenderState() {
            level.Render();
            player.Render();
            balls.RenderEntities();
            Score.Render();
        }
        public static void ChangeLevel(int lvl) {
            level = levelLoaders[lvl].CreateLevel();
        }
        /// <summary>
        /// Creates and registers a new event of the GameEventType.InputEvent
        /// based on the key released. 
        /// </summary>
        /// <param name='Key'>
        /// The Key released
        /// </param>
        private void KeyRelease(KeyboardKey key) {
            switch (key) {
                case KeyboardKey.Left:
                    BreakoutBus.GetBus().RegisterEvent(
                        new GameEvent {
                            EventType = GameEventType.PlayerEvent,
                            Message = "stopMoveLeft",
                        } );
                    break;
                case KeyboardKey.Right:
                    BreakoutBus.GetBus().RegisterEvent(
                        new GameEvent {
                            EventType = GameEventType.PlayerEvent,
                            Message = "stopMoveRight",
                        } );
                    break;
                case KeyboardKey.Escape:
                    BreakoutBus.GetBus().RegisterEvent(
                        new GameEvent {
                            EventType = GameEventType.InputEvent,
                            Message = "Close",
                        } );
                    break;
                case KeyboardKey.P:
                    BreakoutBus.GetBus().RegisterEvent(
                        new GameEvent {
                            EventType = GameEventType.GameStateEvent,
                            Message = "GamePaused",
                        } );
                    break;
                case KeyboardKey.Space:
                    balls.AddEntity(
                        new Ball(
                            new DynamicShape( new Vec2F(player.XPosition() + player.shape.Extent.X/2, 0.1f),
                            new Vec2F(0.008f, 0.021f), new Vec2F(0.0f, 0.01f)),
                            new Image(Path.Combine("Assets", "Images", "ball.png"))));
                    break;
            }
        }
        /// <summary>
        /// Creates a new event of the GameEventType.InputEvent, and registers it
        /// based on the pressed key. 
        /// </summary>
        /// <param name='Key'>
        /// The Key pressed
        /// </param>
        private void KeyPress(KeyboardKey key) {
            switch (key) {
                case KeyboardKey.Left: 
                    BreakoutBus.GetBus().RegisterEvent(
                        new GameEvent {
                            EventType = GameEventType.PlayerEvent,
                            Message = "moveLeft",
                        } );
                    break;
                case KeyboardKey.Right:
                    BreakoutBus.GetBus().RegisterEvent(
                        new GameEvent {
                            EventType = GameEventType.PlayerEvent,
                            Message = "moveRight",
                        } );
                    break;
            }
        }
        /// <summary>
        /// Handles a key based on the KeyBoardAction and KeyBoardKey
        /// </summary>
        /// <param name='action'>
        /// a KeyBoardAction
        /// </param>
        /// <param name='key'>
        /// a KeyBoardKey
        /// </param>
        public void HandleKeyEvent(KeyboardAction action, KeyboardKey key) {
            switch (action){
                case KeyboardAction.KeyPress:
                    KeyPress(key);
                    break;
                case KeyboardAction.KeyRelease:
                    KeyRelease(key);
                    break;
            }
        }
        /*public void ProcessEvent(GameEvent gameEvent) {
            if (gameEvent.EventType == GameEventType.GameStateEvent) {
                switch (gameEvent.Message) {
                    case "GameRunning":
                        ChangeLevel(gameEvent.IntArg1);
                    break;
                    default:
                    break;
                }
            }
        }*/
    }
}


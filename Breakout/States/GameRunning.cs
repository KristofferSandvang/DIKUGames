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

namespace Breakout.BreakoutStates {
    /// <summary>
    /// A class of GameRunning, that contains all information needed for the game to run.
    /// </summary>
    public class GameRunning : IGameState {
        private Player player;
        private EntityContainer<Block> blocks;
        private LevelLoader levelLoader;
        private static GameRunning instance = null;
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
            InitializeGameState();
        }
        /// <summary>
        /// Initializes the GameRunning GameState
        /// </summary>
        public void InitializeGameState() {
            player = new Player(
                    new DynamicShape(new Vec2F(0.45f, 0.1f), new Vec2F(0.15f, 0.03f)),
                    new Image(Path.Combine("Assets", "Images", "player.png")));
            BreakoutBus.GetBus().Subscribe(GameEventType.PlayerEvent, player);
            levelLoader = new LevelLoader("level3.txt");
            blocks = levelLoader.CreateMap();
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
            BreakoutBus.GetBus().ProcessEventsSequentially();
            player.Move();
        }
        /// <summary>
        /// Renders the elements
        /// </summary>
        public void RenderState() {
            blocks.RenderEntities();
            player.Render();
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
    }
}


using DIKUArcade.State;
using DIKUArcade.Graphics;
using DIKUArcade.Entities;
using DIKUArcade.Input;
using DIKUArcade.Math;
using DIKUArcade.Events;
using System.IO;
using Breakout;


namespace Breakout.BreakoutStates {
    /// <summary>
    /// A class of LevelSelector, that contains all information needed for LevelSelector to work.
    /// </summary>
    public class LevelSelector : IGameState {
        private Entity backGroundImage;
        private Text[] menuButtons;
        private int activeMenuButton;
        private int maxMenuButtons;
        public LevelSelector() {
            menuButtons = new Text[] { 
                new Text("Level 1", new Vec2F(0.45f, 0.2f), new Vec2F(0.4f, 0.4f)),
                new Text("Level 2", new Vec2F(0.45f, 0.1f), new Vec2F(0.4f, 0.4f)),
                new Text("Level 3", new Vec2F(0.45f, 0.0f), new Vec2F(0.4f, 0.4f)),
                new Text("Level 4", new Vec2F(0.45f, -0.1f), new Vec2F(0.4f, 0.4f)),
                new Text("Back", new Vec2F(0.45f, -0.2f), new Vec2F(0.4f, 0.4f)),

            };
            foreach (var button in menuButtons) {
                button.SetColor(System.Drawing.Color.Blue);
                button.SetFontSize(50);
            }
            backGroundImage = new Entity(
                new StationaryShape(new Vec2F(0f, 0f), new Vec2F(1f, 1f)), 
                new Image(Path.Combine("Assets", "Images", "BreakoutTitleScreen.png")));
            maxMenuButtons = menuButtons.Length;
            activeMenuButton = 0;
        }
        /// <summary>
        /// Resets the LevelSelector state
        /// </summary>
        public void ResetState() {
            activeMenuButton = 0;
            foreach (var button in menuButtons) {
                button.SetColor(System.Drawing.Color.Blue);
                button.SetFontSize(50);
            }
            menuButtons[activeMenuButton].SetColor(System.Drawing.Color.White);
        }
        /// <summary>
        /// Updates the LevelSelector state
        /// </summary>
        public void UpdateState() {
            foreach (Text button in menuButtons) {
                button.SetColor(System.Drawing.Color.Blue);
            }
            menuButtons[activeMenuButton].SetColor(System.Drawing.Color.White);
        }
        /// <summary>
        /// Renders the LevelSelector state
        /// </summary>
        public void RenderState() {
            backGroundImage.RenderEntity();
            foreach (var button in menuButtons) {
                button.RenderText();
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
            if (action == KeyboardAction.KeyRelease) {
                KeyRelease(key);
            } 
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
                case KeyboardKey.Up:
                    if (activeMenuButton != 0) {
                        activeMenuButton -= 1;
                    }
                    break;
                case KeyboardKey.Down:
                    if (activeMenuButton != maxMenuButtons - 1) {
                        activeMenuButton += 1;
                    }
                    break;
                case KeyboardKey.Enter:
                    if (activeMenuButton == 0) {
                        BreakoutBus.GetBus().RegisterEvent(
                            new GameEvent {
                                EventType = GameEventType.GameStateEvent,
                                Message = "SwitchState",
                                StringArg1 = "GameRunning", 
                            }
                        );
                        GameRunning.ChangeLevel(0);
                    } else if (activeMenuButton == 1) {
                         BreakoutBus.GetBus().RegisterEvent(
                            new GameEvent {
                                EventType = GameEventType.GameStateEvent,
                                Message = "SwitchState",
                                StringArg1 = "GameRunning"
                            }
                        );
                        GameRunning.ChangeLevel(1);
                    } else if (activeMenuButton == 2) {
                         BreakoutBus.GetBus().RegisterEvent(
                            new GameEvent {
                                EventType = GameEventType.GameStateEvent,
                                Message = "SwitchState",
                                StringArg1 = "GameRunning"
                            }
                        );
                        GameRunning.ChangeLevel(3);
                    } else if (activeMenuButton == 3) {
                         BreakoutBus.GetBus().RegisterEvent(
                            new GameEvent {
                                EventType = GameEventType.GameStateEvent,
                                Message = "SwitchState",
                                StringArg1 = "GameRunning"
                            }
                        );
                        GameRunning.ChangeLevel(3);
                    } else if (activeMenuButton == 4) {
                        BreakoutBus.GetBus().RegisterEvent(
                            new GameEvent {
                                EventType = GameEventType.GameStateEvent,
                                Message = "SwitchState",
                                StringArg1 = "MainMenu"
                            }
                        );
                    }
                    break;
                case KeyboardKey.Escape:
                    BreakoutBus.GetBus().RegisterEvent(
                            new GameEvent {
                                EventType = GameEventType.InputEvent,
                                Message = "Close",
                            }
                        );
                    break;
            }
        }


    }
}



using DIKUArcade.State;
using DIKUArcade.Graphics;
using DIKUArcade.Entities;
using DIKUArcade.Input;
using DIKUArcade.Math;
using DIKUArcade.Events;
using System.IO;



namespace Breakout.BreakoutStates {
    /// <summary>
    /// A class of MainMenu, that contains all information needed for MainMenu to work.
    /// </summary>
    public class GamePaused : IGameState {
        private static GamePaused? instance = null;
        private Entity backGroundImage;
        private Text[] menuButtons;
        private int activeMenuButton;
        private int maxMenuButtons;
        public GamePaused() {
            menuButtons = new Text[] { 
                new Text("Continue", new Vec2F(0.45f, 0.4f), new Vec2F(0.2f, 0.2f)),
                new Text("Main Menu", new Vec2F(0.45f, 0.2f), new Vec2F(0.2f, 0.2f)),
            };
            foreach (var button in menuButtons) {
                button.SetColor(System.Drawing.Color.White);
                button.SetFontSize(50);
            }
            backGroundImage = new Entity(
                new StationaryShape(new Vec2F(0f, 0f), new Vec2F(1f, 1f)), 
                new Image(Path.Combine("Assets", "Images", "shipit_titlescreen.png")));

            maxMenuButtons = menuButtons.Length;
            activeMenuButton = 0;
        }
        /// <summary>
        /// Gets the instance of GameRunning
        /// </summary>
        public static GamePaused GetInstance() {
            if (GamePaused.instance == null) {
                GamePaused.instance = new GamePaused();
                GamePaused.instance.InitializeGameState();
            }
            return GamePaused.instance;
        }
        /// <summary>
        /// Initialize the MainMenu-state 
        /// </summary>
        public void InitializeGameState() {
            menuButtons = new Text[] { 
                new Text("Continue", new Vec2F(0.45f, 0.4f), new Vec2F(0.2f, 0.2f)),
                new Text("Main Menu", new Vec2F(0.45f, 0.2f), new Vec2F(0.2f, 0.2f)),
            };
            foreach (var button in menuButtons) {
                button.SetColor(System.Drawing.Color.White);
                button.SetFontSize(50);
            }
            backGroundImage = new Entity(
                new StationaryShape(new Vec2F(0f, 0f), new Vec2F(1f, 1f)), 
                new Image(Path.Combine("Assets", "Images", "shipit_titlescreen.png")));
        }
        /// <summary>
        /// Resets the MainMenu state
        /// </summary>
        public void ResetState() {
            InitializeGameState();
        }
        /// <summary>
        /// Updates the MainMenu state
        /// </summary>
        public void UpdateState() {
            foreach (Text button in menuButtons) {
                button.SetColor(System.Drawing.Color.Blue);
            }
            menuButtons[activeMenuButton].SetColor(System.Drawing.Color.White);
        }
        /// <summary>
        /// Renders the MainMenu state
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
                    if (activeMenuButton == 1) {
                        activeMenuButton -= 1;
                    }
                    break;
                case KeyboardKey.Down:
                    if (activeMenuButton == 0) {
                        activeMenuButton += 1;
                    }
                    break;
                case KeyboardKey.Enter:
                    if (activeMenuButton == 0) {
                        BreakoutBus.GetBus().RegisterEvent(
                            new GameEvent {
                                EventType = GameEventType.GameStateEvent,
                                Message = "GameRunning",
                            }
                        );
                    } else if (activeMenuButton == 1){
                         BreakoutBus.GetBus().RegisterEvent(
                            new GameEvent {
                                EventType = GameEventType.GameStateEvent,
                                Message = "MainMenu",
                            }
                        );
                    }
                    break;
            }
        }


    }
}

using DIKUArcade.State;
using DIKUArcade.Graphics;
using DIKUArcade.Entities;
using DIKUArcade.Input;
using DIKUArcade.Math;
using DIKUArcade.Events;
using DIKUArcade.Timers;
using System.IO;
using Breakout;


namespace Breakout.BreakoutStates {
    /// <summary>
    /// A class of MainMenu, that contains all information needed for MainMenu to work.
    /// </summary>
    public class GameOver: IGameState {
        private static GameOver? instance = null;
        private Entity backGroundImage;
        private Text[] menuButtons;
        private Text HeadLine;
        private int activeMenuButton;
        private int maxMenuButtons;
        private Score score;
        private Text yourScore;

        public GameOver() {
            menuButtons = new Text[] {
                new Text("Quit Game", new Vec2F(0.45f, 0.2f), new Vec2F(0.2f, 0.2f)),
                new Text("Main Menu", new Vec2F(0.45f, 0.1f), new Vec2F(0.2f, 0.2f))
            };
            foreach (var button in menuButtons) {
                button.SetColor(System.Drawing.Color.Yellow);
                button.SetFontSize(50);
            }
            HeadLine = new Text("GameOver!", new Vec2F(0.4f, 0.4f), new Vec2F(0.5f, 0.5f));
            HeadLine.SetColor(System.Drawing.Color.Yellow);
            HeadLine.SetFontSize(100);

            score = new Score(new Vec2F(0.4f, 0.5f), new Vec2F(0.3f, 0.3f));
            yourScore = new Text(string.Format("Your score: " + score.GetScore()), 
                                 new Vec2F(0.40f, 0.5f), new Vec2F(0.3f, 0.3f));
            yourScore.SetColor(System.Drawing.Color.Yellow);
            yourScore.SetFontSize(60);

            backGroundImage = new Entity(
                new StationaryShape(new Vec2F(0f, 0f), new Vec2F(1f, 1f)), 
                new Image(Path.Combine("Assets", "Images", "SpaceBackground.png")));

            maxMenuButtons = menuButtons.Length;
            activeMenuButton = 0;
            Console.WriteLine(StaticTimer.GetElapsedSeconds());
        }

        /// <summary>
        /// Gets the instance of GameOver
        /// </summary>
        public static GameOver GetInstance() {
            if (GameOver.instance == null) {
                GameOver.instance = new GameOver();
                GameOver.instance.InitializeGameState();
            }
            return GameOver.instance;
        }
        /// <summary>
        /// Initialize the GameOver-state 
        /// </summary>
        public void InitializeGameState() {
            menuButtons = new Text[] {
                new Text("Quit Game", new Vec2F(0.45f, 0.2f), new Vec2F(0.2f, 0.2f)),
                new Text("Main Menu", new Vec2F(0.45f, 0.1f), new Vec2F(0.2f, 0.2f))
            };
            foreach (var button in menuButtons) {
                button.SetColor(System.Drawing.Color.Yellow);
                button.SetFontSize(50);
            }
            HeadLine = new Text("GameOver!", new Vec2F(0.4f, 0.4f), new Vec2F(0.5f, 0.5f));
            HeadLine.SetColor(System.Drawing.Color.Yellow);
            HeadLine.SetFontSize(100);

            backGroundImage = new Entity(
                new StationaryShape(new Vec2F(0f, 0f), new Vec2F(1f, 1f)), 
                new Image(Path.Combine("Assets", "Images", "SpaceBackground.png")));
        }

        /// <summary>
        /// Resets the GameOver state
        /// </summary>
        public void ResetState() {
            InitializeGameState();
        }
        /// <summary>
        /// Updates the GameOver state
        /// </summary>
        public void UpdateState() {
            foreach (Text button in menuButtons) {
                button.SetColor(System.Drawing.Color.Blue);
            }
            menuButtons[activeMenuButton].SetColor(System.Drawing.Color.White);
        }
        /// <summary>
        /// Renders the GameOver state
        /// </summary>
        public void RenderState() {
            backGroundImage.RenderEntity();
            foreach (var button in menuButtons) {
                button.RenderText();
            }
            HeadLine.RenderText();
            yourScore.RenderText();
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
                                EventType = GameEventType.InputEvent,
                                Message = "Close",
                            }
                        );
                    }
                    else if (activeMenuButton == 1) {
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
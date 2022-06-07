using DIKUArcade.Timers;
using DIKUArcade.Input;
using DIKUArcade.Entities;
using DIKUArcade.Graphics;
using DIKUArcade.Math;
using DIKUArcade.Events;
using DIKUArcade.State;
using Breakout;
using Breakout.Levels;

namespace Breakout.BreakoutStates {
    /// <summary>
    /// A class of GameRunning, that contains all information needed for the game to run.
    /// </summary>
    public class GameRunning : IGameState {
        private Player player;
        private static LevelLoader[] levelLoaders = {
            new LevelLoader("test.txt"),
            new LevelLoader("level2.txt"),
            new LevelLoader("level3.txt"),
            new LevelLoader("level4.txt")
        }; 
        private static Level level = levelLoaders[0].CreateLevel();      
        private EntityContainer<Ball> balls;
        private Score score; 
        private GameControl controller;
        private GameTime timer;
        
        public GameRunning() {
            player = new Player(
                     new DynamicShape(new Vec2F(0.435f, 0.1f), new Vec2F(0.15f, 0.03f)),
                     new Image(Path.Combine("Assets", "Images", "player.png")));

            score = new Score(new Vec2F(0.0f, 0.7f), new Vec2F(0.3f, 0.3f));
            balls = new EntityContainer<Ball>();
            timer = new GameTime(level.GetTime());
            controller = new GameControl();

            BreakoutBus.GetBus().Subscribe(GameEventType.PlayerEvent, player);
            BreakoutBus.GetBus().Subscribe(GameEventType.StatusEvent, score);
            BreakoutBus.GetBus().Subscribe(GameEventType.ControlEvent, controller);
            BreakoutBus.GetBus().Subscribe(GameEventType.ControlEvent, timer);
        }
        /// <summary>
        /// Resets the GameState
        /// </summary>
        public void ResetState() {
            BreakoutBus.GetBus().Unsubscribe(GameEventType.StatusEvent, score);
            BreakoutBus.GetBus().Unsubscribe(GameEventType.PlayerEvent, player);
            BreakoutBus.GetBus().Unsubscribe(GameEventType.ControlEvent, controller);
            BreakoutBus.GetBus().Unsubscribe(GameEventType.ControlEvent, timer);
            player = new Player(
                     new DynamicShape(new Vec2F(0.435f, 0.1f), new Vec2F(0.15f, 0.03f)),
                     new Image(Path.Combine("Assets", "Images", "player.png")));

            
            score = new Score(new Vec2F(0.0f, 0.7f), new Vec2F(0.3f, 0.3f));
            score.ResetScore();
            controller = new GameControl();
            balls = new EntityContainer<Ball>();
            timer = new GameTime(level.GetTime());

            BreakoutBus.GetBus().Subscribe(GameEventType.ControlEvent, controller);
            BreakoutBus.GetBus().Subscribe(GameEventType.PlayerEvent, player);
            BreakoutBus.GetBus().Subscribe(GameEventType.StatusEvent, score);
            BreakoutBus.GetBus().Subscribe(GameEventType.ControlEvent, timer);
        }
        /// <summary>
        /// Updates the elements
        /// </summary>
        public void UpdateState() {
            player.Move();
            balls.Iterate(ball => {ball.Move(level.GetEC(), player);});
            score.Update(); 
            timer.Update();
            controller.GameOver(timer, player, level.GetEC());
            controller.Update(player);
        }
        /// <summary>
        /// Renders the elements
        /// </summary>
        public void RenderState() {
            level.Render();
            player.Render();
            balls.RenderEntities();
            score.Render();
            timer.Render();
            controller.Render();
        }
        /// <summary>
        /// Changes the active level, that is being played
        /// </summary>
        /// <param name='lvl'>
        /// The level to switch to.
        /// </param>
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
                            Message = "SwitchState",
                            StringArg1 = "GamePaused",
                        } );
                        StaticTimer.PauseTimer();
                    break;
                case KeyboardKey.Space:
                    if (balls.CountEntities() == 0) {
                        balls.AddEntity(
                            new Ball(
                                new DynamicShape( new Vec2F(player.XPosition() + 
                                                  player.shape.Extent.X/2, 0.1f),
                                new Vec2F(0.008f, 0.021f), new Vec2F(0.0f, 0.01f)),
                                new Image(Path.Combine("Assets", "Images", "ball.png"))
                            )
                        );
                        foreach (Ball ball in balls) {
                        BreakoutBus.GetBus().Subscribe(GameEventType.MovementEvent, ball);
                        }
                    } break;
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


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
using Galaga.Squadron;
using Galaga.MovementStrategy;
using DIKUArcade.State;

namespace Galaga.GalagaStates {
    /// <summary>
    /// A class of GameRunning, that contains all information needed for the game to run.
    /// </summary>
    public class GameRunning : IGameState {
        private static GameRunning instance = null;
        private bool gameOver;
        private EntityContainer<Enemy> Enemies;
        private List<Image> enemyStrides; 
        private Player player;
        private Score score;
        private Random rand;
        private IBaseImage playerShotImage;
        private EntityContainer<PlayerShot> playerShots;
        private AnimationContainer enemyExplosions;
        private List<Image> explosionStrides;
        private ISquadron formation; 
        private IMovementStrategy MovementStrategy;
        private int wave;
        private const int EXPLOSION_LENGTH_MS = 500;
        private ISquadron[] formations = { 
            new VFormation(),
            new SquareFormation(),
            new RainFormation() };
        private IMovementStrategy[] MovementStrategies = { 
            new Down(),
            new ZigZagDown(), 
            new NoMove() }; 
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
            gameOver = false;

            player = new Player(
                     new DynamicShape(new Vec2F(0.45f, 0.1f), new Vec2F(0.1f, 0.1f)),
                     new Image(Path.Combine("Assets", "Images", "Player.png")));
            playerShots = new EntityContainer<PlayerShot>();
            playerShotImage = new Image(Path.Combine("Assets", "Images", "BulletRed2.png"));

            score = new Score(new Vec2F(0.05f, 0.7f), new Vec2F(0.3f, 0.3f));
            rand = new Random();
            

            enemyStrides = ImageStride.CreateStrides(4,
            Path.Combine("Assets", "Images", "BlueMonster.png"));
            Enemies = new EntityContainer<Enemy>(8);

            enemyExplosions = new AnimationContainer(8);
            explosionStrides = ImageStride.CreateStrides(8,
                Path.Combine("Assets", "Images", "Explosion.png"));

            wave = 0;
            newWave();

            GalagaBus.GetBus().Subscribe(GameEventType.PlayerEvent, player);
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
            newWave();
            isThisLoss();
            MovementStrategy.MoveEnemies(Enemies);
            IterateShots();
            GalagaBus.GetBus().ProcessEventsSequentially();
            player.move();
        }
        /// <summary>
        /// Renders the elements
        /// </summary>
        public void RenderState() {
            score.RenderScore();
            if (!gameOver) {
                player.Render();
                Enemies.RenderEntities();
                playerShots.RenderEntities();
                enemyExplosions.RenderAnimations();
            }
        }
        /// <summary>
        /// Adds an explosion to a position
        /// </summary>
        /// <param name='postion'>
        /// The position of the explosion
        /// </param>
        /// <param name='extent'>
        /// The extent of the explosion
        /// </param>
        public void AddExplosion(Vec2F position, Vec2F extent) {
            enemyExplosions.AddAnimation(
                new StationaryShape(position, extent),
                EXPLOSION_LENGTH_MS,
                new ImageStride(EXPLOSION_LENGTH_MS/8, explosionStrides)
            );
        }
        
        /// <summary>
        /// Creates a new wave of enemies once the last wave have been defeated
        /// </summary>
        private void newWave() {
            if (Enemies.CountEntities() <= 0) {
                wave++;
                formation = formations[rand.Next(3)];
                Enemies = formation.Enemies;
                formation.CreateEnemies(enemyStrides);
                Enemies.Iterate( enemy => enemy.speedier(wave * 0.00045f));

                if (formation == new RainFormation()) {
                    MovementStrategy = MovementStrategies[rand.Next(2)];
                } else {MovementStrategy = MovementStrategies[rand.Next(3)];}
            }
        }
        /// <summary>
        /// Checks if the game is lost
        /// </summary>
        private void isThisLoss() {
            foreach (Enemy enemy in Enemies){
                if (enemy.Shape.Position.Y < 0.20f) {
                    gameOver = true;
                }
            }
        }
        /// <summary>
        /// Iterates the shots and checks for collisions between Enemy and the shot. 
        /// </summary>
        private void IterateShots() {
            playerShots.Iterate(shot => {
                float shotY = shot.Shape.Position.Y;
                shot.Shape.Move();
                if (shotY >= 1.0f) {
                    shot.DeleteEntity();
                } else {
                    Enemies.Iterate(enemy => {
                        if (CollisionDetection.Aabb(shot.Shape.AsDynamicShape(),
                            enemy.Shape).Collision) {
                            enemy.isHit();
                            shot.DeleteEntity();
                            if (enemy.isDead()) {
                                enemy.DeleteEntity();
                                AddExplosion(enemy.Shape.Position, enemy.Shape.Extent);
                                score.AddPoints();
                            }
                        }
                    });
                }
            });
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
                    GalagaBus.GetBus().RegisterEvent(
                        new GameEvent {
                            EventType = GameEventType.PlayerEvent,
                            Message = "stopMoveLeft",
                        } );
                    break;
                case KeyboardKey.Right:
                    GalagaBus.GetBus().RegisterEvent(
                        new GameEvent {
                            EventType = GameEventType.PlayerEvent,
                            Message = "stopMoveRight",
                        } );
                    break;
                case KeyboardKey.Escape:
                    GalagaBus.GetBus().RegisterEvent(
                        new GameEvent {
                            EventType = GameEventType.InputEvent,
                            Message = "close",
                        } );
                    break;
                case KeyboardKey.Space:
                        playerShots.AddEntity(new PlayerShot(
                            player.shotPosition(), playerShotImage));
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
                    GalagaBus.GetBus().RegisterEvent(
                        new GameEvent {
                            EventType = GameEventType.PlayerEvent,
                            Message = "moveLeft",
                        } );
                    break;
                case KeyboardKey.Right:
                    GalagaBus.GetBus().RegisterEvent(
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

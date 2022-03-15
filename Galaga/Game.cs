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

namespace Galaga {
    /// <summary>
    /// A subclass of the DIKUGame containing all information about the Game.
    /// </summary>
    public class Game : DIKUGame, IGameEventProcessor{
        private EntityContainer<Enemy> Enemies;
        private AnimationContainer enemyExplosions;
        private List<Image> explosionStrides;
        private const int EXPLOSION_LENGTH_MS = 500;
        private IBaseImage playerShotImage;
        private EntityContainer<PlayerShot> playerShots;
        private Player player;
        private GameEventBus eventBus;
        private List<Image> enemyStridesRed;
        private ISquadron formation;
        private IMovementStrategy MovementStrategy; 
        public Game(WindowArgs windowArgs) : base(windowArgs) {
            player = new Player(
                     new DynamicShape(new Vec2F(0.45f, 0.1f), new Vec2F(0.1f, 0.1f)),
                     new Image(Path.Combine("Assets", "Images", "Player.png")));

            eventBus = new GameEventBus();
            eventBus.InitializeEventBus(new List<GameEventType> { GameEventType.InputEvent, GameEventType.PlayerEvent });
            window.SetKeyEventHandler(KeyHandler);
            eventBus.Subscribe(GameEventType.InputEvent, this);
            eventBus.Subscribe(GameEventType.PlayerEvent, player);

            enemyStridesRed = ImageStride.CreateStrides(2, Path.Combine("Assets",
            "Images", "RedMonster.png"));

            var images = ImageStride.CreateStrides(4, Path.Combine("Assets", "Images", "BlueMonster.png"));
            const int numEnemies = 8;
            Enemies = new EntityContainer<Enemy>(numEnemies);
            //for (int i = 0; i < numEnemies; i++) {
            //    Enemies.AddEntity(new Enemy(
            //        new DynamicShape(new Vec2F(0.1f + (float)i * 0.1f, 0.9f), new Vec2F(0.1f, 0.1f)),
            //        new ImageStride(80, images)));
            //}

            playerShots = new EntityContainer<PlayerShot>();
            playerShotImage = new Image(Path.Combine("Assets", "Images", "BulletRed2.png"));

            enemyExplosions = new AnimationContainer(numEnemies);
            explosionStrides = ImageStride.CreateStrides(8,
                Path.Combine("Assets", "Images", "Explosion.png"));

            formation = new SquareFormation();
            formation.CreateEnemies(images);
            Enemies = formation.Enemies;
            MovementStrategy = new ZigZigDown();
        } 
        /// <summary>
        /// Creates a new event of the GameEventType.InputEvent, and registers it
        /// based on the pressed key. 
        /// </summary>
        /// <param name='Key'>
        /// The Key pressed
        /// </param>
        public void KeyPress(KeyboardKey key) {
            switch (key) {
                case KeyboardKey.Left: 
                    eventBus.RegisterEvent(
                        new GameEvent {
                            EventType = GameEventType.PlayerEvent,
                            Message = "moveLeft",
                        } );
                    break;
                case KeyboardKey.Right:
                    eventBus.RegisterEvent(
                        new GameEvent {
                            EventType = GameEventType.PlayerEvent,
                            Message = "moveRight",
                        } );
                    break;
            }
        }
        /// <summary>
        /// Creates and registers a new event of the GameEventType.InputEvent
        /// based on the key released. 
        /// </summary>
        /// <param name='Key'>
        /// The Key released
        /// </param>
        public void KeyRelease(KeyboardKey key) {
            switch (key) {
                case KeyboardKey.Left:
                    eventBus.RegisterEvent(
                        new GameEvent {
                            EventType = GameEventType.PlayerEvent,
                            Message = "stopMoveLeft",
                        } );
                    break;
                case KeyboardKey.Right:
                    eventBus.RegisterEvent(
                        new GameEvent {
                            EventType = GameEventType.PlayerEvent,
                            Message = "stopMoveRight",
                        } );
                    break;
                case KeyboardKey.Escape:
                    eventBus.RegisterEvent(
                        new GameEvent {
                            EventType = GameEventType.InputEvent,
                            Message = "close",
                        } );
                    break;
                case KeyboardKey.Space:
                    eventBus.RegisterEvent(
                        new GameEvent {
                            EventType = GameEventType.InputEvent,
                            Message = "shotFired",
                        } );
                    break;
            }
        }
        /// <summary>
        /// Processes a GameEvent based on the GameEvent.Message
        /// </summary>
        /// <param name='gameEvent'>
        /// A GameEvent
        /// </param>
        public void ProcessEvent(GameEvent gameEvent) {
            if (gameEvent.EventType == GameEventType.InputEvent) {
                switch (gameEvent.Message) {
                    case "close":
                        window.CloseWindow();
                        break;
                    case "shotFired":
                        playerShots.AddEntity(new PlayerShot(
                            player.shotPosition(), playerShotImage));
                        break;   
                    default:
                        break;
                }
            }
        }
        /// <summary>
        /// Renders all Entities in the game.
        /// </summary>
        public override void Render() {
            player.Render();
            Enemies.RenderEntities();
            playerShots.RenderEntities();
            enemyExplosions.RenderAnimations();
        }
        /// <summary>
        /// Updates the Game
        /// </summary>
        public override void Update() {
            MovementStrategy.MoveEnemies(Enemies);
            IterateShots();
            eventBus.ProcessEventsSequentially();
            player.move();
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
        /// Handles a key based on the KeyBoardAction and KeyBoardKey
        /// </summary>
        /// <param name='action'>
        /// a KeyBoardAction
        /// </param>
        /// <param name='key'>
        /// a KeyBoardKey
        /// </param>
        private void KeyHandler(KeyboardAction action, KeyboardKey key) {
            switch (action){
                case KeyboardAction.KeyPress:
                    KeyPress(key);
                    break;
                case KeyboardAction.KeyRelease:
                    KeyRelease(key);
                    break;
            }
        }

    
        /// <summary>
        /// Iterates the shots and checks for collisions between Enemy and the shot. 
        /// </summary>
        private void IterateShots() {
            playerShots.Iterate(shot => {
                float shotY = shot.Shape.Position.Y;
                shot.Shape.Move();
                if (shotY < 0.0f && shotY > 1.0f) {
                    shot.DeleteEntity();
                } else {
                    Enemies.Iterate(enemy => {
                        if (CollisionDetection.Aabb(shot.Shape.AsDynamicShape(), enemy.Shape).Collision) {
                            enemy.isHit();
                            shot.DeleteEntity();
                            if (enemy.isDead()) {
                                enemy.DeleteEntity();
                                AddExplosion(enemy.Shape.Position, enemy.Shape.Extent);
                            }
                        }
                        else if (enemy.Shape.Position.Y < -0.1f) {
                            enemy.DeleteEntity();
                        } 
                    });
                }
            });
        }
    }
} 

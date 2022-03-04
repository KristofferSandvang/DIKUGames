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

namespace Galaga {
    /// <summary>
    /// A subclass of the DIKUGame containing all information about the Game.
    /// </summary>
    public class Game : DIKUGame, IGameEventProcessor {
        private AnimationContainer enemyExplosions;
        private List<Image> explosionStrides;
        private const int EXPLOSION_LENGTH_MS = 500;
        private IBaseImage playerShotImage;
        private EntityContainer<PlayerShot> playerShots;
        private EntityContainer<Enemy> enemies;
        private Player player;
        private GameEventBus eventBus;
        public Game(WindowArgs windowArgs) : base(windowArgs) {
            eventBus = new GameEventBus();
            eventBus.InitializeEventBus(new List<GameEventType> { GameEventType.InputEvent });

            window.SetKeyEventHandler(KeyHandler);

            eventBus.Subscribe(GameEventType.InputEvent, this);

            player = new Player(
                new DynamicShape(new Vec2F(0.45f, 0.1f), new Vec2F(0.1f, 0.1f)),
                new Image(Path.Combine("Assets", "Images", "Player.png")));

            var images = ImageStride.CreateStrides(4, Path.Combine("Assets", "Images", "BlueMonster.png"));
            const int numEnemies = 8;
            enemies = new EntityContainer<Enemy>(numEnemies);
            for (int i = 0; i < numEnemies; i++) {
                enemies.AddEntity(new Enemy(
                    new DynamicShape(new Vec2F(0.1f + (float)i * 0.1f, 0.9f), new Vec2F(0.1f, 0.1f)),
                    new ImageStride(80, images)));
            }

            playerShots = new EntityContainer<PlayerShot>();
            playerShotImage = new Image(Path.Combine("Assets", "Images", "BulletRed2.png"));

            enemyExplosions = new AnimationContainer(numEnemies);
            explosionStrides = ImageStride.CreateStrides(8,
                Path.Combine("Assets", "Images", "Explosion.png"));
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
                            EventType = GameEventType.InputEvent,
                            Message = "moveLeft",
                        } );
                    break;
                case KeyboardKey.Right:
                    eventBus.RegisterEvent(
                        new GameEvent {
                            EventType = GameEventType.InputEvent,
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
                            EventType = GameEventType.InputEvent,
                            Message = "stopMoveLeft",
                        } );
                    break;
                case KeyboardKey.Right:
                    eventBus.RegisterEvent(
                        new GameEvent {
                            EventType = GameEventType.InputEvent,
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
                    case "moveLeft":
                        player.SetMoveLeft(true);
                        break;
                    case "moveRight":
                        player.SetMoveRight(true);
                        break;
                    case "stopMoveLeft":
                        player.SetMoveLeft(false);
                        break;
                    case "stopMoveRight":
                        player.SetMoveRight(false);
                        break;
                    case "shotFired":
                        playerShots.AddEntity(new PlayerShot(
                            player.getPosition(), playerShotImage));
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
            enemies.RenderEntities();
            playerShots.RenderEntities();
            enemyExplosions.RenderAnimations();
        }
        /// <summary>
        /// Updates the Game
        /// </summary>
        public override void Update() {
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
                    enemies.Iterate(enemy => {
                        if (CollisionDetection.Aabb(shot.Shape.AsDynamicShape(), enemy.Shape).Collision) {
                            enemy.DeleteEntity();
                            shot.DeleteEntity();
                            AddExplosion(enemy.Shape.Position, enemy.Shape.Extent);
                        } 
                    });
                }
            });
        }
    }
} 

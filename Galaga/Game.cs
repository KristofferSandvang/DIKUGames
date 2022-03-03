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
    public class Game : DIKUGame, IGameEventProcessor {
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
        } 
        public void KeyPress(KeyboardKey key) {
            // TODO: switch on key string and set the player's move direction
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
        public void KeyRelease(KeyboardKey key) {
            // TODO: switch on key string and disable the player's move direction
            // TODO: Close window if escape is pressed
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
            }
        }

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
                    default:
                        break;
                }
            }
        }

        public override void Render() {
            player.Render();
            enemies.RenderEntities();
        }

        public override void Update() {
            eventBus.ProcessEventsSequentially();
            player.move();
        }
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
    }
}


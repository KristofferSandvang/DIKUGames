using System;
using System.IO;
using DIKUArcade;
using DIKUArcade.GUI;
using DIKUArcade.Input;
using DIKUArcade.Entities;
using DIKUArcade.Graphics;
using DIKUArcade.Math;
using System.Security.Principal;
using System.Collections.Generic;
using DIKUArcade.Events;

namespace Galaga {
    public class Game : DIKUGame, IGameEventProcessor {
        private Player player;
        private GameEventBus eventBus;
        public Game(WindowArgs windowArgs) : base(windowArgs) {
            // TODO: Set key event handler (inherited window field of DIKUGame class)
            eventBus = new GameEventBus();
            eventBus.InitializeEventBus(new List<GameEventType> { GameEventType.InputEvent });

            window.SetKeyEventHandler(KeyHandler);

            eventBus.Subscribe(GameEventType.InputEvent, this);

            player = new Player(
                new DynamicShape(new Vec2F(0.80f, 0.1f), new Vec2F(0.1f, 0.1f)),
                new Image(Path.Combine("Assets", "Images", "Player.png")));
        }
        private void KeyHandler(KeyboardAction action, KeyboardKey key) {
            if (action == KeyboardAction.KeyRelease) {
                switch (key) {
                    case KeyboardKey.Left:
                        new GameEvent {
                            EventType = GameEventType.InputEvent,
                            Message = "Left",
                        };
                        break;
                    case KeyboardKey.A:
                        new GameEvent {
                            EventType = GameEventType.InputEvent,
                            Message = "Left",
                        };
                        break;
                    case KeyboardKey.Right:
                        new GameEvent {
                            EventType = GameEventType.InputEvent,
                            Message = "Right",
                        };
                        break;
                    case KeyboardKey.D:
                        new GameEvent {
                            EventType = GameEventType.InputEvent,
                            Message = "Right",
                        };
                        break;
                    case KeyboardKey.Escape:
                        new GameEvent {
                            EventType = GameEventType.InputEvent,
                            Message = "Close",
                        };
                        break;
                    default:
                        break;
                }
            }
            throw new NotImplementedException();
        }
        // der bliver ikke automatisk registreret events for tastetryk, 
        // så de popper ikke op i ProcessEvents af sig selv. 
        // I skal selv lave dem i KeyHandler, det er den metode, 
        // der får tastetrykkene
        /// fordi I har sat den som KeyEventHandler 
        // Not 100% sure what this does. 
        //TODO: Outcomment  
        public void KeyPress(KeyboardKey key) {
            // TODO: switch on key string and set the player's move direction
            switch (key) {
                case KeyboardKey.Left: 
                    player.SetMoveLeft(true); //Not 100% sure this corrrect. 
                    break;
                case KeyboardKey.A:
                    player.SetMoveLeft(true); //Not 100% sure this corrrect. 
                    break;
                case KeyboardKey.Right:
                    player.SetMoveRight(true);
                    break;
                case KeyboardKey.D:
                    player.SetMoveRight(true);
                    break;
            }
        }
        public void KeyRelease(KeyboardKey key) {
            // TODO: switch on key string and disable the player's move direction
            // TODO: Close window if escape is pressed
            switch (key) {
                case KeyboardKey.Left:
                    player.SetMoveLeft(false); //This feels weird plz gib help
                    break;
                case KeyboardKey.A:
                    player.SetMoveLeft(false);
                    break;
                case KeyboardKey.Right:
                    player.SetMoveRight(false);
                    break;
                case KeyboardKey.D:
                    player.SetMoveRight(false);
                    break;
                case KeyboardKey.Escape:
                    window.CloseWindow();
                    break;
            }
        }
        public void ProcessEvent(GameEvent gameEvent) {
            if (gameEvent.EventType == GameEventType.WindowEvent) {
                switch (gameEvent.Message) {
                    // TODO: Implement
                    default:
                        break;
                }
            }
        }
        public override void Render() {
            player.SetMoveRight(true);
            for (int i = 0; i < 50; i++){
                player.move();
            }
            player.Render();
        }

        public override void Update() {
            player.Render();
        }
       
    }
}


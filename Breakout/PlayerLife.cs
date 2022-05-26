using DIKUArcade.Entities;
using DIKUArcade.Graphics;
using DIKUArcade.Math;
using DIKUArcade.Events;
using System.Collections.Generic;
using System.IO;
using System;
using DIKUArcade.Utilities;
namespace Breakout {
    /// <summary>   
    /// A subclass of Entity, containing information about Player.
    /// </summary>
    public class PlayerLife : IGameEventProcessor {
        private int lives;
        private List<Entity> Entities;

        public PlayerLife() {
            Entities = new List<Entity> ();
            
            for (int i = 0; i < 3; i++) {
                string fileName = Path.Combine(FileIO.GetProjectPath(), 
                                    "Assets", "Images", "heart_filled.png");
                Entities.Add(new Entity(
                    new StationaryShape(new Vec2F(0.0f + i * 0.0125f , 0.0f), new Vec2F(0.025f, 0.025f)),
                    new Image(fileName)));
            }
            lives = Entities.Count - 1;
        }
        private void LoseLife() {
            if (lives >= 1) {
                Entities.RemoveAt(Entities.Count - 1);
                lives = Entities.Count - 1;
            } else if (lives == 0) {
                BreakoutBus.GetBus().RegisterEvent(
                    new GameEvent {
                        EventType = GameEventType.GameStateEvent,
                        Message = "SwitchState",
                        StringArg1 = "GameOver",
                    }
                );
            }
        }
        private void GainLife() {
            int index = Entities.Count - 1;
            string fileName = Path.Combine(FileIO.GetProjectPath(), "Assets", "Images",
                "heart_filled.png");
            Vec2F pos = new Vec2F(0.0f + index * 0.0125f , 0.0f);
            Entities.Add(new Entity(
                    new StationaryShape(pos, new Vec2F(0.025f, 0.025f)), new Image(fileName)));
        }
        public void Render() {
            foreach (Entity life in Entities) {
                life.RenderEntity();
            }
        }

        public void ProcessEvent (GameEvent gameEvent) {
            if (gameEvent.EventType == GameEventType.PlayerEvent) {
                switch (gameEvent.Message) {
                    case "LoseLife":
                        LoseLife();
                        break;
                    case "GainLife":
                        GainLife();
                        break;
                    default:
                        break;
                }                
            }
        }
    }
        
}

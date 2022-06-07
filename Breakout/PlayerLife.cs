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
        private static string fileName = Path.Combine(FileIO.GetProjectPath(), 
                                        "Assets", "Images", "heart_filled.png");
        private int lives;
        private List<Entity> Entities;
        public PlayerLife() {
            Entities = new List<Entity> ();
            
            for (int i = 0; i < 3; i++) {
                Entities.Add(new Entity(
                    new StationaryShape(new Vec2F(0.0f + i * 0.0125f , 0.0f), new Vec2F(0.025f, 0.025f)),
                    new Image(fileName)));
            }
            lives = Entities.Count;
        }
        /// <summary>
        /// Removes a life from the existing lives
        /// </summary>
        private void LoseLife() {
            if (lives >= 1) {
                Entities.RemoveAt(Entities.Count - 1);
                lives = Entities.Count;
            } 
        }
        /// <summary>
        /// Adds a life to the existing lives
        /// </summary>
        private void GainLife() {
            int index = Entities.Count;
            string fileName = Path.Combine(FileIO.GetProjectPath(), "Assets", "Images",
                "heart_filled.png");
            Vec2F pos = new Vec2F(0.0f + index * 0.0125f , 0.0f);

            Entities.Add(new Entity(
                    new StationaryShape(pos, new Vec2F(0.025f, 0.025f)), new Image(fileName)));
            lives = Entities.Count;
        }
        /// <summary>
        /// Renders the Player's lives
        /// </summary>
        public void Render() {
            foreach (Entity life in Entities) {
                life.RenderEntity();
            }
        }
        /// <summary>
        /// determines the amount of lives remaining 
        /// </summary>
        /// <returns>
        /// the amount of lives left.
        /// </returns>
        public int LivesLeft() {
            return lives;
        }
        /// <summary>
        /// Processes a GameEvent based on the GameEvent.Message
        /// </summary>
        /// <param name='gameEvent'>
        /// A GameEvent
        /// </param>
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

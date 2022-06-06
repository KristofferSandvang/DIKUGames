using DIKUArcade.Graphics;
using DIKUArcade.Math;
using DIKUArcade.Events;

namespace Breakout {
    /// <summary>   
    /// A class to keep track of the current score in the game
    /// </summary>
    public class Score : IGameEventProcessor {
        private Text display;
        private static int score = 0;
        public Score(Vec2F position, Vec2F extent) {
            display = new Text ("Score: " + score.ToString(), position, extent);
            display.SetColor(System.Drawing.Color.White);
            display.SetFontSize(30);
        }
        /// <summary>   
        /// Adds val to the current Score
        /// </summary>
        private void AddScore(int val) {
            if (score + val >= 0) {
                score = val + score; 
            }
        }
        /// <summary>   
        /// Resets the score
        /// </summary>
        public void ResetScore() {
            score = 0;
        }
        /// <summary>   
        /// Updates the score
        /// </summary>
        public void Update() {
            display.SetText("Score: " + score); 
        }
        /// <summary>   
        /// Renders the score
        /// </summary>
        public void Render() {
            display.RenderText();
        }
        /// <summary>   
        /// Gets the score
        /// </summary>
        public int GetScore(){
            return score; 
        }
        public void ProcessEvent (GameEvent gameEvent) {
            if (gameEvent.EventType == GameEventType.StatusEvent) {
                switch (gameEvent.Message) {
                    case "AddPoints":
                        AddScore(gameEvent.IntArg1);
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
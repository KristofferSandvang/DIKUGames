using DIKUArcade.Graphics;
using DIKUArcade.Math;
using DIKUArcade.Events;

namespace Breakout {
    /// <summary>   
    /// A class to keep track of the current score in the game
    /// </summary>
    public class Score {
        private static Text display;
        private static int score;
        public Score(Vec2F position, Vec2F extent) {
            score = 0;
            display = new Text ("Score: "+score.ToString(), position, extent);
            display.SetColor(System.Drawing.Color.White);
            display.SetFontSize(30);
        }
        /// <summary>   
        /// Adds val to the current Score
        /// </summary>
        public static void AddScore(int val) {
            if (score + val >= 0) {
            score = score + val; 
            display.SetText("Score: "+score.ToString());
            }
        }
        /// <summary>   
        /// Resets the score
        /// </summary>
        public static void ResetScore() {
            score = 0; 
        }
        /// <summary>   
        /// Renders the score
        /// </summary>
        public static void Render() {
            display.RenderText();
        }
        public int GetScore(){
            return score; 
        }
    }
}
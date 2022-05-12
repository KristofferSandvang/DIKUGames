using DIKUArcade.Graphics;
using DIKUArcade.Math;
using DIKUArcade.Events;

namespace Breakout {
    /// <summary>   
    /// A class to keep track of the current score in the game
    /// </summary>
    public static class Score {

        private Text display;
        private static int score;

        public static void AddScore(int val) {
            if (score + n >= 0) {
            score = score + n; 
            }
            else {score = 0;}
        }
        public static void ResetScore() {
            score = 0; 
        }
    }
}
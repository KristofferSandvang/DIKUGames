using DIKUArcade.Entities;
using DIKUArcade.Graphics;
using System.Collections.Generic;
using System.IO;

namespace Breakout {
    /// <summary>   
    /// A class to keep track of the current score in the game
    /// </summary>
    public static class Score {
        private static int score;

        public static void AddScore(int n) {
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
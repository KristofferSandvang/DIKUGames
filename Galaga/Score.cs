using DIKUArcade.Graphics;
using DIKUArcade.Math;
using DIKUArcade.Events;

namespace Galaga {
    public class Score {
        private int score;
        private Text display;
        public int GetScore{
            get{return score;}
        }
        public Score (Vec2F position, Vec2F extent) {
            score = 0;
            display = new Text ("Score: "+score.ToString(), position, extent);
            display.SetColor(System.Drawing.Color.White);
            display.SetFontSize(30);
        }
        public void AddPoints() {
            score += 100;
            display.SetText("Score: "+score.ToString());
        }
        public void RenderScore() {
            display.RenderText();
        }
    }
}
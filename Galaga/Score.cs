using DIKUArcade.Graphics;
using DIKUArcade.Math;
using DIKUArcade.Events;

namespace Galaga {
    class Score {
        private int score;
        private Text display;
        public Score (Vec2F position, Vec2F extent) {
            score = 0;
            display = new Text (score.ToString(), position, extent);
            display.SetColor(System.Drawing.Color.White);
            display.SetFontSize(300);
        }
        public void AddPoints() {
            score += 100;
            display.SetText(score.ToString());
        }
        public void RenderScore() {
            display.RenderText();
        }
    }
}
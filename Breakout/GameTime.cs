using DIKUArcade.Timers;
using DIKUArcade.Graphics;
using DIKUArcade.Math;
namespace Breakout {
    public class GameTime {
        public double timeRemaining { get; private set;}
        private Text timeDisplay;
        private double totalTime;
        public GameTime(double Time) {
            StaticTimer.RestartTimer();
            totalTime = Time;
            timeRemaining = totalTime - StaticTimer.GetElapsedSeconds();
            timeDisplay = new Text(timeRemaining.ToString(), new Vec2F(0.8f, 0.8f), new Vec2F(0.2f, 0.2f));
            timeDisplay.SetColor(System.Drawing.Color.White);
            timeDisplay.SetFontSize(50);
        }

        public void Update() {
            if (totalTime != -1.0) {
                double timePassed = StaticTimer.GetElapsedSeconds();
                int val = (int) (totalTime - timePassed);
                timeRemaining = (double) val;
                timeDisplay.SetText(val.ToString());
            }
        }
        public void Render() {
            if (totalTime != -1.0) {
                timeDisplay.RenderText();
            }
        }
    }
}
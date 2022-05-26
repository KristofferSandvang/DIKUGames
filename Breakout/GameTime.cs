using DIKUArcade.Timers;
using DIKUArcade.Graphics;
using DIKUArcade.Math;
namespace Breakout {
    public class GameTime {
        public double time { get; private set;}
        private Text timeDisplay;
        public GameTime(double Time) {
            StaticTimer.RestartTimer();
            time = Time;
            timeDisplay = new Text(time.ToString(), new Vec2F(0.8f, 0.8f), new Vec2F(0.2f, 0.2f));
            timeDisplay.SetColor(System.Drawing.Color.White);
            timeDisplay.SetFontSize(50);
        }

        public void Update() {
            if (time != -1.0) {
                double timePassed = StaticTimer.GetElapsedSeconds();
                int val = (int) (time - timePassed);
                timeDisplay.SetText(val.ToString());
            }
        }
        public void Render() {
            if (time != -1.0) {
                timeDisplay.RenderText();
            }
        }
    }
}
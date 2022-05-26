using DIKUArcade.Timers;
using DIKUArcade.Graphics;
using DIKUArcade.Math;
using DIKUArcade.Events;
namespace Breakout {
    public class GameTime {
        double time;
        Text timeDisplay;
        public GameTime(double Time) {
            StaticTimer.RestartTimer();
            time = Time;
            timeDisplay = new Text(time.ToString(), new Vec2F(0.8f, 0.8f), new Vec2F(0.2f, 0.2f));
            timeDisplay.SetColor(System.Drawing.Color.White);
            timeDisplay.SetFontSize(50);
        }

        public void Update() {
            double timePassed = StaticTimer.GetElapsedSeconds();
            int val = (int) (time - timePassed);
            timeDisplay.SetText(val.ToString());
            if (val <= 0) {
                BreakoutBus.GetBus().RegisterEvent(
                    new GameEvent {
                            EventType = GameEventType.GameStateEvent,
                            Message = "SwitchState",
                            StringArg1 = "GameOver",
                    } 
                );
            }
        }
        public void Render() {
            timeDisplay.RenderText();
        }
    }
}
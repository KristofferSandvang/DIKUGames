using DIKUArcade.Timers;
using DIKUArcade.Graphics;
using DIKUArcade.Events;
using DIKUArcade.Math;
namespace Breakout {
    /// <summary>   
    /// A class which controlls if the game is still ongoing, lost or won.
    /// If a game is won or lost it will register an event to switch states.
    /// </summary> 
    public class GameTime : IGameEventProcessor {
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
        /// <summary>
        /// Updates the display for the time
        /// </summary>
        public void Update() {
            if (totalTime != -1.0) {
                double timePassed = StaticTimer.GetElapsedSeconds();
                int val = (int) (totalTime - timePassed);
                timeRemaining = (double) val;
                timeDisplay.SetText(val.ToString());
            }
        }
        /// <summary>
        /// Renders the time
        /// </summary>
        public void Render() {
            if (totalTime != -1.0) {
                timeDisplay.RenderText();
            }
        }
        /// <summary>
        /// Adds 10 seconds to the timeRemaining
        /// </summary>
        private void AddTime() {
            totalTime += 10.0;
            int val = (int) (totalTime - StaticTimer.GetElapsedSeconds());
            timeRemaining = (double) val;
        }
        /// <summary>
        /// Processes a GameEvent based on the GameEvent.Message
        /// </summary>
        /// <param name='gameEvent'>
        /// A GameEvent
        /// </param>
        public void ProcessEvent(GameEvent gameEvent) {
            if (gameEvent.EventType == GameEventType.ControlEvent) {
                switch (gameEvent.Message) {
                    case "MoreTime":
                        AddTime();
                        break;
                }
            }
        } 
    }
}
using DIKUArcade.Events;

namespace Breakout {
    /// <summary>   
    /// A singleton GameEventBus making it possible registering events across all classes  
    /// </summary> 
    public static class BreakoutBus {
        private static GameEventBus? eventBus;
        /// <summary>
        /// Gets the current GameEventBus
        /// </summary>
        /// <returns>
        /// the current GameEventBus
        /// </returns>
        public static GameEventBus GetBus() {
            return BreakoutBus.eventBus ?? (BreakoutBus.eventBus = new GameEventBus());
        }
        /// <summary>
        /// Creates a new GameEventBus
        /// </summary>
        /// <returns>
        /// the new GameEventBus
        /// </returns>
        public static GameEventBus ResetBus() {
            eventBus = new GameEventBus();
            return eventBus;
        }
    }
}


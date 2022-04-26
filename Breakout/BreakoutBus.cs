using DIKUArcade.Events;

namespace Breakout {
    public static class BreakoutBus {
        private static GameEventBus eventBus;
        /// <summary>
        /// Gets the current GameEventBus
        /// </summary>
        /// <returns>
        /// the current GameEventBus
        /// </returns>
        public static GameEventBus GetBus() {
            return BreakoutBus.eventBus ?? (BreakoutBus.eventBus = new GameEventBus());
        }
    }
}


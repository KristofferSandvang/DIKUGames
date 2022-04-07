using DIKUArcade.Events;

namespace Galaga {
    public static class GalagaBus {
        private static GameEventBus eventBus;
        /// <summary>
        /// Gets the current GameEventBus
        /// </summary>
        /// <returns>
        /// the current GameEventBus
        /// </returns>
        public static GameEventBus GetBus() {
            return GalagaBus.eventBus ?? (GalagaBus.eventBus = new GameEventBus());
        }
    }
}

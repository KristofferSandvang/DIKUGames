using DIKUArcade.Entities;
using DIKUArcade.Graphics;
using DIKUArcade.Math;
using DIKUArcade.Events;

namespace Breakout {
    /// <summary>   
    /// A subclass of Entity, containing information about Player.
    /// </summary>
    public class PlayerLife : Entity, IGameEventProcessor {
        private int lives;
        public PlayerLife(StationaryShape shape, IBaseImage image) : base(shape, image) {
            lives = 3;
        }
        
    }
}
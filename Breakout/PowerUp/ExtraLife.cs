using DIKUArcade.Entities;
using DIKUArcade.Graphics;
using DIKUArcade.Events;
using DIKUArcade.Physics;

namespace Breakout.PowerUps{
    /// <summary>
    /// This powerup adds an additional life to the user's amount of lives upon pickup
    /// </summary>
    public class ExtraLife : PowerUp {
        /// <summary>
        /// Determines what happens when the powerUp is collected by the player
        /// </summary>
        /// <param name='player'>
        /// The player that has to collect the powerUp
        /// </param>
        public override void Collected(Player player) {
            if (CollisionDetection.Aabb(shape.AsDynamicShape(), player.shape).Collision) {
                BreakoutBus.GetBus().RegisterEvent(
                    new GameEvent {
                        EventType = GameEventType.PlayerEvent,
                        Message = "GainLife",
                    }
                );
                DeleteEntity();
            }
        }
        public ExtraLife(DynamicShape shape, IBaseImage image) : base(shape, image) {}
    }
}
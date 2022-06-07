using DIKUArcade.Entities;
using DIKUArcade.Graphics;
using DIKUArcade.Events;
using DIKUArcade.Physics;
using DIKUArcade.Timers;

namespace Breakout.PowerUps {
    /// <summary>
    /// This powerup increases the width of the player (shape) for a finite time upon pickup
    /// </summary>
    public class ExtraWidth : PowerUp {
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
                        Message = "ExtraWidth",
                    }
                );
                BreakoutBus.GetBus().RegisterTimedEvent(
                    new GameEvent {
                        EventType = GameEventType.PlayerEvent,
                        Message = "NormalWidth",
                    }, TimePeriod.NewSeconds(5)
                );
                DeleteEntity();
            }
        }
        public ExtraWidth(DynamicShape shape, IBaseImage image) : base(shape, image) {}

    }
}

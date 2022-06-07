using DIKUArcade.Entities;
using DIKUArcade.Graphics;
using DIKUArcade.Physics;
using DIKUArcade.Events;
using DIKUArcade.Timers;

namespace Breakout.PowerUps {
    public class ExtraPlayerSpeed : PowerUp {
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
                        Message = "ExtraSpeed",
                    }
                );
                BreakoutBus.GetBus().RegisterTimedEvent(
                    new GameEvent {
                        EventType = GameEventType.PlayerEvent,
                        Message = "NormalSpeed",
                    }, TimePeriod.NewSeconds(5)
                );
                DeleteEntity();
            }
        }
        public ExtraPlayerSpeed(DynamicShape shape, IBaseImage image) : base(shape, image) {}
    }
}
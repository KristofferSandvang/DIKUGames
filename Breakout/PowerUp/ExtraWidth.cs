using DIKUArcade.Entities;
using DIKUArcade.Graphics;
using DIKUArcade.Events;
using DIKUArcade.Physics;
using DIKUArcade.Timers;

namespace Breakout.PowerUps {
    public class ExtraWidth : PowerUp {
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

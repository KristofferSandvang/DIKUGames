using DIKUArcade.Entities;
using DIKUArcade.Graphics;
using DIKUArcade.Events;
using DIKUArcade.Physics;

namespace Breakout.PowerUps{
    public class MoreTime : PowerUp {
        public override void Collected(Player player) {
            if (CollisionDetection.Aabb(shape.AsDynamicShape(), player.shape).Collision) {
                BreakoutBus.GetBus().RegisterEvent(
                    new GameEvent {
                        EventType = GameEventType.ControlEvent,
                        Message = "MoreTime",
                    }
                );
                DeleteEntity();
            }
        }
        public MoreTime(DynamicShape shape, IBaseImage image) : base(shape, image) {}
    }
}
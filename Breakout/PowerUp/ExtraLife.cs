using DIKUArcade.Entities;
using DIKUArcade.Graphics;
using DIKUArcade.Events;
using DIKUArcade.Physics;

namespace Breakout.PowerUps{
    public class ExtraLife : PowerUp {
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
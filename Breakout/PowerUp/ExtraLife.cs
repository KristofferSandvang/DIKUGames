using DIKUArcade.Entities;
using DIKUArcade.Graphics;
using DIKUArcade.Events;
using DIKUArcade.Physics;

namespace Breakout.PowerUps{
    public class ExtraLife : PowerUp {
        public override void Collected(Player player) {
            if (CollisionDetection.Aabb(player.shape, shape).Collision) {
                BreakoutBus.GetBus().RegisterEvent(
                    new GameEvent {
                        EventType = GameEventType.PlayerEvent,
                        Message = "GainLife",
                    }
                );
            }
        }
        public ExtraLife(DynamicShape shape, IBaseImage image) : base(shape, image) {}
    }
}
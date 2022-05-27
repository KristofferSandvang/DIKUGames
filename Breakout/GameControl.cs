using DIKUArcade.Entities;
using Breakout.Blocks;
using DIKUArcade.Events;
using Breakout.PowerUps;
using DIKUArcade.Timers;
using DIKUArcade.Math;
namespace Breakout {
    public class GameControl : IGameEventProcessor {
        private EntityContainer<PowerUp> powerUps;
        private Random rand;
        private PowerUpType[] powers = {PowerUpType.ExtraLife, PowerUpType.ExtraTime,
            PowerUpType.PlayerSpeed};
        public GameControl() {
            powerUps = new EntityContainer<PowerUp>();
            rand = new Random();
        }
        public void GameOver(GameTime Time, Player player, EntityContainer<BreakoutBlock> blocks) {
            if (TimeOut(Time) || NoLives(player)) {
                BreakoutBus.GetBus().RegisterEvent(
                    new GameEvent {
                        EventType = GameEventType.GameStateEvent,
                        Message = "SwitchState",
                        StringArg1 = "GameOver",
                    }
                );
            } else if (Victory(blocks)) {
                BreakoutBus.GetBus().RegisterEvent(
                    new GameEvent {
                        EventType = GameEventType.GameStateEvent,
                        Message = "SwitchState",
                        StringArg1 = "GameWin",
                    }
                );
            }
        }
        public void ProcessEvent(GameEvent gameEvent) {
            PowerUpType powerUp = powers[rand.Next(powers.Length - 1)];
            if (gameEvent.EventType == GameEventType.ControlEvent) {
                switch (gameEvent.Message) {
                    case "SpawnPowerUp": 
                        if (gameEvent.ObjectArg1 is BreakoutBlock) {
                            BreakoutBlock block = (BreakoutBlock)gameEvent.ObjectArg1;
                            Vec2F pos = block.shape.Position;
                            powerUps.AddEntity(PowerUpFactory.SpawnPowerUp(pos, powerUp));
                        }
                    break;
                }
            }
        }
        public void Render() {
            powerUps.RenderEntities();
        }
        public void Update(Player player){
            powerUps.Iterate(powerUp => {
                powerUp.Move();
                powerUp.Collected(player);
            } ); 
        }
        private bool TimeOut(GameTime Time) {
            if (Time.timeRemaining <= 0) {
                return true;
            } else {return false;}
        }
        private bool NoLives(Player player) {
            if (player.Lives.LivesLeft() == 0) {
                return true;
            } else {return false;}
        }
        private bool Victory(EntityContainer<BreakoutBlock> blocks) {
            if (blocks.CountEntities() <= 0) {
                return true;
            } else {return false;}
        }
    }   
}
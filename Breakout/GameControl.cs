using DIKUArcade.Entities;
using Breakout.Blocks;
using DIKUArcade.Events;
using DIKUArcade.Timers;
namespace Breakout {
    public class GameControl {

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
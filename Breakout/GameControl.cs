using DIKUArcade.Entities;
using Breakout.Blocks;
using DIKUArcade.Events;
namespace Breakout {
    /// <summary>   
    /// Decides if the game is won, lost or still ongoing. 
    /// </summary> 
    public class GameControl {
        /// <summary>
        /// Checks if the game is over and creates events for state switching if so.
        /// </summary>
        /// <param name='Time'>
        /// A GameTime
        /// </param>
        /// <param name='player'>
        /// A player
        /// </param>
        /// <param name='Blocks'>
        /// An EntityContainer containing Breakoutblocks
        /// </param>
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
        /// <summary>
        /// Determines whether the time is out or not
        /// </summary>
        /// <param name='Time'>
        /// A GameTime
        /// </param>
        /// <returns>
        /// True if the time is out, and false if not
        /// </returns>
        private bool TimeOut(GameTime Time) {
            if (Time.timeRemaining <= 0) {
                return true;
            } else {return false;}
        }
        /// <summary>
        /// Determines whether the player has lives remaining 
        /// </summary>
        /// <param name='player'>
        /// A Player
        /// </param>
        /// <returns>
        /// True if the player does not have lives remaining and false if the player does
        /// </returns>
        private bool NoLives(Player player) {
            if (player.Lives.LivesLeft() == 0) {
                return true;
            } else {return false;}
        }
        /// <summary>
        /// Determines whether the game is won or not
        /// </summary>
        /// <param name='blocks'>
        /// An EntityContainer of Breakoutblocks
        /// </param>
        /// <returns>
        /// True if all the Breakoutblokcs have been destroyed; false if not
        /// </returns>
        private bool Victory(EntityContainer<BreakoutBlock> blocks) {
            if (blocks.CountEntities() <= 0) {
                return true;
            } else {return false;}
        }
    }   
}
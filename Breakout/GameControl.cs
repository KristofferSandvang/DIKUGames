using DIKUArcade.Entities;
using Breakout.Blocks;
using DIKUArcade.Events;
using Breakout.PowerUps;
using DIKUArcade.Timers;
using Breakout.PowerUps.PowerUpFactories;
using DIKUArcade.Math;
namespace Breakout {
    public class GameControl : IGameEventProcessor {
        private EntityContainer<PowerUp> powerUps;
        private Random rand;
        private PowerUpFactory[] powers = {new ExtraLifeFactory(), new ExtraPlayerSpeedFactory(),
            new ExtraWidthFactory(), new MoreTimeFactory(), new ExtraBallSpeedFactory() };
        public GameControl() {
            powerUps = new EntityContainer<PowerUp>();
            rand = new Random();
        }
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
        /// Processes a GameEvent based on the GameEvent.Message
        /// </summary>
        /// <param name='gameEvent'>
        /// A GameEvent
        /// </param>
        public void ProcessEvent(GameEvent gameEvent) {
            PowerUpFactory powerUp = powers[rand.Next(powers.Length)];
            if (gameEvent.EventType == GameEventType.ControlEvent) {
                switch (gameEvent.Message) {
                    case "SpawnPowerUp": 
                        if (gameEvent.ObjectArg1 is BreakoutBlock) {
                            BreakoutBlock block = (BreakoutBlock)gameEvent.ObjectArg1;
                            Vec2F pos = block.shape.Position;
                            powerUps.AddEntity(powerUp.CreatePowerUp(pos));
                        }
                    break;
                }
            }
        }
        /// <summary>
        /// Renders the PowerUps
        /// </summary>
        public void Render() {
            powerUps.RenderEntities();
        }
        /// <summary>
        /// Updates the PowerUps and check if they're being collected by a player.
        /// </summary>
        /// <param name='player'>
        /// A player
        /// </param>
        public void Update(Player player){
            powerUps.Iterate(powerUp => {
                powerUp.Move();
                powerUp.Collected(player);
            } ); 
        }
        /// <summary>
        /// Gets the EntityContainer of PowerUps
        /// </summary>
        public EntityContainer<PowerUp> GetPowerUps() {
            return powerUps;
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
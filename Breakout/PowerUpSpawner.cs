using DIKUArcade.Events;
using DIKUArcade.Entities;
using DIKUArcade.Math;
using Breakout.PowerUps;
using Breakout.Blocks;
using Breakout.PowerUps.PowerUpFactories;
namespace Breakout {
    public class PowerUpSpawner : IGameEventProcessor {
        private PowerUpFactory[] factories = {new ExtraLifeFactory(), new ExtraPlayerSpeedFactory(),
            new ExtraWidthFactory(), new MoreTimeFactory(), new ExtraBallSpeedFactory() };
        private Random rand;
        private EntityContainer<PowerUp> powerUps;
        public PowerUpSpawner() {
            rand = new Random();
            powerUps = new EntityContainer<PowerUp>();
        }

        /// <summary>
        /// Processes a GameEvent based on the GameEvent.Message
        /// </summary>
        /// <param name='gameEvent'>
        /// A GameEvent
        /// </param>
        public void ProcessEvent(GameEvent gameEvent) {
            PowerUpFactory powerUp = factories[rand.Next(factories.Length)];
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
    }
}
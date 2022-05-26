using DIKUArcade.Entities;
using Breakout.Blocks;

namespace Breakout.Levels {

    public class Level{
        private double time;
        private string name;
        private string powerUp;
        private EntityContainer<BreakoutBlock> blocks;
        public Level(string Name, double Time, string PowerUp, 
                     EntityContainer<BreakoutBlock> Blocks) {
            time = Time;
            name = Name;
            powerUp = PowerUp;
            blocks = Blocks;
        }
        /// <summary>
        /// Renders the level
        /// </summary>
        public void Render() {
            blocks.RenderEntities();
        }
        public EntityContainer<BreakoutBlock> GetEC() {
            return blocks;
        }
        public string GetPowerUp() {
            return powerUp;
        }
        public double GetTime() {
            return time;
        }
        public string GetName() {
            return name;
        }
    }
}

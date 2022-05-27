using DIKUArcade.Entities;
using Breakout.Blocks;

namespace Breakout.Levels {

    public class Level{
        private double time;
        private string name;
        private char powerUp;
        private EntityContainer<BreakoutBlock> blocks;
        public Level(string Name, double Time, char PowerUp, 
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
        public char GetPowerUp() {
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

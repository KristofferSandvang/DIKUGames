using DIKUArcade.Entities;
using Breakout.Blocks;

namespace Breakout.Levels {
    /// <summary>   
    /// A class that contains all information from the level.txt file, as well 
    /// as the blocks from the level. 
    /// </summary> 
    public class Level {
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
        /// <summary>
        /// Updates the level
        /// </summary>
        public void Update(GameTime time) {
            foreach (BreakoutBlock block in blocks) {
                if (block is HealableBlock) {
                    HealableBlock healBlock = (HealableBlock) block;
                    healBlock.IterateHeal(time);
                }
            }
        }
        /// <summary>
        /// Gets the EntityContainer of blocks
        /// </summary>
        public EntityContainer<BreakoutBlock> GetEC() {
            return blocks;
        }
        /// <summary>
        /// gets the char corresponding to PowerUps
        /// </summary>
        public char GetPowerUp() {
            return powerUp;
        }
        /// <summary>
        /// gets the time as a double
        /// </summary>
        public double GetTime() {
            return time;
        }
        /// <summary>
        /// Gets the level's name
        /// </summary>
        public string GetName() {
            return name;
        }
    }
}

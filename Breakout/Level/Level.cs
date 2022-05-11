using DIKUArcade.Entities;
using Breakout.Blocks;

namespace Breakout.Levels {

    public class Level{
        private string time;
        private string name;
        private string powerUp;
        private EntityContainer<BreakoutBlock> blocks;
        public Level(string Name, string Time, string PowerUp, 
                     EntityContainer<BreakoutBlock> Blocks) {
            time = Time;
            name = Name;
            powerUp = PowerUp;
            blocks = Blocks;
        }
        public Level() {
            time = "";
            name = "";
            powerUp = "";
            blocks = new EntityContainer<BreakoutBlock>();
        }
        public void Render() {
            blocks.RenderEntities();
        }
        public EntityContainer<BreakoutBlock> GetEC() {
            return blocks;
        }
    }
}

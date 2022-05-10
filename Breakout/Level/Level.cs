using DIKUArcade.Entities;
using Breakout.Blocks;

namespace Breakout.Levels {

    public class Level{
        private string time;
        private string name;
        private string powerUp;
        private string hardened;
        private string unbreakable;
        private EntityContainer<BreakoutBlock> blocks;
        public Level(string Name, string Time, string PowerUp, string Hardened,
        EntityContainer<BreakoutBlock> Blocks, string Unbreakable) {
            time = Time;
            name = Name;
            powerUp = PowerUp;
            hardened = Hardened;
            unbreakable = Unbreakable;
            blocks = Blocks;
        }
        public Level() {
            time = "";
            name = "";
            powerUp = "";
            hardened = "";
            unbreakable = "";
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

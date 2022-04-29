using DIKUArcade.Entities;

namespace Breakout.Levels {

    public class Level{
        private string time;
        private string name;
        private string powerUp;
        private string hardened;
        private string unbreakable;
        private EntityContainer<Block> blocks;
        public Level(string Name, string Time, string PowerUp, string Hardened,
        EntityContainer<Block> Blocks, string Unbreakable) {
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
            blocks = new EntityContainer<Block>();
        }
        public void Render() {
            blocks.RenderEntities();
        }
        public EntityContainer<Block> GetEC() {
            return blocks;
        }
    }
}

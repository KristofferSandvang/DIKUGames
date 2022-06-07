using DIKUArcade.Math;
using DIKUArcade.Utilities;
using DIKUArcade.Entities;
using Breakout.Blocks.BlockFactories;
using Breakout.Blocks;

namespace Breakout.Levels {
    /// <summary>   
    /// A LevelLoader that can read all the information from the level.txt file and produce
    /// an object of the Level class.
    /// </summary> 
    public class LevelLoader {
        private int mapStart = 0;
        private int mapEnd = 0;
        private int metaStart = 0;
        private int metaEnd = 0;
        private int legendStart = 0;
        private int legendEnd = 0;
        private string fileName;
        private char powerUp;
        private string[] lines;
        private Dictionary<char, string> legend;
        private Dictionary<char, BlockFactory> meta;
        private BlockFactory standard;
        
        /// <summary>
        /// Gets the specific level-file.
        /// </summary>
        public LevelLoader(string FileName) { 
            fileName = Path.Combine(FileIO.GetProjectPath(), "Assets", "Levels", FileName);
            lines = File.ReadAllLines(fileName);
            FindCheckpoints();
            standard = new StandardBlockFactory();
            legend = new Dictionary<char, string>();
            meta = new Dictionary<char, BlockFactory>();
            ReadLegend();
            ReadMeta();
        }
        /// <summary>
        /// Initializes the levelLoader
        /// </summary>
        public void InitializeLevelLoader() {
            FindCheckpoints();
            legend = new Dictionary<char, string>();
        }
        /// <summary>
        /// Finds all checkpoints meaning the lines where map, meta, legend have their start/ends
        /// by reading through the level document in its entirity, 
        /// </summary>
        private void FindCheckpoints() {
            mapStart = Array.IndexOf(lines, "Map:");
            mapEnd = Array.IndexOf(lines, "Map/");

            metaStart = Array.IndexOf(lines, "Meta:");
            metaEnd = Array.IndexOf(lines, "Meta/");

            legendStart = Array.IndexOf(lines, "Legend:");
            legendEnd = Array.IndexOf(lines, "Legend/");
        }
        /// <summary>
        /// Reads through the Legend information field and
        /// adding the information to the dictionary
        /// </summary>
        private void ReadLegend() {
            for (int i = legendStart + 1; i < legendEnd; i++) {
                char symbol = lines[i][0];
                string imgName = lines[i].Substring(3);
                legend.TryAdd(symbol, imgName);
            }
        }
        /// <summary>
        /// Reads the Meta data.
        /// </summary>
        private void ReadMeta() {
            for (int i = metaStart + 1; i < metaEnd; i++) {
                string line = lines[i];
                if (line.Contains("Hardened:")) {
                    int index = lines[i].IndexOf(' ');
                    char symbol = lines[i][index + 1];
                    meta.Add(symbol, new HardenedBlockFactory());
                }
                if (line.Contains("Unbreakable:")) {
                    int index = lines[i].IndexOf(' ');
                    char symbol = lines[i][index + 1];
                    meta.Add(symbol, new UnbreakableBlockFactory());
                }
                if (line.Contains("Switch:")) {
                    int index = lines[i].IndexOf(' ');
                    char symbol = lines[i][index + 1];
                    meta.Add(symbol, new SwitchBlockFactory());
                }
                if (line.Contains("SwitchReciever:")) {
                    int index = lines[i].IndexOf(' ');
                    char symbol = lines[i][index + 1];
                    meta.Add(symbol, new SwitchRecieverBlockFactory());
                }
                if (line.Contains("Healable:")) {
                    int index = lines[i].IndexOf(' ');
                    char symbol = lines[i][index + 1];
                    meta.Add(symbol, new HealAbleBlockFactory());
                }
            }
        }
        /// <summary>   
        /// Generates the blocks that corresponds to the Map section of the level
        /// </summary>
        ///<returns>
        /// an EntityContainer containing the BreakoutBlocks
        /// </returns>
        private EntityContainer<BreakoutBlock> ReadMap() {
            EntityContainer<BreakoutBlock> Blocks = new EntityContainer<BreakoutBlock>();
            for (int line = mapStart + 1; line < mapEnd; line++) {
                for (int block = 0; block < 12; block++) {
                    bool power = false;
                    if (lines[line][block] != '-') {
                        if (powerUp == lines[line][block]) {power = true;}
                        string imgName = Path.Combine(FileIO.GetProjectPath(), "Assets", 
                            "Images", legend[lines[line][block]]);
                        Vec2F pos = new Vec2F(0.0f + block * 0.08333334f, 1f - (line - 1) * 0.028f);

                        if (meta.ContainsKey(lines[line][block])) {
                            Blocks.AddEntity((meta[lines[line][block]].CreateBlock(imgName, pos, power)));                                                  
                        } else {
                            Blocks.AddEntity(standard.CreateBlock(imgName, pos, power));
                        }
                    }  
                }  
            } return Blocks;
        }
        /// <summary>   
        /// Creates a Level with values corresponding to its .txt document
        /// </summary>
        public Level CreateLevel() {
            string Name = "";
            double Time = -1.0;
            char PowerUp = '-';

            for (int i = metaStart + 1; i < metaEnd; i++) {
                if (lines[i].Contains("Name:")) {
                    int index = lines[i].IndexOf(' ');
                    Name = lines[i].Substring(index + 1);
                }
                if (lines[i].Contains("Time:")) {
                    int index = lines[i].IndexOf(' ');
                    Time = Double.Parse(lines[i].Substring(index + 1));
                }
                if (lines[i].Contains("PowerUp:")) {
                    int index = lines[i].IndexOf(' ');
                    powerUp = lines[i][index + 1];
                    PowerUp = powerUp;
                }
            } 

            EntityContainer<BreakoutBlock> Blocks = ReadMap();

            return new Level(Name, Time, PowerUp, Blocks);
        }        
    }
}

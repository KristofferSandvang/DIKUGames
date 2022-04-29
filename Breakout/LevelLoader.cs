using System.IO;
using System;
using DIKUArcade.Entities;
using DIKUArcade.Math;
using DIKUArcade.Graphics;
using DIKUArcade.Events;

namespace Breakout {
    public class LevelLoader {
        private int mapStart = 0;
        private int mapEnd = 0;
        private int metaStart = 0;
        private int metaEnd = 0;
        private int legendStart = 0;
        private int legendEnd = 0;
        private string fileName;
        private string[] lines;
        private Dictionary<char, string> legend;
        
        /// <summary>
        /// Gets the specific level-file.
        ///
        /// Read the file by putting the lines in arrays, then reads the lines and saves it in lines.
        /// </summary>
        public LevelLoader(string FileName) { 
            try {
                fileName = Path.Combine("Breakout","Assets", "Levels", FileName);
            } catch (System.IO.FileNotFoundException e1) {
                Console.WriteLine("Noob");
                BreakoutBus.GetBus().RegisterEvent(
                            new GameEvent {
                                EventType = GameEventType.GameStateEvent,
                                Message = "LevelSelector",
                            }
                        );
            }
            lines = File.ReadAllLines(fileName);
            InitializeLevelLoader();
            legend = new Dictionary<char, string>();
        }
        /// <summary>
        /// Initializes the levelLoader, finding checkpoints and creating a dictionary
        /// later used for storing the information in "Meta" and "Legend". 
        /// </summary>
        public void InitializeLevelLoader() {
            FindCheckpoints();
        }
        /// <summary>
        /// Finds all checkpoints meaning the lines where map, meta, legend have their start/ends
        /// by reading through the level document in its entirity, 
        /// storing that information in variables to be used later
        /// for the methods having to process that information.
        /// </summary>
        private void FindCheckpoints() {
            mapStart = Array.IndexOf(lines, "Map:");
            mapEnd = Array.IndexOf(lines, "Map/");

            metaStart = Array.IndexOf(lines, "Meta:");
            metaEnd = Array.IndexOf(lines, "Meta/");

            legendStart = Array.IndexOf(lines, "Legend:");
            legendEnd = Array.IndexOf(lines, "Legend/");
            //læs hver linje iterativt for at finde enten
            //mapstart,mapend,metastart,metaend,legendstart,legendend
            //hver af disse 6 bliver gemt i en int variabel 
            //som repræsenterer dens linjenummer
        }
        /// <summary>
        /// Reads through the Legend information field 
        /// Iteratively adding that information to the dictionary
        /// </summary>
        public void ReadLegend() {
            for (int i = legendStart + 1; i < legendEnd; i++) {
                char symbol = lines[i][0];
                string imgName = lines[i].Substring(3);
                legend.Add(symbol, imgName);
            }
        }
        /// <summary>
        /// Reads through the Meta information field 
        /// Iteratively adding that information to the dictionary
        /// </summary>
        public void ReadMeta() {
            for (int i = metaStart + 1; i < metaEnd; i++) {
                // går igennem indexs i meta delen.
            }
        }
        /// <summary>   
        /// Uses all the previous (ReadLegend, ReadMeta) after having initialized the levelLoader
        /// to iteratively apply the needed information from dictionary when intializing each block
        /// in the level (checking for each block)
        /// </summary>

        //overvejelser - vi vil have blokene i intervallet (0.2 til og med 1)
        public EntityContainer<Block> CreateMap() {
            bool hard = false;
            bool unbreak = false;
            EntityContainer<Block> blocks = new EntityContainer<Block>();
            ReadLegend();
            ReadMeta();
            //Går igennem alle linjerne
            for (int line = mapStart + 1; line < mapEnd; line++) {
                //går igennem alle tegne i linjerne
                for (int block = 0; block < 12; block++) {
                    if (lines[line][block] != '-') {
                        string imgName = Path.Combine("Assets", "Images",
                                         legend[lines[line][block]]);
                        if (true) {hard = true;}
                        if (true) {unbreak = true;}
                        blocks.AddEntity(new Block(
                            new DynamicShape(new Vec2F(0.0f + block * 0.08f, 1f - line * 0.04f),
                            new Vec2F(0.08f, 0.04f)),
                            new Image(imgName),
                            hard, unbreak));
                    }  
                }  
            } 
            return blocks;
        }        
    }
}

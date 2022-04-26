using System.IO;
using System;
using DIKUArcade.Entities;
using DIKUArcade.Math;
using DIKUArcade.Graphics;

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
            fileName = Path.Combine("Breakout","Assets", "Levels", FileName);
            lines = File.ReadAllLines(fileName);
            InitializeLevelLoader();
        }
        /// <summary>
        /// Initializes the levelLoader, finding checkpoints and creating a dictionary
        /// later used for storing the information in "Meta" and "Legend". 
        /// </summary>
        public void InitializeLevelLoader() {
            FindCheckpoints();
            legend = new Dictionary<char, string>();
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
        public void Testing() {
            Console.WriteLine("============");
            Console.WriteLine(legend['0']);
            Console.WriteLine("============");
            Console.WriteLine(legend['w']);
            Console.WriteLine("============");
            Console.WriteLine(legend['#']);
            Console.WriteLine("============");
            Console.WriteLine(legend['Y']);
            Console.WriteLine("============");
            Console.WriteLine(legend['b']);
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
        public void ReadMeta(int metastart, int metaend, bool levelDoc) {
            //start ved legendstart
            //iterativt add legend information til dictionary
            //end ved legendEnd
        }
        /// <summary>   
        /// Uses all the previous (ReadLegend, ReadMeta) after having initialized the levelLoader
        /// to iteratively apply the needed information from dictionary when intializing each block
        /// in the level (checking for each block)
        /// </summary>

        // <param name='levelDoc'>
        // The level file which is to be read
        

        //overvejelser - vi vil have blokene i intervallet (0.2 til og med 1)
        public EntityContainer<Block> CreateMap() {
            EntityContainer<Block> blocks = new EntityContainer<Block>();
            ReadLegend();
            //Går igennem alle linjerne
            for (int line = mapStart + 1; line < mapEnd; line++) {
                //går igennem alle tegne i linjerne
                for (int block = 0; block < 12; block++) {
                    if (lines[line][block] != '-') {
                        string imgName = Path.Combine("Assets", "Images",
                                         legend[lines[line][block]]);
                        blocks.AddEntity(new Block(
                            new DynamicShape(new Vec2F(0.0f + block * 0.08f, 1f - line * 0.04f),
                            new Vec2F(0.08f, 0.04f)),
                            new Image(imgName)));
                    } 
                }  
            }
            return blocks;
        }        
    }
}

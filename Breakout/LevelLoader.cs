using System.IO;
using System;

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
        //private IDictionary<char> LevelDictionary;
        
        /// <summary>
        /// Gets the specific level-file.
        ///
        /// Read the file by putting the lines in arrays, then reads the lines and saves it in lines.
        /// </summary>
        public LevelLoader(string FileName) {
            fileName = Path.Combine("Breakout","Assets", "Levels", FileName);
            lines = File.ReadAllLines(fileName);
            InitializeLevelLoader();
            Console.WriteLine(lines.Length);
        }
        /// <summary>
        /// Initializes the levelLoader, finding checkpoints and creating a dictionary
        /// later used for storing the information in "Meta" and "Legend". 
        /// </summary>
        public void InitializeLevelLoader() {
            FindCheckpoints();
            //LevelDictionary = new IDictionary<char>();
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
            Console.WriteLine(mapStart);
            Console.WriteLine(mapEnd);
            Console.WriteLine("============");
            Console.WriteLine(metaStart);
            Console.WriteLine(metaEnd);
            Console.WriteLine("============");
            Console.WriteLine(legendStart);
            Console.WriteLine(legendEnd);
            Console.WriteLine("============");
            Console.WriteLine(lines[0]);
        }
        
        /// <summary>
        /// Reads through the Legend information field 
        /// Iteratively adding that information to the dictionary
        /// </summary>
        public void ReadLegend(int legendstart, int legendend, bool levelDoc) {
            
            //start ved legendstart
            //iterativt add legend information til dictionary
            //end ved legendEnd
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
        
        //public void CreateMap(int mapstart, int mapend, bool leveldoc, Dictionary leveldictionary) {
            //ReadLegend(levelDoc);
            //ReadMeta(levelDoc);
            //apply information to map
       // }        
    }
}

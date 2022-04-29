using System.IO;
using System;
using DIKUArcade.Entities;
using DIKUArcade.Math;
using DIKUArcade.Graphics;
using DIKUArcade.Events;

namespace Breakout.Levels {
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
            fileName = Path.Combine("Assets", "Levels", FileName);
            BreakoutBus.GetBus().RegisterEvent(
                new GameEvent {
                    EventType = GameEventType.GameStateEvent,
                    Message = "LevelSelector",
                    }
            );
            lines = File.ReadAllLines(fileName);
            FindCheckpoints();
            legend = new Dictionary<char, string>();
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
        /// <summary>
        /// Reads through the Legend information field xf
        /// Iteratively adding that information to the dictionary
        /// </summary>
        public void ReadLegend() {
            for (int i = legendStart + 1; i < legendEnd; i++) {
                char symbol = lines[i][0];
                string imgName = lines[i].Substring(3);
                if (!legend.ContainsKey(symbol)) {
                    legend.Add(symbol, imgName);
                }
            }
        }
        /// <summary>
        /// Reads through the Meta information field 
        /// Iteratively adding that information to the dictionary
        /// </summary>
        /*public void ReadMeta() {
            string Name = "";
            int Time = 10000;
            char Hard = '-';
            char PowerUp = '-';
            char Unbreakable = '-';
            for (int i = metaStart + 1; i < metaEnd; i++) {
                if (lines[i].Contains("Name:")){
                    int index = String.IndexOf(" ", lines[i]);
                    Name = lines[i].Substring(index + 1);
                }
                if (lines[i].Contains("Time:")){
                    int index = String.IndexOf(" ", lines[i]);
                    Time = (int) lines[i].Substring(index + 1);
                }
                if (lines[i].Contains("Hardened:")){
                    int index = String.IndexOf(" ", lines[i]);
                    Hard = lines[i].Substring(index + 1);
                }
                if (lines[i].Contains("PowerUp:")){
                    int index = String.IndexOf(" ", lines[i]);
                    PowerUp = lines[i].Substring(index + 1);
                }
                if (lines[i].Contains("Unbreakable:")){
                    int index = String.IndexOf(" ", lines[i]);
                    Unbreakable = lines[i].Substring(index + 1);
                }
            }
        }*/
        /// <summary>   
        /// Uses all the previous (ReadLegend, ReadMeta) after having initialized the levelLoader
        /// to iteratively apply the needed information from dictionary when intializing each block
        /// in the level (checking for each block)
        /// </summary>

        //overvejelser - vi vil have blokene i intervallet (0.2 til og med 1)
        public Level CreateLevel() {
            string Name = "";
            string Time = "10000";
            string Hard = "-";
            string PowerUp = "-";
            string Unbreakable = "-";
            EntityContainer<Block> Blocks = new EntityContainer<Block>();
            ReadLegend();
            //Går igennem alle linjerne
            for (int line = mapStart + 1; line < mapEnd; line++) {
                //går igennem alle tegne i linjerne
                for (int block = 0; block < 12; block++) {
                    if (lines[line][block] != '-') {
                        string imgName = Path.Combine("Assets", "Images",
                                         legend[lines[line][block]]);
                        Blocks.AddEntity(new Block(
                            new DynamicShape(new Vec2F(0.0f + block * 0.08f, 1f - line * 0.04f),
                            new Vec2F(0.08f, 0.04f)),
                            new Image(imgName),
                            false, false));
                    }  
                }  
            }
            for (int i = metaStart + 1; i < metaEnd; i++) {
                if (lines[i].Contains("Name:")) {
                    int index = lines[i].IndexOf(' ');
                    Name = lines[i].Substring(index + 1);
                }
                if (lines[i].Contains("Time:")) {
                    int index = lines[i].IndexOf(' ');
                    Time = lines[i].Substring(index + 1);
                }
                if (lines[i].Contains("Hardened:")) {
                    int index = lines[i].IndexOf(' ');
                    Hard = lines[i].Substring(index + 1);
                }
                if (lines[i].Contains("PowerUp:")) {
                    int index = lines[i].IndexOf(' ');
                    PowerUp = lines[i].Substring(index + 1);
                }
                if (lines[i].Contains("Unbreakable:")) {
                    int index = lines[i].IndexOf(' ');
                    Unbreakable = lines[i].Substring(index + 1);
                }
            } 
            return new Level(Name, Time, PowerUp, Hard, Blocks, Unbreakable);
        }        
    }
}

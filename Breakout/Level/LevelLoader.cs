using System.IO;
using System;
using DIKUArcade.Entities;
using DIKUArcade.Math;
using DIKUArcade.Graphics;
using DIKUArcade.Events;
using Breakout.Blocks;

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
            lines = File.ReadAllLines(fileName);
            FindCheckpoints();
            legend = new Dictionary<char, string>();
            ReadLegend();
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
        }
        /// <summary>
        /// Reads through the Legend information field xf
        /// Iteratively adding that information to the dictionary
        /// </summary>
        public void ReadLegend() {
            for (int i = legendStart + 1; i < legendEnd; i++) {
                char symbol = lines[i][0];
                string imgName = lines[i].Substring(3);
                legend.TryAdd(symbol, imgName);
            }
        }
        public void ReadMeta() {
            for (int i = legendStart + 1; i < legendEnd; i++) {
                char symbol = lines[i][0];
                string imgName = lines[i].Substring(3);
                legend.TryAdd(symbol, imgName);
            }
        }
        /// <summary>   
        /// Uses all the previous (ReadLegend, ReadMeta) after having initialized the levelLoader
        /// to iteratively apply the needed information from dictionary when intializing each block
        /// in the level (checking for each block)
        /// </summary>
        public Level CreateLevel() {
            string Name = "";
            string Time = "10000";
            string Hard = "-";
            string PowerUp = "-";
            string Unbreakable = "-";
            EntityContainer<BreakoutBlock> Blocks = new EntityContainer<BreakoutBlock>();
            
            //Går igennem alle linjerne
            for (int line = mapStart + 1; line < mapEnd; line++) {
                //går igennem alle tegne i linjerne
                for (int block = 0; block < 12; block++) {
                    if (lines[line][block] != '-') {
                        string imgName = Path.Combine("Assets", "Images",
                                         legend[lines[line][block]]);
                        Blocks.AddEntity(new StandardBlock(
                            new DynamicShape(new Vec2F(0.0f + block * 0.08f, 1f - (line - 1) * 0.04f),
                            new Vec2F(0.08f, 0.04f)),
                            new Image(imgName)));
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

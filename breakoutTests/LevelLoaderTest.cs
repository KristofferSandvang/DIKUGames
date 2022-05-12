using NUnit.Framework;
using System;
using System.IO;
using DIKUArcade;
using DIKUArcade.GUI;
using DIKUArcade.Input;
using DIKUArcade.Entities;
using DIKUArcade.Graphics;
using DIKUArcade.Math;
using DIKUArcade.Physics;
using System.Security.Principal;
using System.Collections.Generic;
using DIKUArcade.Events;
using DIKUArcade.State;
using Breakout;
using Breakout.Levels;

namespace breakoutTests {

    public class LevelLoaderTest {

        private LevelLoader tester;

        //Makes a tester levelLoader from "level1.txt" 
        //and creates a variable testLevel from this using .CreateLevel()
        [SetUp]
        public void Setup() {
        
        Window.CreateOpenGLContext();
        tester = new LevelLoader("level1.txt");
        var testLevel = tester.CreateLevel();
        }


        //Testing that the correct amount of entities has been instanizated 
        [Test]
        public void EntityCount() {
            Assert.AreEqual(testLevel.GetEC().CountEntities(),76);
        }
        
        //Testing that the correct time was read from the meta-data
        [Test]
        public void CorrectTime() {
            Assert.True(testLevel.GetTime(),"300");
        }

        //Testing that the correct name was read from the meta-data
        [Test]
        public void CorrectName() {
            Assert.True(testLevel.GetName(),"LEVEL 1");
        }


        //Testing that the correct powerup symbol was read from the meta-data
        [Test]
        public void CorrectPowerUp() {
            Assert.True(testLevel.GetPowerUp(),"2");
        }
    }
}

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

        [SetUp]
        public void Setup() {
        
        Window.CreateOpenGLContext();
        tester = new LevelLoader("level1.txt");
        }
        [Test]
        public void entityCount() {
            var level = tester.CreateLevel();
            Assert.AreEqual(level.GetEC().CountEntities(),76);

        }
    }
}

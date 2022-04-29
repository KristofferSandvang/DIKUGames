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
using Breakout.BreakoutStates;
using Breakout.Levels;
#pragma warning disable 8618
namespace breakoutTests;

    [TestFixture]
    public class StateTransformerTests {
        private StateTransformer Transformer;
        [SetUp]
        public void InitiateStateTransformer() {
            Transformer = new StateTransformer();
        }

        [Test]
        public void StateToString1() {
            string s = StateTransformer.TransformStateToString(GameStateType.MainMenu);
            Assert.AreEqual(s, "MainMenu");
        }
        [Test]
        public void StateToString2() {
            string s = StateTransformer.TransformStateToString(GameStateType.LevelSelector);
            Assert.AreEqual(s, "LevelSelector");
        }
        [Test]
        public void StateToString3() {
            string s = StateTransformer.TransformStateToString(GameStateType.GameRunning);
            Assert.AreEqual(s, "GameRunning");
        }
        [Test]
        public void StringToState1() {
            GameStateType s = StateTransformer.TransformStringToState("MainMenu");
            Assert.AreEqual(s, GameStateType.MainMenu);
        }
        [Test]
        public void StringToState2() {
            GameStateType s = StateTransformer.TransformStringToState("LevelSelector");
            Assert.AreEqual(s, GameStateType.LevelSelector);
        }
        [Test]
        public void StringToState3() {
            GameStateType s = StateTransformer.TransformStringToState("GameRunning");
            Assert.AreEqual(s, GameStateType.GameRunning);
        }

    }

    

using Breakout.BreakoutStates;
using NUnit.Framework;
using System;
#pragma warning disable 8618

namespace breakoutTests;

[TestFixture]
public class StateTransformerTests {
        //Tests the StateToString method, by inputting GameStateType.MainMenu
        [Test]
        public void TestStateToString_MainMenu() {
            string s = StateTransformer.TransformStateToString(GameStateType.MainMenu);
            Assert.AreEqual(s, "MainMenu");
        }
        //Tests the StateToString method, by inputting GameStateType.LevelSelector
        [Test]
        public void TestStateToString_LevelSelector() {
            string s = StateTransformer.TransformStateToString(GameStateType.LevelSelector);
            Assert.AreEqual(s, "LevelSelector");
        }
        //Tests the StateToString method, by inputting GameStateType.GameRunning
        [Test]
        public void TestStateToString_GameRunning() {
            string s = StateTransformer.TransformStateToString(GameStateType.GameRunning);
            Assert.AreEqual(s, "GameRunning");
        }
        //Tests the StateToString method, by inputting GameStateType.GamePaused
        [Test]
        public void TestStateToString_GamePaused() {
            string s = StateTransformer.TransformStateToString(GameStateType.GamePaused);
            Assert.AreEqual(s, "GamePaused");
        }
        //Tests the StateToString method, by inputting GameStateType.GameWin
        [Test]
        public void TestStateToString_GameWin() {
            string s = StateTransformer.TransformStateToString(GameStateType.GameWin);
            Assert.AreEqual(s, "GameWin");
        }
        //Tests the StateToString method, by inputting GameStateType.GameOver
        [Test]
        public void TestStateToString_GameOver() {
            string s = StateTransformer.TransformStateToString(GameStateType.GameOver);
            Assert.AreEqual(s, "GameOver");
        }
        //Tests the StateToString method, by inputting a invalid argument
        [Test]
        public void TestStateToString_Invalid() {
            Assert.Throws<ArgumentException>(
                delegate {StateTransformer.TransformStateToString(GameStateType.Invalid);}
            );
        }
        //Tests the String to State method, by inputting "MainMenu"
        [Test]
        public void TestStringToState_MainMenu() {
            GameStateType s = StateTransformer.TransformStringToState("MainMenu");
            Assert.AreEqual(s, GameStateType.MainMenu);
        }
        //Tests the String to State method, by inputting "LevelSelector"
        [Test]
        public void TestStringToState_LevelSelector() {
            GameStateType s = StateTransformer.TransformStringToState("LevelSelector");
            Assert.AreEqual(s, GameStateType.LevelSelector);
        }
        //Tests the String to State method, by inputting "GameRunning"
        [Test]
        public void TestStringToState_GameRunning() {
            GameStateType s = StateTransformer.TransformStringToState("GameRunning");
            Assert.AreEqual(s, GameStateType.GameRunning);
        }
        //Tests the String to State method, by inputting "GamePaused"
        [Test]
        public void TestStringToState_GamePaused() {
            GameStateType s = StateTransformer.TransformStringToState("GamePaused");
            Assert.AreEqual(s, GameStateType.GamePaused);
        }
        //Tests the String to State method, by inputting "GameWin"
        [Test]
        public void TestStringToState_GameWin() {
            GameStateType s = StateTransformer.TransformStringToState("GameWin");
            Assert.AreEqual(s, GameStateType.GameWin);
        }
        //Tests the String to State method, by inputting "GameOver"
        [Test]
        public void TestStringToState_GameOver() {
            GameStateType s = StateTransformer.TransformStringToState("GameOver");
            Assert.AreEqual(s, GameStateType.GameOver);
        }
        //Tests the String to State method, by inputting an invalid argument
        [Test]
        public void TestStringToState_Invalid() {
             Assert.Throws<ArgumentException>(
                delegate {StateTransformer.TransformStringToState("Invalid");}
            );
        }

}
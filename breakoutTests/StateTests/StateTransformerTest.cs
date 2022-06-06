using Breakout.BreakoutStates;
using NUnit.Framework;

#pragma warning disable 8618

namespace breakoutTests;

[TestFixture]
public class StateTransformerTests {
        private StateTransformer Transformer;

        [SetUp]
        public void InitializeStateTransformer() {
            Transformer = new StateTransformer();
        }

        [Test]
        public void TestStateToString_MainMenu() {
            string s = StateTransformer.TransformStateToString(GameStateType.MainMenu);
            Assert.AreEqual(s, "MainMenu");
        }

        [Test]
        public void TestStateToString_LevelSelector() {
            string s = StateTransformer.TransformStateToString(GameStateType.LevelSelector);
            Assert.AreEqual(s, "LevelSelector");
        }
        [Test]
        public void TestStateToString_GameRunning() {
            string s = StateTransformer.TransformStateToString(GameStateType.GameRunning);
            Assert.AreEqual(s, "GameRunning");
        }

        [Test]
        public void TestStateToString_GamePaused() {
            string s = StateTransformer.TransformStateToString(GameStateType.GamePaused);
            Assert.AreEqual(s, "GamePaused");
        }

        [Test]
        public void TestStateToString_GameWin() {
            string s = StateTransformer.TransformStateToString(GameStateType.GameWin);
            Assert.AreEqual(s, "GameWin");
        }
        [Test]
        public void TestStateToString_GameOver() {
            string s = StateTransformer.TransformStateToString(GameStateType.GameOver);
            Assert.AreEqual(s, "GameOver");
        }

        [Test]
        public void TestStringToState_MainMenu() {
            GameStateType s = StateTransformer.TransformStringToState("MainMenu");
            Assert.AreEqual(s, GameStateType.MainMenu);
        }

        [Test]
        public void TestStringToState_LevelSelector() {
            GameStateType s = StateTransformer.TransformStringToState("LevelSelector");
            Assert.AreEqual(s, GameStateType.LevelSelector);
        }
        
        [Test]
        public void TestStringToState_GameRunning() {
            GameStateType s = StateTransformer.TransformStringToState("GameRunning");
            Assert.AreEqual(s, GameStateType.GameRunning);
        }

        [Test]
        public void TestStringToState_GamePaused() {
            GameStateType s = StateTransformer.TransformStringToState("GamePaused");
            Assert.AreEqual(s, GameStateType.GamePaused);
        }
        
        [Test]
        public void TestStringToState_GameWin() {
            GameStateType s = StateTransformer.TransformStringToState("GameWin");
            Assert.AreEqual(s, GameStateType.GameWin);
        }

        [Test]
        public void TestStringToState_GameOver() {
            GameStateType s = StateTransformer.TransformStringToState("GameOver");
            Assert.AreEqual(s, GameStateType.GameOver);
        }


}
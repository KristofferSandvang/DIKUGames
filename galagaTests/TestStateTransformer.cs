using Galaga.GalagaStates;
using NUint.Framework;
namespace GalagaTests;

    [TestFixture]
    public class StateMachineTesting {
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
            string s = StateTransformer.TransformStateToString(GameStateType.GamePaused);
            Assert.AreEqual(s, "GamePaused");
        }
        [Test]
        public void StateToString3() {
            GameStateType s = StateTransformer.TransformStateToString(GameStateType.GameRunning);
            Assert.AreEqual(s, "GameRunning");
        }
        [Test]
        public void StringToState1() {
            GameStateType s = StateTransformer.TransformStateToString("MainMenu");
            Assert.AreEqual(s, GameStateType.MainMenu);
        }
        [Test]
        public void StringToState2() {
            GameStateType s = StateTransformer.TransformStateToString("GamePaused");
            Assert.AreEqual(s, GameStateType.GamePaused);
        }
        [Test]
        public void StringToState3() {
            GameStateType s = StateTransformer.TransformStateToString("GameRunning");
            Assert.AreEqual(s, GameStateType.GameRunning);
        }

    }

    

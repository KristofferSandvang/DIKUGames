using Galaga.GalagaStates;
namespace GalagaTests {
    [TestFixture]
    public class StateMachineTesting {
        private StateTransformer Transformer;
        [SetUp]
        public void InitiateStateTransformer() {
            Transformer = new StateTransformer();
        }

        [Test]
        public void TestInitialState() {
            StateTransformer.TransformStateToString();
            Assert.That(stateMachine.ActiveState, Is.InstanceOf<MainMenu>());
        }
    }
}
    

using Galaga.GalagaStates;
using NUint.Framework;
using Galaga;
using DIKUArcade.Events;
using System.Collections.Generic;
namespace GalagaTests;

    [TestFixture]
    public class StateMachineTesting {
        private StateMachine stateMachine;
        private GameEventBus eventBus;

        [OneTimeSetUp]
        public void InitializeEventBus() {
            eventBus = GalagaBus.GetBus();
            eventBus.InitializeEventBus(new List<GameEventType> { GameEventType.InputEvent,
            GameEventType.GameStateEvent });
        }

        [SetUp]
        public void InitiateStateTransformer() {
            DIKUArcade.Window.CreateOpenGLContext();
            stateMachine = new StateMachine();
            eventBus.Subscribe(GameEventType.GameStateEvent, stateMachine);
        }

        [Test]
        public void TestInitialState() {
            Assert.That(stateMachine.ActiveState, Is.InstanceOf<MainMenu>());
        }
        [Test]
        public void TestEventGamePaused() {
            GalagaBus.GetBus().RegisterEvent(
                new GameEvent{
                EventType = GameEventType.GameStateEvent,
                Message = "changeState",
                StringArg1 = "gamePaused"
                }
            );

            GalagaBus.GetBus().ProcessEventsSequentially();
            Assert.That(stateMachine.ActiveState, Is.InstanceOf<GamePaused>());
        }
    }

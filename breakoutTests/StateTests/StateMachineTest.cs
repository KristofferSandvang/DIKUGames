using NUnit.Framework;
using Breakout.BreakoutStates;
using DIKUArcade.Events;
using DIKUArcade;
using DIKUArcade.GUI;
using Breakout;
using System.Collections.Generic;
#pragma warning disable 8618

namespace breakoutTests;

   [TestFixture]
    public class StateMachineTesting {
        private StateMachine stateMachine;

        [OneTimeSetUp]
        public void InitializeEventBus() {
            BreakoutBus.GetBus().InitializeEventBus(new List<GameEventType> { GameEventType.InputEvent,
            GameEventType.PlayerEvent, GameEventType.GameStateEvent, GameEventType.StatusEvent,
            GameEventType.ControlEvent, GameEventType.MovementEvent } );
        }

        [OneTimeTearDown]
        public void ResetEventbus() {
            BreakoutBus.ResetBus();
        }

        [SetUp]
        public void InitializeStateMachine() {
            Window.CreateOpenGLContext();
            stateMachine = new StateMachine();
            BreakoutBus.GetBus().Subscribe(GameEventType.GameStateEvent, stateMachine);
        }

        
        [Test]
        public void TestInitialState() {
            Assert.IsInstanceOf<MainMenu>(stateMachine.ActiveState);
        }
    }
using NUnit.Framework;
using Breakout.BreakoutStates;
using DIKUArcade.Events;
using DIKUArcade.GUI;
using Breakout;
using System;
using System.Collections.Generic;

namespace BreakoutTests.StateTests;

   [TestFixture]
    public class StateMachineTest {
        private StateMachine stateMachine;

        public StateMachineTest() {
            stateMachine = new StateMachine();
        }

        [OneTimeSetUp]
        public void InitializeEventBus() {
            Window.CreateOpenGLContext();
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

        //Tests that the initial state is MainMenu
        [Test]
        public void TestInitialState() {
            Assert.IsInstanceOf<MainMenu>(stateMachine.ActiveState);
        }
        //Tests that statemachine can switch the active state to LevelSelector
        [Test]
        public void TestSwitchTo_LevelSelector() {
            BreakoutBus.GetBus().RegisterEvent(
                new GameEvent {
                    EventType = GameEventType.GameStateEvent,
                    Message = "SwitchState",
                    StringArg1 = "LevelSelector"
                }
            );

            BreakoutBus.GetBus().ProcessEventsSequentially();
            Assert.IsInstanceOf<LevelSelector>(stateMachine.ActiveState);
        }
        //Tests that statemachine can switch the active state to GameRunning
        [Test]
        public void TestSwitchTo_GameRunning() {
            BreakoutBus.GetBus().RegisterEvent(
                new GameEvent {
                    EventType = GameEventType.GameStateEvent,
                    Message = "SwitchState",
                    StringArg1 = "GameRunning"
                }
            );

            BreakoutBus.GetBus().ProcessEventsSequentially();
            Assert.IsInstanceOf<GameRunning>(stateMachine.ActiveState);
        }
        //Tests that statemachine can switch the active state to GamePaused
        [Test]
        public void TestSwitchTo_GamePaused() {
            BreakoutBus.GetBus().RegisterEvent(
                new GameEvent {
                    EventType = GameEventType.GameStateEvent,
                    Message = "SwitchState",
                    StringArg1 = "GamePaused"
                }
            );

            BreakoutBus.GetBus().ProcessEventsSequentially();
            Assert.IsInstanceOf<GamePaused>(stateMachine.ActiveState);
        }
        //Tests that statemachine can switch the active state to GameWin
        [Test]
        public void TestSwitchTo_GameWin() {
            BreakoutBus.GetBus().RegisterEvent(
                new GameEvent {
                    EventType = GameEventType.GameStateEvent,
                    Message = "SwitchState",
                    StringArg1 = "GameWin"
                }
            );

            BreakoutBus.GetBus().ProcessEventsSequentially();
            Assert.IsInstanceOf<GameWin>(stateMachine.ActiveState);
        }
        //Tests that statemachine can switch the active state to GameOver
        [Test]
        public void TestSwitchTo_GameOver() {
            BreakoutBus.GetBus().RegisterEvent(
                new GameEvent {
                    EventType = GameEventType.GameStateEvent,
                    Message = "SwitchState",
                    StringArg1 = "GameOver"
                }
            );

            BreakoutBus.GetBus().ProcessEventsSequentially();
            Assert.IsInstanceOf<GameOver>(stateMachine.ActiveState);
        }
        //Tests that statemachine will throw an argument exception if not presented with a valid
        // argument
        [Test]
        public void TestSwitchTo_InvalidArgument() {
            BreakoutBus.GetBus().RegisterEvent(
                new GameEvent {
                    EventType = GameEventType.GameStateEvent,
                    Message = "SwitchState",
                    StringArg1 = "InvalidArgument"
                }
            );

            Assert.Throws<ArgumentException>(
                delegate { BreakoutBus.GetBus().ProcessEventsSequentially(); }
            );
        }
    }
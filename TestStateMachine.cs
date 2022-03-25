using NUnit.Framework;
using Galaga;
using System;
using System.IO;
using DIKUArcade;
using DIKUArcade.GUI;
using DIKUArcade.Input;
using DIKUArcade.Entities;
using DIKUArcade.Graphics;
using DIKUArcade.Math;
using DIKUArcade.Events;
using System.Collections.Generic;
using Galaga.MovementStrategy;
using Galaga.GalagaStates;

namespace GalagaTests;
#pragma warning disable 8618
   [TestFixture]
    public class StateMachineTesting {
        private StateMachine stateMachine;
        private GameEventBus eventBus;  
        [SetUp]
        public void InitializeStateMachine() {
            stateMachine = new StateMachine();
            eventBus.Subscribe(GameEventType.GameStateEvent, stateMachine);
        }

        [OneTimeSetUp]
        public void InitializeEventBus() {
            Window.CreateOpenGLContext();    
            eventBus = new GameEventBus();
    
            eventBus.InitializeEventBus(new List<GameEventType> { 
                GameEventType.InputEvent,
                GameEventType.GameStateEvent,
                GameEventType.PlayerEvent,
                 } );
        }
        [Test]
        public void TestInitialState() {
            Assert.That(stateMachine.ActiveState, Is.InstanceOf<MainMenu>());
        }
        [Test]
        public void TestEventGameRunning() {
            eventBus.RegisterEvent(
                new GameEvent{
                EventType = GameEventType.GameStateEvent,
                Message = "GameRunning",
                }
            );
            
            eventBus.ProcessEventsSequentially();
            Assert.That(stateMachine.ActiveState, Is.InstanceOf<GameRunning>());
        }
    }
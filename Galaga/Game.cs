using DIKUArcade;
using DIKUArcade.GUI;
using DIKUArcade.Input;
using System.Collections.Generic;
using DIKUArcade.Events;
using Galaga.GalagaStates;

namespace Galaga {
    /// <summary>
    /// A subclass of the DIKUGame containing all information about the Game.
    /// </summary>
    public class Game : DIKUGame, IGameEventProcessor{
        private StateMachine stateMachine;
        
        public Game(WindowArgs windowArgs) : base(windowArgs) {
            stateMachine = new StateMachine();

            GalagaBus.GetBus().InitializeEventBus(new List<GameEventType> { GameEventType.InputEvent,
            GameEventType.PlayerEvent, GameEventType.GameStateEvent });
            window.SetKeyEventHandler(HandleKeyEvent);
            GalagaBus.GetBus().Subscribe(GameEventType.InputEvent, this);
            GalagaBus.GetBus().Subscribe(GameEventType.GameStateEvent, stateMachine);

            
        } 
        public void HandleKeyEvent(KeyboardAction action, KeyboardKey key) {
            stateMachine.ActiveState.HandleKeyEvent(action, key);
        }
        /// <summary>
        /// Processes a GameEvent based on the GameEvent.Message
        /// </summary>
        /// <param name='gameEvent'>
        /// A GameEvent
        /// </param>
        public void ProcessEvent(GameEvent gameEvent) {
            if (gameEvent.EventType == GameEventType.InputEvent) {
                switch (gameEvent.Message) {
                    case "close":
                        window.CloseWindow();
                        break;
                    default:
                        break;
                }
            }
        }
        /// <summary>
        /// Renders all Entities in the game.
        /// </summary>
        public override void Render() {
            stateMachine.ActiveState.RenderState();
        }
        /// <summary>
        /// Updates the Game
        /// </summary>
        public override void Update() {
            GalagaBus.GetBus().ProcessEventsSequentially();
            stateMachine.ActiveState.UpdateState();
        }   
    }
} 

using DIKUArcade.Events;
using DIKUArcade.State;
using System;
using Galaga;

namespace Galaga.GalagaStates {
    public class StateMachine : IGameEventProcessor {
        public IGameState ActiveState { get; private set; }
        public StateMachine() {

            GalagaBus.GetBus().Subscribe(GameEventType.GameStateEvent, this);
            GalagaBus.GetBus().Subscribe(GameEventType.InputEvent, this);
            ActiveState = MainMenu.GetInstance();
            GameRunning.GetInstance(); 
        }
        /// <summary>
        /// Switches the current state
        /// </summary>
        /// <param name='stateType'>
        /// The GameStateType you wish the current State to be.
        /// </param>
        private void SwitchState(GameStateType stateType) {
            switch (stateType) {
                case GameStateType.MainMenu:
                    ActiveState = new MainMenu();
                    break;
                case GameStateType.GamePaused:
                    ActiveState = new GamePaused();
                    break;
                case GameStateType.GameRunning:
                    ActiveState = new GameRunning();
                    break;
            }
            
        }
        /// <summary>
        /// Processes a GameEvent based on the GameEvent.Message
        /// </summary>
        /// <param name='gameEvent'>
        /// A GameEvent
        /// </param>
        public void ProcessEvent(GameEvent gameEvent) {
            if (gameEvent.EventType == GameEventType.GameStateEvent) {
                switch (gameEvent.Message) {
                    case "GamePaused":
                        SwitchState(StateTransformer.TransformStringToState("GamePaused"));
                        break; 
                    case "GameRunning":
                        SwitchState(StateTransformer.TransformStringToState("GameRunning"));
                        break;
                }
            }
        }        
    }
}

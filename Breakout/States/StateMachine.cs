using DIKUArcade.Events;
using DIKUArcade.State;
using System;

namespace Breakout.BreakoutStates {
    public class StateMachine : IGameEventProcessor {
        public IGameState ActiveState { get; private set; }
        public StateMachine() {

            BreakoutBus.GetBus().Subscribe(GameEventType.GameStateEvent, this);
            BreakoutBus.GetBus().Subscribe(GameEventType.InputEvent, this);
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
                case GameStateType.GameRunning:
                    ActiveState = new GameRunning();
                    break;
                case GameStateType.LevelSelector:
                    ActiveState = new LevelSelector();
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
                    case "LevelSelector":
                        SwitchState(StateTransformer.TransformStringToState("LevelSelector"));
                        break;
                }
            }
        }        
    }
}


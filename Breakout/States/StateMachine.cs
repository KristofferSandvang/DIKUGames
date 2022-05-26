using DIKUArcade.Events;
using DIKUArcade.State;
using DIKUArcade.Timers;
using System;

namespace Breakout.BreakoutStates {
    public class StateMachine : IGameEventProcessor {
        public IGameState ActiveState { get; private set; }
        private IGameState[] States = { new MainMenu(), new LevelSelector(), new GameRunning(),
                                       new GamePaused(), new GameOver(), new GameWin() };
        public StateMachine() {
            BreakoutBus.GetBus().Subscribe(GameEventType.GameStateEvent, this);
            BreakoutBus.GetBus().Subscribe(GameEventType.InputEvent, this);
            ActiveState = States[0];
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
                    States[0].ResetState();
                    ActiveState = States[0];
                    break;

                case GameStateType.LevelSelector:
                    States[1].ResetState();
                    ActiveState = States[1];
                    break;

                case GameStateType.GameRunning:
                    if (ActiveState is GamePaused) {
                        StaticTimer.ResumeTimer();
                        ActiveState = States[2];
                    } else {
                        States[2].ResetState();
                        ActiveState = States[2];
                    }
                    break;
                
                case GameStateType.GamePaused:
                    States[3].ResetState();
                    ActiveState = States[3];
                    break;

                case GameStateType.GameOver:
                    States[4].ResetState();
                    ActiveState = States[4];
                    break;
                
                case GameStateType.GameWin:
                    States[5].ResetState();
                    ActiveState = States[5];
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
                    case "SwitchState":
                        SwitchState(StateTransformer.TransformStringToState(gameEvent.StringArg1));
                        break; 
                    default:
                        break;
                }
            }
        }        
    }
}


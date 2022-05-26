using DIKUArcade.Events;
using DIKUArcade.State;
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
                    ActiveState = MainMenu.GetInstance();
                    break;
                case GameStateType.GameRunning:
                    ActiveState = GameRunning.GetInstance();
                    break;
                case GameStateType.LevelSelector:
                    ActiveState = LevelSelector.GetInstance();
                    break;
                case GameStateType.GamePaused:
                    ActiveState = GamePaused.GetInstance();
                    break;
                case GameStateType.GameWin:
                    ActiveState = GameWin.GetInstance();
                    break;
                case GameStateType.GameOver:
                    ActiveState = GameOver.GetInstance();
                    break;
            }
        }
        public void ResetStates() {
            foreach (IGameState state in States) {
                state.ResetState();
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


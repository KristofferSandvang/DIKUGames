using DIKUArcade;
using DIKUArcade.GUI;
using DIKUArcade.Events;
using DIKUArcade.Input;
using Breakout.BreakoutStates;

namespace Breakout {
    public class Game : DIKUGame, IGameEventProcessor {
        private StateMachine stateMachine;
        public Game(WindowArgs windowArgs) : base(windowArgs) {
            stateMachine = new StateMachine();
            BreakoutBus.GetBus().InitializeEventBus(new List<GameEventType> { GameEventType.InputEvent,
            GameEventType.PlayerEvent, GameEventType.GameStateEvent });
            window.SetKeyEventHandler(HandleKeyEvent);
            BreakoutBus.GetBus().Subscribe(GameEventType.InputEvent, this);
            BreakoutBus.GetBus().Subscribe(GameEventType.GameStateEvent, stateMachine);
        }
        public void HandleKeyEvent(KeyboardAction action, KeyboardKey key) {
            stateMachine.ActiveState.HandleKeyEvent(action, key);
        }
        /// <summary>   
        /// Renders the active state of the game
        /// </summary>
        public override void Render() {
            stateMachine.ActiveState.RenderState();
        }
        /// <summary>   
        /// Updates the active state of the game
        /// </summary>
        public override void Update() {
            BreakoutBus.GetBus().ProcessEventsSequentially();
            stateMachine.ActiveState.UpdateState();
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
                    case "Close":
                        window.CloseWindow();
                        break;
                    default:
                        break;
                }
            }
        }
    }
}

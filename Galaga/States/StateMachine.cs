using DIKUArcade.Events;
using DIKUArcade.State;
using System;
using Galaga;

namespace Galaga.GalagaStates {
    public class StateMachine : IGameEventProcessor {
        public IGameState ActiveState { get; private set; }
        public StateMachine() {
          //  GalagaBus.GetBus().Subscribe(GameEventType.GameStateEvent, this);
            //GalagaBus.GetBus().Subscribe(GameEventType.InputEvent, this);
            //ActiveState = MainMenu.GetInstance();
            //GameRunning.GetInstance(); 
            //GamePaused.GetInstance();
        }
        private void SwitchState(GameStateType stateType) {
            //switch (stateType) {
              //  default:
                //break;
            //}
            throw new NotImplementedException();
            
        }
        public void ProcessEvent(GameEvent gameEvent) {
            if (gameEvent.EventType == GameEventType.GameStateEvent) {
                switch (gameEvent.Message) {
                    case "moveLeft":
                        break; 
                }
            }
        }        
    }
}
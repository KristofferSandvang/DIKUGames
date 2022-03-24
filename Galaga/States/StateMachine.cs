using DIKUArcade.Events;
using DIKUArcade.State;
using Galaga.GalagaStates;
using Galaga;

namespace Galaga.GalagaStates {
    public class StateMachine : IGameEventProcessor {
        public IGameState ActiveState { get; private set; }
        //public StateMachine() {
          //  GalagaBus.GetBus().Subscribe(GameEventType.GameStateEvent, this);
            //GalagaBus.GetBus().Subscribe(GameEventType.InputEvent, this);
            //ActiveState = MainMenu.GetInstance();
            //ameRunning.GetInstance(); 
            //GamePaused.GetInstance();
        //}
        private void SwitchState(GameStateType stateType) {
            switch (stateType) {
                default:
                break;
            }
        }
        public void ProcessEvent(GameEvent gameevent) {

        }
    }
}
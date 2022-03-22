namespace Galaga.State {
    public class StateTransformer {
        public static GameStateType TransformStringToState(string state) {
            switch (state) {
                case "MainMenu":
                    return GameStateType.MainMenu;
                case "GamePaused":
                    return GameStateType.GamePaused;
                case "GameRunning":
                    return GameStateType.GameRunning;
                default:
                    throw new ArgumentException(
                        String.Format("{0} does not correspond to a GameStateType", state),
                        "state");;
            }
        }
        public static string TransformStateToString(GameStateType state) {
            switch (state) {
                case GameStateType.MainMenu:
                    return "MainMenu";
                case GameStateType.MainMenu:
                    return "GamePaused";
                case GameStateType.GameRunning:
                    return "GameRunning";
                default:
                    throw new ArgumentException(
                        String.Format("{0} is not a GameStateType", state),
                        "state");;
            }
        }
    }
}

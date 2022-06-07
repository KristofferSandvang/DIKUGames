namespace Breakout.BreakoutStates {
    /// <summary>   
    /// A class that can transform strings to GameStateTypes and GameStateTypes to strings. 
    /// </summary> 
    public class StateTransformer {
        /// <summary>
        /// Transforms a string in to GameStateType
        /// </summary>
        /// <param name='state'>
        /// a string corresponding to a GameStateType
        /// </param>
        /// <returns>
        /// the corresponding GameStateType
        /// </returns>
        public static GameStateType TransformStringToState(string state) {
            switch (state) {
                case "MainMenu":
                    return GameStateType.MainMenu;
                case "GameRunning":
                    return GameStateType.GameRunning;
                case "LevelSelector":
                    return GameStateType.LevelSelector;
                case "GamePaused":
                    return GameStateType.GamePaused;
                case "GameWin":
                    return GameStateType.GameWin;
                case "GameOver":
                    return GameStateType.GameOver;
                default:
                    throw new ArgumentException(
                        String.Format("{0} does not correspond to a GameStateType", state),
                        "state");;
            }
        }
        /// <summary>
        /// Transforms a GameStateType into a string
        /// </summary>
        /// <param name='state'>
        /// A GameStateType
        /// </param>
        /// <returns>
        /// the corresponding string
        /// </returns>
        public static string TransformStateToString(GameStateType state) {
            switch (state) {
                case GameStateType.MainMenu:
                    return "MainMenu";
                case GameStateType.GameRunning:
                    return "GameRunning";
                case GameStateType.LevelSelector:
                    return "LevelSelector";
                case GameStateType.GamePaused:
                    return "GamePaused";
                case GameStateType.GameWin:
                    return "GameWin";
                case GameStateType.GameOver:
                    return "GameOver";
                default:
                    throw new ArgumentException(
                        String.Format("{0} is not a GameStateType", state),
                        "state");;
            }
        }
    }
}


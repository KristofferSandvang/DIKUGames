using System;
using DIKUArcade.GUI;

namespace Breakout {
    class Program {
        static void Main(string[] args) {
            var ll = new LevelLoader("Level3.txt");
            var windowArgs = new WindowArgs() { Title = "Breakout v0.0.1" };
            var game = new Game(windowArgs);
            ll.Testing();
            game.Run();
        }
    }
}

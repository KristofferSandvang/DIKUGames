using System.IO;
using DIKUArcade;
using DIKUArcade.GUI;
using DIKUArcade.Input;
using DIKUArcade.Entities;
using DIKUArcade.Graphics;
using DIKUArcade.Math;

namespace Galaga {
    public class Game : DIKUGame {
        private Player player;
        public Game(WindowArgs windowArgs) : base(windowArgs) {
            // TODO: Set key event handler (inherited window field of DIKUGame class)
            player = new Player(
                new DynamicShape(new Vec2F(0.45f, 0.1f), new Vec2F(0.1f, 0.1f)),
                new Image(Path.Combine("Assets", "Images", "Player.png")));
        }

        //private void KeyHandler(KeyboardAction action, KeyboardKey key) {} // TODO: Outcomment

        public override void Render() {
            player.Render();
        }

        public override void Update() {
            player.SetMoveLeft(true);
            player.move();
            player.move();
            player.move();
            player.Render();
        }
    }
}


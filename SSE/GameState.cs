using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSE {
    public class GameState : State {
        public Game game;

        public GameState(Game game) {
            this.game = game;
        }
        public void draw(Graphics g) {
            this.game.draw(g);
        }
    }
}

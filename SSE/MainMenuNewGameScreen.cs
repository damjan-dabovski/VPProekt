using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SSE {
    public class MainMenuNewGameScreen : MenuState {
        TextBox player1name, player2name;
        Button startGame, back;

        public MainMenuNewGameScreen(int width, int height) : base(width, height) {
            player1name = new TextBox();
            player2name = new TextBox();
            startGame = new Button();
            back = new Button();
            this.buttons = new Button[2] { startGame, back };
            //TODO custom button and textbox positioning, image
        }
    }
}

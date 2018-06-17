using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SSE {
    public class MainMenuStartScreen : MenuState {
        Button newGame, loadGame, settings, tutorial, quitGame;

        public MainMenuStartScreen(int width, int height) : base(width,height) {
            newGame = new Button();
            loadGame = new Button();
            settings = new Button();
            tutorial = new Button();
            quitGame = new Button();
            this.buttons = new Button[5] { newGame, loadGame, settings, tutorial, quitGame };
            //TODO image
        }


    }
}

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SSE {
    public class MainMenuStartScreen : MenuState {
        public Button newGame, loadGame, tutorial, quitGame;

        public MainMenuStartScreen(int width, int height) : base(width,height) {
            newGame = new Button();
            loadGame = new Button();
            tutorial = new Button();
            quitGame = new Button();
            this.buttons = new Button[4] { newGame, loadGame, tutorial, quitGame };
            this.background = Properties.Resources.mainmenusplash;
            for (int i = 0; i < buttons.Length; i++) {
                buttons[i].Location = new Point(480, (210 + (125 * i)));
                buttons[i].Size = new Size(308, 108);
                buttons[i].BackgroundImage = Properties.Resources.mainmenubutton;
                buttons[i].BackgroundImageLayout = ImageLayout.None;
                buttons[i].BackColor = Color.Transparent;
                buttons[i].FlatAppearance.BorderSize = 0;
                buttons[i].FlatAppearance.MouseDownBackColor = Color.Transparent;
                buttons[i].FlatAppearance.MouseOverBackColor = Color.Transparent;
                buttons[i].FlatStyle = FlatStyle.Flat;
            }
            this.newGame.Text = "New Game";
            this.loadGame.Text = "Load Game";
            this.tutorial.Text = "Tutorial";
            this.quitGame.Text = "Quit Game";
        }


    }
}

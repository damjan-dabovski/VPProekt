using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SSE {
    public class MainMenuNewGameScreen : MenuState {
        public TextBox player1name, player2name;
        public Button startGame, back;

        public MainMenuNewGameScreen(int width, int height) : base(width, height) {
            player1name = new TextBox();
            player2name = new TextBox();
            startGame = new Button();
            back = new Button();
            this.buttons = new Button[2] { startGame, back };
            //TODO custom button and textbox positioning, image
            this.background = Properties.Resources.newgame;
            this.startGame.Text = "Start";
            this.back.Text = "Back";
            buttons[0].Location = new Point(width-183, height - 83);
            buttons[1].Location = new Point(25, height - 83);
            for (int i = 0; i < buttons.Length;i++) {            
                buttons[i].Size = new Size(158, 58);
                buttons[i].BackgroundImage = Properties.Resources.mainmenubutton;
                buttons[i].BackgroundImageLayout = ImageLayout.Zoom;
                buttons[i].BackColor = Color.Transparent;
                buttons[i].FlatAppearance.BorderSize = 0;
                buttons[i].FlatAppearance.MouseDownBackColor = Color.Transparent;
                buttons[i].FlatAppearance.MouseOverBackColor = Color.Transparent;
                buttons[i].FlatStyle = FlatStyle.Flat;
            }
        }
    }
}

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
        public Label player1, player2;
        public Button startGame, back;

        public MainMenuNewGameScreen(int width, int height) : base(width, height) {
            player1name = new TextBox();
            player2name = new TextBox();
            startGame = new Button();
            back = new Button();
            player1 = new Label();
            player2 = new Label();
            this.buttons = new Button[2] { startGame, back };
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

            this.player1.Font = new Font(Form1.font.Families[0], 20, FontStyle.Regular);
            this.player2.Font = new Font(Form1.font.Families[0], 20, FontStyle.Regular);
            this.player1name.Font= new Font(Form1.font.Families[0], 20, FontStyle.Regular);
            this.player2name.Font = new Font(Form1.font.Families[0], 20, FontStyle.Regular);

            this.player1.AutoSize = true;
            this.player2.AutoSize = true;
            this.player1.Text = "Player 1 Name:";
            this.player2.Text = "Player 2 Name:";

            this.player1.Location = new Point(490, 250);
            this.player1name.Location = new Point(525, 300);
            this.player1name.Size = new Size(200, 30);
            this.player1.BackColor = Color.Transparent;
            this.player1.ForeColor = Color.White;

            this.player2.Location = new Point(485, 400);
            this.player2name.Location = new Point(525, 450);
            this.player2name.Size = new Size(200, 30);
            this.player2.ForeColor = Color.White;
            this.player2.BackColor = Color.Transparent;
        }
    }
}

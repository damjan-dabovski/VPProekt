using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SSE
{
    [Serializable()]
    public class GameState : State
    {
        public Game game;
        public Image background;
        public int width, height;
        public Label p1Score, p2Score, activePlayerReminder;
        public Label[] colonyNumbers;
        public Button colonyButton, tradeButton, menuButton;
        public Button[] buttons;
        public IngameMenu menu;
        public MessagePopup endGamePopup;
        private String FileName;


        public GameState(Game game, int width, int height)
        {
            this.FileName = null;
            this.game = game;
            this.menu = null;
            this.endGamePopup = null;
            this.background = Properties.Resources.gamebackground;
            this.width = width;
            this.height = height;
            this.p1Score = new Label();
            this.p2Score = new Label();
            this.activePlayerReminder = new Label();
            this.colonyButton = new Button();
            this.tradeButton = new Button();
            this.menuButton = new Button();
            this.buttons = new Button[3] { colonyButton, tradeButton, menuButton };
            for (int i = 0; i < buttons.Length; i++)
            {
                buttons[i].Size = new Size(108, 108);
                buttons[i].BackgroundImageLayout = ImageLayout.None;
                buttons[i].BackColor = Color.Transparent;
                buttons[i].FlatAppearance.BorderSize = 0;
                buttons[i].FlatAppearance.MouseDownBackColor = Color.Transparent;
                buttons[i].FlatAppearance.MouseOverBackColor = Color.Transparent;
                buttons[i].FlatStyle = FlatStyle.Flat;
            }
            this.colonyButton.BackgroundImage = Properties.Resources.colonybutton_on;
            this.tradeButton.BackgroundImage = Properties.Resources.colonybutton_trade_off;
            this.menuButton.BackgroundImage = Properties.Resources.mainmenubutton;
            this.colonyButton.Location = new Point(954, 294);
            this.tradeButton.Location = new Point(1092, 294);
            this.menuButton.Location = new Point(960, 630);
            this.menuButton.Size = new Size(248, 88);
            this.menuButton.BackgroundImageLayout = ImageLayout.Zoom;
            this.menuButton.Text = "Menu";
            this.menuButton.Font = new Font(Form1.font.Families[0], 22, FontStyle.Regular);

            this.p1Score.AutoSize = true;
            this.p1Score.BackColor = Color.Transparent;
            this.p1Score.ForeColor = Color.White;
            this.p1Score.Location = new Point(964, 524);
            this.p1Score.Font = new Font(Form1.font.Families[0], 22, FontStyle.Regular);

            this.p2Score.AutoSize = true;
            this.p2Score.BackColor = Color.Transparent;
            this.p2Score.ForeColor = Color.White;
            this.p2Score.Location = new Point(964, 574);
            this.p2Score.Font = new Font(Form1.font.Families[0], 22, FontStyle.Regular);

            this.activePlayerReminder.AutoSize = true;
            this.activePlayerReminder.Location = new Point(980, 125);
            this.activePlayerReminder.Font = new Font(Form1.font.Families[0], 24, FontStyle.Regular);
            this.activePlayerReminder.ForeColor = Color.White;
            this.activePlayerReminder.BackColor = Color.Transparent;

            this.colonyNumbers = new Label[2];
            for (int i = 0; i < colonyNumbers.Length; i++)
            {
                colonyNumbers[i] = new Label();
                colonyNumbers[i].AutoSize = true;
                colonyNumbers[i].Location = new Point(980 + (140 * i), 395);
                colonyNumbers[i].Font = new Font(Form1.font.Families[0], 22, FontStyle.Regular);
                colonyNumbers[i].ForeColor = Color.Black;
                colonyNumbers[i].BackColor = Color.Transparent;
            }
        }


        public void draw(Graphics g)
        {
            g.DrawImage(this.background, new Rectangle(new Point(0, 0), new Size(this.width, this.height)));
            this.game.draw(g);
            p1Score.Text = String.Format("{0} : {1}", this.game.p1.name, this.game.p1.score.ToString());
            while (p1Score.Width > 220) {
                p1Score.Font = new Font(Form1.font.Families[0], p1Score.Font.Size - 1, FontStyle.Regular);
            }
            p2Score.Text = String.Format("{0} : {1}", this.game.p2.name, this.game.p2.score.ToString());
            while (p2Score.Width > 220) {
                p2Score.Font = new Font(Form1.font.Families[0], p2Score.Font.Size - 1, FontStyle.Regular);
            }
            g.FillRectangle(new SolidBrush(game.activePlayer.color), new Rectangle(new Point(activePlayerReminder.Location.X - (activePlayerReminder.Height + 10), activePlayerReminder.Location.Y), new Size(50,50)));
            activePlayerReminder.Text = String.Format("{0}", this.game.activePlayer.name);
            if (game.activePlayer.numColonies <= 5)
            {
                colonyNumbers[0].ForeColor = Color.Red;
            }
            else
            {
                colonyNumbers[0].ForeColor = Color.Black;
            }
            if (game.activePlayer.numTradePosts <= 2)
            {
                colonyNumbers[1].ForeColor = Color.Red;
            }
            else
            {
                colonyNumbers[1].ForeColor = Color.Black;
            }
            colonyNumbers[0].Text = game.activePlayer.numColonies.ToString();
            colonyNumbers[1].Text = game.activePlayer.numTradePosts.ToString();
            if (this.menu != null)
            {
                this.menu.draw(g);
            }
            if (this.endGamePopup != null)
            {
                this.endGamePopup.draw(g);
            }
        }


        public void saveGame()
        {
                SaveFileDialog dialog = new SaveFileDialog();
                dialog.Title = "Save your game";
                dialog.Filter = "Small Star Empire|*.sse";
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    this.FileName = dialog.FileName;
                }
                else
                {
                return;
                }
                try
                {
                    using (FileStream stream = new FileStream(this.FileName, FileMode.Create))
                    {
                        IFormatter formatter = new BinaryFormatter();
                        formatter.Serialize(stream, this.game);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error while saving your game");
                    MessageBox.Show(ex.Message);

                }
        }



    }
}

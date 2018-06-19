using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SSE {
    public class GameState : State {
        public Game game;
        public Label p1Score,p2score,activePlayerReminder;
        public Button colonyButton, tradeButton;

        public GameState(Game game) {
            this.game = game;
            this.p1Score = new Label();
            this.p2score = new Label();
            this.activePlayerReminder = new Label();
            this.colonyButton = new Button();
            this.tradeButton = new Button();
            this.p1Score.Text = this.game.p1.score.ToString();
            this.p1Score.Location = new Point(900, 100);
        }
        public void draw(Graphics g) {
            this.game.draw(g);
            this.p1Score.Text = this.game.p1.score.ToString();
            this.p1Score.Refresh();
            //g.DrawString(this.p1Score.Text, new Font("Arial", 16), new SolidBrush(Color.Black), this.p1Score.Location);
        }
    }
}

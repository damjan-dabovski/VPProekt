using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace SSE {
    public class IngameMenu :PopupMenu {
        public Button resume, saveGame, quitToMain;
        public MessagePopup quitConfirm;


        public IngameMenu(int width, int height) : base(width, height) {
            this.background = Properties.Resources.popup;
            resume = new Button();
            saveGame = new Button();
            quitToMain = new Button();
            this.buttons = new Button[3] { resume, saveGame, quitToMain };
            for (int i = 0; i < buttons.Length; i++) {
                buttons[i].Location = new Point(480, (180 + (125 * i)));
                buttons[i].Size = new Size(308, 108);
                buttons[i].BackgroundImage = Properties.Resources.mainmenubutton;
                buttons[i].BackgroundImageLayout = ImageLayout.None;
                buttons[i].BackColor = Color.Transparent;
                buttons[i].FlatAppearance.BorderSize = 0;
                buttons[i].FlatAppearance.MouseDownBackColor = Color.Transparent;
                buttons[i].FlatAppearance.MouseOverBackColor = Color.Transparent;
                buttons[i].FlatStyle = FlatStyle.Flat;
                buttons[i].Font = new Font(Form1.font.Families[0], 20, FontStyle.Regular);
            }
            this.resume.Text = "Resume";
            this.saveGame.Text = "Save Game";
            this.quitToMain.Text = "Quit to Main Menu";
            this.quitConfirm = null;
        }

        public override void draw(Graphics g) {
            g.DrawImage(this.background, new Rectangle(this.location, new Size(this.width, this.height)));
            if (this.quitConfirm != null) {
                this.quitConfirm.draw(g);
            }
        }
    }
}

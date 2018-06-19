using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace SSE {
    public class MessagePopup : PopupMenu{
        public Label text;
        public Button buttonYes, buttonNo;

        public MessagePopup(int width, int height) : base(width, height) {
            this.background = Properties.Resources.popup;
            this.text = new Label();
            this.buttonNo = new Button();
            this.buttonYes = new Button();
            this.buttons = new Button[2] { buttonYes, buttonNo };
            for (int i = 0; i < buttons.Length; i++) {
                buttons[i].Location = new Point(480, (305 + (125 * i)));
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
            this.buttonYes.Text = "Yes";
            this.buttonNo.Text = "No";
            this.text.Text = "Are you sure ?";
            //this.text.AutoSize = true;
            this.text.Size = new Size(this.width-20, 50);
            this.text.Location = new Point(490, 230);
            this.text.Font = new Font(Form1.font.Families[0], 18, FontStyle.Regular);
            this.text.ForeColor = Color.White;
            this.text.BackColor = Color.Transparent;

        }

        public override void draw(Graphics g) {
            g.DrawImage(this.background, new Rectangle(this.location, new Size(this.width, this.height)));
        }
    }
}

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SSE {
    public class MenuState : State {
        public Button[] buttons;
        public int width, height;
        public Image background;
        public MessagePopup quitConfirm;

        public MenuState(int width, int height) {
            this.width = width;
            this.height = height;
            this.quitConfirm = null;
        }

        public void draw(Graphics g) {
            g.DrawImage(this.background, new Rectangle(new Point(0,0),new Size(this.width,this.height)));
            if (this.quitConfirm != null) {
                this.quitConfirm.draw(g);
            }
        }
    }
}

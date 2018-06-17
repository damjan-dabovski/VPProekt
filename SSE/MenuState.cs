using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SSE {
    public class MenuState {
        public Button[] buttons;
        public int width, height;
        public Image background;

        public MenuState(int width, int height) {
            this.width = width;
            this.height = height;
        }

        public void draw(Graphics g) {
            g.DrawImage(this.background, new Point(0, 0));
        }
    }
}

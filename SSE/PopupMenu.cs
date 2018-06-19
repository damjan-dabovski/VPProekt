using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SSE {
    public abstract class PopupMenu {
        public Point location;
        public Button[] buttons;
        public Image background;
        public int width, height;

        public PopupMenu(int width, int height) {
            this.width = width;
            this.height = height;
        }

        public abstract void draw(Graphics g);
    }
}

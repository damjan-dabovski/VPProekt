using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSE {
    [Serializable()]
    public class Colony {
        public Player owner;
        public bool isColony;
        public Point position;

        public Colony(Player owner) {
            this.owner = owner;
            this.isColony = true;
            this.position = new Point(0, 0);
        }

        public void draw(Graphics g, Point position) {
            this.position = position;
            if (this.isColony) {
                g.FillEllipse(new SolidBrush(Color.White), new Rectangle(new Point(this.position.X-3,this.position.Y-3), new Size(36, 36)));
                g.FillEllipse(new SolidBrush(this.owner.color), new Rectangle(this.position, new Size(30, 30)));
            } else {
                g.FillRectangle(new SolidBrush(Color.White), new Rectangle(new Point(this.position.X - 3, this.position.Y - 3), new Size(36, 36)));
                g.FillRectangle(new SolidBrush(this.owner.color), new Rectangle(this.position, new Size(30, 30)));
            }
        }
    }
}

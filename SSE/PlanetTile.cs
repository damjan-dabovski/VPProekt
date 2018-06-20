using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSE {
    [Serializable()]
    public class PlanetTile : Tile {
        public int numPoints { get; set; }

        public PlanetTile(int numPoints) : base() {
            this.numPoints = numPoints;
            this.type = "planet";
            switch (numPoints) {
                case 0:
                    this.image = Properties.Resources.tile;
                    break;
                case 1:
                    this.image = Properties.Resources.tile_p1;
                    break;
                case 2:
                    this.image = Properties.Resources.tile_p2;
                    break;
                case 3:
                    this.image = Properties.Resources.tile_p3;
                    break;
            }
        }

        public override int getPoints() {
            int temp = 0;
            if (this.colony.isColony == false) {
                foreach (Tile t in this.neighbors.Values) {
                    if (t!=null && t.colony != null && t.colony.owner != this.colony.owner) {
                        temp++;
                    }
                }
            }
            temp += numPoints;
            return temp;
        }

        public override void draw(Graphics g) {
            g.DrawImage(this.image, new Rectangle(this.location, this.image.Size));
            if (isHighlighted) {
                g.DrawImage(Properties.Resources.tile_highlight, new Rectangle(this.location, this.image.Size));
            }
            if (this.ship != null) {
                this.ship.draw(g, new Point(this.location.X + 5, this.location.Y + 20));
            }
            if (this.colony != null) {
                this.colony.draw(g, new Point(this.location.X + this.image.Width - 35, this.location.Y + 40));
            }
        }

    }
}

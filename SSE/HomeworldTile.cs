using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSE {
    public class HomeworldTile : Tile {
        public List<Ship> ships;
        public Player player;

        public HomeworldTile() :base() {
            this.image=Properties.Resources.homeworld_r;
            this.ships = new List<Ship>(); 
        }

        public override int getPoints() {
            return 0;
        }

        public override void draw(Graphics g) {
            if (player.color == Color.Red) {
                this.image = Properties.Resources.homeworld_r;
            } else {
                this.image = Properties.Resources.homeworld_b;
            }
            g.DrawImage(this.image, new Rectangle(this.location, this.image.Size));
            if (isHighlighted) {
                g.DrawImage(Properties.Resources.tile_highlight, new Rectangle(this.location, this.image.Size));
            }            
            for (int i = 0; i < ships.Count; i++) {
                ships.ElementAt(i).draw(g, new Point(this.location.X + (16 * i), this.location.Y + 20));
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSE {
    public class Ship {
        public Player owner;
        public Tile current;
        public List<Tile> legalMoves;
        public Image image;
        public bool isHighlighted;
        public Point location;

        public Ship(Player p, Tile t) {
            this.owner = p;
            this.current = t;
            this.legalMoves = new List<Tile>();
            this.isHighlighted = false;
            this.location = new Point(0, 0);
            if (this.owner.color == Color.Red) {
                this.image = Properties.Resources.ship_red;
            } else {
                this.image = Properties.Resources.ship_blue;
            }
        }

        public List<Tile> getLegalMoves() {
            List<Tile> list=new List<Tile>();
            foreach (Tile.Direction dir in Enum.GetValues(typeof(Tile.Direction))) {
                list.AddRange(current.getLine(dir));
            }
            foreach (Tile t in list) {
                if (t.colony != null && t.colony.owner == this.owner) {
                    list.Remove(t);
                }
            }
            this.legalMoves = list;
            return legalMoves;
        }

        public void colonize() {
            if (this.owner.activeColonyType == "colony") {
                current.colony = new Colony(this.owner);
                this.owner.numColonies--;
            }
            if (this.owner.activeColonyType == "tradepost") {
                current.colony = new TradingPostColony(this.owner);
                this.owner.numColonies--;
            }

            foreach (Tile t in current.neighbors.Values) {
                if (t != null)
                {
                    if (t.colony != null && t.colony.type == "tradepost" && t.colony.owner != current.colony.owner)
                    {
                        t.colony.owner.score++;
                    }
                }
            }
        }

        public void move(Tile t) {
            Tile temp = current;
            if (t != current && legalMoves.Contains(t)) {
                t.ship = this;
                current = t;
                temp.ship = null;
                colonize();
                if (current.type == "planet") {
                    PlanetTile tile = (PlanetTile)current;
                    this.owner.score += tile.getPoints();
                }

                if (current.type == "nebula") {
                    NebulaTile tile = (NebulaTile)current;
                    this.owner.score += tile.getPoints();
                }
            }
        }

        public void draw(Graphics g, Point location) {
            this.location = location;
            g.DrawImage(this.image, new Rectangle(location, this.image.Size));
            if (isHighlighted) {
                g.DrawImage(Properties.Resources.ship_highlight, new Rectangle(location, this.image.Size));
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSE {
    [Serializable()]
    public abstract class Tile {

        public enum Direction
        {
            Right,
            Left,
            UpRight,
            UpLeft,
            DownRight,
            DownLeft
        }

        public Dictionary<Direction, Tile> neighbors;
        public Ship ship { get; set; }
        public Colony colony { get; set; }
        public Image image { get; set; }
        public String type { get; set; }
        public Point location;
        public bool isHighlighted;

        public Tile() {
            ship = null;
            colony = null;
            neighbors = new Dictionary<Direction, Tile>();
            location = new Point(0, 0);
            foreach (Direction dir in Enum.GetValues(typeof(Direction))) {
                neighbors.Add(dir, null);
            }
            isHighlighted = false;
        }

        public abstract int getPoints();

        public void addNeighbour(Direction direction, Tile t){
            //switch case za dodavanje na obostrani sosedstva
            switch (direction) {
                case Direction.Right:
                    t.neighbors[Direction.Left]= this;
                    break;
                case Direction.Left:
                    t.neighbors[Direction.Right]= this;
                    break;
                case Direction.UpRight:
                    t.neighbors[Direction.DownLeft] = this;
                    break;
                case Direction.UpLeft:
                    t.neighbors[Direction.DownRight] = this;
                    break;
                case Direction.DownRight:
                    t.neighbors[Direction.UpLeft] = this;
                    break;
                case Direction.DownLeft:
                    t.neighbors[Direction.UpRight] = this;
                    break;
            };
            neighbors[direction]=t;
        }

        public List<Tile> getLine(Direction dir) {
            List<Tile> list = new List<Tile>();
            Tile temp = this;
            if (!(this is HomeworldTile)) {
                while (temp.neighbors[dir] != null) {
                    if (temp.neighbors[dir].colony != null && temp.neighbors[dir].colony.owner != this.ship.owner)
                    {
                        break;
                    }
                    else if (temp.neighbors[dir] is HomeworldTile) {
                        HomeworldTile tmp = (HomeworldTile)temp.neighbors[dir];
                        if (tmp.player != this.colony.owner) {
                            break;
                        }
                    }
                    temp = temp.neighbors[dir];
                    list.Add(temp);
                }
            } else {
                HomeworldTile asHomeworld = (HomeworldTile)this;
                while (temp.neighbors[dir] != null) {
                    if (temp.neighbors[dir].colony != null && temp.neighbors[dir].colony.owner != asHomeworld.player) {
                        break;
                    }
                    temp = temp.neighbors[dir];
                    list.Add(temp);
                }
            }
            return list;
        }

        public abstract void draw(Graphics g);
    }
}

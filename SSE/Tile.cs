using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSE {
    public class Tile {

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


        public Tile(Image image) {
            ship = null;
            colony = null;
            neighbors = new Dictionary<Direction, Tile>();
            foreach (Direction dir in Enum.GetValues(typeof(Direction))) {
                neighbors.Add(dir, null);
            }
            this.image = image;
        }
        public void addNeighbour(Direction direction, Tile t){
            //switch case za dodavanje na obostrani sosedstva
            switch (direction) {
                case Direction.Right:
                    t.addNeighbour(Direction.Left, this);
                    break;
                case Direction.Left:
                    t.addNeighbour(Direction.Right, this);
                    break;
                case Direction.UpRight:
                    t.addNeighbour(Direction.DownLeft, this);
                    break;
                case Direction.UpLeft:
                    t.addNeighbour(Direction.DownRight, this);
                    break;
                case Direction.DownRight:
                    t.addNeighbour(Direction.UpLeft, this);
                    break;
                case Direction.DownLeft:
                    t.addNeighbour(Direction.UpRight, this);
                    break;
            };
            neighbors[direction]=t;
        }
    }
}

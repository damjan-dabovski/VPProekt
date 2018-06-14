using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSE {
    public class Tile {
        public Dictionary<String, Tile> neighbors;
        public Ship ship { get; set; }
        public Colony colony { get; set; }
        public Image image { get; set; }
        public String type { get; set; }


        public Tile(Image image) {
            ship = null;
            colony = null;
            neighbors = new Dictionary<string, Tile>();
            this.image = image;
        }

    }
}

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSE {
    public class PlanetTile : Tile {
        public int numPoints { get; set; }

        public PlanetTile(Image image,int numPoints) : base(image) {
            this.numPoints = numPoints;
            this.type = "planet";
        }
    }
}

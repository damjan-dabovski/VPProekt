using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSE {
    public class NebulaTile : Tile {
        public Color nebulaColor;

        public NebulaTile(Image image, Color nebulaColor) : base(image) {
            this.nebulaColor = nebulaColor;
            this.type = "nebula";
        }
    }
}
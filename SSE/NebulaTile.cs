using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSE {
    public class NebulaTile : Tile {
        public String nebulaColor;

        public NebulaTile(Image image, String nebulaColor) : base(image) {
            this.nebulaColor = nebulaColor;
            this.type = "nebula";
        }
    }
}
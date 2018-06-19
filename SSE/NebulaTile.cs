using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSE {
    public class NebulaTile : Tile {
        public Color nebulaColor;

        public NebulaTile(Color nebulaColor) : base() {
            this.nebulaColor = nebulaColor;
            this.type = "nebula";
            if (this.nebulaColor == Color.Red) {
                this.image = Properties.Resources.tile_nR;
            } else if (this.nebulaColor == Color.Blue) {
                this.image = Properties.Resources.tile_nB;
            } else {
                this.image = Properties.Resources.tile_nG;
            }
        }

        public override int getPoints() {
            int temp=0;
            if (this.colony.type == "tradepost") {
                foreach (Tile t in this.neighbors.Values) {
                    if (t != null && t.colony != null && t.colony.owner != this.colony.owner) {
                        temp++;
                    }
                }
            } else if (this.nebulaColor == Color.Red) {
                return this.colony.owner.ownedNebulaTypes[0] > 1 ? 3 : 2;
            } else if (this.nebulaColor == Color.Green) {
                return this.colony.owner.ownedNebulaTypes[1] > 1 ? 3 : 2;
            } else {
                return this.colony.owner.ownedNebulaTypes[3] > 1 ? 3 : 2;
            }
            return temp;
        }
    }
}
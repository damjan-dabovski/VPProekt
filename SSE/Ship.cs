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
        //Should probably be a Dictionary, for directions
        public List<Tile> legalMoves;

        public Ship(Player p, Tile t) {
            this.owner = p;
            this.current = t;
            this.legalMoves = new List<Tile>();
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
            if (legalMoves.Contains(t)) {
                t.ship = this;
                current = t;
                temp.ship = null;
            }
            colonize();
            //VOODOO AHEAD
            if (current.type == "planet") {
                PlanetTile tile = (PlanetTile)current;
                this.owner.score += tile.numPoints;
            }

            if (current.type == "nebula") {
                NebulaTile tile = (NebulaTile)current;
                if (tile.nebulaColor == Color.Red)
                {
                    this.owner.ownedNebulaTypes[0]++;
                    this.owner.score += this.owner.ownedNebulaTypes[0] > 1 ? 2 : 3;
                }
                else if (tile.nebulaColor == Color.Green)
                {
                    this.owner.ownedNebulaTypes[1]++;
                    this.owner.score += this.owner.ownedNebulaTypes[1] > 1 ? 2 : 3;
                }
                else {
                    this.owner.ownedNebulaTypes[2]++;
                    this.owner.score += this.owner.ownedNebulaTypes[2] > 1 ? 2 : 3;
                }
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSE {
    public class Ship {
        public Player owner;
        public Tile current;
        public List<Tile> legalMoves;

        public Ship(Player p, Tile t) {
            this.owner = p;
            this.current = t;
            this.legalMoves = new List<Tile>();
        }

        

        public void move(Tile t) {
            //TODO PROVERKI
            this.current = t;
        }
    }
}

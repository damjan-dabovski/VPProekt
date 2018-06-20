using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSE {
    [Serializable()]
    public class Player {
        public String name { get; set; }
        public Color color;
        public List<Ship> ships;
        public int score;
        public int numColonies;
        public int numTradePosts;
        public Ship activeShip;
        public String activeColonyType;
        public int[] ownedNebulaTypes;

        public Player(String name, Color color) {
            this.name = name;
            this.color = color;
            this.score = 0;
            this.numColonies = 16;
            this.numTradePosts = 4;
            this.activeColonyType = "colony";
            this.activeShip = null;
            ownedNebulaTypes = new int[3] { 0, 0, 0 };
            this.ships = new List<Ship>();
        }
    }
}

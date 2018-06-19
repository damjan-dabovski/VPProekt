using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSE {
    public class Game {
        public Queue<Player> players;
        public Player activePlayer, p1,p2;
        public Map board;

        public Game(String name1 = "Player 1", String name2 = "Player 2") {
            p1 = new Player(name1, Color.Red);
            p2 = new Player(name2, Color.Blue);
            players = new Queue<Player>();
            board = new Map();
            players.Enqueue(p2);
            players.Enqueue(p1);
            activePlayer = p1;

            HomeworldTile homeRed = (HomeworldTile)this.board.tiles[5][1];
            HomeworldTile homeBlue = (HomeworldTile)this.board.tiles[3][7];
            homeRed.player = p1;
            homeBlue.player = p2;

            Ship[] redShips = new Ship[4];
            Ship[] blueShips = new Ship[4];

            for (int i = 0; i < redShips.Length; i++) {
                redShips[i] = new Ship(p1, homeRed);
                blueShips[i] = new Ship(p2, homeBlue);
            }

            foreach (Ship s in redShips) {
                homeRed.ships.Add(s);
                p1.ships.Add(s);
            }

            foreach (Ship s in blueShips) {
                homeBlue.ships.Add(s);
                p2.ships.Add(s);
            }
        }

        public Game(Game g) {
            this.players = g.players;
            this.board = g.board;
            this.activePlayer = g.activePlayer;
        }

        public void draw(Graphics g) {
            this.board.draw(g);
        }

        public void endTurn() {
            List<Tile> allLegalMoves = new List<Tile>();
            activePlayer = players.Dequeue(); 
            if (canMakeMove(activePlayer)) {
                players.Enqueue(activePlayer);
            } else {
                activePlayer = players.Dequeue();
                players.Enqueue(activePlayer);
            }         
        }

        public bool canMakeMove(Player p) {
            List<Tile> allLegalMoves = new List<Tile>();
            foreach (Ship s in p.ships) {
                allLegalMoves.AddRange(s.getLegalMoves());
            }
            int totalColonies = p.numColonies + p.numTradePosts;
            if (allLegalMoves.Count < 1 || totalColonies<1) {
                return false;
            }
            return true;
        }
    }
}

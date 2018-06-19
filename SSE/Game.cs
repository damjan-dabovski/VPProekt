using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSE {
    public class Game {
        public Queue<Player> players;
        public Player activePlayer;
        public Map board;

        public Game(String name1 = "Player 1", String name2 = "Player 2") {
            Player p1 = new Player(name1, Color.Red);
            Player p2 = new Player(name2, Color.Blue);
            players = new Queue<Player>();
            board = new Map();
            players.Enqueue(p1);
            players.Enqueue(p2);
            activePlayer = null;
            endTurn();
            //TEST SHIP
            this.board.tiles[5][1].ship = new Ship(p1, board.tiles[5][1]);
            activePlayer.ships.Add(this.board.tiles[5][1].ship);
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
            activePlayer = players.Dequeue();
            players.Enqueue(activePlayer);
        }
    }
}

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
            players.Enqueue(p1);
            players.Enqueue(p2);
            activePlayer = null;
            endTurn();
            //TEST SHIP
            Ship testShip= new Ship(p1, board.tiles[5][1]);
            Ship testShip2 = new Ship(p2, board.tiles[3][7]);
            this.board.tiles[5][1].ship = testShip;
            this.board.tiles[3][7].ship = testShip2;
            p2.ships.Add(testShip2);
            activePlayer.ships.Add(testShip);
            this.board.tiles[5][1].colony = new Colony(p1);
            this.board.tiles[5][4].colony = new TradingPostColony(p2);
            this.board.tiles[3][7].colony = new Colony(p2);
            /*p1.activeColonyType = "tradepost";
            testShip.move(this.board.tiles[5][2]);*/
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

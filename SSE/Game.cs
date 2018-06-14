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
        public Board board;

        public Game(String name1 = "Player 1", String name2 = "Player 2") {
            Player p1 = new Player(name1, Color.Red);
            Player p2 = new Player(name2, Color.Blue);
            players = new Queue<Player>();
            board = new Board();
            players.Enqueue(p1);
            players.Enqueue(p2);
            activePlayer = null;
            endTurn();
        }

        public void endTurn() {
            activePlayer = players.Dequeue();
            players.Enqueue(activePlayer);
        }
    }
}

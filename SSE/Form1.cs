using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SSE {
    public partial class Form1 : Form {
        State state;
        PrivateFontCollection font;

        public Form1() {
            InitializeComponent();
        }

        private void Form1_Paint(object sender, PaintEventArgs e) {
            state.draw(e.Graphics);
        }

        private void initializeFont() {
            font = new PrivateFontCollection();
            int fontLength = Properties.Resources.neuropolitical_rg.Length;
            byte[] fontData = Properties.Resources.neuropolitical_rg;
            System.IntPtr data = Marshal.AllocCoTaskMem(fontLength);
            Marshal.Copy(fontData, 0, data, fontLength);
            font.AddMemoryFont(data, fontLength);
        }

        private void Form1_Load(object sender, EventArgs e) {
            this.DoubleBuffered = true;
            initializeFont();
            setContextMainMenu();        
        }

        private void setContextMainMenu() {
            Controls.Clear();
            state = new MainMenuStartScreen(ClientSize.Width, ClientSize.Height);
            MainMenuStartScreen temp = (MainMenuStartScreen)state;
            temp.newGame.Click += setContextNewGame;
            temp.tutorial.Click += setContextTutorial;
            temp.quitGame.Click += quitGame_Click;
            foreach (Button b in temp.buttons) {
                b.Font = new Font(font.Families[0], 20, FontStyle.Regular);
                Controls.Add(b);
            }
            Invalidate(true);
        }

        private void setContextTutorial(Object sender, EventArgs e) {
            Controls.Clear();
            state = new TutorialScreen(ClientSize.Width, ClientSize.Height);
            TutorialScreen temp = (TutorialScreen)state;
            temp.buttons[0].Font = new Font(font.Families[0], 20, FontStyle.Regular);
            temp.buttons[0].Click += backButton_Click;
            Controls.Add(temp.buttons[0]);
            Invalidate(true);
        }

        private void setContextNewGame(Object sender, EventArgs e) {
            Controls.Clear();
            state = new MainMenuNewGameScreen(ClientSize.Width, ClientSize.Height);
            MainMenuNewGameScreen temp = (MainMenuNewGameScreen)state;
            temp.back.Click += backButton_Click;
            temp.startGame.Click += startGame;
            foreach (Button b in temp.buttons) {
                b.Font = new Font(font.Families[0], 20, FontStyle.Regular);
                Controls.Add(b);
            }
            //TODO NEW GAME FUNCTION
            Invalidate(true);
        }

        private void startGame(Object sender, EventArgs e) {
            Controls.Clear();
            state = new GameState(new Game());
            GameState temp = (GameState)state;
            Controls.Add(temp.p1Score);
            Invalidate(true);
        }

        private void backButton_Click(Object sender, EventArgs e) {
            setContextMainMenu();
        }

        private void quitGame_Click(Object sender, EventArgs e) {
            this.Close();
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e) {
            if (state is GameState) {
                if (e.KeyCode == Keys.Escape) {
                    setContextMainMenu();
                }
            }
        }

        private Tile getClickedTile(int x, int y) {
            GameState temp = (GameState)state;
            foreach (Tile[] row in temp.game.board.tiles) {
                foreach (Tile tile in row) {
                    if (tile != null) {
                        if (x > tile.location.X && x < tile.location.X + tile.image.Width && y > tile.location.Y && y < tile.location.Y + tile.image.Height) {
                            return tile;
                        }
                    }
                }
            }
            return null;
        }

        private Ship getClickedShip(int x, int y) {
            GameState temp = (GameState)state;
            foreach (Ship s in temp.game.activePlayer.ships) {
                if (x > s.location.X && x < s.location.X + s.image.Width && y > s.location.Y && y < s.location.Y + s.image.Height) {
                    return s;
                }
            }
            return null;
        }

        private Ship activeShipSwitch(Ship activeShip, Ship newShip) {
            if (activeShip!=null && newShip != activeShip) {
                activeShip.isHighlighted = false;
                foreach (Tile t in activeShip.getLegalMoves()) {
                    t.isHighlighted = false;
                }
            }
            activeShip = newShip;
            activeShip.isHighlighted = true;
            foreach (Tile t in activeShip.getLegalMoves()) {
                t.isHighlighted = true;
            }
            return activeShip;
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e) {
            if (state is GameState) {
                GameState temp = (GameState)state;
                Tile clickedTile = getClickedTile(e.X,e.Y);
                Ship clickedShip = getClickedShip(e.X, e.Y);
                if (temp.game.activePlayer.activeShip == null) {
                    if (clickedShip != null) {
                        /*temp.game.activePlayer.activeShip = clickedShip;
                        temp.game.activePlayer.activeShip.isHighlighted = true;
                        foreach (Tile t in temp.game.activePlayer.activeShip.getLegalMoves()) {
                            t.isHighlighted = true;
                        }*/
                        temp.game.activePlayer.activeShip = activeShipSwitch(null, clickedShip);
                    }
                } else {
                    if (clickedShip != null) {
                        temp.game.activePlayer.activeShip = activeShipSwitch(temp.game.activePlayer.activeShip, clickedShip);
                    } else if (clickedTile != null) {
                        if (temp.game.activePlayer.activeShip.getLegalMoves().Contains(clickedTile)) {
                            temp.game.activePlayer.activeShip.move(clickedTile);
                            endTurnCleanup();
                            temp.game.activePlayer.activeShip = null;
                            temp.game.endTurn();
                        } else {
                            endTurnCleanup();
                            temp.game.activePlayer.activeShip = null;
                        }
                    }
                }
                Invalidate(true);
            }
        }

        private void endTurnCleanup() {
            GameState temp = (GameState)state;
            temp.game.activePlayer.activeShip.isHighlighted = false;
            foreach (Tile[] t in temp.game.board.tiles) {
                foreach (Tile tile in t) {
                    if (tile != null) {
                        tile.isHighlighted = false;
                    }
                }
            }
            Invalidate(true);
        }
    }
}

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
        public static PrivateFontCollection font;

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
            Controls.Add(temp.player1);
            Controls.Add(temp.player2);
            Controls.Add(temp.player1name);
            Controls.Add(temp.player2name);
            //TODO NEW GAME FUNCTION
            Invalidate(true);
        }

        private void startGame(Object sender, EventArgs e) {
            MainMenuNewGameScreen tempScreen = (MainMenuNewGameScreen)state;
            String p1name = "Player 1";
            String p2name = "Player 2";
            if (tempScreen.player1name.Text.Length > 0) {
                p1name = tempScreen.player1name.Text;
            }
            if (tempScreen.player2name.Text.Length > 0) {
                p2name = tempScreen.player2name.Text;
            }
            Controls.Clear();
            state = new GameState(new Game(p1name,p2name),ClientSize.Width,ClientSize.Height);
            GameState temp = (GameState)state;
            Controls.Add(temp.p1Score);
            Controls.Add(temp.p2Score);
            Controls.Add(temp.activePlayerReminder);
            foreach (Label l in temp.colonyNumbers) {
                Controls.Add(l);
            }
            foreach (Button b in temp.buttons) {
                Controls.Add(b);
            }
            temp.colonyButton.Click += colonyButtonClick;
            temp.tradeButton.Click += tradeButtonClick;
            temp.menuButton.Click += menuButtonClick;
            Invalidate(true);
        }

        private void menuButtonClick(Object sender, EventArgs e) {
            GameState temp = (GameState)state;
            if (temp.menu == null) {
                temp.menu = new IngameMenu(350, 400);
                temp.menu.location = new Point(450, 150);
                foreach (Button b in temp.menu.buttons) {
                    Controls.Add(b);
                }
                temp.menu.resume.Click += resumeGame;
                temp.menu.quitToMain.Click += quitToMainConfirm;
            }
            Invalidate(true);
        }

        private void colonyButtonClick(Object sender, EventArgs e) {
            GameState temp = (GameState)state;
            temp.colonyButton.BackgroundImage = Properties.Resources.colonybutton_on;
            temp.tradeButton.BackgroundImage = Properties.Resources.colonybutton_trade_off;
            temp.game.activePlayer.activeColonyType = "colony";
            Invalidate(true);
        }

        private void tradeButtonClick(Object sender, EventArgs e) {
            GameState temp = (GameState)state;
            temp.colonyButton.BackgroundImage = Properties.Resources.colonybutton_off;
            temp.tradeButton.BackgroundImage = Properties.Resources.colonybutton_trade_on;
            temp.game.activePlayer.activeColonyType = "tradepost";
            Invalidate(true);
        }

        private void backButton_Click(Object sender, EventArgs e) {
            setContextMainMenu();
        }

        private void quitGame_Click(Object sender, EventArgs e) {
            MainMenuStartScreen temp = (MainMenuStartScreen)state;
            temp.quitConfirm = new MessagePopup(350, 400);
            temp.quitConfirm.location = new Point(450, 150);
            Controls.Add(temp.quitConfirm.text);
            foreach (Button b in temp.quitConfirm.buttons) {
                Controls.Add(b);
            }
            foreach(Button b in temp.buttons) {
                b.Hide();
            }
            Invalidate(true);
            temp.quitConfirm.buttonYes.Click += quit;
            temp.quitConfirm.buttonNo.Click += goBack;
        }

        private void quit(Object sender, EventArgs e) {
            this.Close();
        }

        private void goBack(Object sender, EventArgs e) {
            setContextMainMenu();
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e) {
            if (state is GameState) {
                GameState temp = (GameState)state;
                if (e.KeyCode == Keys.Escape) {
                    if (temp.menu == null) {
                        temp.menu = new IngameMenu(350, 400);
                        temp.menu.location = new Point(450, 150);
                        foreach (Button b in temp.menu.buttons) {
                            Controls.Add(b);
                        }
                        temp.menu.resume.Click += resumeGame;
                        temp.menu.quitToMain.Click += quitToMainConfirm;
                    } else {
                        foreach (Button b in temp.menu.buttons) {
                            Controls.Remove(b);
                        }
                        temp.menu = null;
                    }
                }
                Invalidate(true);
            }
        }

        private void quitToMainConfirm(Object sender, EventArgs e) {
            GameState temp = (GameState)state;
            temp.menu.quitConfirm = new MessagePopup(350, 400);
            temp.menu.quitConfirm.location = new Point(450, 150);
            temp.menu.quitConfirm.text.Text = "Are you sure? All unsaved progress will be lost.";
            temp.menu.quitConfirm.text.Location = new Point(490, 200);
            temp.menu.quitConfirm.text.Size= new Size(temp.menu.quitConfirm.width - 20, 100);
            Controls.Add(temp.menu.quitConfirm.text);
            foreach (Button b in temp.menu.quitConfirm.buttons) {
                Controls.Add(b);
            }
            foreach (Button b in temp.menu.buttons) {
                b.Hide();
            }
            Invalidate(true);
            temp.menu.quitConfirm.buttonYes.Click += backButton_Click;
            temp.menu.quitConfirm.buttonNo.Click += backToPauseMenu;
        }

        private void backToPauseMenu(Object sender, EventArgs e) {
            GameState temp = (GameState)state;
            foreach (Button b in temp.menu.quitConfirm.buttons) {
                Controls.Remove(b);
            }
            Controls.Remove(temp.menu.quitConfirm.text);
            temp.menu.quitConfirm = null;
            foreach (Button b in temp.menu.buttons) {
                b.Show();
            }
            Invalidate(true);
        }

        private void resumeGame(Object sender, EventArgs e) {
            GameState temp = (GameState)state;
            foreach (Button b in temp.menu.buttons) {
                 Controls.Remove(b);
            }
            temp.menu = null;
            Invalidate(true);
        }

        private Tile getClickedTile(int x, int y) {
            GameState temp = (GameState)state;
            if (temp.menu == null) {
                foreach (Tile[] row in temp.game.board.tiles) {
                    foreach (Tile tile in row) {
                        if (tile != null) {
                            if (x > tile.location.X && x < tile.location.X + tile.image.Width && y > tile.location.Y && y < tile.location.Y + tile.image.Height) {
                                return tile;
                            }
                        }
                    }
                }
            }
            return null;
        }

        private Ship getClickedShip(int x, int y) {
            GameState temp = (GameState)state;
            if (temp.menu == null) {
                foreach (Ship s in temp.game.activePlayer.ships) {
                    if (x > s.location.X && x < s.location.X + s.image.Width && y > s.location.Y && y < s.location.Y + s.image.Height) {
                        return s;
                    }
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
                            if (temp.game.activePlayer.activeColonyType == "colony") {
                                temp.colonyButton.BackgroundImage = Properties.Resources.colonybutton_on;
                                temp.tradeButton.BackgroundImage = Properties.Resources.colonybutton_trade_off;
                            } else {
                                temp.colonyButton.BackgroundImage = Properties.Resources.colonybutton_off;
                                temp.tradeButton.BackgroundImage = Properties.Resources.colonybutton_trade_on;
                            }
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
            if (temp.game.canMakeMove(temp.game.p1) == false && temp.game.canMakeMove(temp.game.p2) == false) {
                Player winner = null;
                temp.endGamePopup = new MessagePopup(350, 400);
                temp.endGamePopup.location= new Point(450, 150);
                temp.endGamePopup.text.Location = new Point(470, 200);
                temp.endGamePopup.text.Size = new Size(temp.endGamePopup.width - 20, 100);
                Controls.Add(temp.endGamePopup.text);
                foreach (Button b in temp.endGamePopup.buttons) {
                    Controls.Add(b);
                }
                if (temp.game.p1.score > temp.game.p2.score) {
                    winner = temp.game.p1;
                } else if (temp.game.p2.score > temp.game.p1.score) {
                    winner = temp.game.p2;
                }
                if (winner != null) {
                    temp.endGamePopup.text.Text = String.Format("{0} wins! Would you like to play again?", winner.name);
                } else {
                    temp.endGamePopup.text.Text = "The game is a draw! Would you like to play again?";
                }
                temp.endGamePopup.buttonNo.Click += backButton_Click;
                temp.endGamePopup.buttonYes.Click += setContextNewGame;
            }
            Invalidate(true);
        }
    }

    //Alokin, 19.06. Funkcii za serijalizacija
}

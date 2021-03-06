﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SSE {
    [Serializable()]
    public class Ship {
        public Player owner;
        public Tile current;
        public List<Tile> legalMoves;
        public Image image;
        public bool isHighlighted;
        public Point location;

        public Ship(Player p, Tile t) {
            this.owner = p;
            this.current = t;
            this.legalMoves = new List<Tile>();
            this.isHighlighted = false;
            this.location = new Point(0, 0);
            if (this.owner.color == Color.Red) {
                this.image = Properties.Resources.ship_red;
            } else {
                this.image = Properties.Resources.ship_blue;
            }
        }

        public List<Tile> getLegalMoves() {
            List<Tile> list=new List<Tile>();
            List<Tile> removalList = new List<Tile>();
            foreach (Tile.Direction dir in Enum.GetValues(typeof(Tile.Direction))) {
                list.AddRange(current.getLine(dir));
            }
            foreach (Tile t in list) {
                if ((t.colony != null && t.colony.owner == this.owner) || (t is HomeworldTile)) {
                    removalList.Add(t);
                }
            }
            foreach (Tile t in removalList) {
                list.Remove(t);
            }
            this.legalMoves = list;
            return legalMoves;
        }

        public void colonize() {
            if (this.owner.numColonies < 1) {
                this.owner.activeColonyType = "tradepost";
            }
            if (this.owner.numTradePosts < 1) {
                this.owner.activeColonyType = "colony";
            }
            if (this.owner.activeColonyType == "colony" && this.owner.numColonies>0) {
                current.colony = new Colony(this.owner);
                this.owner.numColonies--;
            }
            if (this.owner.activeColonyType == "tradepost" && this.owner.numTradePosts>0) {
                current.colony = new TradingPostColony(this.owner);
                this.owner.numTradePosts--;
            }

            foreach (Tile t in current.neighbors.Values) {
                if (t != null)
                {
                    if (t.colony != null && t.colony.isColony == false && t.colony.owner != current.colony.owner)
                    {
                        t.colony.owner.score++;
                    }
                }
            }
        }

        public void move(Tile t) {
            this.legalMoves = getLegalMoves();
            if (t != current && legalMoves.Contains(t)) {
                Tile temp = current;
                if(current is HomeworldTile) {
                    HomeworldTile asHomeworld = (HomeworldTile)current;
                    asHomeworld.ships.Remove(this);
                }
                current = t;
                t.ship = this;
                temp.ship = null;
                colonize();
                if (current.type == "planet") {
                    PlanetTile tile = (PlanetTile)current;
                    this.owner.score += tile.getPoints();
                }

                if (current.type == "nebula") {
                    NebulaTile tile = (NebulaTile)current;
                    if (tile.nebulaColor == Color.Red) {
                        this.owner.ownedNebulaTypes[0]++;
                    } else if (tile.nebulaColor == Color.Green) {
                        this.owner.ownedNebulaTypes[1]++;
                    } else {
                        this.owner.ownedNebulaTypes[2]++;
                    }
                    this.owner.score += tile.getPoints();
                }
            }
        }

        public void draw(Graphics g, Point location) {
            this.location = location;
            g.DrawImage(this.image, new Rectangle(location, this.image.Size));
            if (isHighlighted) {
                g.DrawImage(Properties.Resources.ship_highlight, new Rectangle(location, this.image.Size));
            }
        }
    }
}

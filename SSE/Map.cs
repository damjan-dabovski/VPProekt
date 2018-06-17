using SSE.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSE
{
    public class Map
    {
        public List<Tile> tiles;
        Image nebula = Resources.Bubbleicon;
        Image planeta = Resources.sp_venus_c;

        public Map()
        {
            //prv red
            Tile tile1 = new PlanetTile(planeta, 1);
            Tile tile2 = new NebulaTile(nebula, Color.Red);
            tile2.addNeighbour(Tile.Direction.Left, tile1);

            //vtor red
            Tile tile3 = new NebulaTile(nebula, Color.Green);
            Tile tile4 = new PlanetTile(planeta, 0);
            Tile tile5 = new PlanetTile(planeta, 2);
            Tile tile6 = new PlanetTile(planeta, 1);
            Tile tile7 = new PlanetTile(planeta, 0);

            tile3.addNeighbour(Tile.Direction.UpRight, tile1);
            tile3.addNeighbour(Tile.Direction.Right, tile4);

            tile4.addNeighbour(Tile.Direction.UpLeft, tile1);
            tile4.addNeighbour(Tile.Direction.UpRight, tile2);
            tile4.addNeighbour(Tile.Direction.Right, tile5);

            tile5.addNeighbour(Tile.Direction.UpLeft, tile2);
            tile5.addNeighbour(Tile.Direction.Right, tile6);

            tile6.addNeighbour(Tile.Direction.Right, tile7);

            //tret red
            Tile tile8 = new PlanetTile(planeta, 2);
            Tile tile9 = new PlanetTile(planeta, 3);
            Tile tile10 = new PlanetTile(planeta, 3);
            Tile tile11 = new PlanetTile(planeta, 1);
            Tile tile12 = new NebulaTile(nebula, Color.Blue);
            Tile tile13 = new PlanetTile(planeta, 0);
            Tile tile14 = new PlanetTile(planeta, 1);
            Tile tile15 = new PlanetTile(planeta, 1);

            tile9.addNeighbour(Tile.Direction.Left, tile8);
            tile9.addNeighbour(Tile.Direction.UpRight, tile3);
            tile9.addNeighbour(Tile.Direction.Right, tile10);

            tile10.addNeighbour(Tile.Direction.UpLeft, tile3);
            tile10.addNeighbour(Tile.Direction.UpRight, tile4);
            tile10.addNeighbour(Tile.Direction.Right, tile11);

            tile11.addNeighbour(Tile.Direction.UpLeft, tile4);
            tile11.addNeighbour(Tile.Direction.UpRight, tile5);
            tile11.addNeighbour(Tile.Direction.Right, tile12);

            tile12.addNeighbour(Tile.Direction.UpLeft, tile5);
            tile12.addNeighbour(Tile.Direction.UpRight, tile6);
            tile12.addNeighbour(Tile.Direction.Right, tile13);

            tile13.addNeighbour(Tile.Direction.UpLeft, tile6);
            tile13.addNeighbour(Tile.Direction.UpRight, tile7);
            tile13.addNeighbour(Tile.Direction.Right, tile14);

            tile14.addNeighbour(Tile.Direction.UpLeft, tile7);
            tile14.addNeighbour(Tile.Direction.Right, tile15);

            //cetvrt red
            Tile tile16 = new NebulaTile(nebula, Color.Green);
            Tile tile17 = new PlanetTile(planeta, 0);
            Tile tile18 = new PlanetTile(planeta, 1);
            Tile tile19 = new PlanetTile(planeta, 2);
            Tile tile20 = new PlanetTile(planeta, 1);
            Tile tile21 = new PlanetTile(planeta, 1);
            Tile tile22 = new PlanetTile(planeta, 3);
            Tile tile23 = new PlanetTile(planeta, 2);
            Tile tile24 = new PlanetTile(planeta, 0);

            tile16.addNeighbour(Tile.Direction.UpRight, tile8);
            tile16.addNeighbour(Tile.Direction.Right, tile17);

            tile17.addNeighbour(Tile.Direction.UpLeft, tile8);
            tile17.addNeighbour(Tile.Direction.UpRight, tile9);
            tile17.addNeighbour(Tile.Direction.Right, tile18);

            tile18.addNeighbour(Tile.Direction.UpLeft, tile9);
            tile18.addNeighbour(Tile.Direction.UpRight, tile10);
            tile18.addNeighbour(Tile.Direction.Right, tile19);

            tile19.addNeighbour(Tile.Direction.UpLeft, tile10);
            tile19.addNeighbour(Tile.Direction.UpRight, tile11);
            tile19.addNeighbour(Tile.Direction.Right, tile20);

            tile20.addNeighbour(Tile.Direction.UpLeft, tile11);
            tile20.addNeighbour(Tile.Direction.UpRight, tile12);
            tile20.addNeighbour(Tile.Direction.Right, tile21);

            tile21.addNeighbour(Tile.Direction.UpLeft, tile12);
            tile21.addNeighbour(Tile.Direction.UpRight, tile13);
            tile21.addNeighbour(Tile.Direction.Right, tile22);

            tile22.addNeighbour(Tile.Direction.UpLeft, tile13);
            tile22.addNeighbour(Tile.Direction.UpRight, tile14);
            tile22.addNeighbour(Tile.Direction.Right, tile23);

            tile23.addNeighbour(Tile.Direction.UpLeft, tile14);
            tile23.addNeighbour(Tile.Direction.UpRight, tile15);
            tile23.addNeighbour(Tile.Direction.Right, tile24);

            tile24.addNeighbour(Tile.Direction.UpLeft, tile15);

            //pet red
            Tile tile25 = new PlanetTile(planeta, 2);
            Tile tile26 = new PlanetTile(planeta, 2);
            Tile tile27 = new PlanetTile(planeta, 1);
            Tile tile28 = new PlanetTile(planeta, 1);
            Tile tile29 = new PlanetTile(planeta, 0);
            Tile tile30 = new NebulaTile(nebula, Color.Red);
            Tile tile31 = new PlanetTile(planeta, 1);
            Tile tile32 = new PlanetTile(planeta, 2);
            Tile tile33 = new PlanetTile(planeta, 2);

            tile25.addNeighbour(Tile.Direction.UpRight, tile16);

            tile26.addNeighbour(Tile.Direction.Left, tile25);
            tile26.addNeighbour(Tile.Direction.UpLeft, tile16);
            tile26.addNeighbour(Tile.Direction.UpRight, tile17);
            tile26.addNeighbour(Tile.Direction.Right, tile27);

            tile27.addNeighbour(Tile.Direction.UpLeft, tile17);
            tile27.addNeighbour(Tile.Direction.UpRight, tile18);
            tile27.addNeighbour(Tile.Direction.Right, tile28);

            tile28.addNeighbour(Tile.Direction.UpLeft, tile18);
            tile28.addNeighbour(Tile.Direction.UpRight, tile19);
            tile28.addNeighbour(Tile.Direction.Right, tile29);

            tile29.addNeighbour(Tile.Direction.UpLeft, tile19);
            tile29.addNeighbour(Tile.Direction.UpRight, tile20);
            tile29.addNeighbour(Tile.Direction.Right, tile30);

            tile30.addNeighbour(Tile.Direction.UpLeft, tile20);
            tile30.addNeighbour(Tile.Direction.UpRight, tile21);
            tile30.addNeighbour(Tile.Direction.Right, tile31);

            tile31.addNeighbour(Tile.Direction.UpLeft, tile21);
            tile31.addNeighbour(Tile.Direction.UpRight, tile22);
            tile31.addNeighbour(Tile.Direction.Right, tile32);

            tile32.addNeighbour(Tile.Direction.UpLeft, tile22);
            tile32.addNeighbour(Tile.Direction.UpRight, tile23);
            tile32.addNeighbour(Tile.Direction.Right, tile33);

            tile33.addNeighbour(Tile.Direction.UpLeft, tile24);
            tile33.addNeighbour(Tile.Direction.UpRight, tile25);

            //sest red
            Tile tile34 = new PlanetTile(planeta, 0);
            Tile tile35 = new PlanetTile(planeta, 2);
            Tile tile36 = new PlanetTile(planeta, 1);
            Tile tile37 = new NebulaTile(nebula, Color.Green);
            Tile tile38 = new PlanetTile(planeta, 3);
            Tile tile39 = new PlanetTile(planeta, 1);
            Tile tile40 = new PlanetTile(planeta, 1);
            Tile tile41 = new PlanetTile(planeta, 0);
            Tile tile42 = new PlanetTile(planeta, 2);

            tile34.addNeighbour(Tile.Direction.UpRight, tile25);

            tile35.addNeighbour(Tile.Direction.Left, tile34);
            tile35.addNeighbour(Tile.Direction.UpLeft, tile25);
            tile35.addNeighbour(Tile.Direction.UpRight, tile26);
            tile35.addNeighbour(Tile.Direction.Right, tile36);

            tile36.addNeighbour(Tile.Direction.UpLeft, tile26);
            tile36.addNeighbour(Tile.Direction.UpRight, tile27);
            tile36.addNeighbour(Tile.Direction.Right, tile37);

            tile37.addNeighbour(Tile.Direction.UpLeft, tile27);
            tile37.addNeighbour(Tile.Direction.UpRight, tile28);
            tile37.addNeighbour(Tile.Direction.Right, tile38);

            tile38.addNeighbour(Tile.Direction.UpLeft, tile28);
            tile38.addNeighbour(Tile.Direction.UpRight, tile29);
            tile38.addNeighbour(Tile.Direction.Right, tile39);

            tile39.addNeighbour(Tile.Direction.UpLeft, tile29);
            tile39.addNeighbour(Tile.Direction.UpRight, tile30);
            tile39.addNeighbour(Tile.Direction.Right, tile40);

            tile40.addNeighbour(Tile.Direction.UpLeft, tile30);
            tile40.addNeighbour(Tile.Direction.UpRight, tile31);
            tile40.addNeighbour(Tile.Direction.Right, tile41);

            tile41.addNeighbour(Tile.Direction.UpLeft, tile31);
            tile41.addNeighbour(Tile.Direction.UpRight, tile32);
            tile41.addNeighbour(Tile.Direction.Right, tile42);

            tile42.addNeighbour(Tile.Direction.UpLeft, tile32);
            tile42.addNeighbour(Tile.Direction.UpRight, tile33);

            //sedmi red
            Tile tile43 = new PlanetTile(planeta, 1);
            Tile tile44 = new PlanetTile(planeta, 2);
            Tile tile45 = new PlanetTile(planeta, 0);
            Tile tile46 = new PlanetTile(planeta, 1);
            Tile tile47 = new PlanetTile(planeta, 1);
            Tile tile48 = new PlanetTile(planeta, 2);
            Tile tile49 = new PlanetTile(planeta, 3);
            Tile tile50 = new NebulaTile(nebula, Color.Red);

            tile43.addNeighbour(Tile.Direction.UpLeft, tile34);
            tile43.addNeighbour(Tile.Direction.UpRight, tile35);

            tile44.addNeighbour(Tile.Direction.Left, tile43);
            tile44.addNeighbour(Tile.Direction.UpLeft, tile35);
            tile44.addNeighbour(Tile.Direction.UpRight, tile36);
            tile44.addNeighbour(Tile.Direction.Right, tile45);

            tile45.addNeighbour(Tile.Direction.UpLeft, tile36);
            tile45.addNeighbour(Tile.Direction.UpRight, tile37);
            tile45.addNeighbour(Tile.Direction.Right, tile46);

            tile46.addNeighbour(Tile.Direction.UpLeft, tile37);
            tile46.addNeighbour(Tile.Direction.UpRight, tile38);
            tile46.addNeighbour(Tile.Direction.Right, tile47);

            tile47.addNeighbour(Tile.Direction.UpLeft, tile38);
            tile47.addNeighbour(Tile.Direction.UpRight, tile39);
            tile47.addNeighbour(Tile.Direction.Right, tile48);

            tile48.addNeighbour(Tile.Direction.UpLeft, tile39);
            tile48.addNeighbour(Tile.Direction.UpRight, tile40);
            tile48.addNeighbour(Tile.Direction.Right, tile49);

            tile49.addNeighbour(Tile.Direction.UpLeft, tile40);
            tile49.addNeighbour(Tile.Direction.UpRight, tile41);
            tile49.addNeighbour(Tile.Direction.Right, tile50);

            tile50.addNeighbour(Tile.Direction.UpLeft, tile41);
            tile50.addNeighbour(Tile.Direction.UpRight, tile42);

            //osmi red
            Tile tile51 = new PlanetTile(planeta, 3);
            Tile tile52 = new NebulaTile(nebula, Color.Blue);
            Tile tile53 = new PlanetTile(planeta, 3);
            Tile tile54 = new PlanetTile(planeta, 0);
            Tile tile55 = new PlanetTile(planeta, 1);

            tile51.addNeighbour(Tile.Direction.UpLeft, tile44);
            tile51.addNeighbour(Tile.Direction.UpRight, tile45);

            tile52.addNeighbour(Tile.Direction.Left, tile51);
            tile52.addNeighbour(Tile.Direction.UpLeft, tile45);
            tile52.addNeighbour(Tile.Direction.UpRight, tile46);
            tile52.addNeighbour(Tile.Direction.Right, tile53);

            tile53.addNeighbour(Tile.Direction.UpLeft, tile46);
            tile53.addNeighbour(Tile.Direction.UpRight, tile47);
            tile53.addNeighbour(Tile.Direction.Right, tile54);

            tile54.addNeighbour(Tile.Direction.UpLeft, tile47);
            tile54.addNeighbour(Tile.Direction.UpRight, tile48);
            tile54.addNeighbour(Tile.Direction.Right, tile55);

            tile55.addNeighbour(Tile.Direction.UpLeft, tile48);
            tile55.addNeighbour(Tile.Direction.UpRight, tile49);

            //deveti red
            Tile tile56 = new PlanetTile(planeta, 2);
            Tile tile57 = new NebulaTile(nebula, Color.Blue);

            tile56.addNeighbour(Tile.Direction.Right, tile57);
            tile56.addNeighbour(Tile.Direction.UpLeft, tile53);
            tile56.addNeighbour(Tile.Direction.UpRight, tile54);

            tile57.addNeighbour(Tile.Direction.UpLeft, tile54);
            tile57.addNeighbour(Tile.Direction.UpRight, tile55);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modern_Tactics
{
    public struct Tile
    {
        public int x, y, w, h;
    }

    public class BattleMap
    {
        public int mapWidth;
        public int mapHeight;
        public Tile[][] tileMap;

        public BattleMap()
        {
            mapWidth = 10;
            mapHeight = 10;
            tileMap = new Tile[mapHeight][];
        }
        public BattleMap(int Width, int Height)
        {
            mapWidth = Width;
            mapHeight = Height;

            tileMap = new Tile[Height][];
        }

        public void CreateTileMap(){
            //tileMap = new int[][];
            for(int y=0;y < mapHeight;y++){
                tileMap[y] = new Tile[mapWidth];
                for(int x=0;x < mapWidth;x++){

                    //change the 32 to a reference to TILE_SIZE to get zooming working
                    tileMap[y][x].x = x * 32;
                    tileMap[y][x].y = y * 32;
                    tileMap[y][x].w = 32;
                    tileMap[y][x].h = 32;
                }
            }
        }
    }
}

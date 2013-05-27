using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modern_Tactics
{
    public class Tile
    {
        public int x, y;

        public int[] layerTextureID;

        public bool fog; //fog system might be changed

        public int defenseValue;

        //this are likely to change
        public int sensorCost;
        public int moveCost;

        /*
         * ?change move cost to somthing like
         * footCost
         * treadCost
         * wheeledCost
         * aboveWaterCost
         * underWaterCost
         * but this limits modability :(
        */

        //rough idea for destroyable tiles though doesnt allow for multiple type of destroyed tiles
        public bool destructable;
        public int destroyedTileId;

        Tile()
        {
            x = 0;
            y = 0;
            fog = false;
            defenseValue = 0;
            sensorCost = 0;
            moveCost = 0;
        }
    }

    public class TileSet
    {
        public string tileSetName;
        public int tileSetSize;
        public Tile[] tile;

        TileSet()
        {
            tileSetName = "My first tile set";
        }
        TileSet(int size)
        {
            tileSetName = "Wish I had a real name";
            tileSetSize = size;
            tile = new Tile[tileSetSize];
        }

        public void ChangeTileSetSize(int size)
        {
            Tile[] tmpSet = new Tile[size];
            
            int loop;
            if(tile.GetLength(0) > size){
                loop = size;
            }else{
                loop = tile.GetLength(0);
            }

            for(int i=0;i < loop;i++){
                tmpSet[i] = tile[i];
            }
            tile = tmpSet;
        }

        public void LoadTileSet()//pass in tileSet file
        {
            tileSetSize = 1;//load size
            tile = new Tile[tileSetSize];

            for (int i = 0; i < tileSetSize; i++)
            {
                //load all tiles from map file
                //tile[i].defenseValue = mapfile.tile[i].defenseValue;
            }
        }
    }

    public class TileMap
    {
        public int mapWidth;
        public int mapHeight;
        public int layers;
        public int[][][] tile;

        public TileMap()
        {
            mapWidth = 10;
            mapHeight = 10;
            layers = 1;
            tile = new int[mapHeight][][];

            CreateTileMap();
        }
        public TileMap(int Width, int Height) // change this to pass in map file
        {
            mapWidth = Width;
            mapHeight = Height;

            layers = 1;//will read this from map file

            tile = new int[Height][][];

            CreateTileMap();
        }
        
        public void CreateTileMap(){
            for(int y=0;y < mapHeight;y++){
                tile[y] = new int[mapWidth][];
                for(int x=0;x < mapWidth;x++){
                    int setID = 1;//change to load tileSetId
                    int tileID = 1;//change to load tileId
                    tile[y][x][0] = setID;
                    tile[y][x][1] = tileID;
                }
            }
        }

        //end TileMap class
    }
}

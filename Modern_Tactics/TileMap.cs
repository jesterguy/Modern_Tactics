using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SharpGL;
using SharpGL.SceneGraph.Assets;

namespace Modern_Tactics
{
	public class Tile
	{
		//dont think i need x y anymore
		private int _x;
		public int x { get { return _x; } set { _x = value; } }

		private int _y;
		public int y { get { return _y; } set { _y = value; } }

		private int _defenseValue;
		public int defenseValue { get { return _defenseValue; } set { _defenseValue = value; } }

		//this are likely to change
		public int sensorCost;
		public int moveCost;

		//rough idea for destroyable tiles though doesnt allow for multiple type of destroyed tiles
		private bool _destructable;
		public bool destructable { get { return _destructable; } set { _destructable = value; } }
		
		private int _destroyedTileID;
		public int destroyedTileId { get { return _destroyedTileID; } set { _destroyedTileID = value; } }
		
		public List<Sprite> tileSprite = new List<Sprite>();

		public Tile()
		{
			x = 0;
			y = 0;
			defenseValue = 0;
			sensorCost = 0;
			moveCost = 0;
		}
	}

	public class TileSet
	{
		public string tileSetName;
		public List<Tile> tile;
		public SpriteSheet tileSheet;

		public TileSet()
		{
			tileSetName = "My first tile set";
			tile = new List<Tile>();
			tileSheet = new SpriteSheet();
		}

		public void ChangeTileSetSize(int size)
		{
			int loop;
			bool add;
			if (tile.Count > size)
			{
				loop = tile.Count - size;
				add = false;
			}
			else
			{
				loop = size - tile.Count;
				add = true;
			}

			for (int i = 0; i < loop; i++)
			{
				if (add)
				{
					tile.Add(new Tile());
				}
				else
				{
					tile.RemoveAt(tile.Count - 1);
				}
			}
		}

		public void LoadTileSet()//pass in tileSet file
		{
			tile = new List<Tile>();

			for (int i = 0; i < tile.Count; i++)
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
		public int tileSize;
		public int[][][] tile;

		public List<TileSet> tileSet;

		public TileMap(int Width = 100, int Height = 100, int tileSize = 32) // change this to pass in map file
		{
			mapWidth = Width;
			mapHeight = Height;
			this.tileSize = tileSize;
			tileSet = new List<TileSet>();
			tile = new int[Height][][];

			CreateTileMap();
		}

		public int pixelMapWidth
		{
			get
			{
				return mapWidth * tileSize;
			}
		}
		public int pixelMapHeight
		{
			get
			{
				return mapHeight * tileSize;
			}
		}

		public void CreateTileMap()
		{
			for (int y = 0; y < mapHeight; y++)
			{
				tile[y] = new int[mapWidth][];
				for (int x = 0; x < mapWidth; x++)
				{
					tile[y][x] = new int[2];
					int setID = 1;//change to load tileSetId
					int tileID = 1;//change to load tileId
					tile[y][x][0] = setID;
					tile[y][x][1] = tileID;
				}
			}
		}
	}
}

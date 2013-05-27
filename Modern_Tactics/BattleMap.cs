using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modern_Tactics
{
	public class BattleMap
	{
		public TileMap tileMap;
		public int tileSize = 32;

		public BattleMap(int Width = 10, int Height = 10)
		{
			tileMap = new TileMap(Width, Height, tileSize);
		}
	}
}

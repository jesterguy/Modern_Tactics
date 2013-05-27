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

        public BattleMap()
        {
            tileMap = new TileMap();
        }
        public BattleMap(int Width, int Height)
        {
            tileMap = new TileMap(Width, Height);
        }
    }
}

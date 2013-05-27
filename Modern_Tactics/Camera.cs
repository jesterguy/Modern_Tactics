using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Modern_Tactics
{
	class Camera
	{
		private int _x;
		public int x
		{
			get
			{
				return _x;
			}
			set
			{
				if (value < 0)
				{
					_x = 0;
				}
				else if (_x + this.w > tileMap.mapWidth)
				{
					_x = tileMap.mapWidth - this.w;
				}
				else
				{
					_x = value;
				}
			}
		}

		private int _y;
		public int y
		{
			get
			{
				return _y;
			}
			set
			{
				if (value < 0)
				{
					_y = 0;
				}
				else if (_y + this.w > tileMap.mapHeight)
				{
					_y = tileMap.mapHeight - this.h;
				}
				else
				{
					_y = value;
				}
			}
		}
		public int w { get; set; }
		public int h { get; set; }

		private TileMap tileMap;

		int scrollSpeed;

		public Camera(ref TileMap tilemap, int winWidth = 715, int winHeight = 553)
		{
			this.tileMap = tilemap;
			x = 0;
			y = 0;
			w = winWidth;
			h = winHeight;

			scrollSpeed = 20;
			
		}

		public void handleMouseMove(object sender, MouseEventArgs e)
		{
			this.x = e.X;
			this.y = e.Y;
		}
	}
}

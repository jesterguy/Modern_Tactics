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
		public int x
		{
			get
			{
				return x;
			}
			set
			{
				if (value < 0)
				{
					this.x = 0;
				}
				else if (this.x + this.w > tileMap.mapWidth)
				{
					this.x = tileMap.mapWidth - this.w;
				}
				else
				{
					this.x = value;
				}
			}
		}

		public int y
		{
			get
			{
				return y;
			}
			set
			{
				if (value < 0)
				{
					this.y = 0;
				}
				else if (this.y + this.w > tileMap.mapHeight)
				{
					this.y = tileMap.mapHeight - this.h;
				}
				else
				{
					this.y = value;
				}
			}
		}
		public int w { get; set; }
		public int h { get; set; }

		private TileMap tileMap;

		int scrollSpeed;

		public Camera(ref TileMap tilemap, int winWidth = 715, int winHeight = 553)
		{
			x = 0;
			y = 0;
			w = winWidth;
			h = winHeight;

			scrollSpeed = 20;
			this.tileMap = tilemap;
		}

		public void handleMouseMove(object sender, MouseEventArgs e)
		{
			this.x = e.X;
			this.y = e.Y;
		}
	}
}

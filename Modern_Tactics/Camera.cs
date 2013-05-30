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
				else if (_x + this.w + value > tileMap.pixelMapWidth)
				{
					_x = tileMap.pixelMapWidth - this.w;
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
				else if (_y + this.h + value > tileMap.pixelMapHeight)
				{
					_y = tileMap.pixelMapHeight - this.h;
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

		private int xDir = 0, yDir = 0;

		public Camera(ref TileMap tilemap, int winWidth = 715, int winHeight = 553)
		{
			this.tileMap = tilemap;
			x = 0;
			y = 0;
			w = winWidth;
			h = winHeight;

			scrollSpeed = 20;
			
		}

		public void moveCamera()
		{
			if (xDir != 0)
			{
				this.x += xDir * scrollSpeed;
			}
			if (yDir != 0)
			{
				this.y += yDir * scrollSpeed;
			}
		}

		public void handleMouseMove(object sender, MouseEventArgs e)
		{
			int scrollDistance = 20;

			if (e.X < scrollDistance)
			{
				xDir = -1;
			}
			else if (e.X > this.x + this.w - scrollDistance)
			{
				xDir = 1;
			}
			else
			{
				xDir = 0;
			}
			if (e.Y < scrollDistance)
			{
				yDir = -1;
			}
			else if (e.Y > this.y + this.h - scrollDistance)
			{
				yDir = 1;
			}
			else
			{
				yDir = 0;
			}
		}
	}
}

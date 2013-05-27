using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modern_Tactics
{
    class Camera
    {
        int x;
        int y;
        int w;
        int h;

        int scrollSpeed;

        Camera()
        {
            x = 0;
            y = 0;
            w = 715;//change these plz
            h = 553;

            scrollSpeed = 20;
        }
        Camera(int winWidth, int winHeight)
        {
            x = 0;
            y = 0;
            w = winWidth;
            h = winHeight;

            scrollSpeed = 20;
        }

        void BoundsCheck(int MapWidth, int MapHeight)
        {
            if (this.x < 0)
            {
                this.x = 0;
            }
            if (this.y < 0)
            {
                this.y = 0;
            }

            if (this.x + this.w > MapWidth)
            {
                this.x = MapWidth - this.w;
            }
            if (this.y + this.h > MapHeight)
            {
                this.y = MapHeight - this.h;
            }
        }
    }
}

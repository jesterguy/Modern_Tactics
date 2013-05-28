using SharpGL;
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

		public BattleMap(int Width = 100, int Height = 100)
		{
			tileMap = new TileMap(Width, Height, tileSize);
		}

		public void DisplayMap(OpenGL gl, int camX,int camY)
		{
			DrawGrid(gl,camX,camY);
		}
		public void DrawGrid(OpenGL gl, int camX,int camY)
		{
			gl.Clear(OpenGL.GL_COLOR_BUFFER_BIT | OpenGL.GL_DEPTH_BUFFER_BIT);
			gl.LoadIdentity();

			int MapHeight = tileMap.mapHeight;
			int MapWidth = tileMap.mapWidth;

			float[] darkColor = { 0.2f, 0.2f, 0.2f };
			float[] lightColor = { 0.25f, 0.25f, 0.25f };
			for (int h = 0; h < MapHeight; h++)
			{
				if (h % 10 == 0)
				{
					gl.LineWidth(2.0f);
					gl.Color(lightColor);
				}
				else
				{
					gl.LineWidth(1.0f);
					gl.Color(darkColor);
				}
				if (h == 0)
				{
					gl.LineWidth(4.0f);
					gl.Color(lightColor);
				}
				gl.Begin(OpenGL.GL_LINES);							// Start Drawing Verticle Cell Borders
				gl.Vertex(0 - camX, h * tileSize - camY, 0);// Left Side Of Horizontal Line
				gl.Vertex((MapWidth * tileSize) - camX, (h * tileSize) - camY, 0);// Right Side Of Horizontal Line
				gl.End();
			}
			for (int v = 0; v < MapWidth; v++)
			{
				if (v % 10 == 0)
				{
					gl.LineWidth(2.0f);
					gl.Color(lightColor);
				}
				else
				{
					gl.LineWidth(1.0f);
					gl.Color(darkColor);
				}
				if (v == 0)
				{
					gl.LineWidth(4.0f);
					gl.Color(lightColor);
				}
				gl.Begin(OpenGL.GL_LINES);							// Start Drawing Verticle Cell Borders
				gl.Vertex(v * tileSize - camX, 0 - camY, 0);// Left Side Of Horizontal Line
				gl.Vertex((v * tileSize) - camX, (MapHeight * tileSize) - camY, 0);// Right Side Of Horizontal Line
				gl.End();
			}
		}
	}
}

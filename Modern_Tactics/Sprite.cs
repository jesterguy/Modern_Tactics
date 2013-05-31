using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SharpGL;
using SharpGL.SceneGraph.Assets;
namespace Modern_Tactics
{
	public struct Sprite
	{
		public float spriteX;
		public float spriteY;
		public float spriteWidth;
		public float spriteHeight;
		public int spriteFrames;//for animation
		public Sprite(float x, float y, float w, float h, int frames = -1)
		{
			spriteX = x;
			spriteY = y;
			spriteWidth = w;
			spriteHeight = h;
			spriteFrames = frames;
		}
	}

	public class SpriteSheet
	{
		public int texWidth;
		public int texHeight;

		public Texture tex;

		public SpriteSheet()
		{
			tex = new Texture();
			texWidth = 0;
			texHeight = 0;
		}
		public SpriteSheet(Texture texture)
		{
			tex = texture;
			texWidth = 0;
			texHeight = 0;
		}

		public void DrawSprite(float posX, float posY, Sprite sprite, OpenGL gl)
		{
			float[] verts = {
				posX, posY,
				posX + 32, posY,
				posX + 32, posY + 32,
				posX, posY + 32
			};
			float tw = sprite.spriteWidth;
			float th = sprite.spriteHeight;
			float tx = sprite.spriteX;
			float ty = sprite.spriteY;
			float[] texVerts = {
				tx, ty,
				tx + tw, ty,
				tx + tw, ty + th,
				tx, ty + th
			};

			gl.Color(1.0, 1.0, 1.0, 1.0); // reset gl color
			tex.Bind(gl);

			gl.Begin(OpenGL.GL_QUADS);
			gl.TexCoord(texVerts[0], texVerts[1]); gl.Vertex(verts[0], verts[1], 0.0f);	// Bottom Left Of The Texture and Quad
			gl.TexCoord(texVerts[2], texVerts[3]); gl.Vertex(verts[2], verts[3], 0.0f);	// Bottom Right Of The Texture and Quad
			gl.TexCoord(texVerts[4], texVerts[5]); gl.Vertex(verts[4], verts[5], 0.0f);	// Top Right Of The Texture and Quad
			gl.TexCoord(texVerts[6], texVerts[7]); gl.Vertex(verts[6], verts[7], 0.0f);	// Top Left Of The Texture and Quad
			gl.End();

			//this is sposed to be better but doesnt seem to work
			//gl.VertexPointer(2, OpenGL.GL_FLOAT, 0, verts);
			//gl.TexCoordPointer(2, OpenGL.GL_FLOAT, 0, texVerts);
			//gl.DrawArrays(OpenGL.GL_TRIANGLE_STRIP,0,4);
		}

		public Sprite CreateSprite(float x,float y, float w, float h, int frames = -1)
		{
			float sx = x / texWidth;
			float sy = y / texHeight;
			float sw = w / texWidth;
			float sh = h / texHeight;
			Sprite tmpSprite = new Sprite(sx, sy, sw, sh, frames);

			return tmpSprite;
		}
	}
}

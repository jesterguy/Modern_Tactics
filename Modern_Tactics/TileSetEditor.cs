using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using SharpGL;
using SharpGL.SceneGraph.Assets;

namespace Modern_Tactics
{
	public partial class TileSetEditor : Form
	{
		Texture tileSetImg = new Texture();

		private bool tileSetImgLoaded = false;

		public TileSetEditor()
		{
			InitializeComponent();

			//  Get the OpenGL object, for quick access.
			SharpGL.OpenGL gl1 = this.openGLControl1.OpenGL;

			//  A bit of extra initialisation here, we have to enable textures.
			gl1.Enable(OpenGL.GL_TEXTURE_2D);

			//  Get the OpenGL object, for quick access.
			SharpGL.OpenGL gl2 = this.openGLControl2.OpenGL;

			//  A bit of extra initialisation here, we have to enable textures.
			gl2.Enable(OpenGL.GL_TEXTURE_2D);
		}

		private void openGLControl1_Load(object sender, EventArgs e)
		{
			this.openGLControl1.OpenGLDraw += new System.Windows.Forms.PaintEventHandler(this.openGLControl1_OpenGLDraw);
		}

		private void openGLControl1_OpenGLDraw(object sender, PaintEventArgs e)
		{
		}

		private void openGLControl2_Load(object sender, EventArgs e)
		{
			this.openGLControl2.OpenGLDraw += new System.Windows.Forms.PaintEventHandler(this.openGLControl2_OpenGLDraw);
		}
		private void openGLControl2_OpenGLDraw(object sender, PaintEventArgs e)
		{
			if (tileSetImgLoaded)
			{
				int width = tileSetImg.ToBitmap().Width;
				int height = tileSetImg.ToBitmap().Height;

				//  Get the OpenGL object, for quick access.
				SharpGL.OpenGL gl = this.openGLControl1.OpenGL;

				gl.Clear(OpenGL.GL_COLOR_BUFFER_BIT | OpenGL.GL_DEPTH_BUFFER_BIT);
				gl.LoadIdentity();

				//  Bind the texture.
				tileSetImg.Bind(gl);

				gl.Begin(OpenGL.GL_QUADS);
				// Front Face
				gl.TexCoord(0.0f, 0.0f); gl.Vertex(0.0f, 0.0f, 1.0f);	// Bottom Left Of The Texture and Quad
				gl.TexCoord(1.0f, 0.0f); gl.Vertex(width, height, 1.0f);	// Bottom Right Of The Texture and Quad
				gl.TexCoord(1.0f, 1.0f); gl.Vertex(0.0f, height, 1.0f);	// Top Right Of The Texture and Quad
				gl.TexCoord(0.0f, 1.0f); gl.Vertex(width, 0.0f, 1.0f);	// Top Left Of The Texture and Quad
				gl.End();
			}
		}

		private void button1_Click(object sender, EventArgs e)
		{
			//  Show a file open dialog.
			if (openFileDialog1.ShowDialog() == DialogResult.OK)
			{
				//  Destroy the existing texture.
				tileSetImg.Destroy(openGLControl2.OpenGL);

				//  Create a new texture.
				tileSetImg.Create(openGLControl2.OpenGL, openFileDialog1.FileName);

				//  Redraw.
				openGLControl2.Invalidate();

				tileSetImgLoaded = true;
			}
		}
	}
}

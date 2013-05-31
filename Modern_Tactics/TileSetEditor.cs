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
using SharpGL.Enumerations;

namespace Modern_Tactics
{
	public partial class TileSetEditor : Form
	{
		Texture tileSetImg = new Texture();
		private int imgWidth, imgHeight;

		private bool tileSetImgLoaded = false;

		TileSet tileSet = new TileSet();

		private int control1SelectionX = 0;
		private int control1SelectionY = 0;
		private int selectedTile = 0;
		private int control2SelectionX = 0;
		private int control2SelectionY = 0;
		private int control2SelectionW = 0;
		private int control2SelectionH = 0;
		
		public TileSetEditor()
		{
			InitializeComponent();

			//  Get the OpenGL object, for quick access.
			SharpGL.OpenGL gl1 = this.openGLControl1.OpenGL;
			SharpGL.OpenGL gl2 = this.openGLControl2.OpenGL;
			//  A bit of extra initialisation here, we have to enable textures.
			gl1.Enable(OpenGL.GL_TEXTURE_2D);
			gl2.Enable(OpenGL.GL_TEXTURE_2D); 

			//transparancy crap needs to work at somepoint
			//gl1.Enable(OpenGL.GL_BLEND);
			//gl1.BlendFunc(OpenGL.GL_SRC_ALPHA, OpenGL.GL_ONE_MINUS_SRC_ALPHA);
			//gl1.TexImage2D(OpenGL.GL_TEXTURE_2D, 0, OpenGL.GL_RGBA, imgWidth, imgHeight, 0, OpenGL.GL_RGBA, OpenGL.GL_UNSIGNED_BYTE,);

			openGLControl1.MouseClick += HandleMouseClick1;
			openGLControl2.MouseClick += HandleMouseClick2;
			//openGLControl2.MouseDown += HandleMouseDown; Deal with this crap later
			//openGLControl2.MouseUp += HandleMouseUp;

			tileSet.ChangeTileSetSize(100);

			hScrollBar1.Visible = false;
			vScrollBar1.Visible = false;

			hScrollBar2.Visible = false;
			vScrollBar2.Visible = false;
		}
		public void ResetOpenGL(SharpGL.OpenGL gl,int width,int height)
		{
			gl.Viewport(0, 0, width, height);

			gl.Color(1.0, 1.0, 1.0, 1.0); // reset gl color

			gl.MatrixMode(MatrixMode.Projection);
			gl.LoadIdentity();
			gl.Ortho(0, width, height, 0, -10, 10);

			gl.MatrixMode(MatrixMode.Modelview);

			gl.Clear(OpenGL.GL_COLOR_BUFFER_BIT | OpenGL.GL_DEPTH_BUFFER_BIT);
			gl.LoadIdentity();
		}

		private void HandleMouseClick1(object sender, MouseEventArgs e)
		{
			control1SelectionX = e.X / 32;
			control1SelectionY = e.Y / 32;

			int x = 0;
			int y = 0;
			int rows = 1;
			int tileID = -1;
			for (int i = 0; i < tileSet.tileSetSize; i++)
			{
				if (x + 32 > this.openGLControl1.Width)
				{
					x = 0;
					y += 32;
					rows++;
				}
				if (x / 32 == control1SelectionX && y / 32 == control1SelectionY)
				{
					tileID = i;
					selectedTile = i;
				}
				x += 32;
			}

			if (tileID != -1)
			{
				if (tileSet.tile[tileID] == null)
				{
					tileSet.tile[tileID] = new Tile();

					tileSet.tile[tileID].tileSprite.Add( tileSet.tileSheet.CreateSprite(control2SelectionX * 32, control2SelectionY * 32, 32, 32) );
				}

				listBox1.DataSource = null;
				listBox1.DataSource = tileSet.tile[tileID].tileSprite;

				if (e.Button == MouseButtons.Right)
				{
					int index = listBox1.SelectedIndex;
					tileSet.tile[tileID].tileSprite[index] = tileSet.tileSheet.CreateSprite(control2SelectionX * 32, control2SelectionY * 32, 32, 32);
				}
				propertyGrid1.SelectedObject = tileSet.tile[tileID];
			}
		}
		private void HandleMouseClick2(object sender, MouseEventArgs e)
		{
			control2SelectionX = (e.X + hScrollBar2.Value) / 32;
			control2SelectionY = (e.Y + vScrollBar2.Value) / 32;
			control2SelectionW = (32*control2SelectionX) + 32;
			control2SelectionH = (32*control2SelectionY) + 32;
		}

		private void openGLControl1_Load(object sender, EventArgs e)
		{
			this.openGLControl1.OpenGLDraw += new System.Windows.Forms.PaintEventHandler(this.openGLControl1_OpenGLDraw);
		}

		private void openGLControl1_OpenGLDraw(object sender, PaintEventArgs e)
		{
			SharpGL.OpenGL gl = this.openGLControl1.OpenGL;
			ResetOpenGL(gl, this.openGLControl1.Width, this.openGLControl1.Height);
			
			int x = 0;
			int y = 0;
			for (int i=0; i < tileSet.tileSetSize; i++)
			{
				if (x + 32 > this.openGLControl1.Width)
				{
					x = 0;
					y += 32;
				}
				//Draw tile imgs
				if ( tileSet.tile[i] != null)
				{
					for( int l=0; l < tileSet.tile[i].tileSprite.Count; l++) // to diplay all layers on tile
					{
						tileSet.tileSheet.DrawSprite(x, y,tileSet.tile[i].tileSprite[l], gl);
					}
				}
				else
				{
					gl.Color(0.25f, 0.25f, 0.25f);
					gl.LineWidth(2.0f);
					gl.Begin(OpenGL.GL_QUADS);
					gl.Vertex(x, y, 1);
					gl.Vertex(x, y+32, 1);
					gl.Vertex(x+32,y,1);
					gl.Vertex(x+32,y+32,1);
					gl.End();
				}
				gl.LoadIdentity();

				x += 32;
			}

			//Draw Selection
			gl.Color(1.25f, 0.25f, 0.25f);
			gl.LineWidth(2.0f);
			gl.Begin(OpenGL.GL_LINES);
			gl.Vertex(control1SelectionX * 32, control1SelectionY * 32, 1);
			gl.Vertex((control1SelectionX * 32) + 32, (control1SelectionY * 32) + 32, 1);
			gl.End();
		}

		private void openGLControl2_Load(object sender, EventArgs e)
		{
			this.openGLControl2.OpenGLDraw += new System.Windows.Forms.PaintEventHandler(this.openGLControl2_OpenGLDraw);

			SharpGL.OpenGL gl = this.openGLControl2.OpenGL;
			gl.Color(0.0f, 0.0f, 0.0f);
		}
		private void openGLControl2_OpenGLDraw(object sender, PaintEventArgs e)
		{
			if (tileSetImgLoaded)
			{
				//  Get the OpenGL object, for quick access.
				SharpGL.OpenGL gl = this.openGLControl2.OpenGL;

				ResetOpenGL(gl, this.openGLControl2.Width,this.openGLControl2.Height);
				gl.Translate(-hScrollBar2.Value, -vScrollBar2.Value,0);
				//  Bind the texture.
				tileSetImg.Bind(gl); // commenting this out doesnt change anything but it should.why?

				gl.Begin(OpenGL.GL_QUADS);
				gl.TexCoord(0.0f, 0.0f); gl.Vertex(0.0f, 0.0f, 0.0f);	// Bottom Left Of The Texture and Quad
				gl.TexCoord(1.0f, 0.0f); gl.Vertex(imgWidth, 0.0f, 0.0f);	// Bottom Right Of The Texture and Quad
				gl.TexCoord(1.0f, 1.0f); gl.Vertex(imgWidth, imgHeight, 0.0f);	// Top Right Of The Texture and Quad
				gl.TexCoord(0.0f, 1.0f); gl.Vertex(0.0f, imgHeight, 0.0f);	// Top Left Of The Texture and Quad
				gl.End();

				//Draw Selection
				gl.Color(1.25f, 0.25f, 0.25f);
				gl.LineWidth(2.0f);
				gl.Begin(OpenGL.GL_LINES);
				gl.Vertex(control2SelectionX*32, control2SelectionY*32, 1);
				gl.Vertex(control2SelectionW, control2SelectionH, 1);
				gl.End();

				//DrawGrid
				for (int y = 0; y < imgWidth / 32; y++)
				{
					gl.Begin(OpenGL.GL_LINES);							// Start Drawing Verticle Cell Borders
					gl.Vertex(y * 32, 0, 1);// Left Side Of Horizontal Line
					gl.Vertex(y * 32, imgHeight, 1);// Right Side Of Horizontal Line
					gl.End();
				}
				for (int x = 0; x < imgHeight / 32; x++)
				{
					gl.Begin(OpenGL.GL_LINES);							// Start Drawing Verticle Cell Borders
					gl.Vertex(0,x*32 , 1);// Left Side Of Horizontal Line
					gl.Vertex(imgWidth, x * 32, 1);// Right Side Of Horizontal Line
					gl.End();
				}
			}
		}

		private void button1_Click(object sender, EventArgs e)
		{
			//  Show a file open dialog.
			if (openFileDialog1.ShowDialog() == DialogResult.OK)
			{
				//  Destroy the existing texture.
				tileSet.tileSheet.tex.Destroy(openGLControl1.OpenGL);
				tileSetImg.Destroy(openGLControl2.OpenGL);

				//  Create a new texture.
				tileSet.tileSheet.tex.Create(openGLControl1.OpenGL, openFileDialog1.FileName);
				tileSetImg.Create(openGLControl2.OpenGL, openFileDialog1.FileName);

				//  Redraw.
				openGLControl1.Invalidate();
				openGLControl2.Invalidate();

				int[] widthArray = new int[1];
				int[] heightArray = new int[1];
				openGLControl1.OpenGL.GetTexLevelParameter(OpenGL.GL_TEXTURE_2D, 0, OpenGL.GL_TEXTURE_WIDTH, widthArray);
				tileSet.tileSheet.texWidth = widthArray[0];
				openGLControl1.OpenGL.GetTexLevelParameter(OpenGL.GL_TEXTURE_2D, 0, OpenGL.GL_TEXTURE_HEIGHT, heightArray);
				tileSet.tileSheet.texHeight = heightArray[0];

				openGLControl2.OpenGL.GetTexLevelParameter(OpenGL.GL_TEXTURE_2D, 0, OpenGL.GL_TEXTURE_WIDTH, widthArray);
				imgWidth = widthArray[0];
				openGLControl2.OpenGL.GetTexLevelParameter(OpenGL.GL_TEXTURE_2D, 0, OpenGL.GL_TEXTURE_HEIGHT, heightArray);
				imgHeight = heightArray[0];

				if (widthArray[0] > openGLControl2.Width)
				{
					hScrollBar2.Visible = true;
					hScrollBar2.Maximum = widthArray[0] - openGLControl2.Width;
				}
				else
				{
					vScrollBar2.Visible = false;
				}
				if (heightArray[0] > openGLControl2.Width)
				{
					vScrollBar2.Visible = true;
					vScrollBar2.Maximum = heightArray[0] - openGLControl2.Height;
				}
				else
				{
					vScrollBar2.Visible = false;
				}

				tileSetImgLoaded = true;
			}
		}

		private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
		{

		}

		private void button2_Click(object sender, EventArgs e)
		{
			tileSet.tile[selectedTile].tileSprite.Add(tileSet.tileSheet.CreateSprite(control2SelectionX * 32, control2SelectionY * 32, 32, 32));
			listBox1.DataSource = null;
			listBox1.DataSource = tileSet.tile[selectedTile].tileSprite;
		}

		private void button3_Click(object sender, EventArgs e)
		{
			int index = listBox1.SelectedIndex;
			tileSet.tile[selectedTile].tileSprite.RemoveAt(index);
			listBox1.DataSource = null;
			listBox1.DataSource = tileSet.tile[selectedTile].tileSprite;
		}
	}
}

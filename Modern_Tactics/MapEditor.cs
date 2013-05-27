using SharpGL;
using SharpGL.Enumerations;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Modern_Tactics
{
    public partial class MapEditor : Form
    {
        public MapEditor()
        {
            InitializeComponent();
        }

        private void openGLControl1_Load(object sender, EventArgs e)
        {
            this.openGLControl1.OpenGLDraw += new System.Windows.Forms.PaintEventHandler(this.openGLControl1_OpenGLDraw);
        }

        private void openGLControl1_OpenGLDraw(object sender, PaintEventArgs e)
        {

            SharpGL.OpenGL gl = this.openGLControl1.OpenGL;

            gl.Viewport(0, 0, openGLControl1.Width, openGLControl1.Height);

            gl.ClearColor(0.0f, 0.0f, 0.0f, 0.0f);

            gl.MatrixMode(MatrixMode.Projection);
            gl.LoadIdentity();
            gl.Ortho(0, openGLControl1.Width, openGLControl1.Height, 0, -10, 10);

            gl.MatrixMode(MatrixMode.Modelview);

            DrawGrid();
        }

        private void DrawGrid()
        {
            OpenGL gl = this.openGLControl1.OpenGL;
            
            gl.Clear(OpenGL.GL_COLOR_BUFFER_BIT | OpenGL.GL_DEPTH_BUFFER_BIT);
            gl.LoadIdentity();

            int MapHeight = 100;
            int MapWidth = 100;

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
                gl.Begin(OpenGL.GL_LINES);							// Start Drawing Verticle Cell Borders
                gl.Vertex(0, h * Globals.TILE_SIZE, 0);// Left Side Of Horizontal Line
                gl.Vertex(MapWidth * Globals.TILE_SIZE, h * Globals.TILE_SIZE, 0);// Right Side Of Horizontal Line
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
                gl.Begin(OpenGL.GL_LINES);							// Start Drawing Verticle Cell Borders
                gl.Vertex(v * Globals.TILE_SIZE, 0, 0);// Left Side Of Horizontal Line
                gl.Vertex(v * Globals.TILE_SIZE, MapHeight * Globals.TILE_SIZE, 0);// Right Side Of Horizontal Line
                gl.End();
            }
        }

        private void tileSetEditorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new TileSetEditor();
            frm.Location = this.Location;
            frm.StartPosition = FormStartPosition.Manual;
            frm.FormClosing += delegate { this.Show(); };
            frm.Show();
            //this.Hide();
        }
    }
}

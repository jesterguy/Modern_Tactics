using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;

using SharpGL;
using SharpGL.Enumerations;
using System.Configuration;

namespace Modern_Tactics
{
	public partial class BattleScreen : Form
	{
		//temp battleMap til i have something to load saved maps
		BattleMap battleMap;
		Camera camera;

		Timer timer = new Timer();

		public BattleScreen()
		{
			battleMap = new BattleMap();
			camera = new Camera(ref battleMap.tileMap);

			InitializeComponent();
			openGLControl1.DrawFPS = true;
			openGLControl1.MouseMove += camera.handleMouseMove;
			openGLControl1.Resize += openGLControl1_Resized;

			timer.Tick += new EventHandler(timer_Tick);

			timer.Interval = 1;
			timer.Enabled = true;
			timer.Start();

			ResetOpenGL();
		}

		public void ResetOpenGL()
		{
			SharpGL.OpenGL gl = this.openGLControl1.OpenGL;

			gl.Viewport(0, 0, openGLControl1.Width, openGLControl1.Height);

			gl.ClearColor(0.0f, 0.0f, 0.0f, 0.0f);

			gl.MatrixMode(MatrixMode.Projection);
			gl.LoadIdentity();
			gl.Ortho(0, openGLControl1.Width, openGLControl1.Height, 0, -10, 10);

			gl.MatrixMode(MatrixMode.Modelview);
		}

		void timer_Tick(object sender, EventArgs e)
		{
			camera.moveCamera();
		}

		private void openGLControl1_OpenGLDraw(object sender, PaintEventArgs e)
		{
			battleMap.DisplayMap(this.openGLControl1.OpenGL, camera.x, camera.y);
		}

		private void openGLControl1_OpenGLInitialized(object sender, EventArgs e)
		{

		}

		private void openGLControl1_Resized(object sender, EventArgs e)
		{
			ResetOpenGL();
			camera.w = openGLControl1.Width;
			camera.h = openGLControl1.Height;
		}

		
	}
}
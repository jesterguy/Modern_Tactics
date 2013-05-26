using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;

using SharpGL;
using SharpGL.Enumerations;
using System.Configuration;

namespace Modern_Tactics
{
   public partial class Form2 : Form
   {
      public Form2()
      {
         InitializeComponent();
         this.openGLControl1.DrawFPS = true;
      }
       
      private void openGLControl1_OpenGLDraw(object sender, PaintEventArgs e)
      {
         OpenGL gl = this.openGLControl1.OpenGL;

         gl.Clear(OpenGL.GL_COLOR_BUFFER_BIT | OpenGL.GL_DEPTH_BUFFER_BIT);
         gl.LoadIdentity();

         int MapHeight = 100;
         int MapWidth = 100;

        float[] darkColor = {1.2f, 0.2f, 0.2f};
	    float[] lightColor = {1.25f, 0.25f, 0.25f};
	    for(int h=0; h < MapHeight; h++ ){
		    if( h % 10 == 0){
			    gl.LineWidth(2.0f);
			    gl.Color(lightColor);
		    }else{
			    gl.LineWidth(1.0f);
			    gl.Color(darkColor);
		    }
		    gl.Begin(OpenGL.GL_LINES);							// Start Drawing Verticle Cell Borders
			    gl.Vertex4i(0, h*32,0,2);// Left Side Of Horizontal Line
                gl.Vertex4i(MapWidth * 32, h * 32, 0, 2);// Right Side Of Horizontal Line
		    gl.End();
	    }
	    for(int v=0; v < MapWidth; v++ ){
		    if( v % 10 == 0){
			    gl.LineWidth(2.0f);
			    gl.Color(lightColor);
		    }else{
			    gl.LineWidth(1.0f);
			    gl.Color(darkColor);
		    }
		    gl.Begin(OpenGL.GL_LINES);							// Start Drawing Verticle Cell Borders
                gl.Vertex4i(v * 32, 0, 0, 2);// Left Side Of Horizontal Line
                gl.Vertex4i(v * 32, MapHeight * 32, 0, 2);// Right Side Of Horizontal Line
		    gl.End();	
	    }

        gl.Flush();
      }

      private void openGLControl1_OpenGLInitialized(object sender, EventArgs e)
      {
          SharpGL.OpenGL gl = this.openGLControl1.OpenGL;

          int WinWidth = Int32.Parse(ConfigurationManager.AppSettings["WINDOW_WIDTH"]);
          int WinHeight = Int32.Parse(ConfigurationManager.AppSettings["WINDOW_HEIGHT"]);

          gl.Viewport(0, 0, WinWidth, WinHeight);

          gl.ClearColor(0.0f, 0.0f, 0.0f, 0.0f);

          gl.MatrixMode(OpenGL.GL_PROJECTION);
          gl.LoadIdentity();

          gl.Ortho(0, WinWidth, WinHeight, 0, -1, 1);

          gl.MatrixMode(OpenGL.GL_MODELVIEW);

      }

      private void openGLControl1_Resized(object sender, SharpGL.SceneGraph.OpenGLEventArgs args)
      {
      }
   }
}
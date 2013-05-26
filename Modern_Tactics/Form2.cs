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
         InitializeOpenGL();
      }

      public void InitializeOpenGL()
      {
          SharpGL.OpenGL gl = this.openGLControl1.OpenGL;

          gl.Viewport(0, 0, openGLControl1.Width, openGLControl1.Height);

          gl.ClearColor(0.0f, 0.0f, 0.0f, 0.0f);

          gl.MatrixMode(MatrixMode.Projection);
          gl.LoadIdentity();
          gl.Ortho(0, openGLControl1.Width, openGLControl1.Height, 0, -10, 10);

          gl.MatrixMode(MatrixMode.Modelview);
      }
       
      private void openGLControl1_OpenGLDraw(object sender, PaintEventArgs e)
      {
         OpenGL gl = this.openGLControl1.OpenGL;

         //find a way to run only on resize
         InitializeOpenGL();

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
             gl.Vertex(0, h * 32, 0);// Left Side Of Horizontal Line
             gl.Vertex(MapWidth * 32, h * 32, 0);// Right Side Of Horizontal Line
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
             gl.Vertex(v * 32, 0, 0);// Left Side Of Horizontal Line
             gl.Vertex(v * 32, MapHeight * 32, 0);// Right Side Of Horizontal Line
             gl.End();
         }
      }

      private void openGLControl1_OpenGLInitialized(object sender, EventArgs e)
      {

      }

      private void openGLControl1_Resized(object sender, EventArgs e)
      {
          InitializeOpenGL();
      }
   }
}
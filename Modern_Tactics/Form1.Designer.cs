using System;
using System.Configuration;
namespace Modern_Tactics
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.openGLControl1 = new SharpGL.OpenGLControl();
            this.sceneControl1 = new SharpGL.SceneControl();
            ((System.ComponentModel.ISupportInitialize)(this.openGLControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sceneControl1)).BeginInit();
            this.SuspendLayout();
            // 
            // openGLControl1
            // 
            this.openGLControl1.BitDepth = 32;
            this.openGLControl1.DrawFPS = true;
            this.openGLControl1.FrameRate = 20;
            this.openGLControl1.Location = new System.Drawing.Point(12, 12);
            this.openGLControl1.Name = "openGLControl1";
            this.openGLControl1.RenderContextType = SharpGL.RenderContextType.DIBSection;
            this.openGLControl1.Size = new System.Drawing.Size(402, 423);
            this.openGLControl1.TabIndex = 0;
            this.openGLControl1.Load += new System.EventHandler(this.openGLControl1_Load);
            // 
            // sceneControl1
            // 
            this.sceneControl1.BitDepth = 24;
            this.sceneControl1.DrawFPS = false;
            this.sceneControl1.FrameRate = 20;
            this.sceneControl1.Location = new System.Drawing.Point(420, 285);
            this.sceneControl1.Name = "sceneControl1";
            this.sceneControl1.RenderContextType = SharpGL.RenderContextType.DIBSection;
            this.sceneControl1.Size = new System.Drawing.Size(150, 150);
            this.sceneControl1.TabIndex = 1;
            this.sceneControl1.Load += new System.EventHandler(this.sceneControl1_Load);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(582, 447);
            this.Controls.Add(this.sceneControl1);
            this.Controls.Add(this.openGLControl1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.openGLControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sceneControl1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private SharpGL.OpenGLControl openGLControl1;
        private Microsoft.VisualBasic.PowerPacks.ShapeContainer shapeContainer1;
        private Microsoft.VisualBasic.PowerPacks.LineShape lineShape1;
        private SharpGL.SceneControl sceneControl1;
    }
}


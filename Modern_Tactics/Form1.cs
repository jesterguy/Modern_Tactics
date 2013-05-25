using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Modern_Tactics
{
    public partial class Form1 : Form
    {
        int FPS = Int32.Parse(ConfigurationManager.AppSettings["FRAMES_PER_SECOND"]);
        int WIN_WIDTH = Int32.Parse(ConfigurationManager.AppSettings["WINDOW_WIDTH"]);
        int WIN_HEIGHT = Int32.Parse(ConfigurationManager.AppSettings["WINDOW_HEIGHT"]);
        public Form1()
        {
            InitializeComponent();
        }

        private void openGLControl1_Load(object sender, EventArgs e)
        {

        }
    }
}

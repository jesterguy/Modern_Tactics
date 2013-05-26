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
        public Form1()
        {
            InitializeComponent();
            this.Width = Int32.Parse(ConfigurationManager.AppSettings["WINDOW_WIDTH"]);
            this.Height = Int32.Parse(ConfigurationManager.AppSettings["WINDOW_HEIGHT"]);
        }

        private void openGLControl1_Load(object sender, EventArgs e)
        {

        }
    }
}

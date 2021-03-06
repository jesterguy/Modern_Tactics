﻿using System;
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
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();
            this.Width = Int32.Parse(ConfigurationManager.AppSettings["WINDOW_WIDTH"]);
            this.Height = Int32.Parse(ConfigurationManager.AppSettings["WINDOW_HEIGHT"]);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var frm = new BattleScreen();
            frm.Location = this.Location;
            frm.StartPosition = FormStartPosition.Manual;
            frm.FormClosing += delegate { this.Show(); };
            frm.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        
        private void button3_Click(object sender, EventArgs e)
        {
            var frm = new MapEditor();
            frm.Location = this.Location;
            frm.StartPosition = FormStartPosition.Manual;
            frm.FormClosing += delegate { this.Show(); };
            frm.Show();
            this.Hide();
        }
    }
}

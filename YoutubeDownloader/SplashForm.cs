using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YoutubeDownloader
{
    public partial class SplashForm : Form
    {
        public SplashForm()
        {
            InitializeComponent();
        }

        private void SplashForm_Load(object sender, EventArgs e)
        {
            Timer t = new Timer();
            t.Interval = 3000;
            t.Tick += new EventHandler(timerTick);
            t.Start();
        }

        private void timerTick(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}

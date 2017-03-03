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
    partial class AddVideoForm : Form
    {

        private Video video;

        public AddVideoForm(ref Video video)
        {
            InitializeComponent();
            this.video = video;
        }

        private void AddVideoForm_Load(object sender, EventArgs e)
        {
            videoUrlTextBox.Text = video.url;
            videoNameTextBox.Text = video.getVideoName();
            foreach(string s in video.getVideoDetails())
            {
                videoListComboBox.Items.Add(s);
            }
        }

        private void addVideoButton_Click(object sender, EventArgs e)
        {
            this.video.updateInfo(videoListComboBox.SelectedIndex);
            this.Dispose();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.video = null;
            this.Dispose();
        }
    }
}

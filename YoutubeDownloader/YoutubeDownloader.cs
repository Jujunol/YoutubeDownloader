using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;
using System.Diagnostics;

namespace YoutubeDownloader
{
    /// <summary>
    /// Author : John Horne
    /// Date : 4/08/16
    /// </summary>
    public partial class YoutubeDownloader : Form
    {
        public YoutubeDownloader()
        {
            InitializeComponent();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FileVersionInfo versionInfo = FileVersionInfo.GetVersionInfo(Assembly.GetExecutingAssembly().Location);

            MessageBox.Show("Author: " + versionInfo.CompanyName +
                "\nVersion: " + versionInfo.FileVersion +
                "\n" + versionInfo.LegalCopyright);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        /// <summary>
        /// Adds Url to download Queue
        /// </summary>
        private void addUrlButton_Click(object sender, EventArgs e)
        {
            Video video = addVideo(urlTextBox.Text);
            if(video != null)
            {
                urlListBox.Items.Add(video);
                urlTextBox.Text = "";
            }
        }

        /// <summary>
        /// Adds Url to download Queue upon pressing enter
        /// </summary>
        private void urlTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                addUrlButton_Click(null, null);
            }
        }

        /// <summary>
        /// Removes selected items from the list
        /// </summary>
        private void removeFromListButton_Click(object sender, EventArgs e)
        {
            // Note: has to be inverse for loop as the list changes SelectedIndices as you remove
            for(int i = urlListBox.SelectedIndices.Count -1; i >= 0; i--)
            {
                urlListBox.Items.RemoveAt(urlListBox.SelectedIndices[i]);
            }
        }

        /// <summary>
        /// Downloads all the links in the list
        /// </summary>
        private void downloadButton_Click(object sender, EventArgs e)
        {
            // Check if there's any items in the list
            if (urlListBox.Items.Count == 0)
            {
                MessageBox.Show("The download queue is empty", "Nothing to download", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Get the desired download location
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.Description = "Choose where to store the files";
            if(dialog.ShowDialog() != DialogResult.OK) {
                MessageBox.Show("A folder to store the files is required", "No download folder selected", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string path = dialog.SelectedPath;

            statusTextBox.Text = "Starting download process... \n\n";
            lockComponents();

            // Loop through the list and download every video, skip upon error
            int i = 0;
            while(i < urlListBox.Items.Count && urlListBox.Items.Count > 0)
            {
                Video video = (Video) urlListBox.Items[i];
                statusTextBox.AppendText("Fetching " + video.url + "\n");

                if(video.download(path))
                {
                    statusTextBox.AppendText("Successfully downloaded!");
                    urlListBox.Items.RemoveAt(i);
                }
                else
                {
                    statusTextBox.AppendText("Could not complete download!");
                    i++; // Will allow skipping of errored video
                }
                statusTextBox.AppendText("\n\n");
            }
            unlockComponents();
            MessageBox.Show("Download completed", "Finished!", MessageBoxButtons.OK);
        }

        // -- Independent Functions

        /// <summary>
        /// Opens the form for the user to select the video quality the desire
        /// </summary>
        /// <param name="url">The URL of the Video</param>
        /// <returns>A video object of the requested Video</returns>
        private Video addVideo(string url)
        {
            try
            {
                Video video = new Video(url);

                AddVideoForm videoForm = new AddVideoForm(ref video);
                videoForm.ShowDialog();

                return video;
            } catch(Exception ex)
            {
                MessageBox.Show("Youtube Video not found at URL!", "Invalid URL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                MessageBox.Show(ex.Message);
            }
            return null;
        }

        /// <summary>
        /// Locks all the components to prevent updating fields
        /// </summary>
        private void lockComponents()
        {
            urlTextBox.Enabled = false;
            addUrlButton.Enabled = false;
            removeFromListButton.Enabled = false;
            downloadButton.Enabled = false;
        }

        /// <summary>
        /// Unlocks all the components
        /// </summary>
        private void unlockComponents()
        {
            urlTextBox.Enabled = true;
            addUrlButton.Enabled = true;
            removeFromListButton.Enabled = true;
            downloadButton.Enabled = true;
        }
    }
}

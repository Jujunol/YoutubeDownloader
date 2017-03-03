using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoutubeExtractor;

namespace YoutubeDownloader
{
    /// <summary>
    /// Purpose : To hold the information of each requested video
    /// Author : John Horne
    /// Date : 4/08/16
    /// </summary>
    class Video
    {

        private VideoInfo[] videoList;
        private int listIndex;
        private string name;

        public string url { get; }

        public Video(string url)
        {
            this.url = url;

            // Check if the video exists
            try {
                IEnumerable<VideoInfo> videoList = DownloadUrlResolver.GetDownloadUrls(url);

                if (videoList == null || videoList.Count() <= 0)
                {
                    throw new Exception("Youtube Video not found");
                }

                this.videoList = videoList.ToArray();
            } catch(Exception ex)
            {
                throw new Exception("Youtube Video not found!", ex);
            }
        }

        /// <summary>
        /// Updates the video information so it downloads the correct video resolution
        /// </summary>
        /// <param name="index">The index of where the videoInfo is in the videolist</param>
        public void updateInfo(int index)
        {
            this.listIndex = index;

            // Grab the video and Decipher the video if it was encrypted
            VideoInfo info = videoList[index];
            if (info.RequiresDecryption)
            {
                DownloadUrlResolver.DecryptDownloadUrl(info);
            }

            // safe-escape the string (may contain bad characters)
            name = String.Join("_", (info.Title + info.VideoExtension).Split(Path.GetInvalidFileNameChars()));
        }

        /// <summary>
        /// Downloads the video
        /// </summary>
        /// <param name="path">The Path to store it</param>
        /// <returns>Whether it was successful or not</returns>
        public bool download(string path)
        {
            try
            {
                string videoUri = path + "/" + name;

                // download the video
                VideoDownloader videoDownloader = new VideoDownloader(videoList[listIndex], videoUri);
                videoDownloader.Execute();

                return true;
            }
            catch (Exception) {  }

            return false;
        }

        /// <summary>
        /// Returns the information of type and resolution as string
        /// Purpose: to be shown in a drop-down menu
        /// </summary>
        /// <returns>A list of information regarding type and resolution</returns>
        public IEnumerable<string> getVideoDetails()
        {
            List<string> types = new List<string>();
            foreach (VideoInfo info in videoList)
            {
                types.Add("{ Type: " + info.VideoExtension + ", Resolution: " + info.Resolution + "p }");
            }
            return types;
        }

        /// <summary>
        /// Returns the name of the Video, same for every video info
        /// </summary>
        /// <returns>The name of the Video</returns>
        public string getVideoName()
        {
            return videoList.First().Title;
        }

        /// <summary>
        /// Overidden method
        /// Purpose: Displayed in list of videos as well as the downloaded video name
        /// </summary>
        /// <returns>Video's name with videoInfo</returns>
        public override string ToString()
        {
            return name;
        }

    }
}

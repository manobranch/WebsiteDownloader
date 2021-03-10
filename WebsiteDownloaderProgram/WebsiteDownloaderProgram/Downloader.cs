using System;
using System.Collections.Generic;
using System.Text;

namespace WebsiteDownloaderProgram
{
    public class Downloader
    {
        #region Startup region

        public Downloader()
        {

        }

        public void Run(string webSite)
        {
            ToScreen($"Downloading website: {webSite}");
        }

        #endregion

        #region Utility methods

        private void ToScreen(string text)
        {
            Console.WriteLine(text);
        }

        #endregion
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace WebsiteDownloaderProgram.Objects
{
    public class ImgTag
    {
        public string DirectoryLevel { get; set; }
        public string BasePath { get; set; }
        public string LinkPath { get; set; }

        public ImgTag(string directoryLevel, string basePath, string linkPath)
        {
            DirectoryLevel = directoryLevel;
            BasePath = basePath;
            LinkPath = linkPath;
        }
    }
}

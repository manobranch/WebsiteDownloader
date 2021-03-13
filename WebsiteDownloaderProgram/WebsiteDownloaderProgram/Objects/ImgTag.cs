using System;
using System.Collections.Generic;
using System.Text;

namespace WebsiteDownloaderProgram.Objects
{
    public class ImgTag
    {
        public string Path { get; set; }
        public string FileName { get; set; }

        public ImgTag()
        {

        }

        public ImgTag(string path)
        {
            Path = FormatPath(path);
            FileName = FormatFileName(Path);
        }

        internal static bool ValidateImg(string imgPath)
        {
            var formatedLinkPath = FormatPathStatic(imgPath);

            if (formatedLinkPath.ToLower().EndsWith(".svg"))
                return true;

            return false;
        }

        private string FormatPath(string path)
        {
            // "<img src=\"assets/i/delivery_teams.svg\">"
            var splittedPath = path.Split('"');

            return splittedPath[1];
        }

        private static string FormatPathStatic(string path)
        {
            // "<img src=\"assets/i/delivery_teams.svg\">"
            var splittedPath = path.Split('"');

            return splittedPath[1];
        }

        private string FormatFileName(string path)
        {
            var splittedPath = path.Split('/');
            
            return splittedPath[splittedPath.Length -1];
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WebsiteDownloaderProgram.Objects
{
    public class Atag
    {
        public string Path { get; set; }

        public Atag(string linkPath)
        {
            Path = FormatLinkPath(linkPath);
        }

        public static bool ValidateAHref(string href, string linkPath)
        {
            ////"<a href=\"/"
            var formatedLinkPath = FormatLinkPathStatic(href);

            if (formatedLinkPath.ToLower().EndsWith(".html"))
                return false;

            if (formatedLinkPath.ToLower().Contains("google"))
                return false;

            if (formatedLinkPath == linkPath)
                return false;

            if (href.StartsWith("<a href=\"/"))
                return true;
            else
                return false;
        }

        private static string FormatLinkPathStatic(string link)
        {
            //<a href=\"/who-we-are\">Who we are</a>

            var splittedLink = link.Split('"');

            return splittedLink[1];
        }

        private string FormatLinkPath(string link)
        {
            //<a href=\"/who-we-are\">Who we are</a>

            var splittedLink = link.Split('"');

            return splittedLink[1];
        }
    }
}

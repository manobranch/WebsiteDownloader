using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WebsiteDownloaderProgram.Objects
{
    public class Atag
    {
        //public string DirectoryLevel { get; set; }
        //public string BasePath { get; set; }
        public string Path { get; set; }

        private static List<string> RootLevelLinks()
        {
            return new List<string>()
            {
                "/who-we-are",
                "/what-we-do",
                "/knowledge-sharing",
                "/join",
                "/contact",
                "/events",
                "/blog",
                "/cookies",
                "/privacy-policy"
            };

        }


        public Atag(string directoryLevel, string basePath, string linkPath)
        {
            //DirectoryLevel = directoryLevel;
            //BasePath = basePath;
            Path = FormatLinkPath(linkPath);
        }

        public static bool ValidateAHref(string href, string linkPath)
        {


            ////"<a href=\"/"
            var formatedLinkPath = FormatLinkPathStatic(href);

            //if (linkPath != "root")
            //{
            //    var list = RootLevelLinks();
            //    bool b = list.Any(href.Contains);

            //    if (b)
            //    {
            //        return false;
            //    }
            //}

            //if (formatedLinkPath == "/")
            //    return false;

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

            var asdf = link.Split('"');

            return asdf[1];
        }
        private string FormatLinkPath(string link)
        {
            //<a href=\"/who-we-are\">Who we are</a>

            var asdf = link.Split('"');

            return asdf[1];
        }
    }
}

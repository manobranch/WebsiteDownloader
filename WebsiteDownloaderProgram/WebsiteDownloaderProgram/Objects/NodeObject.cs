using System;
using System.Collections.Generic;
using System.Text;

namespace WebsiteDownloaderProgram.Objects
{
    public class NodeObject
    {
        public string DirectoryLevel { get; set; }
        public string ParsedText { get; set; }
        public List<Atag> ATags { get; set; }
        public List<ImgTag> ImgTags { get; set; }

        public NodeObject(string directoryLevel, string parsedText, List<Atag> aTags, List<ImgTag> imgTags)
        {
            DirectoryLevel = directoryLevel;
            ParsedText = parsedText;
            ATags = aTags;
            ImgTags = imgTags;
        }
    }
}

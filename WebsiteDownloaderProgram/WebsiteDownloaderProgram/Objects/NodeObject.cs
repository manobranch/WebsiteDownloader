using System.Collections.Generic;

namespace WebsiteDownloaderProgram.Objects
{
    public class NodeObject
    {
        public string ParsedText { get; set; }
        public List<Atag> ATags { get; set; }
        public List<ImgTag> ImgTags { get; set; }

        public NodeObject(string parsedText, List<Atag> aTags, List<ImgTag> imgTags)
        {
            ParsedText = parsedText;
            ATags = aTags;
            ImgTags = imgTags;
        }
    }
}

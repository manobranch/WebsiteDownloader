using Dasync.Collections;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using WebsiteDownloaderProgram.Objects;

namespace WebsiteDownloaderProgram
{
    public class Downloader
    {
        #region Properties

        public static List<string> VisitedUrls { get; set; }

        #endregion

        #region Startup region

        public static async Task Run(string domain, string directory)
        {
            VisitedUrls = new List<string>();

            await GetHtml(domain, "", directory);
        }

        #endregion

        #region Download methods

        public static async Task GetHtml(string domain, string subDirectory, string folderBase)
        {
            // Set up for method
            var address = $"{domain}{subDirectory}";
            var folderPath = $"{folderBase}{subDirectory}";
            var URL = new Uri(address);

            // Basic validation 
            if (VisitedUrls.Contains(address))
                return;

            VisitedUrls.Add(address);

            if (!CreateFolder(folderPath))
                return;

            // Request URL
            ToScreen($"Requesting address: {URL}");
            HtmlWeb web = new HtmlWeb();
            HtmlDocument document = web.Load(URL);

            // Map response information
            var aTagList = GetATagList(document, subDirectory);
            var imgTagsList = GetImgList(document);
            var nodeObject = new NodeObject(document.ParsedText, aTagList, imgTagsList);

            // Download files
            await nodeObject.ImgTags.ParallelForEachAsync(async imgTag =>
            {
                using WebClient client = new WebClient();
                ToScreen($"Downloading file: {domain}/{imgTag.Path}");
                await client.DownloadFileTaskAsync(new Uri($"{domain}/{imgTag.Path}"), $"{folderPath}/{imgTag.FileName}");

            }, maxDegreeOfParallelism: 10);

            // Recursively get sub pages 
            await nodeObject.ATags.ParallelForEachAsync(async aTag =>
            {
                await GetHtml(domain, aTag.Path, folderBase);

            }, maxDegreeOfParallelism: 10);

            // Print HTML to disc
            ToScreen($"Print HTML to disc. {folderPath}");
            await PrintHtml(folderPath, nodeObject.ParsedText);
        }

        private static bool CreateFolder(string folderPath)
        {
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);

                return true;
            }
            else
            {
                return false;
            }
        }

        private static List<Atag> GetATagList(HtmlDocument document, string subDirectory)
        {
            var documentATags = new List<HtmlNode>();

            try
            {
                documentATags = document.DocumentNode.SelectNodes("//a[@href]").ToList();
            }
            catch (Exception e)
            {
                ToScreen($"Error when selecting a href nodes. Techical message: {e.Message}");
            }

            var aTagList = new List<Atag>();

            foreach (var item in documentATags)
            {
                if (Atag.ValidateAHref(item.OuterHtml, subDirectory))
                {
                    aTagList.Add(new Atag(item.OuterHtml));
                }
            }

            return aTagList;
        }

        private static List<ImgTag> GetImgList(HtmlDocument document)
        {
            var documentImages = new List<HtmlNode>();

            try
            {
                documentImages = document.DocumentNode.SelectNodes("//img[@src]").ToList();
            }
            catch (Exception e)
            {
                ToScreen($"Error when selecting img nodes. Techical message: {e.Message}");
            }

            var imgList = new List<ImgTag>();

            foreach (var item in documentImages)
            {
                if (ImgTag.ValidateImg(item.OuterHtml))
                {
                    imgList.Add(new ImgTag(item.OuterHtml));
                }
            }

            return imgList.Select(r => new ImgTag { Path = r.Path, FileName = r.FileName })
                            .GroupBy(x => x.Path)
                            .Select(x => x.First()).ToList();
        }

        public static async Task PrintHtml(string directory, string htmlText)
        {
            await File.WriteAllTextAsync($"{directory}\\SiteContent.html", htmlText);
        }

        #endregion

        #region Utility methods

        private static void ToScreen(string text)
        {
            Console.WriteLine(text);
        }

        #endregion
    }
}

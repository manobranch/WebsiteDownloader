﻿using HtmlAgilityPack;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
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

        // MNTODO Remove Counter. Useful during development
        public static int Counter { get; set; }

        #region Download methods
        public static async Task GetHtml(string domain, string subDirectory, string folderBase)
        {
            var address = $"{domain}{subDirectory}";
            var folderPath = $"{folderBase}{subDirectory}";


            if (VisitedUrls.Contains(address))
            {
                return;
            }

            VisitedUrls.Add(address);

            try
            {
                if (!Directory.Exists(folderPath))
                {
                    Counter++;
                    Directory.CreateDirectory(folderPath);
                    ToScreen($"{Counter}_ Downloading address: {address}");
                }
                else
                {
                    return;
                }

                var URL = new Uri(address);

                HtmlWeb web = new HtmlWeb();
                HtmlDocument document = web.Load(URL);

                List<HtmlNode> documentATags = new List<HtmlNode>();

                try
                {
                    documentATags = document.DocumentNode.SelectNodes("//a[@href]").ToList();
                }
                catch (Exception)
                {
                    var stophere = "asdasdf";
                }

                var aTagList = new List<Atag>();

                int smallCounter = 0;

                foreach (var item in documentATags)
                {
                    if (Atag.ValidateAHref(item.OuterHtml, subDirectory))
                    {
                        smallCounter++;

                        if (smallCounter < 15)
                            aTagList.Add(new Atag(folderBase, domain, item.OuterHtml));
                    }
                }

                // MNTODO add images
                //var imgTagsList = document.DocumentNode.SelectNodes("//img[@src]").ToList();

                var nodeObject = new NodeObject(folderBase, document.ParsedText, aTagList, new List<ImgTag>());

                foreach (var aTag in nodeObject.ATags)
                {
                    await GetHtml(domain, aTag.Path, folderBase);
                }

                await PrintHtml(folderPath, nodeObject.ParsedText);
            }
            catch (Exception e)
            {
                ToScreen(e.Message);
                throw;
            }
        }

        public static async Task PrintHtml(string directory, string htmlText)
        {
            await File.WriteAllTextAsync($"{directory}\\WriteText.txt", htmlText);
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

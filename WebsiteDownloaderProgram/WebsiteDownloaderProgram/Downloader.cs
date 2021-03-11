using HtmlAgilityPack;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WebsiteDownloaderProgram
{
    public class Downloader
    {
        #region Startup region

        public static string RootFolder { get; set; }

        public Downloader()
        {
        }

        public void Run(string address, string rootFolderName)
        {
            RootFolder = rootFolderName;
            ToScreen($"Downloading website: {address}");
            
            TheFirstTest(address);

        }

        #endregion

        #region Download methods

        private void TheFirstTest(string address)
        {
            // MNTODO make this method async
            try
            {
                Uri URL = new Uri(address);

                HtmlWeb web = new HtmlWeb();
                HtmlDocument document = web.Load(URL);

                ExamplePrint(document.ParsedText);
                
                // MNTODO: Start working with nodes
                //var nodes = document.DocumentNode.SelectNodes("//a[@href]").ToArray();

                //foreach (var item in nodes)
                //{
                //    ToScreen(item.OuterHtml);

                //    var something = "asdfasdfd";
                //}
            }
            catch (Exception e)
            {
                ToScreen(e.Message);
                throw;
            }
        }

        public static async Task ExamplePrint(string text)
        {
            await File.WriteAllTextAsync($"{RootFolder}\\WriteText.txt", text);
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

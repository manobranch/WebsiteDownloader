using System;
using System.IO;

namespace WebsiteDownloaderProgram
{
    class Program
    {
        private static string webSiteAddress = @"https://tretton37.com/";

        static void Main(string[] args)
        {
            try
            {
                if (args?.Length > 0)
                {
                    webSiteAddress = args[0];
                }

                Console.WriteLine("Starting program");

                var rootFolderName = GetRootFolderName();

                new Downloader().Run(webSiteAddress, rootFolderName);

                Console.WriteLine("Ending program");
                Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine($"Something went wrong! (The program will now end) \nTechnical message: {e.Message}");
                Console.ReadLine();
            }
        }

        static string GetRootFolderName()
        {
            string startFolderName = GetStartFolderName();

            if (!Directory.Exists(startFolderName))
            {
                Directory.CreateDirectory(startFolderName);
            }

            return startFolderName;
        }

        private static string GetStartFolderName()
        {
            return $"tretton37_{DateTime.Now.ToString("yyyy-MM-dd_HH-mm_ss")}";
        }
    }
}

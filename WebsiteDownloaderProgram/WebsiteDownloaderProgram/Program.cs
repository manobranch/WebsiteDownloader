using System;
using System.IO;

namespace WebsiteDownloaderProgram
{
    class Program
    {
        private static readonly string WebSiteAddress = @"https://tretton37.com";
        private static readonly string RootFolderName = @"tretton37";

        static void Main()
        {
            try
            {
                Console.WriteLine("Starting program");

                DeletePreviousStartFolder(RootFolderName);

                var task = Downloader.Run(WebSiteAddress, RootFolderName);
                task.Wait();

                Console.Write(" - Ending program \nPress ENTER to quit");
                Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine($"Something went wrong! (The program will now end) \nTechnical message: {e.Message}");
                Console.ReadLine();
            }
        }

        static void DeletePreviousStartFolder(string startFolderName)
        {
            if (Directory.Exists(startFolderName))
            {
                Console.WriteLine("Delete previous folder");

                Directory.Delete(startFolderName, recursive: true);
            }
        }
    }
}

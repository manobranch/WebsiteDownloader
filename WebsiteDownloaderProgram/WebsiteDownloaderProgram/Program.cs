using System;
using System.IO;

namespace WebsiteDownloaderProgram
{
    class Program
    {
        private static string WebSiteAddress = @"https://tretton37.com";
        private static string RootFolderName = @"tretton37";


        static void Main()
        {
            try
            {
                Console.WriteLine("Starting program");

                DeletePreviousStartFolder(RootFolderName);

                var task = Downloader.Run(WebSiteAddress, RootFolderName);
                task.Wait();

                Console.WriteLine("Ending program");
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
                Directory.Delete(startFolderName, recursive: true);
            }
        }
    }
}

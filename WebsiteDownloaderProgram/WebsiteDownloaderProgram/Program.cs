using System;

namespace WebsiteDownloaderProgram
{
    class Program
    {
        private static string webSite = "www.tretton37.com";

        static void Main(string[] args)
        {
            try
            {
                if (args?.Length > 0)
                {
                    webSite = args[0];
                }

                Console.WriteLine("Starting program");

                new Downloader().Run(webSite);

                Console.WriteLine("Ending program");
                Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine($"Something went wrong! (The program will now end) \nTechnical message: {e.Message}");
                Console.ReadLine();
            }
        }
    }
}

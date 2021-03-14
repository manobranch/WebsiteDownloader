# WebsiteDownloader

--- Summary of program:
This a demo project for downloading the content of website https://www.tretton37.com and its sub pages. 
Since it is a demo, html code and .svg files will be downloaded.



--- Basic design of code:
The design is fairly straight forward. The standard Program file more or less just starts the program and then call the class Downloader. 
In addition to these two classes with logic, there exists some classes to hold data.

The most central method is GetHtml, which get a web address as parameter. The HTML document for that address is received. All links to other
pages are extracted from the data and then, the code will call GetHtml again in a recursively pattern. 

In addition to get html, the GetHtml method will have call code to download images (of format .svg) and print html to local disc. The method could
have been smaller but since the program it self is fairly small, it will be ok anyway.



--- Progress in program:
As the program runs, you will see status updates. Three main kind of updates will be visisible:
   -> "Requesting address: https://tretton37.com/who-we-are"
   -> "Downloading file: https://tretton37.com/assets/i/delivery_teams.svg"
   -> "Print HTML to disc. tretton37/who-we-are"
If something goes wrong, a techical message will show. This might not be useful to the customer, but most likely to a developer.
 


--- Installation:
The console application does not really needs to be installed as such. If you as a developer are giving the program to the customer, 
simply build the solution in Visual Studio (in release mode) and give the Release folder including "WebsiteDownloaderProgram.exe" to the customer. 
You could perhaps change the name of the folder. 
Also, remember that .exe files are sometimes looked upon as virus from mail clients and such, so it better to upload the program
to some shared file server or similar.


--- Downloaded content:
The content thats gets downloaded is found in the same place as the "WebsiteDownloaderProgram.exe" is found.


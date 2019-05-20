using OpenQA.Selenium;
using OpenQA.Selenium.IE;
using System;

namespace Default.Web.Test.Automation.BrowserUtility
{
    //definition to initiate Internet Explorer browser
    class InternetExplorer : Browsers
    {
        //initiating Internet Explorer browser
        public IWebDriver initiateBrowser()
        {
            String projectDirectory = System.AppDomain.CurrentDomain.BaseDirectory;
            projectDirectory = projectDirectory.Replace("\\bin\\Debug\\", "");
            InternetExplorerDriverService service = InternetExplorerDriverService.CreateDefaultService(projectDirectory + @"\Drivers", "IEDriverServer.exe");
            Console.WriteLine("Internet Explorer Browser Instance is created");
            return new InternetExplorerDriver(service);
        }
    }

}

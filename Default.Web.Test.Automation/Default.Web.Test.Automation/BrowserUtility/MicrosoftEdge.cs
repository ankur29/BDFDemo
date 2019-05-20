using Default.Web.Test.Automation.BrowserUtility;
using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using System;

namespace Default.Web.Test.Automation.BrowserUtility
{
    class MicrosoftEdge : Browsers
    {
        //initiating Microsoft Edge browser
        public IWebDriver initiateBrowser()
        {
            String projectDirectory = System.AppDomain.CurrentDomain.BaseDirectory;
            projectDirectory = projectDirectory.Replace("\\bin\\Debug\\", "");
            EdgeDriverService service = EdgeDriverService.CreateDefaultService(projectDirectory + @"\Drivers", "MicrosoftWebDriver.exe");
            Console.WriteLine("Microsoft Edge browser Instance is created");
            return new EdgeDriver(service);
        }
    }
}

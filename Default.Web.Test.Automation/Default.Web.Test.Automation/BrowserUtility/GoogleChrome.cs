using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;

namespace Default.Web.Test.Automation.BrowserUtility
{
    //definition to initiate Chrome browser
    class GoogleChrome : Browsers
    {
        //initiating Chrome browser
        public IWebDriver initiateBrowser()
        {
            ChromeOptions opts = new ChromeOptions();
            opts.AddArgument("disable-infobars");
            opts.AddUserProfilePreference("plugins.always_open_pdf_externally", true);
            var ChromeDriver = new ChromeDriver(opts);         
            ChromeDriver.Manage().Window.Maximize();
            return ChromeDriver;
    }

        private void helpingBrowser()
        {
            String projectDirectory = System.AppDomain.CurrentDomain.BaseDirectory;
            projectDirectory = projectDirectory.Replace("\\bin\\Debug\\", "");
            ChromeDriverService service = ChromeDriverService.CreateDefaultService(projectDirectory + @"\Drivers", "chromedriver.exe");
            Console.WriteLine("Chrome Browser Instance is created");
            ChromeOptions opts = new ChromeOptions();
            opts.AddUserProfilePreference("download.default_directory", "c://temp");
            opts.AddUserProfilePreference("download.prompt_for_download", "false");
            opts.AddUserProfilePreference("pdfjs.disabled", false);

        }
    }
}

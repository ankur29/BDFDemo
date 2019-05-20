using Default.Web.Test.Automation.BrowserUtility;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Configuration;

namespace Default.Web.Test.Automation.TestCases
{
    class ManageDriver
    {
        /// <summary>
        /// select the browser
        /// </summary>
        /// <param name="browserName"></param>
        /// <returns>Instance of Iwebdriver</returns>
        public IWebDriver parallelRun(String browserName)
        {

            if (browserName.Equals("Chrome"))
            {
                // return driver instance of chrome
                GoogleChrome chrome = new GoogleChrome();
                Console.WriteLine("Chrome");
                return chrome.initiateBrowser();
            }
            else if (browserName.Equals("Firefox"))
            {
                // return driver instance of Mozilla
                MozillaFirefoxBrowser mozilla = new MozillaFirefoxBrowser();
                return mozilla.initiateBrowser();
            }
            else if (browserName.Equals("Internet Explorer"))
            {
                // return driver instance of Internet Explorer
                InternetExplorer browser = new InternetExplorer();
                return browser.initiateBrowser();
            }
            else if (browserName.Equals("Microsoft Edge"))
            {
                // return driver instance of Microsoft Edge
                MicrosoftEdge browser = new MicrosoftEdge();
                return browser.initiateBrowser();
            }
            else
            {
                Console.WriteLine(browserName + " browser is not present");
            }
            return null;

        }

        //contains browser name
        public static IEnumerable<String> parallelBrowsers()
        {
            List<String> browserList = new List<string>(ConfigurationManager.AppSettings["Browsers"].Split(new char[] { ';' }));
            //String[] browserList = { "Firefox", "Chrome" };            
            foreach (String s in browserList)
            {
                yield return s;
            }
        }


    }
}

using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Default.Web.Test.Automation.Library
{
  public class CaptureScreenshot
    {
        IWebDriver driver;
        public CaptureScreenshot(IWebDriver _driver)
        {
            driver = _driver;
        }
        public String takeScreenshot(String fileName)
        {
            ITakesScreenshot screen = driver as ITakesScreenshot;  // ITakesScreenshot is  an interface inside OpenQA.Selenium namespace
            Screenshot scrnst = screen.GetScreenshot();  // Screenshot is a class inside OpenQA.Selenium namespace
            String projectDirectory = System.AppDomain.CurrentDomain.BaseDirectory;
            projectDirectory = projectDirectory.Replace("\\bin\\Debug\\", "");
            string screenshot = projectDirectory+"/Screenshot/" + fileName+".png";
            scrnst.SaveAsFile(screenshot);
            return screenshot;
        }
    }
}

using Default.Web.Test.Automation.Entities;
using Default.Web.Test.Automation.Library;
using Default.Web.Test.Automation.ObjectRepository;
using OpenQA.Selenium;
using RelevantCodes.ExtentReports;
using System;

namespace Default.Web.Test.Automation.BusinessUitilities
{
    class LoginDweb
    {
        //Define Objects
        IWebDriver driver;
        PerformAction performAction;

        public LoginDweb(IWebDriver _driver)
        {
            driver = _driver;
            performAction = new PerformAction(driver);

        }
        //login into Application
        public ExtentTest loginToDWeb(ExtentReports report, TestData testdata)
        {
            ExtentTest loginSteps = report.StartTest("Login Steps");
            try
            {
                //Store WebElement
                IWebElement dWebLogo = performAction.getLocator(LoginPage.PRODUCTLOGO_LOGIN_XPATH, "PRODUCTLOGO_LOGIN_XPATH");
                if (dWebLogo.Displayed)
                {
                    performAction.highlightText(dWebLogo);
                    //Login Steps
                    performAction.clickButton(LoginPage.USERNAME_LOGIN_XPATH, "USERNAME_LOGIN_XPATH");
                    performAction.enterText(LoginPage.USERNAME_LOGIN_XPATH, "USERNAME_LOGIN_XPATH", testdata.UserName);
                    loginSteps.Log(LogStatus.Info, "Enter the User Name", "[" + testdata.UserName + "]");
                    performAction.clickButton(LoginPage.PASSWORD_LOGIN_XPATH, "PASSWORD_LOGIN_XPATH");
                    performAction.enterText(LoginPage.PASSWORD_LOGIN_XPATH, "PASSWORD_LOGIN_XPATH", testdata.password);
                    loginSteps.Log(LogStatus.Info, "Enter the password", "[" + testdata.password + "]");            
                    performAction.clickButton(LoginPage.LOGINBUTTON_LOGIN_XPATH, "LOGINBUTTON_LOGIN_XPATH");
                    loginSteps.Log(LogStatus.Info, "Click on Login button","");
                }

            }
            catch (Exception e)
            {
                loginSteps.Log(LogStatus.Fail, "Unable to login", e);
                var imagePath = new CaptureScreenshot(driver).takeScreenshot(testdata.testCaseName);
                loginSteps.Log(LogStatus.Info, "Snapshot below: " + loginSteps.AddScreenCapture(imagePath));
            }
            return loginSteps;
        }

        
        

        //Click on requested Link/button
        public ExtentTest clickOn(String toClick, ExtentReports report, TestData testData)
        {
            ExtentTest testSteps = report.StartTest("Click ON " + toClick);
            toClick = toClick.ToUpper();
            String[] toClickList = toClick.Split(',');
            try
            {
                for (int i = 0; i < toClickList.Length; i++)
                {
                    if (toClickList[i].Equals("USER"))
                    {
                        performAction.waitIfElementPresent(performAction.getLocator(MenuItemsPage.USERICON_EVENT_XPATH, "USERICON_EVENT_XPATH"),10);
                        performAction.clickButton(MenuItemsPage.USERICON_EVENT_XPATH, "USERICON_EVENT_XPATH");
                        testSteps.Log(LogStatus.Pass, "Click on <b>" + toClickList[i] + "</b>");
                    }
                    else if (toClickList[i].Equals("SIGNOUT"))
                    {
                        performAction.waitIfElementPresent(performAction.getLocator(MenuItemsPage.SIGNOUT_EVENT_XPATH, "SIGNOUT_EVENT_XPATH"), 10);
                        performAction.clickButton(MenuItemsPage.SIGNOUT_EVENT_XPATH, "SIGNOUT_EVENT_XPATH");
                        testSteps.Log(LogStatus.Pass, "Click on <b>" + toClickList[i] + "</b>");
                    }
                    else if (toClickList[i].Equals("ACCEPTALERT"))
                    {
                        driver.FindElement(By.XPath("//button[text()='Ok']")).Click();
                        testSteps.Log(LogStatus.Pass, "Click on <b>" + toClickList[i] + "</b>");
                    }

                    else
                    {
                        testSteps.Log(LogStatus.Fail, "Unable to click on <b>" + toClickList[i] + "</b>");

                    }

                }

            }
            catch (Exception e)
            {
                testSteps.Log(LogStatus.Fail, "Unable to Click on ", e);
                var imagePath = new CaptureScreenshot(driver).takeScreenshot(testData.testCaseName);
                testSteps.Log(LogStatus.Info, "Snapshot below: " + testSteps.AddScreenCapture(imagePath));
            }
            return testSteps;
        }
    }
}

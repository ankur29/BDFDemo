using Default.Web.Test.Automation.Entities;
using Default.Web.Test.Automation.Library;
using Default.Web.Test.Automation.ObjectRepository;
using OpenQA.Selenium;
using RelevantCodes.ExtentReports;
using System;

namespace Default.Web.Test.Automation.BusinessUitilities
{
    class ForgotPassword
    {
        //Define Objects
        IWebDriver driver;
        PerformAction performAction;

        public ForgotPassword(IWebDriver _driver)
        {
            driver = _driver;
            performAction = new PerformAction(driver);

        }

        //forgot password
        public ExtentTest forgotPasswordDWeb(ExtentReports report, TestData testdata)
        {
            ExtentTest forgotPasswordSteps = report.StartTest("Forgot Password Test");
            try
            {
                //Store WebElement
                IWebElement dWebLogo = performAction.getLocator(LoginPage.PRODUCTLOGO_LOGIN_XPATH, "PRODUCTLOGO_LOGIN_XPATH");
                //     IWebElement loginImage = performAction.getLocator(LoginPage.LOGINTITLE_LOGIN_XPATH, "LOGINTITLE_LOGIN_XPATH");
                if (dWebLogo.Displayed)
                {
                    performAction.highlightText(dWebLogo);

                    performAction.clickButton(ForgotPasswordPage.FORGOTPASSWORD_LOGIN_XPATH, "FORGOTPASSWORD_LOGIN_XPATH");
                    forgotPasswordSteps.Log(LogStatus.Info, "Click on Forgot Password Link", "");
                    performAction.clickButton(ForgotPasswordPage.EMAIL_FORGOTPASSWORD_XPATH, "EMAIL_FORGOTPASSWORD_XPATH");
                    performAction.enterText(ForgotPasswordPage.EMAIL_FORGOTPASSWORD_XPATH, "EMAIL_FORGOTPASSWORD_XPATH", testdata.UserName);
                    forgotPasswordSteps.Log(LogStatus.Info, "Enter Email", "[" + testdata.UserName + "]");
                    performAction.clickButton(ForgotPasswordPage.SEND_FORGOTPASSWORD_XPATH, "SEND_FORGOTPASSWORD_XPATH");
                    forgotPasswordSteps.Log(LogStatus.Info, "Click on Send button", "");
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return forgotPasswordSteps;
        }
    }
}

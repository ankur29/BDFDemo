using Default.Web.Test.Automation.Entities;
using Default.Web.Test.Automation.Library;
using Default.Web.Test.Automation.ObjectRepository;
using OpenQA.Selenium;
using RelevantCodes.ExtentReports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Default.Web.Test.Automation.BusinessUitilities
{
    class ResetPassword
    {
        //Define Objects
        IWebDriver driver;
        PerformAction performAction;
        public ResetPassword(IWebDriver _driver)
        {
            driver = _driver;
            performAction = new PerformAction(driver);
        }

        public ExtentTest resetForgotPassword(ExtentReports report, TestData testdata)
        {
            ExtentTest resetPasswordSteps = report.StartTest("Reset Password Steps");
            try
            {
                //Store WebElement
                IWebElement resetPasswordTitle = performAction.getLocator(ResetPasswordPage.RESETPASSWORDTITLE_RESETPASSWORD_XPATH, "RESETPASSWORDTITLE_RESETPASSWORD_XPATH");
                if (resetPasswordTitle.Displayed)
                {
                    performAction.highlightText(resetPasswordTitle);
                }
                //reset Password Steps
                performAction.enterText(ResetPasswordPage.NEWPASSWORD_RESETPASSWORD_XPATH, "SAVEBUTTON_RESETPASSWORD_XPATH",testdata.NewPassword);
                resetPasswordSteps.Log(LogStatus.Info, "Enter the New Password", "[" + testdata.NewPassword + "]");
                performAction.enterText(ResetPasswordPage.CONFIRMNEWPASSWORD_RESETPASSWORD_XPATH, "CONFIRMNEWPASSWORD_RESETPASSWORD_XPATH", testdata.ConfirmPassword);
                resetPasswordSteps.Log(LogStatus.Info, "Enter the Confirm New Password", "[" + testdata.ConfirmPassword + "]");
                performAction.clickButton(ResetPasswordPage.SAVEBUTTON_RESETPASSWORD_XPATH, "SAVEBUTTON_RESETPASSWORD_XPATH");
                resetPasswordSteps.Log(LogStatus.Info, "Click on Save button", "");

                //To Validate Error message
                String errorMessageLocator = testdata.errorMessage.ToString().Replace("||", "|").Split('|')[1];
                if (!testdata.errorMessage.ToString().Equals(""))
                {
                    verifyExpectedResult(resetPasswordSteps, errorMessageLocator);
                }
                else
                {
                    //Verify next page
                    verifyExpectedResult(resetPasswordSteps, errorMessageLocator);

                }
            }
            catch (Exception e)
            {
                resetPasswordSteps.Log(LogStatus.Fail, "Unable to login", e);
                var imagePath = new CaptureScreenshot(driver).takeScreenshot(testdata.testCaseName);
                resetPasswordSteps.Log(LogStatus.Info, "Snapshot below: " + resetPasswordSteps.AddScreenCapture(imagePath));
            }
            return resetPasswordSteps;
        }

        //Reset Old Passwor
        public ExtentTest resetOldForgotPassword(ExtentReports report, TestData testdata)
        {
            ExtentTest resetPasswordSteps = report.StartTest("Reset Old Password Steps");
            try
            {
                //Store WebElement
                IWebElement resetPasswordTitle = performAction.getLocator(ResetPasswordPage.RESETPASSWORDTITLE_RESETPASSWORD_XPATH, "RESETPASSWORDTITLE_RESETPASSWORD_XPATH");
                if (resetPasswordTitle.Displayed)
                {
                    performAction.highlightText(resetPasswordTitle);
                }
                if (resetPasswordTitle.Displayed)
                {
                    performAction.highlightText(resetPasswordTitle);
                }
                //reset Password Steps
                performAction.enterText(ResetPasswordPage.NEWPASSWORD_RESETPASSWORD_XPATH, "SAVEBUTTON_RESETPASSWORD_XPATH", testdata.NewPassword);
                resetPasswordSteps.Log(LogStatus.Info, "Enter the New Password", "[" + testdata.NewPassword + "]");
                performAction.enterText(ResetPasswordPage.CONFIRMNEWPASSWORD_RESETPASSWORD_XPATH, "CONFIRMNEWPASSWORD_RESETPASSWORD_XPATH", testdata.ConfirmPassword);
                resetPasswordSteps.Log(LogStatus.Info, "Enter the Confirm New Password", "[" + testdata.ConfirmPassword + "]");
                performAction.clickButton(ResetPasswordPage.SAVEBUTTON_RESETPASSWORD_XPATH, "SAVEBUTTON_RESETPASSWORD_XPATH");
                resetPasswordSteps.Log(LogStatus.Info, "Click on Save button", "");
                String errorMessageLocator = testdata.errorMessage.ToString().Replace("||", "|").Split('|')[2];
               
             //       verifyExpectedResult(resetPasswordSteps, errorMessageLocator);
                }
            catch (Exception e)
            {
                resetPasswordSteps.Log(LogStatus.Fail, "Unable to login", e);
                var imagePath = new CaptureScreenshot(driver).takeScreenshot(testdata.testCaseName);
                resetPasswordSteps.Log(LogStatus.Info, "Snapshot below: " + resetPasswordSteps.AddScreenCapture(imagePath));
            }
            return resetPasswordSteps;

        }

        //verify Expected Message
        private void verifyExpectedResult(ExtentTest loginSteps,String errorMessageLocator)
        {
            //for (int i = 1; i < errorMessageLocator.Length; i++)
            //{
                System.Threading.Thread.Sleep(1000);
                IWebElement errorMessage = driver.FindElement(By.XPath(errorMessageLocator));
                performAction.highlightText(errorMessage);
                loginSteps.Log(LogStatus.Pass, "Actual Message", errorMessage.Text);
            //}
        }

        public ExtentTest resetTemporaryPassword(ExtentReports report,TestData testData)
        {
            ExtentTest testSteps = report.StartTest("Reset Temporary Password Steps");
            try
            {
                performAction.clickButton(ResetPasswordPage.EMAIL_RESETPASSWORD_XPATH, "EMAIL_RESETPASSWORD_XPATH");
                performAction.enterText(ResetPasswordPage.EMAIL_RESETPASSWORD_XPATH, "EMAIL_RESETPASSWORD_XPATH", testData.UserName);
                testSteps.Log(LogStatus.Info, "Enter the Email",  testData.UserName);
                performAction.clickButton(ResetPasswordPage.CURRENTPASSWORD_RESETPASSWORD_XPATH, "CURRENTPASSWORD_RESETPASSWORD_XPATH");
                performAction.enterText(ResetPasswordPage.CURRENTPASSWORD_RESETPASSWORD_XPATH, "CURRENTPASSWORD_RESETPASSWORD_XPATH", testData.password);
                testSteps.Log(LogStatus.Info, "Enter the Current Password", testData.password);
                performAction.clickButton(ResetPasswordPage.NEWPASSWORD_RESETPASSWORD_XPATH, "NEWPASSWORD_RESETPASSWORD_XPATH");
                performAction.enterText(ResetPasswordPage.NEWPASSWORD_RESETPASSWORD_XPATH, "NEWPASSWORD_RESETPASSWORD_XPATH", testData.NewPassword);
                testSteps.Log(LogStatus.Info, "Enter the New Password", testData.NewPassword);
                performAction.clickButton(ResetPasswordPage.CONFIRMNEWPASSWORD_RESETPASSWORD_XPATH, "CONFIRMNEWPASSWORD_RESETPASSWORD_XPATH");
                performAction.enterText(ResetPasswordPage.CONFIRMNEWPASSWORD_RESETPASSWORD_XPATH, "CONFIRMNEWPASSWORD_RESETPASSWORD_XPATH", testData.ConfirmPassword);
                testSteps.Log(LogStatus.Info, "Enter the Confirm Password", testData.ConfirmPassword);
                performAction.clickButton(ResetPasswordPage.SAVEBUTTON_RESETPASSWORD_XPATH, "SAVEBUTTON_RESETPASSWORD_XPATH");
                testSteps.Log(LogStatus.Info, "Click on Save button", "");
                testData.password = testData.ConfirmPassword;

            }
            catch (Exception e)
            {
                testSteps.Log(LogStatus.Fail, "Unable to Reset Temporary Password", e);
                var imagePath = new CaptureScreenshot(driver).takeScreenshot(testData.testCaseName);
                testSteps.Log(LogStatus.Info, "Snapshot below: " + testSteps.AddScreenCapture(imagePath));
            }
            return testSteps;
        }
    }
}
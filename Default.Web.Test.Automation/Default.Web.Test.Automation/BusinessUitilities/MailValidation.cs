using Default.Web.Test.Automation.Entities;
using Default.Web.Test.Automation.Library;
using Default.Web.Test.Automation.ObjectRepository;
using OpenQA.Selenium;
using RelevantCodes.ExtentReports;
using System;

namespace Default.Web.Test.Automation.BusinessUitilities
{
    class MailValidation
    {
        //Define Objects
        IWebDriver driver;
        PerformAction performAction;
        public MailValidation(IWebDriver _driver)
        {
            driver = _driver;
            performAction = new PerformAction(driver);
        }

        
        public ExtentTest validateMail(ExtentReports report, TestData testdata)
        {
            ExtentTest testSteps = report.StartTest("Mail Validation Steps");
            
            try
            {
                    System.Threading.Thread.Sleep(1000);                
                    performAction.clickButton(MailPage.MAILVALIDATION_MAIL_XPATH, "MAILVALIDATION_MAIL_XPATH");
                    testSteps.Log(LogStatus.Info, "Click on Mail Validation Link", "");
                String s = testdata.MailValidationCount;

                int loopCount = Convert.ToInt32(testdata.MailValidationCount.Split(',')[0]);
                    String barCodeNumber = testdata.MailValidationCount.Split(',')[1];
                if (barCodeNumber.Equals("REQUESTMAILID"))
                {
                    barCodeNumber = testdata.MailingId;
                }else if (barCodeNumber.Equals("INVALIDBARNUMBER"))
                {
                    barCodeNumber = barCodeNumber;
                }
            else if (barCodeNumber.Equals("CERTIFIEDNUMBER"))
            {
                barCodeNumber =testdata.CertifiedNumber;
            }
                else if (barCodeNumber.Equals("MAILID"))
                {
                    barCodeNumber = testdata.Id;
                }

                for (int i = 0; i < loopCount; i++)
                    {
                        performAction.enterText(MailPage.BARCODENUMBERINPUT_MAILVALIDATION_XPATH, "BARCODENUMBERINPUT_MAILVALIDATION_XPATH", barCodeNumber);
                        testSteps.Log(LogStatus.Info, "Enter Bar Code Number", barCodeNumber);
                        performAction.clickButton(MailPage.ENTERBUTTON_MAILVALIDATION_XPATH, "ENTERBUTTON_MAILVALIDATION_XPATH");
                        testSteps.Log(LogStatus.Info, "Click on Enter Button", "");
                        System.Threading.Thread.Sleep(1000);
                        performAction.highlightText(driver.FindElement(By.XPath("//tbody/tr/td[2]")));
                        testSteps.Log(LogStatus.Info, "Validate Id", driver.FindElement(By.XPath("//tbody/tr/td[2]")).Text);
                    }               
            }
            catch (Exception e)
            {
                testSteps.Log(LogStatus.Fail, "Unable to verify the data on Mail History Page", e);
                var imagePath = new CaptureScreenshot(driver).takeScreenshot(testdata.testCaseName);
                testSteps.Log(LogStatus.Info, "Snapshot below: " + testSteps.AddScreenCapture(imagePath));
            }
            return testSteps;
        }

    }
}

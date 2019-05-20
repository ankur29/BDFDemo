using Default.Web.Test.Automation.BrowserUtility;
using Default.Web.Test.Automation.BusinessUitilities;
using Default.Web.Test.Automation.Entities;
using Default.Web.Test.Automation.Library;
using Default.Web.Test.Automation.ObjectRepository;
using Default.Web.Test.Automation.ReportUtility;
using NUnit.Framework;
using OpenQA.Selenium;
using RelevantCodes.ExtentReports;
using System;
using System.Collections.Generic;
using System.Configuration;

namespace Default.Web.Test.Automation.TestCases
{
    [TestFixture]
    [Parallelizable]
    class ResetPasswordTestCases : ReportGenerator
    {
        //Define Objects
        IWebDriver driver;
        ManageDriver manageDriver = new ManageDriver();
        ExtentTest test, systemHealthCheck, forgotPasswordSteps,resetPasswordSteps,forgotOldPasswordSteps, resetOldPasswordSteps;
        ReportGenerator reportGenerator = new ReportGenerator();
        ReadTestData readTestData = new ReadTestData();
        PerformAction performAction;
        LoginDweb loginDWeb;
        ResetPassword resetPass;
        Dictionary<string, string> testDataMap;
        public List<string> keys;
        int columnCount;
        TestData testData;

        [SetUp]
        //Read Test data from excel
        public void setupConfigurations()
        {
            try
            {
                Console.WriteLine("Setup Test Configurations");
                testDataMap = readTestData.readExcelData("Reset Password");
                keys = readTestData.keyCount;
                totalTestCases = readTestData.keyCount;
                Console.WriteLine(totalTestCases);
                if (totalTestCases.Count == 0)
                {
                    test = report.StartTest("Exception in reading Test Data");
                    ExtentTest exception = report.StartTest("Exception");
                    exception.Log(LogStatus.Warning, "Unable to execute Test Cases as no Test Case is marked Y");
                    storeReport(exception);
                    return;
                }
            }
            catch (Exception e)
            {
                test = report.StartTest("Exception in reading Test Data");
                ExtentTest exception = report.StartTest("Exception");
                exception.Log(LogStatus.Error, e.ToString());
                storeReport(exception);
            }
        }

        private void storeReport(ExtentTest exception)
        {
            test.AppendChild(exception);
            report.EndTest(test);
            report.Flush();
        }


        [Test]
        //providing browser details
        [TestCaseSource(typeof(ManageDriver), "parallelBrowsers")]
        public void resetPassword(String browserName)
        {
            String appUrl = ConfigurationManager.AppSettings["DEV_URL"];
            testData = new TestData();
            for (int i = 0; i < totalTestCases.Count; i++)
            {
                test = report.StartTest(testDataMap["TestCaseName_" + keys[i]], "");
                //Application health check
                systemHealthCheck = EnvironmentHealthCheck.checkUrlStatus(appUrl, report);
                Console.WriteLine(systemHealthCheck.GetCurrentStatus().ToString());
                if (systemHealthCheck.GetCurrentStatus().ToString().Equals("Pass"))
                {
                    driver = manageDriver.parallelRun(browserName);
                    performAction = new PerformAction(driver);
                    test.AssignCategory(testData.methodName + "-" + browserName + performAction.getBrowserVersion()); test.AssignCategory(testDataMap["Method Name_" + keys[i]]);
                    Console.WriteLine("Assigned");
                    testData.UserName = testDataMap["Username_" + keys[i]];
                    testData.errorMessage = testDataMap["ExpectedErrorMessage_" + keys[i]];
                    testData.validateDBValues = testDataMap["ValidateDBDetails_" + keys[i]];
                    testData.NewPassword = testDataMap["NewPassword_" + keys[i]];
                    testData.ConfirmPassword = testDataMap["ConfirmPassword_" + keys[i]];
                     testData.ExecutionSteps= testDataMap["ExecutionSteps_" + keys[i]];
                    testData.methodName = testDataMap["Method Name_" + keys[i]];

                    String password;
                    //set a dynamic password
                    if (testData.NewPassword.Equals("generateNewPassword()") & testData.ConfirmPassword.Equals("generateNewPassword()"))
                    {
                        password = CreateDynamicPassword.getPassword();
                        testData.NewPassword = password;
                        testData.ConfirmPassword = password;
                    }
                    forgotPasswordSteps=applyForgotPassword(appUrl);
                    string resetPasswordLink = getResetPasswordLink();
                    //open reset password link
                    new TestRunner(driver).openApplication(resetPasswordLink, 6);
                    System.Threading.Thread.Sleep(2000);
                    resetPass = new ResetPassword(driver);
                    resetPasswordSteps = resetPass.resetForgotPassword(report, testData);

                    if (testData.ExecutionSteps.Equals("resetOldPassword()"))
                    {
                        forgotOldPasswordSteps = applyForgotPassword(appUrl);
                        string resetOldPasswordLink = getResetPasswordLink();
                        //open reset password link
                        resetOldPasswordSteps=applyResetPasswordLink(resetOldPasswordLink);
                        //writing report
                        test.AppendChild(systemHealthCheck).AppendChild(forgotPasswordSteps).AppendChild(resetPasswordSteps).AppendChild(forgotOldPasswordSteps).AppendChild(resetOldPasswordSteps);
                    }else if (testData.ExecutionSteps.Equals("resetExpiredLink()"))
                    {
                        forgotOldPasswordSteps = applyForgotPassword(appUrl);
                        string resetOldPasswordLink = getResetPasswordLink();
                        //open reset password link
                        resetOldPasswordSteps = applyResetPasswordLink(resetPasswordLink);
                        //writing report
                        test.AppendChild(systemHealthCheck).AppendChild(forgotPasswordSteps).AppendChild(resetPasswordSteps).AppendChild(forgotOldPasswordSteps).AppendChild(resetOldPasswordSteps);
                    }
                    else
                    {
                        //writing report
                        test.AppendChild(systemHealthCheck).AppendChild(forgotPasswordSteps).AppendChild(resetPasswordSteps);          
                    }
                    report.EndTest(test);
                    report.Flush();
                    driver.Close();
                }
                else
                {
                    passedTestCases.Add(keys[i].ToString());
                    Console.WriteLine("keys[i]=" + keys[i]);
                    test.AppendChild(systemHealthCheck);
                    report.EndTest(test);
                    report.Flush();
                    continue;
                }

            }
        }

        private ExtentTest applyResetPasswordLink(string resetOldPasswordLink)
        {
            new TestRunner(driver).openApplication(resetOldPasswordLink, 6);
            System.Threading.Thread.Sleep(2000);
            resetPass = new ResetPassword(driver);
            return resetPass.resetOldForgotPassword(report, testData);
        }

        private ExtentTest applyForgotPassword(string appUrl)
        {
            new TestRunner(driver).openApplication(appUrl, 6);
            ForgotPassword forgotPassword = new ForgotPassword(driver);
            return forgotPassword.forgotPasswordDWeb(report, testData);
        }

        private string getResetPasswordLink()
        {
            new TestRunner(driver).openApplication("https://mail.protonmail.com/login", 6);
            System.Threading.Thread.Sleep(30000);
            driver.FindElement(By.XPath(WebMailPage.USERNAME_PROTONMAIL_XPATH)).SendKeys("bdftester@protonmail.com");
            driver.FindElement(By.XPath(WebMailPage.PASSWORD_PROTONMAIL_XPATH)).SendKeys("$Dell2019");
            driver.FindElement(By.XPath(WebMailPage.LOGINBUTTON_PROTONMAIL_XPATH)).Click();
            System.Threading.Thread.Sleep(5000);
            driver.FindElement(By.XPath(WebMailPage.SEARCHMESSAGE_PROTONMAIL_XPATH)).SendKeys("Password Recovery");
            driver.FindElement(By.XPath(WebMailPage.SEARCHFORM_PROTONMAIL_XPATH)).Click();
            System.Threading.Thread.Sleep(1000);
            driver.FindElement(By.XPath(WebMailPage.FIRSTEMAIL_PROTONMAIL_XPATH)).Click();
            System.Threading.Thread.Sleep(8000);
            IWebElement webl = driver.FindElement(By.XPath("//div[2]/div[3]/div"));
            String text = webl.Text;

            IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;
            Console.WriteLine(text);
            
            String emailLink = text.Split(new string[] { "http" }, StringSplitOptions.None)[1].Split(new string[] {"This" }, StringSplitOptions.None)[0];


            String resetPasswordLink = "http"+emailLink;
      //      Console.WriteLine(resetPasswordLink);
            return resetPasswordLink;
        }
    }


}

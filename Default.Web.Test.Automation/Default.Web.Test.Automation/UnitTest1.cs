using Default.Web.Test.Automation.BrowserUtility;
using Default.Web.Test.Automation.BusinessUitilities;
using Default.Web.Test.Automation.DatabaseManager;
using Default.Web.Test.Automation.Entities;
using Default.Web.Test.Automation.Library;
using Default.Web.Test.Automation.ReportUtility;
using Default.Web.Test.Automation.TestCases;
using NUnit.Framework;
using OpenQA.Selenium;
using RelevantCodes.ExtentReports;
using System;
using System.Collections.Generic;
using System.Configuration;

namespace Default.Web.Test.Automation.TestCases
{
    [TestFixture]
  //  [Parallelizable]
    class UnitTest1 : ReportGenerator
    {
        //Define Objects
        IWebDriver driver;
        ManageDriver manageDriver = new ManageDriver();
        ExtentTest test, systemHealthCheck, loginSteps;
        ReportGenerator reportGenerator = new ReportGenerator();
        ReadTestData readTestData = new ReadTestData();
        PerformAction performAction;
        LoginDweb loginDWeb;
        Dictionary<String, String> testDataMap;
        public List<string> keys;
        TestData testData;

        [SetUp]
        //Read Test data from excel
        public void setupConfigurations()
        {
            try
            {
                Console.WriteLine("Setup Test Configurations");
                testDataMap = readTestData.readExcelData("Login");
                keys = readTestData.keyCount;
                totalTestCases = readTestData.keyCount;
                if (totalTestCases.Count==0)
                {
                    test = report.StartTest("Exception in reading Test Data");
                    ExtentTest exception = report.StartTest("Exception");
                    exception.Log(LogStatus.Warning, "Unable to execute Test Cases as no Test Case is marked Y");
                    reportGenerator.storeReport(test,exception);                   
                    return;
                }
            }
            catch (Exception e)
            {
                test = report.StartTest("Exception in reading Test Data");
                ExtentTest exception = report.StartTest("Exception");
                exception.Log(LogStatus.Error,e.ToString());
                reportGenerator.storeReport(test, exception);
            }
        }


        [Test]
        //providing browser details
        [TestCaseSource(typeof(ManageDriver), "parallelBrowsers")]
        //Test cases steps
        public void loginTC(String browserName)
        {
            String appUrl = ConfigurationManager.AppSettings["DEV_URL"];
            testData = new TestData();
            for (int i = 0; i < totalTestCases.Count; i++)
            {
                //set Test Data
                test = report.StartTest(testDataMap["TestCaseName_" + keys[i]], "");
                testData.testCaseName = testDataMap["TestCaseName_" + keys[i]];
                testData.UserName = testDataMap["Username_" + keys[i]];
                testData.password = testDataMap["Password_" + keys[i]];
                testData.errorMessage = testDataMap["ExpectedErrorMessage_" + keys[i]];
                testData.validateDBValues = testDataMap["ValidateDBDetails_" + keys[i]];
                testData.executionSteps = testDataMap["ExecutionSteps_" + keys[i]];
                testData.methodName = testDataMap["Method Name_" + keys[i]];
               
                //assign browser
                driver = manageDriver.parallelRun(browserName);
                performAction = new PerformAction(driver);
                test.AssignCategory(testData.methodName + "-" + browserName+ performAction.getBrowserVersion());

                //initiate classes
                CommonUtility commonUtility = new CommonUtility(driver);

                String executionSteps = testData.executionSteps;
                String[] executionStepsList = executionSteps.Replace("||", "|").Split('|');
                //execute keywords
                for (int executionCounter = 0; executionCounter < executionStepsList.Length; executionCounter++)
                {
                    if (executionStepsList[executionCounter].ToUpper().Equals("SYSTEMHEALTHCHECK"))
                    {
                        //Application health check
                        systemHealthCheck = EnvironmentHealthCheck.checkUrlStatus(appUrl, report);
                        if (systemHealthCheck.GetCurrentStatus().ToString().Equals("Fail"))
                        {
                            test.AppendChild(systemHealthCheck);
                            break;
                        }
                        else
                        {
                            test.AppendChild(systemHealthCheck);
                        }
                        //Login into DWeb Application
                    } else if (executionStepsList[executionCounter].ToUpper().Equals("LOGINDWEB") || executionStepsList[executionCounter].ToUpper().Equals("LOGIN"))
                    {
                        //open application URL
                        new TestRunner(driver).openApplication(appUrl, 6);
                        loginDWeb = new LoginDweb(driver);
                        loginSteps = loginDWeb.loginToDWeb(report, testData);
                        if (loginSteps.GetCurrentStatus().ToString().Equals("Fail"))
                        {
                            test.AppendChild(loginSteps);
                            break;
                        }
                        else
                        {
                            test.AppendChild(loginSteps);
                        }
                        
                    } else if (executionStepsList[executionCounter].ToUpper().Contains("VERIFYEXPECTEDMESSAGE"))
                    {
                        String messageNeedToVerify = executionStepsList[executionCounter].ToUpper().Replace(")", "").Replace("(", "").Replace("VERIFYEXPECTEDMESSAGE", "");
                        Console.WriteLine("messageNeedToVerify=" + messageNeedToVerify);
                        ExtentTest verifyExpectedMessage = commonUtility.verifyExpectedResult(messageNeedToVerify, testData, report);
                        if (verifyExpectedMessage.GetCurrentStatus().ToString().Equals("Fail"))
                        {
                            test.AppendChild(verifyExpectedMessage);
                            break;
                        }
                        else
                        {
                            test.AppendChild(verifyExpectedMessage);
                        }
                    } else if (executionStepsList[executionCounter].ToUpper().Contains("CLICKON"))
                    {
                        String toClick = executionStepsList[executionCounter].ToUpper().Replace("CLICKON", "").Replace("(", "").Replace(")", "");
                       ExtentTest testSteps = loginDWeb.clickOn(toClick, report, testData);
                        if (testSteps.GetCurrentStatus().ToString().Equals("Fail"))
                        {
                            test.AppendChild(testSteps);
                            break;
                        }
                        else
                        {
                            test.AppendChild(testSteps);
                        }
                    } else if (executionStepsList[executionCounter].ToUpper().Contains("VALIDATEDB"))
                    {
                        String dbToValidate = executionStepsList[executionCounter].Replace("(", "").Replace(")", "").Replace("ValidateDB", "");
                        VerifyDatabase verifyDatabase = new VerifyDatabase();
                        ExtentTest testSteps = verifyDatabase.checkDBDetails(dbToValidate, testData, report);
                        test.AppendChild(testSteps);
                    }
                    else
                    {
                        ExtentTest testSteps = report.StartTest("Execution Steps Status");
                        testSteps.Log(LogStatus.Fail, "Unable to execute [" + executionStepsList[executionCounter] + "]  execution step.","");
                        reportGenerator.storeReport(test, testSteps);
                        return;
                    }
                }
                driver.Close();
                report.EndTest(test);
                report.Flush();
            }
        }
    }
}

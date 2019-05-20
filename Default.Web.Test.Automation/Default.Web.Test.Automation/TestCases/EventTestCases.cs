using Default.Web.Test.Automation.BrowserUtility;
using Default.Web.Test.Automation.BusinessUitilities;
using Default.Web.Test.Automation.Entities;
using Default.Web.Test.Automation.Library;
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
    class EventTestCases : ReportGenerator
    {
        //Define Objects
         IWebDriver driver;
        ManageDriver manageDriver = new ManageDriver();
        ExtentTest test, systemHealthCheck, loginSteps;
        ReportGenerator reportGenerator = new ReportGenerator();
        ReadTestData readTestData = new ReadTestData();
        LoginDweb loginDWeb;
      
        Dictionary<String, String> testDataMap;
        public List<string> keys;
        TestData testData;

        public object EventMaintenace { get; private set; }

        [SetUp]
        //Read Test data from excel
        public void setupConfigurations()
        {
            try
            {
                Console.WriteLine("Setup Test Configurations");
                testDataMap = readTestData.readExcelData("Event");
                keys = readTestData.keyCount;
                totalTestCases = readTestData.keyCount;
                if (totalTestCases.Count == 0)
                {
                    test = report.StartTest("Exception in reading Test Data");
                    ExtentTest exception = report.StartTest("Exception");
                    exception.Log(LogStatus.Warning, "Unable to execute Test Cases as no Test Case is marked Y");
                    reportGenerator.storeReport(test, exception);
                    return;
                }
            }
            catch (Exception e)
            {
                test = report.StartTest("Exception in reading Test Data");
                ExtentTest exception = report.StartTest("Exception");
                exception.Log(LogStatus.Error, e.ToString());
                reportGenerator.storeReport(test, exception);
            }
        }

        [Test]
        //providing browser details
        [TestCaseSource(typeof(ManageDriver), "parallelBrowsers")]
        //Test cases steps
        public void eventScheduling(String browserName)
        {
            testData = new TestData();
            for (int i = 0; i < totalTestCases.Count; i++)
            {
                String appUrl = ConfigurationManager.AppSettings["DEV_URL"];
                //set Test Data
                test = report.StartTest(testDataMap["TestCaseName_" + keys[i]], "");
                testData.testCaseName = testDataMap["TestCaseName_" + keys[i]];
                testData.UserName = testDataMap["Username_" + keys[i]];
                testData.password = testDataMap["Password_" + keys[i]];
                testData.errorMessage = testDataMap["ExpectedErrorMessage_" + keys[i]];
                testData.validateDBValues = testDataMap["ValidateDBDetails_" + keys[i]];
                testData.executionSteps = testDataMap["ExecutionSteps_" + keys[i]];
                testData.methodName = testDataMap["Method Name_" + keys[i]];
                testData.EventCode = testDataMap["EventCode_" + keys[i]];
                testData.EventName = testDataMap["EventName_" + keys[i]];
                testData.ModifiedName = testDataMap["ModifiedName_" + keys[i]];
                testData.Milestone = testDataMap["Milestone_" + keys[i]];
                testData.PageCount = testDataMap["PageCount_" + keys[i]];
                testData.Name = testDataMap["TestCaseName_" + keys[i]];
                testData.DeactivateReason = testDataMap["DeactivateReason_" + keys[i]];
                testData.ReactivateReason = testDataMap["ReactivateReason_" + keys[i]];


                if (testData.EventCode.Equals("DynamicEventCode"))
                {
                    Random random = new Random();
                    testData.EventCode ="E"+Convert.ToString( random.Next(10000));
                }


                //assign browser
                driver = manageDriver.parallelRun(browserName);
               PerformAction performAction = new PerformAction(driver);
                test.AssignCategory(testData.methodName + "-" + browserName + performAction.getBrowserVersion());


                //initiate classes
                CommonUtility commonUtility = new CommonUtility(driver);
                EventMaintenance eventMaintenance=new EventMaintenance(driver);

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
                    }
                    else if (executionStepsList[executionCounter].ToUpper().Equals("LOGINDWEB"))
                    {
                        //open application URL
                        new TestRunner(driver).openApplication(appUrl, 6);
                        loginDWeb = new LoginDweb(driver);
                        ExtentTest testSteps = loginDWeb.loginToDWeb(report, testData);
                        if (testSteps.GetCurrentStatus().ToString().Equals("Fail"))
                        {
                            test.AppendChild(testSteps);
                            break;
                        }
                        else
                        {
                            test.AppendChild(testSteps);
                        }
                    }
                    else if (executionStepsList[executionCounter].ToUpper().Contains("VERIFYEXPECTEDMESSAGE"))
                    {
                        String messageNeedToVerify = executionStepsList[executionCounter].ToUpper().Replace(")", "").Replace("(", "").Replace("VERIFYEXPECTEDMESSAGE", "");
                        Console.WriteLine("messageNeedToVerify=" + messageNeedToVerify);

                        ExtentTest testSteps = commonUtility.verifyExpectedResult(messageNeedToVerify, testData, report);
                        if (testSteps.GetCurrentStatus().ToString().Equals("Fail"))
                        {
                            test.AppendChild(testSteps);
                            break;
                        }
                        else
                        {
                            test.AppendChild(testSteps);
                        }
                    }
                    else if (executionStepsList[executionCounter].ToUpper().Contains("CLICKON"))
                    {
                        String toClick = executionStepsList[executionCounter].ToUpper().Replace("CLICKON", "").Replace("(", "").Replace(")", "");
                        ExtentTest testSteps = eventMaintenance.clickOn(toClick, report, testData);
                        if (testSteps.GetCurrentStatus().ToString().Equals("Fail"))
                        {
                            test.AppendChild(testSteps);
                            break;
                        }
                        else
                        {
                            test.AppendChild(testSteps);
                        }
                    }
                    else if (executionStepsList[executionCounter].ToUpper().Contains("ADDEVENT"))
                    {
                        ExtentTest testSteps = eventMaintenance.eventAdd(report, testData);
                        if (testSteps.GetCurrentStatus().ToString().Equals("Fail"))
                        {
                            test.AppendChild(testSteps);
                            break;
                        }
                        else
                        {
                            test.AppendChild(testSteps);
                        }
                    }
                    else if (executionStepsList[executionCounter].ToUpper().Contains("SEARCHEVENT"))
                    {
                        testData.Filters = executionStepsList[executionCounter].ToUpper().Replace("(", "").Replace(")", "").Replace("SEARCHEVENT","");
                        ExtentTest testSteps = eventMaintenance.EventSearch(report, testData);
                        if (testSteps.GetCurrentStatus().ToString().Equals("Fail"))
                        {
                            test.AppendChild(testSteps);
                            break;
                        }
                        else
                        {
                            test.AppendChild(testSteps);
                        }
                    }
                    else if (executionStepsList[executionCounter].Contains("EventList"))
                    {
                        ExtentTest testReport = eventMaintenance.EventList(report, testData);
                        test.AppendChild(testReport);
                    }
                    else if (executionStepsList[executionCounter].Contains("ModifyEvent"))
                    {
                        ExtentTest testReport = eventMaintenance.ModifyEvent(report, testData);
                        test.AppendChild(testReport);
                    }
                    else if (executionStepsList[executionCounter].ToUpper().Contains("DEACTIVATEEVENT") || executionStepsList[executionCounter].ToUpper().Contains("REACTIVATEEVENT"))
                    {
                        testData.EventState = executionStepsList[executionCounter].ToUpper();
                        ExtentTest testReport = eventMaintenance.DeactivateEvent(report, testData);
                        test.AppendChild(testReport);
                    }
                    else
                    {
                        ExtentTest testSteps = report.StartTest("Execution Steps Status");
                        testSteps.Log(LogStatus.Fail, "Unable to execute [" + executionStepsList[executionCounter] + "]  execution step.", "");
                        reportGenerator.storeReport(test, testSteps);
                        break;
                    }
                }
                    driver.Close();               
                    report.EndTest(test);
                    report.Flush();
            }


        }
    }
}

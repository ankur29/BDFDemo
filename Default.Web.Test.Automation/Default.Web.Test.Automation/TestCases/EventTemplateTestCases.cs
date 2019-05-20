using Default.Web.Test.Automation.BrowserUtility;
using Default.Web.Test.Automation.BusinessUitilities;
using Default.Web.Test.Automation.DatabaseManager;
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
    class EventTemplateTestCases : ReportGenerator
    {
        //Define Objects
        IWebDriver driver;
        ManageDriver manageDriver = new ManageDriver();
        ReportGenerator reportGenerator = new ReportGenerator();
        ReadTestData readTestData = new ReadTestData();
        ExtentTest test;
        PerformAction performAction;
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
                testDataMap = readTestData.readExcelData("EventTemplate");
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
        public void eventTemplate(String browserName)
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
                testData.OrganizationName = testDataMap["OrganizationName_" + keys[i]];
                testData.StartDate = testDataMap["StartDate_" + keys[i]];
                testData.EndDate = testDataMap["EndDate_" + keys[i]];
                testData.IsPrimaryEvent = testDataMap["IsPrimaryEvent_" + keys[i]];
                testData.TemplateCode= testDataMap["TemplateCode_" + keys[i]];
                testData.ShowActiveEvents = testDataMap["ShowActive_" + keys[i]];


                if (testData.TemplateCode.Equals("DynamicTemplateCode"))
                {
                    testData.TemplateCode = CreateDynamicPassword.setDynamicData("T", 10000);
                }
                if (testData.EventCode.Equals("DynamicEventCode"))
                {
                    testData.EventCode = CreateDynamicPassword.setDynamicData("E", 10000);

                }
                //assign browser
                driver = manageDriver.parallelRun(browserName);
                PerformAction performAction = new PerformAction(driver);
                test.AssignCategory(testData.methodName + "-" + browserName + performAction.getBrowserVersion());


                //initiate classes
                CommonUtility commonUtility = new CommonUtility(driver);
                EventMaintenance eventMaintenance = new EventMaintenance(driver);
                EventTemplate eventTemplate = new EventTemplate(driver);


                String executionSteps = testData.executionSteps;
                String[] executionStepsList = executionSteps.Replace("||", "|").Split('|');
                //execute keywords
                for (int executionCounter = 0; executionCounter < executionStepsList.Length; executionCounter++)
                {
                    if (executionStepsList[executionCounter].ToUpper().Equals("SYSTEMHEALTHCHECK"))
                    {
                        //Application health check
                        ExtentTest systemHealthCheck = EnvironmentHealthCheck.checkUrlStatus(appUrl, report);
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
                        LoginDweb loginDWeb = new LoginDweb(driver);
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
                        ExtentTest testSteps = eventTemplate.clickOn(toClick, report, testData);
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
                    else if (executionStepsList[executionCounter].ToUpper().Equals("ADDEVENT"))
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
                    else if (executionStepsList[executionCounter].ToUpper().Contains("ADDTEMPLATE"))
                    {
                        ExtentTest testSteps = eventTemplate.addTemplate(report, testData);
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
                    else if (executionStepsList[executionCounter].ToUpper().Equals("ADDEVENTTOTEMPLATE"))
                    {
                        ExtentTest testSteps = eventTemplate.addEventToTemplate(report, testData);
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
                    else if (executionStepsList[executionCounter].ToUpper().Contains("FINDEVENT"))
                    {
                        ExtentTest testSteps = report.StartTest("Event Find Steps");
                         testSteps = eventTemplate.findEvent(testSteps, testData);
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

                    else if (executionStepsList[executionCounter].ToUpper().Contains("VALIDATEDB"))
                    {
                        String dbToValidate = executionStepsList[executionCounter].Replace("(", "").Replace(")", "").Replace("ValidateDB", "");
                        VerifyDatabase verifyDatabase = new VerifyDatabase();
                        ExtentTest testSteps = verifyDatabase.checkDBDetails(dbToValidate, testData, report);
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



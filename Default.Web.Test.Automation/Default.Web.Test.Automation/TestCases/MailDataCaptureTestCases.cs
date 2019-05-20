using Default.Web.Test.Automation.BrowserUtility;
using Default.Web.Test.Automation.BusinessUitilities;
using Default.Web.Test.Automation.DatabaseManager;
using Default.Web.Test.Automation.Entities;
using Default.Web.Test.Automation.Library;
using Default.Web.Test.Automation.ReportUtility;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using RelevantCodes.ExtentReports;
using System;
using System.Collections.Generic;
using System.Configuration;


namespace Default.Web.Test.Automation.TestCases
{
    [TestFixture]
    [Parallelizable]
    class MailDataCaptureTestCases : ReportGenerator
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
        int columnCount;
        TestData testData;

        [SetUp]
        //Read Test data from excel
        public void setupConfigurations()
        {
            try
            {
                Console.WriteLine("Setup Test Configurations");
                testDataMap = readTestData.readExcelData("Mail");
                keys = readTestData.keyCount;
                totalTestCases = readTestData.keyCount;
                Console.WriteLine(totalTestCases);
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
        public void mailData(String browserName)
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
                testData.MailingDate = testDataMap["MailingDate_" + keys[i]];
                testData.MailDescription = testDataMap["MailDescription_" + keys[i]];
                testData.PrimaryFirstName = testDataMap["PrimaryFirstName_" + keys[i]];
                testData.PrimaryLastName = testDataMap["PrimaryLastName_" + keys[i]];
                testData.OrganizationAddress1 = testDataMap["OrganizationAddress1_" + keys[i]];
                testData.OrganizationAddress2 = testDataMap["OrganizationAddress2_" + keys[i]];
                testData.Zipcode = testDataMap["Zipcode_" + keys[i]];
                testData.City = testDataMap["City_" + keys[i]];
                testData.State = testDataMap["State_" + keys[i]];
                testData.MailType = testDataMap["MailType_" + keys[i]];
                testData.MailService = testDataMap["MailService_" + keys[i]];
                testData.MailEnclosure = testDataMap["MailEnclosure_" + keys[i]];
                testData.DocumentName = testDataMap["DocumentName_" + keys[i]];
                testData.Banner = testDataMap["Banner_" + keys[i]];
                testData.RetainDocument = testDataMap["RetainDocument_" + keys[i]];
                testData.SelectAll = testDataMap["SelectAll_" + keys[i]];
                testData.ReferenceNumber = testDataMap["ReferenceNumber_" + keys[i]];
                testData.BarCodeNumber = testDataMap["BarCodeNumber_" + keys[i]];



                if (testData.MailingDate.Equals("Dynamicdate"))
                {
                    testData.MailingDate=DateTime.Today.ToString("MM-dd-yyyy");
                }
                if (testData.ReferenceNumber.Equals("DynamicReferenceNumber"))
                {
                    testData.ReferenceNumber = DateTime.Now.ToString("yyyyMMddHHmmss");
                    Console.WriteLine(testData.ReferenceNumber);
                }

                //assign browser
                driver = manageDriver.parallelRun(browserName);
                performAction = new PerformAction(driver);
                test.AssignCategory(testData.methodName + "-" + browserName + performAction.getBrowserVersion());

                //initiate classes
                CommonUtility commonUtility = new CommonUtility(driver);
                MailDataActions mailDataActions = new MailDataActions(driver);
                MailHistory mailHistory = new MailHistory(driver);
                MailReconciliation mailReconciliation = new MailReconciliation(driver);
                MailValidation mailValidation = new MailValidation(driver);



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
                    else if (executionStepsList[executionCounter].ToUpper().Equals("LOGINDWEB") || executionStepsList[executionCounter].ToUpper().Equals("LOGIN"))
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

                    }
                    else if (executionStepsList[executionCounter].ToUpper().Contains("VERIFYEXPECTEDMESSAGE"))
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
                    }
                    else if (executionStepsList[executionCounter].ToUpper().Contains("CLICKON"))
                    {
                        String toClick = executionStepsList[executionCounter].ToUpper().Replace("CLICKON", "").Replace("(", "").Replace(")", "");
                        ExtentTest testSteps = mailDataActions.clickOn(toClick, report, testData);
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
                    else if (executionStepsList[executionCounter].ToUpper().Contains("SEARCHMAILHISTORY"))
                    {
                        ExtentTest testSteps = mailHistory.searchMailHistory(report, testData);
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
                    else if (executionStepsList[executionCounter].ToUpper().Contains("MAILRECONCILIATION"))
                    {
                        ExtentTest testSteps = mailReconciliation.reconcileMail(report, testData);
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
                    else if (executionStepsList[executionCounter].ToUpper().Contains("MAILVALIDATION"))
                    {
                        testData.MailValidationCount = executionStepsList[executionCounter].ToUpper().Replace("MAILVALIDATION", "").Replace("(", "").Replace(")","");
                        ExtentTest testSteps = mailValidation.validateMail(report, testData);
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
                    else if (executionStepsList[executionCounter].ToUpper().Contains("VALIDATEPAGINATION"))
                    {
                        testData.PaginationCount = executionStepsList[executionCounter].ToUpper().Replace("(", "").Replace(")", "").Replace("VALIDATEPAGINATION", "");
                        ExtentTest testSteps = mailHistory.validatePaginationResult(report, testData);
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
                    else if (executionStepsList[executionCounter].ToUpper().Contains("SCHEDULEMAIL"))
                    {
                        ExtentTest testReport = mailDataActions.scheduleMail(report, testData);
                        test.AppendChild(testReport);
                    } else if (executionStepsList[executionCounter].ToUpper().Contains("SUBMITRECIPIENTANDMAILINGINFORMATION"))
                    {
                        String dataSetCount = executionStepsList[executionCounter].ToUpper().Replace("SUBMITRECIPIENTANDMAILINGINFORMATION", "").Replace("(", "").Replace(")", "");
                        testData.recipientListLength=Convert.ToInt32(dataSetCount);
                        testData.RecipientCount = dataSetCount;
                        ExtentTest testSteps = mailDataActions.submitRecipentInformation(testData,report, dataSetCount);
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
                    else if (executionStepsList[executionCounter].ToUpper().Contains("UPLOADDOCUMENTS"))
                    {
                        String dataSetCount = executionStepsList[executionCounter].ToUpper().Replace("UPLOADDOCUMENTS", "").Replace("(", "").Replace(")", "");
                        testData.UploadDocumentCount = dataSetCount;
                        ExtentTest testSteps = mailDataActions.uploadDocuments(report,testData, dataSetCount);
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
                    else if (executionStepsList[executionCounter].ToUpper().Contains("READPDF"))
                    {
                        mailReconciliation.pdfReader();
                    }
                    else
                    {
                        ExtentTest testSteps = report.StartTest("Execution Steps Status");
                        testSteps.Log(LogStatus.Fail, "Unable to execute [" + executionStepsList[executionCounter] + "]  execution step.", "");
                        test.AppendChild(testSteps);
                    }
                }
                //driver.Close();
                report.EndTest(test);
                report.Flush();
            }      
        }
    }
}

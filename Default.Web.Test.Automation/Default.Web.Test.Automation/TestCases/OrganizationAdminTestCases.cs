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
    class OrganizationAdminTestCases : ReportGenerator
    {
        //Define Objects
        IWebDriver driver;
        ManageDriver manageDriver = new ManageDriver();
        ExtentTest test, systemHealthCheck, loginSteps;
        ReportGenerator reportGenerator = new ReportGenerator();
        ReadTestData readTestData = new ReadTestData();
        CommonUtility commonUtility;
        LoginDweb loginDWeb;
        OrganizationAdmin organizationAdmin;
        Dictionary<String, String> testDataMap;
        public List<string> keys;
        int columnCount;
        TestData testData;

        [SetUp]
        //Read Test data from excel
        public void setupConfigurations()
        {
            Console.WriteLine("Setup Test Configurations");
            testDataMap = readTestData.readExcelData("Organization");
            keys = readTestData.keyCount;
            totalTestCases = readTestData.keyCount;
        }

        [Test]
        //providing browser details
        [TestCaseSource(typeof(ManageDriver), "parallelBrowsers")]
        //Test cases steps
        public void organization(String browserName)
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
                testData.executionSteps= testDataMap["ExecutionSteps_" + keys[i]];
                testData.methodName = testDataMap["Method Name_" + keys[i]];
                testData.OrganizationName = testDataMap["OrganizationName_" + keys[i]];
                testData.OrganizationAddress1 = testDataMap["OrganizationAddress1_" + keys[i]];
                testData.OrganizationAddress2 = testDataMap["OrganizationAddress2_" + keys[i]];
                testData.OrganizationAddress1 = testDataMap["OrganizationAddress1_" + keys[i]];
                testData.Zipcode = testDataMap["Zipcode_" + keys[i]];
                testData.City = testDataMap["City_" + keys[i]];
                testData.State = testDataMap["State_" + keys[i]];
                //Store Primary Contact Data
                testData.PrimaryFirstName = testDataMap["PrimaryFirstName_" + keys[i]];
                testData.PrimaryLastName = testDataMap["PrimaryLastName_" + keys[i]];
                testData.PrimaryEmail = testDataMap["PrimaryEmail_" + keys[i]];
                testData.PrimaryPhone = testDataMap["PrimaryPhone_" + keys[i]];
                //Store Secondary Contact Data
                testData.SecondaryFirstName = testDataMap["SecondaryFirstName_" + keys[i]];
                testData.SecondaryLastName = testDataMap["SecondaryLastName_" + keys[i]];
                testData.SecondaryEmail = testDataMap["SecondaryEmail_" + keys[i]];
                testData.SecondaryPhone = testDataMap["SecondaryPhone_" + keys[i]];
                //Store Billing Contact Data
                testData.BillingFirstName = testDataMap["BillingFirstName_" + keys[i]];
                testData.BillingLastName = testDataMap["BillingLastName_" + keys[i]];
                testData.BillingEmail = testDataMap["BillingEmail_" + keys[i]];
                testData.BillingPhone = testDataMap["BillingPhone_" + keys[i]];
                //Store Licenses Details Data
                testData.UserLicense = testDataMap["UserLicense_" + keys[i]];
                testData.FileLicense = testDataMap["FileLicense_" + keys[i]];
                testData.StorageLicense = testDataMap["StorageLicense_" + keys[i]];
                testData.Features = testDataMap["Features_" + keys[i]];
                testData.DeactivateReason= testDataMap["DeactivateReason_" + keys[i]];
                testData.ReactivateReason = testDataMap["ReactivateReason_" + keys[i]];




                //assign browser
                driver = manageDriver.parallelRun(browserName);
                PerformAction performAction = new PerformAction(driver);
                test.AssignCategory(testData.methodName + "-" + browserName + performAction.getBrowserVersion());

                //initiate objects
                organizationAdmin = new OrganizationAdmin(driver);
                commonUtility = new CommonUtility(driver);
                //assign dynamic data 
                if (testData.OrganizationName.Contains("generateOrganizationName"))
                {
                    testData.OrganizationName=organizationAdmin.generateOrganizationName();
                }


                String executionSteps = testData.executionSteps;
                String[] executionStepsList = executionSteps.Replace("||","|").Split('|');
                //execute keywords
                for (int executionCounter=0; executionCounter<executionStepsList.Length;executionCounter++)
                {
                    if (executionStepsList[executionCounter].ToUpper().Equals("SYSTEMHEALTHCHECK"))
                    {
                        //Application health check
                        systemHealthCheck = EnvironmentHealthCheck.checkUrlStatus(appUrl, report);
                        if (systemHealthCheck.GetCurrentStatus().ToString().Equals("Fail"))
                        {
                            test.AppendChild(systemHealthCheck);
                            break;
                        }else
                        {
                            test.AppendChild(systemHealthCheck);
                        }
                        //Login into DWeb Application
                    }else if (executionStepsList[executionCounter].ToUpper().Equals("LOGINDWEB"))
                    {
                        //open application url
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
                        String messageNeedToVerify = executionStepsList[executionCounter].ToUpper().Replace(")","").Replace("(","").Replace("VERIFYEXPECTEDMESSAGE", "");
                        Console.WriteLine("messageNeedToVerify="+ messageNeedToVerify);
                       
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
                    else if (executionStepsList[executionCounter].ToUpper().Contains("SEARCHORGANIZATION"))
                    {
                        organizationAdmin = new OrganizationAdmin(driver);
                        ExtentTest testSteps = organizationAdmin.searchOrganization(report, testData);
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
                    else if (executionStepsList[executionCounter].ToUpper().Contains("VIEWORGANIZATIONDETAILS"))
                    {
                        organizationAdmin = new OrganizationAdmin(driver);
                        ExtentTest testSteps = organizationAdmin.viewOrganizationDetails(report, testData);
                        if (testSteps.GetCurrentStatus().ToString().Equals("Fail"))
                        {
                            test.AppendChild(testSteps);
                            break;
                        }
                        else
                        {
                            test.AppendChild(testSteps);
                        }
                    }else if (executionStepsList[executionCounter].ToUpper().Contains("CLICKON"))
                    {
                        String toClick = executionStepsList[executionCounter].ToUpper().Replace("CLICKON", "").Replace("(", "").Replace(")", "");
                        ExtentTest testSteps = organizationAdmin.clickOn(toClick, report, testData);
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
                    else if (executionStepsList[executionCounter].ToUpper().Contains("EDITORGANIZATIONDETAILS") || executionStepsList[executionCounter].ToUpper().Contains("CREATENEWORGANIZATION"))
                    {
                        String organizationData = executionStepsList[executionCounter].Replace("(", "#").Replace(")", "");
                        ExtentTest testSteps = organizationAdmin.createandModifyOrganization(report, testData, organizationData);
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
                        String dbToValidate = executionStepsList[executionCounter].ToUpper().Replace("(", "").Replace(")", "").Replace("VALIDATEDB", "");
                        VerifyDatabase verifyDatabase = new VerifyDatabase();
                        ExtentTest testSteps = verifyDatabase.checkDBDetails(dbToValidate, testData,report);
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
                    else if (executionStepsList[executionCounter].ToUpper().Contains("DEACTIVATEORGANIZATION"))
                    {
                        ExtentTest testSteps = organizationAdmin.deactivateOrganization(report,testData);
                        if (testSteps.GetCurrentStatus().ToString().Equals("Fail"))
                        {
                            test.AppendChild(testSteps);
                            break;
                        }
                        else
                        {
                            test.AppendChild(testSteps);
                        }
                    } else if (executionStepsList[executionCounter].ToUpper().Contains("REACTIVATEORGANIZATION"))
                    {
                        ExtentTest testSteps = organizationAdmin.reactivateOrganization(report, testData);
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


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
    class UserAdminTestCases : ReportGenerator
    {
        //Define Objects
        IWebDriver driver;
        ManageDriver manageDriver = new ManageDriver();
        ExtentTest test, systemHealthCheck, loginSteps;
        ReportGenerator reportGenerator = new ReportGenerator();
        ReadTestData readTestData = new ReadTestData();
        CommonUtility commonUtility;
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
                testDataMap = readTestData.readExcelData("User Admin");
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
        public void userAdminTest(String browserName)
        {
            //try { 
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
                testData.DeactivateReason = testDataMap["DeactivateReason_" + keys[i]];
                testData.ReactivateReason = testDataMap["ReactivateReason_" + keys[i]];
                testData.NewPassword = testDataMap["NewPassword_" + keys[i]];
                testData.ConfirmPassword = testDataMap["ConfirmPassword_" + keys[i]];



                ////user admin page
                testData.FirstName = testDataMap["FirstName_" + keys[i]];
                testData.LastName = testDataMap["LastName_" + keys[i]];
                testData.Address1 = testDataMap["Address1_" + keys[i]];
                testData.Address2 = testDataMap["Address2_" + keys[i]];
                testData.Phone = testDataMap["Phone_" + keys[i]];
                testData.CEmail = testDataMap["CEmail_" + keys[i]];
                testData.Email = testDataMap["Email_" + keys[i]];
                testData.sample = testDataMap["sample_" + keys[i]];

                if (testData.Email.ToUpper().Equals("DYNAMICEMAIL"))
                {
                    string randomValue = DateTime.Now.ToString("HHmmss");
                    string userName = "QATESTUSER";
                    testData.Email= userName + randomValue+"@xyz.com";
                }
                String password;
                //set a dynamic password
                if (testData.NewPassword.Equals("generateNewPassword") & testData.ConfirmPassword.Equals("generateNewPassword"))
                {
                    password = CreateDynamicPassword.getPassword();
                    testData.NewPassword = password;
                    testData.ConfirmPassword = password;
                }

                //assign browser
                driver = manageDriver.parallelRun(browserName);
                PerformAction performAction = new PerformAction(driver);
                test.AssignCategory(testData.methodName + "-" + browserName + performAction.getBrowserVersion());

                commonUtility = new CommonUtility(driver);
                UserAdmin userAdmin = new UserAdmin(driver);
                ResetPassword resetPassword = new ResetPassword(driver);
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
                            //open application URL
                            new TestRunner(driver).openApplication(appUrl, 6);
                        }
                        //Login into DWeb Application
                    }
                    else if (executionStepsList[executionCounter].ToUpper().Equals("LOGINDWEB"))
                    {
                        
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
                        System.Threading.Thread.Sleep(1000);
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
                    }else if (executionStepsList[executionCounter].ToUpper().Contains("CLICKON"))
                    {
                        String toClick = executionStepsList[executionCounter].ToUpper().Replace("CLICKON", "").Replace("(", "").Replace(")", "");
                        ExtentTest testSteps = userAdmin.clickOn(toClick, report, testData);
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
                    else if (executionStepsList[executionCounter].ToUpper().Equals("SELECTORGANIZATION"))
                    {
                        ExtentTest testSteps = userAdmin.selectOrganization(report, testData);
                        if (testSteps.GetCurrentStatus().ToString().Equals("Fail"))
                        {
                            test.AppendChild(testSteps);
                            break;
                        }
                        else
                        {
                            test.AppendChild(testSteps);
                        }
                    } else if (executionStepsList[executionCounter].ToUpper().Equals("SUBMITUSERDETAILS"))
                    {
                        ExtentTest testSteps = userAdmin.submitUserDetails(report, testData);
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
                    else if (executionStepsList[executionCounter].ToUpper().Equals("SUBMITROLEDETAILS"))
                    {                      
                        ExtentTest testSteps = userAdmin.submitRoleDetails(report, testData);
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
                    else if (executionStepsList[executionCounter].Equals("ViewUser"))
                    {
                        ExtentTest viewUserSteps = userAdmin.viewUser(report, testData);
                        test.AppendChild(viewUserSteps);
                    }
                    else if (executionStepsList[executionCounter].ToUpper().Equals("SEARCHUSER"))
                    {
                        ExtentTest testSteps = userAdmin.searchUser(report, testData);
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
                    else if (executionStepsList[executionCounter].Equals("EditUser"))
                    {
                        ExtentTest editUserSteps = userAdmin.editUser(report, testData);
                        test.AppendChild(editUserSteps);
                    }
                    else if (executionStepsList[executionCounter].ToUpper().Contains("DEACTIVATEUSER"))
                    {
                        ExtentTest testSteps = userAdmin.deactivateUser(report, testData);
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
                    else if (executionStepsList[executionCounter].Equals("VerifyIcon"))
                    {
                        ExtentTest verifyIconSteps = userAdmin.verifyIcon(report, testData);
                        test.AppendChild(verifyIconSteps);
                    }
                    else if (executionStepsList[executionCounter].ToUpper().Equals("REACTIVATEUSER"))
                    {
                        ExtentTest testSteps = userAdmin.reactivateUser(report, testData);
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
                    else if (executionStepsList[executionCounter].ToUpper().Equals("RESETTEMPPASSWORD"))
                    {
                        ExtentTest testSteps = resetPassword.resetTemporaryPassword(report, testData);
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


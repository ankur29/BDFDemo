using Default.Web.Test.Automation.Constants;
using Default.Web.Test.Automation.DatabaseManager;
using Default.Web.Test.Automation.Entities;
using Default.Web.Test.Automation.Library;
using Default.Web.Test.Automation.ObjectRepository;
using OpenQA.Selenium;
using RelevantCodes.ExtentReports;
using System;

namespace Default.Web.Test.Automation.BusinessUitilities
{
    class OrganizationAdmin
    {
        //Define Objects
        IWebDriver driver;
        PerformAction performAction;

        public OrganizationAdmin(IWebDriver _driver)
        {
            driver = _driver;
            performAction = new PerformAction(driver);
        }
  
        //Switch on Licensing Details Section
        public ExtentTest viewOrganizationDetails(ExtentReports report, TestData testData)
        {
            ExtentTest submitPrimarySteps = report.StartTest("View Organization Details");
            try
            {
                System.Threading.Thread.Sleep(1000);
                performAction.clickButton(OrganizationPage.VIEWICON_ORGADMIN_XPATH, "VIEWICON_ORGADMIN_XPATH");
                submitPrimarySteps.Log(LogStatus.Info, "Click on View Icon Link", "");
                System.Threading.Thread.Sleep(2000);
                performAction.highlightText(performAction.getLocator(OrganizationPage.PRIMARYDETAILSTITLE_ORGADMIN_XPATH, "PRIMARYDETAILSTITLE_ORGADMIN_XPATH"));
                submitPrimarySteps.Log(LogStatus.Info, "Verify Primary Details", "");
                performAction.highlightText(performAction.getLocator(OrganizationPage.ORGANIZATIONDETAILSTITLE_ORGADMIN_XPATH, "ORGANIZATIONDETAILSTITLE_ORGADMIN_XPATH"));
                submitPrimarySteps.Log(LogStatus.Info, "Verify Organization Details", "");
                performAction.highlightText(driver.FindElement(By.XPath("//tbody/tr/td[1]/div[text()=' " + testData.OrganizationName + " ']")));
                submitPrimarySteps.Log(LogStatus.Info, "Verify OrganizationName", testData.OrganizationName);
                performAction.highlightText(driver.FindElement(By.XPath("//tbody/tr/td[1]/div[text()=' " + testData.Zipcode + " ']")));
                submitPrimarySteps.Log(LogStatus.Info, "Verify Zip Code", testData.Zipcode);
                performAction.highlightText(performAction.getLocator(OrganizationPage.PRIMARYCONTACTTITLE_ORGADMIN_XPATH, "PRIMARYCONTACTTITLE_ORGADMIN_XPATH"));
                submitPrimarySteps.Log(LogStatus.Info, "Verify Primary Contact Details", "");
                performAction.highlightText(driver.FindElement(By.XPath("//tbody/tr/td[2]/div[text()=' " + testData.PrimaryFirstName + " ']")));
                submitPrimarySteps.Log(LogStatus.Info, "Verify Primary First Name", testData.PrimaryFirstName);
                performAction.highlightText(driver.FindElement(By.XPath("//tbody/tr/td[2]/div[text()=' " + testData.PrimaryLastName + " ']")));
                submitPrimarySteps.Log(LogStatus.Info, "Verify Primary Last Name", testData.PrimaryLastName);
                performAction.highlightText(driver.FindElement(By.XPath("//tbody/tr/td[2]/div[text()=' " + testData.PrimaryEmail + " ']")));
                performAction.highlightText(driver.FindElement(By.XPath("//tbody/tr/td[2]/div[text()=' " + testData.PrimaryPhone + " ']")));
                performAction.highlightText(performAction.getLocator(OrganizationPage.SECONDARYCONTACTTITLE_ORGADMIN_XPATH, "SECONDARYCONTACTTITLE_ORGADMIN_XPATH"));
                performAction.highlightText(performAction.getLocator(OrganizationPage.BILLINGCONTACTTITLE_ORGADMIN_XPATH, "BILLINGCONTACTTITLE_ORGADMIN_XPATH"));
                performAction.highlightText(driver.FindElement(By.XPath("//tbody/tr/td[4]/div[text()=' " + testData.BillingFirstName + " ']")));
                performAction.highlightText(driver.FindElement(By.XPath("//tbody/tr/td[4]/div[text()=' " + testData.BillingLastName + " ']")));
                performAction.highlightText(driver.FindElement(By.XPath("//tbody/tr/td[4]/div[text()=' " + testData.BillingEmail + " ']")));
                performAction.highlightText(driver.FindElement(By.XPath("//tbody/tr/td[4]/div[text()=' " + testData.BillingPhone + " ']")));

                performAction.clickButton(OrganizationPage.LICENSINGDETAILS_ORGADMIN_XPATH, "LICENSINGDETAILS_ORGADMIN_XPATH");
                submitPrimarySteps.Log(LogStatus.Info, "Click on License Details Section");
                System.Threading.Thread.Sleep(1000);
                performAction.highlightText(performAction.getLocator(OrganizationPage.LICENSINGDETAILSTITLE_ORGADMIN_XPATH, "LICENSINGDETAILSTITLE_ORGADMIN_XPATH"));
                performAction.highlightText(driver.FindElement(By.XPath("//tbody/tr[1]/td[2]/p[text()=' " + testData.UserLicense + " ']")));
                performAction.highlightText(driver.FindElement(By.XPath("//tbody/tr[2]/td[2]/p[text()=' " + testData.FileLicense + " ']")));
                performAction.highlightText(driver.FindElement(By.XPath("//tbody/tr[3]/td[2]/p[text()=' " + testData.StorageLicense + "GB ']")));
                performAction.highlightText(driver.FindElement(By.XPath("//input[@aria-checked='true']")));
 }
            catch (Exception e)
            {
                submitPrimarySteps.Log(LogStatus.Fail, "Unable to Click on License Details Section", e);
                var imagePath = new CaptureScreenshot(driver).takeScreenshot(testData.testCaseName);
                submitPrimarySteps.Log(LogStatus.Info, "Snapshot below: " + submitPrimarySteps.AddScreenCapture(imagePath));
            }
            return submitPrimarySteps;
        }

        //search Organization
        public ExtentTest searchOrganization(ExtentReports report, TestData testData)
        {
            ExtentTest submitPrimarySteps = report.StartTest("Search Organization");
            try
            {
                System.Threading.Thread.Sleep(3000);
                performAction.clickButton(MenuItemsPage.ADMINLINK_MENU_XPATH, "ADMINLINK_MENU_XPATH");
                submitPrimarySteps.Log(LogStatus.Info, "Click on ADMIN Link", "");
                performAction.clickButton(MenuItemsPage.ORGADMINLINK_MENU_XPATH, "ORGADMINLINK_MENU_XPATH");
                submitPrimarySteps.Log(LogStatus.Info, "Click on ORG ADMIN Link", "");
                performAction.enterText(OrganizationPage.SEARCHBAR_ORGADMIN_XPATH, "SEARCHBAR_ORGADMIN_XPATH",testData.OrganizationName);
                submitPrimarySteps.Log(LogStatus.Info, "Search for "+testData.OrganizationName,"");
                performAction.clickButton(OrganizationPage.SEARCHICON_ORGADMIN_XPATH, "SEARCHICON_ORGADMIN_XPATH");

            }
            catch (Exception e)
            {
                submitPrimarySteps.Log(LogStatus.Fail, "Unable to Search ", e);
                var imagePath = new CaptureScreenshot(driver).takeScreenshot(testData.testCaseName);
                submitPrimarySteps.Log(LogStatus.Info, "Snapshot below: " + submitPrimarySteps.AddScreenCapture(imagePath));
            }
            return submitPrimarySteps;
        }



        //Add\Edit Organization
        public ExtentTest createandModifyOrganization(ExtentReports report, TestData testData,String organizationData)
        {
            System.Threading.Thread.Sleep(2000);
            Console.WriteLine("organizationData="+ organizationData);
            String testCaseDescription = organizationData.Split('#')[0];
            Console.WriteLine("testCaseDescription=", testCaseDescription);
            ExtentTest testSteps = report.StartTest(testCaseDescription);
            try
            {
                if (testCaseDescription.Equals("EditOrganizationDetails"))
            {
                String testDataDetails= organizationData.Split('#')[1];
                String[] testDataList = testDataDetails.Split(',');

                for (int i=0;i<testDataList.Length;i++)
                {
                    String dataKey = testDataList[i].Split('=')[0].ToUpper();
                    String dataValue = testDataList[i].Split('=')[1];
                        System.Threading.Thread.Sleep(1000);

                    if (dataKey.Equals(OrganizationConstants.ORGANIZATION_NAME))
                    {
                        testData.OrganizationName = dataValue;
                        performAction.getLocator(OrganizationPage.ORGANIZATIONNAME_ORGADMIN_XPATH, "ORGANIZATIONNAME_ORGADMIN_XPATH").Clear();
                        performAction.enterText(OrganizationPage.ORGANIZATIONNAME_ORGADMIN_XPATH, "ORGANIZATIONNAME_ORGADMIN_XPATH", testData.OrganizationName);
                        testSteps.Log(LogStatus.Info, "Enter ORGANIZATION NAME", testData.OrganizationName);
                    }else if (dataKey.Equals(OrganizationConstants.ORGANIZATION_ADDRESS1))
                    {
                        testData.OrganizationAddress1 = dataValue;
                        performAction.getLocator(OrganizationPage.ADDRESS1_ORGADMIN_XPATH, "ADDRESS1_ORGADMIN_XPATH").Clear();
                        performAction.enterText(OrganizationPage.ADDRESS1_ORGADMIN_XPATH, "ADDRESS1_ORGADMIN_XPATH", testData.OrganizationAddress1);
                        testSteps.Log(LogStatus.Info, "Enter ADDRESS1 ", testData.OrganizationAddress1);
                    }
                    else if (dataKey.Equals(OrganizationConstants.ORGANIZATION_ADDRESS2))
                    {
                        testData.OrganizationAddress2 = dataValue;
                        performAction.getLocator(OrganizationPage.ADDRESS2_ORGADMIN_XPATH, "ADDRESS2_ORGADMIN_XPATH").Clear();
                        performAction.enterText(OrganizationPage.ADDRESS2_ORGADMIN_XPATH, "ADDRESS2_ORGADMIN_XPATH", testData.OrganizationAddress2);
                        testSteps.Log(LogStatus.Info, "Enter ADDRESS2 ", testData.OrganizationAddress2);
                    } else if (dataKey.Equals(OrganizationConstants.ORGANIZATION_ZIPCODE))
                    {
                        testData.Zipcode = dataValue;
                        performAction.getLocator(OrganizationPage.ZIPCODE_ORGADMIN_XPATH, "ZIPCODE_ORGADMIN_XPATH").Clear();
                        performAction.enterText(OrganizationPage.ZIPCODE_ORGADMIN_XPATH, "ZIPCODE_ORGADMIN_XPATH", testData.Zipcode);
                        testSteps.Log(LogStatus.Info, "Enter ZIPCODE", testData.Zipcode);
                    } else if (dataKey.Equals(OrganizationConstants.ORGANIZATION_CITY))
                    {
                        testData.City = dataValue;
                        performAction.getLocator(OrganizationPage.CITY_ORGADMIN_XPATH, "CITY_ORGADMIN_XPATH").Clear();
                        performAction.enterText(OrganizationPage.CITY_ORGADMIN_XPATH, "CITY_ORGADMIN_XPATH", testData.City);
                        testSteps.Log(LogStatus.Info, "Enter CITY", testData.City);
                    }else if (dataKey.Equals(OrganizationConstants.ORGANIZATION_STATE))
                    {
                        testData.State = dataValue;
                        performAction.getLocator(OrganizationPage.SELECTSTATE_ORGADMIN_XPATH, "SELECTSTATE_ORGADMIN_XPATH").Clear();
                        performAction.enterText(OrganizationPage.SELECTSTATE_ORGADMIN_XPATH, "SELECTSTATE_ORGADMIN_XPATH", testData.State);
                        testSteps.Log(LogStatus.Info, "Enter STATE", testData.State);
                    }else if (dataKey.Equals(OrganizationConstants.PRIMARY_FIRST_NAME))
                    {
                        testData.PrimaryFirstName = dataValue;
                        performAction.getLocator(OrganizationPage.PRIMARYCONTACTFIRSTNAME_ORGADMIN_XPATH, "PRIMARYCONTACTFIRSTNAME_ORGADMIN_XPATH").Clear();
                        performAction.enterText(OrganizationPage.PRIMARYCONTACTFIRSTNAME_ORGADMIN_XPATH, "PRIMARYCONTACTFIRSTNAME_ORGADMIN_XPATH", testData.PrimaryFirstName);
                        testSteps.Log(LogStatus.Info, "Enter PRIMARY FIRST NAME", testData.PrimaryFirstName);
                    }else if (dataKey.Equals(OrganizationConstants.PRIMARY_LAST_NAME))
                    {
                        testData.PrimaryLastName = dataValue;
                        performAction.getLocator(OrganizationPage.PRIMARYCONTACTLASTNAME_ORGADMIN_XPATH, "PRIMARYCONTACTLASTNAME_ORGADMIN_XPATH").Clear();
                        performAction.enterText(OrganizationPage.PRIMARYCONTACTLASTNAME_ORGADMIN_XPATH, "PRIMARYCONTACTLASTNAME_ORGADMIN_XPATH", testData.PrimaryLastName);
                        testSteps.Log(LogStatus.Info, "Enter PRIMARY LAST NAME", testData.PrimaryLastName);
                    }else if (dataKey.Equals(OrganizationConstants.PRIMARY_EMAIL))
                    {
                        testData.PrimaryEmail = dataValue;
                        performAction.getLocator(OrganizationPage.PRIMARYCONTACTEMAIL_ORGADMIN_XPATH, "PRIMARYCONTACTEMAIL_ORGADMIN_XPATH").Clear();
                        performAction.enterText(OrganizationPage.PRIMARYCONTACTEMAIL_ORGADMIN_XPATH, "PRIMARYCONTACTEMAIL_ORGADMIN_XPATH", testData.PrimaryEmail);
                        testSteps.Log(LogStatus.Info, "Enter PRIMARY EMAIL", testData.PrimaryEmail);
                    } else if (dataKey.Equals(OrganizationConstants.PRIMARY_PHONE))
                    {
                        testData.PrimaryPhone = dataValue;
                        performAction.getLocator(OrganizationPage.PRIMARYCONTACTPHONE_ORGADMIN_XPATH, "PRIMARYCONTACTPHONE_ORGADMIN_XPATH").Clear();
                        performAction.enterText(OrganizationPage.PRIMARYCONTACTPHONE_ORGADMIN_XPATH, "PRIMARYCONTACTPHONE_ORGADMIN_XPATH", testData.PrimaryPhone);
                        testSteps.Log(LogStatus.Info, "Enter PRIMARY EMAIL", testData.PrimaryPhone);
                    }else if (dataKey.Equals(OrganizationConstants.SECONDARY_FIRST_NAME))
                    {
                        testData.SecondaryFirstName = dataValue;
                        performAction.getLocator(OrganizationPage.SECONDARYCONTACTFIRSTNAME_ORGADMIN_XPATH, "SECONDARYCONTACTFIRSTNAME_ORGADMIN_XPATH").Clear();
                        performAction.enterText(OrganizationPage.SECONDARYCONTACTFIRSTNAME_ORGADMIN_XPATH, "SECONDARYCONTACTFIRSTNAME_ORGADMIN_XPATH", testData.SecondaryFirstName);
                        testSteps.Log(LogStatus.Info, "Enter SECONDARY FIRST NAME", testData.SecondaryFirstName);
                    }else if (dataKey.Equals(OrganizationConstants.SECONDARY_LAST_NAME))
                    {
                        testData.SecondaryLastName = dataValue;
                        performAction.getLocator(OrganizationPage.SECONDARYCONTACTLASTNAME_ORGADMIN_XPATH, "SECONDARYCONTACTLASTNAME_ORGADMIN_XPATH").Clear();
                        performAction.enterText(OrganizationPage.SECONDARYCONTACTLASTNAME_ORGADMIN_XPATH, "SECONDARYCONTACTLASTNAME_ORGADMIN_XPATH", testData.SecondaryLastName);
                        testSteps.Log(LogStatus.Info, "Enter SECONDARY LAST NAME", testData.SecondaryLastName);
                    }else if (dataKey.Equals(OrganizationConstants.SECONDARY_EMAIL))
                    {
                        testData.SecondaryEmail = dataValue;
                        performAction.getLocator(OrganizationPage.SECONDARYCONTACTEMAIL_ORGADMIN_XPATH, "SECONDARYCONTACTEMAIL_ORGADMIN_XPATH").Clear();
                        performAction.enterText(OrganizationPage.SECONDARYCONTACTEMAIL_ORGADMIN_XPATH, "SECONDARYCONTACTEMAIL_ORGADMIN_XPATH", testData.SecondaryEmail);
                        testSteps.Log(LogStatus.Info, "Enter SECONDARY EMAIL", testData.SecondaryEmail);
                    } else if (dataKey.Equals(OrganizationConstants.SECONDARY_PHONE))
                    {
                        testData.SecondaryPhone = dataValue;
                        performAction.getLocator(OrganizationPage.SECONDARYCONTACTPHONE_ORGADMIN_XPATH, "SECONDARYCONTACTPHONE_ORGADMIN_XPATH").Clear();
                        performAction.enterText(OrganizationPage.SECONDARYCONTACTPHONE_ORGADMIN_XPATH, "SECONDARYCONTACTPHONE_ORGADMIN_XPATH", testData.SecondaryPhone);
                        testSteps.Log(LogStatus.Info, "Enter SECONDARY PHONE", testData.SecondaryPhone);
                    }

                }

            }
            else if(testCaseDescription.Equals("CreateNewOrganization"))
            {
                    performAction.clickButton(MenuItemsPage.ADMINLINK_MENU_XPATH, "ADMINLINK_MENU_XPATH");
                    testSteps.Log(LogStatus.Info, "Click on ADMIN Link", "");
                    performAction.clickButton(MenuItemsPage.ORGADMINLINK_MENU_XPATH, "ORGADMINLINK_MENU_XPATH");
                    testSteps.Log(LogStatus.Info, "Click on ORG ADMIN Link", "");
                    System.Threading.Thread.Sleep(5000);
                    performAction.clickButton(OrganizationPage.ADDORGANIZATION_ORGADMIN_XPATH, "ADDORGANIZATION_ORGADMIN_XPATH");
                    testSteps.Log(LogStatus.Info, "Click on ADD ORGANIZATION BUTTON", "");
                    performAction.waitIfElementPresent(performAction.getLocator(OrganizationPage.ORGANIZATIONDETAILS_ORGADMIN_XPATH, "ORGANIZATIONDETAILS_ORGADMIN_XPATH"), 10);
                    performAction.highlightText(performAction.getLocator(OrganizationPage.ORGANIZATIONDETAILS_ORGADMIN_XPATH, "ORGANIZATIONDETAILS_ORGADMIN_XPATH"));
                    performAction.clickButton(OrganizationPage.ORGANIZATIONNAME_ORGADMIN_XPATH, "ORGANIZATIONNAME_ORGADMIN_XPATH");
                    performAction.enterText(OrganizationPage.ORGANIZATIONNAME_ORGADMIN_XPATH, "ORGANIZATIONNAME_ORGADMIN_XPATH", testData.OrganizationName);
                    testSteps.Log(LogStatus.Info, "Enter ORGANIZATION NAME", testData.OrganizationName);
                    performAction.clickButton(OrganizationPage.ADDRESS1_ORGADMIN_XPATH, "ADDRESS1_ORGADMIN_XPATH");
                    performAction.enterText(OrganizationPage.ADDRESS1_ORGADMIN_XPATH, "ADDRESS1_ORGADMIN_XPATH", testData.OrganizationAddress1);
                    testSteps.Log(LogStatus.Info, "Enter ORGANIZATION ADDRESS1", testData.OrganizationAddress1);
                    performAction.clickButton(OrganizationPage.ADDRESS2_ORGADMIN_XPATH, "ADDRESS2_ORGADMIN_XPATH");
                    performAction.enterText(OrganizationPage.ADDRESS2_ORGADMIN_XPATH, "ADDRESS2_ORGADMIN_XPATH", testData.OrganizationAddress2);
                    testSteps.Log(LogStatus.Info, "Enter ORGANIZATION ADDRESS2", testData.OrganizationAddress2);
                    performAction.clickButton(OrganizationPage.ZIPCODE_ORGADMIN_XPATH, "ZIPCODE_ORGADMIN_XPATH");
                    performAction.enterText(OrganizationPage.ZIPCODE_ORGADMIN_XPATH, "ZIPCODE_ORGADMIN_XPATH", testData.Zipcode);
                    testSteps.Log(LogStatus.Info, "Enter ZIPCODE", testData.Zipcode);
                    //performAction.enterText(OrganizationPage.CITY_ORGADMIN_XPATH, "CITY_ORGADMIN_XPATH", testData.City);
                    //testSteps.Log(LogStatus.Info, "Enter CITY", testData.City);
                    //performAction.enterText(OrganizationPage.SELECTSTATE_ORGADMIN_XPATH, "SELECTSTATE_ORGADMIN_XPATH", testData.State);
                    //testSteps.Log(LogStatus.Info, "Select STATE", testData.State);
                    System.Threading.Thread.Sleep(1000);
                    performAction.clickButton(OrganizationPage.PRIMARYCONTACTFIRSTNAME_ORGADMIN_XPATH, "PRIMARYCONTACTFIRSTNAME_ORGADMIN_XPATH");
                    performAction.enterText(OrganizationPage.PRIMARYCONTACTFIRSTNAME_ORGADMIN_XPATH, "PRIMARYCONTACTFIRSTNAME_ORGADMIN_XPATH", testData.PrimaryFirstName);
                    testSteps.Log(LogStatus.Info, "Enter Primary Contact FIRST NAME", testData.PrimaryFirstName);
                    performAction.clickButton(OrganizationPage.PRIMARYCONTACTLASTNAME_ORGADMIN_XPATH, "PRIMARYCONTACTLASTNAME_ORGADMIN_XPATH");
                    performAction.enterText(OrganizationPage.PRIMARYCONTACTLASTNAME_ORGADMIN_XPATH, "PRIMARYCONTACTLASTNAME_ORGADMIN_XPATH", testData.PrimaryLastName);
                    testSteps.Log(LogStatus.Info, "Enter Primary Contact LAST NAME", testData.PrimaryLastName);
                    performAction.clickButton(OrganizationPage.PRIMARYCONTACTEMAIL_ORGADMIN_XPATH, "PRIMARYCONTACTEMAIL_ORGADMIN_XPATH");
                    performAction.enterText(OrganizationPage.PRIMARYCONTACTEMAIL_ORGADMIN_XPATH, "PRIMARYCONTACTEMAIL_ORGADMIN_XPATH", testData.PrimaryEmail);
                    testSteps.Log(LogStatus.Info, "Enter Primary Contact EMAIL", testData.PrimaryEmail);
                    performAction.clickButton(OrganizationPage.PRIMARYCONTACTPHONE_ORGADMIN_XPATH, "PRIMARYCONTACTPHONE_ORGADMIN_XPATH");
                    performAction.enterText(OrganizationPage.PRIMARYCONTACTPHONE_ORGADMIN_XPATH, "PRIMARYCONTACTPHONE_ORGADMIN_XPATH", testData.PrimaryPhone);
                    testSteps.Log(LogStatus.Info, "Enter Primary Contact PHONE", testData.PrimaryPhone);
                    performAction.clickButton(OrganizationPage.SECONDARYCONTACTFIRSTNAME_ORGADMIN_XPATH, "SECONDARYCONTACTFIRSTNAME_ORGADMIN_XPATH");
                    performAction.enterText(OrganizationPage.SECONDARYCONTACTFIRSTNAME_ORGADMIN_XPATH, "SECONDARYCONTACTFIRSTNAME_ORGADMIN_XPATH", testData.SecondaryFirstName);
                    testSteps.Log(LogStatus.Info, "Enter Secondary Contact FIRST NAME", testData.SecondaryFirstName);
                    performAction.clickButton(OrganizationPage.SECONDARYCONTACTLASTNAME_ORGADMIN_XPATH, "SECONDARYCONTACTLASTNAME_ORGADMIN_XPATH");
                    performAction.enterText(OrganizationPage.SECONDARYCONTACTLASTNAME_ORGADMIN_XPATH, "SECONDARYCONTACTLASTNAME_ORGADMIN_XPATH", testData.SecondaryLastName);
                    testSteps.Log(LogStatus.Info, "Enter Secondary Contact LAST NAME", testData.SecondaryLastName);
                    performAction.clickButton(OrganizationPage.SECONDARYCONTACTEMAIL_ORGADMIN_XPATH, "SECONDARYCONTACTEMAIL_ORGADMIN_XPATH");
                    performAction.enterText(OrganizationPage.SECONDARYCONTACTEMAIL_ORGADMIN_XPATH, "SECONDARYCONTACTEMAIL_ORGADMIN_XPATH", testData.SecondaryEmail);
                    testSteps.Log(LogStatus.Info, "Enter Secondary Contact EMAIL", testData.SecondaryEmail);
                    performAction.clickButton(OrganizationPage.SECONDARYCONTACTPHONE_ORGADMIN_XPATH, "SECONDARYCONTACTPHONE_ORGADMIN_XPATH");
                    performAction.enterText(OrganizationPage.SECONDARYCONTACTPHONE_ORGADMIN_XPATH, "SECONDARYCONTACTPHONE_ORGADMIN_XPATH", testData.SecondaryPhone);
                    testSteps.Log(LogStatus.Info, "Enter Secondary Contact PHONE", testData.SecondaryPhone);
                    performAction.clickButton(OrganizationPage.BILLINGCONTACTFIRSTNAME_ORGADMIN_XPATH, "BILLINGCONTACTFIRSTNAME_ORGADMIN_XPATH");
                    performAction.enterText(OrganizationPage.BILLINGCONTACTFIRSTNAME_ORGADMIN_XPATH, "BILLINGCONTACTFIRSTNAME_ORGADMIN_XPATH", testData.BillingFirstName);
                    testSteps.Log(LogStatus.Info, "Enter Billing Contact FIRST NAME", testData.BillingFirstName);
                    performAction.clickButton(OrganizationPage.BILLINGCONTACTLASTNAME_ORGADMIN_XPATH, "BILLINGCONTACTLASTNAME_ORGADMIN_XPATH");
                    performAction.enterText(OrganizationPage.BILLINGCONTACTLASTNAME_ORGADMIN_XPATH, "BILLINGCONTACTLASTNAME_ORGADMIN_XPATH", testData.BillingLastName);
                    testSteps.Log(LogStatus.Info, "Enter Billing Contact LAST NAME", testData.BillingLastName);
                    performAction.clickButton(OrganizationPage.BILLINGCONTACTEMAIL_ORGADMIN_XPATH, "BILLINGCONTACTEMAIL_ORGADMIN_XPATH");
                    performAction.enterText(OrganizationPage.BILLINGCONTACTEMAIL_ORGADMIN_XPATH, "BILLINGCONTACTEMAIL_ORGADMIN_XPATH", testData.BillingEmail);
                    testSteps.Log(LogStatus.Info, "Enter Billing Contact EMAIL", testData.BillingEmail);
                    performAction.clickButton(OrganizationPage.BILLINGCONTACTPHONE_ORGADMIN_XPATH, "BILLINGCONTACTPHONE_ORGADMIN_XPATH");
                    performAction.enterText(OrganizationPage.BILLINGCONTACTPHONE_ORGADMIN_XPATH, "BILLINGCONTACTPHONE_ORGADMIN_XPATH", testData.BillingPhone);
                    testSteps.Log(LogStatus.Info, "Enter Billing Contact PHONE", testData.BillingPhone);
                    System.Threading.Thread.Sleep(1000);
                    performAction.clickButton(OrganizationPage.LICENSINGDETAILS_ORGADMIN_XPATH, "LICENSINGDETAILS_ORGADMIN_XPATH");
                    testSteps.Log(LogStatus.Info, "Click on Licensing Details", "");
                    System.Threading.Thread.Sleep(1000);
                    performAction.clickButton(OrganizationPage.USERLICENSE_ORGADMIN_XPATH, "USERLICENSE_ORGADMIN_XPATH");
                    performAction.enterText(OrganizationPage.USERLICENSE_ORGADMIN_XPATH, "USERLICENSE_ORGADMIN_XPATH", testData.UserLicense);
                    testSteps.Log(LogStatus.Info, "Enter USERS license", testData.UserLicense);
                    performAction.clickButton(OrganizationPage.FILELICENSE_ORGADMIN_XPATH, "FILELICENSE_ORGADMIN_XPATH");
                    performAction.enterText(OrganizationPage.FILELICENSE_ORGADMIN_XPATH, "FILELICENSE_ORGADMIN_XPATH", testData.FileLicense);
                    testSteps.Log(LogStatus.Info, "Enter FILES License", testData.FileLicense);
                    performAction.clickButton(OrganizationPage.STORAGELICENSE_ORGADMIN_XPATH, "STORAGELICENSE_ORGADMIN_XPATH");
                    performAction.enterText(OrganizationPage.STORAGELICENSE_ORGADMIN_XPATH, "STORAGELICENSE_ORGADMIN_XPATH", testData.StorageLicense);
                    testSteps.Log(LogStatus.Info, "Enter SRORAGES License", testData.StorageLicense);
                    if (!testData.Features.Equals(""))
                    {
                        String[] featuresList = testData.Features.Split('|');
                        for (int i = 0; i < featuresList.Length; i++)
                        {
                            IWebElement element = null;
                            if (featuresList[i].Equals("Bankruptcy"))
                            {
                                element = performAction.getLocator(OrganizationPage.BANKRUPTCYFEATURE_ORGADMIN_XPATH, "BANKRUPTCYFEATURE_ORGADMIN_XPATH");
                            }
                            else if (featuresList[i].Equals("Eviction"))
                            {
                                element = performAction.getLocator(OrganizationPage.EVICTIONFEATURE_ORGADMIN_XPATH, "EVICTIONFEATURE_ORGADMIN_XPATH");
                            }
                            else if (featuresList[i].Equals("Title"))
                            {
                                element = performAction.getLocator(OrganizationPage.TITLEFEATURE_ORGADMIN_XPATH, "TITLEFEATURE_ORGADMIN_XPATH");
                            }
                            else if (featuresList[i].Equals("Miscellaneous"))
                            {
                                element = performAction.getLocator(OrganizationPage.MISCELLEANEOUSFEATURE_ORGADMIN_XPATH, "MISCELLEANEOUSFEATURE_ORGADMIN_XPATH");
                            }
                            else if (featuresList[i].Equals("Foreclosure"))
                            {
                                element = performAction.getLocator(OrganizationPage.FORECLOSUREFEATURE_ORGADMIN_XPATH, "FORECLOSUREFEATURE_ORGADMIN_XPATH");
                            }
                            else if (featuresList[i].Equals("Litigation"))
                            {
                                element = performAction.getLocator(OrganizationPage.LITIGATIONFEATURE_ORGADMIN_XPATH, "LITIGATIONFEATURE_ORGADMIN_XPATH");
                            }
                            else if (featuresList[i].Equals("Mailing"))
                            {
                                element = performAction.getLocator(OrganizationPage.MAILINGFEATURE_ORGADMIN_XPATH, "MAILINGFEATURE_ORGADMIN_XPATH");
                            }
                            if (!element.Selected)
                            {
                                element.Click();
                                testSteps.Log(LogStatus.Info, featuresList[i] + " is selected", "");
                            }
                            else
                            {
                                element.Click();
                                testSteps.Log(LogStatus.Info, featuresList[i] + " is deselected", "");
                            }
                        }
                    }
                }

        
            }
            catch (Exception e)
            {
                testSteps.Log(LogStatus.Fail, "Unable to Search ", e);
                var imagePath = new CaptureScreenshot(driver).takeScreenshot(testData.testCaseName);
                testSteps.Log(LogStatus.Info, "Snapshot below: " + testSteps.AddScreenCapture(imagePath));
            }
            return testSteps;
        }

        //generate dynamic Organization Name
        public String generateOrganizationName()
        {
            string randomValue = DateTime.Now.ToString("HHmmss");
            string organizationName = "QATESTORG";
            return organizationName + randomValue;
        }

        //deactivate Organization
        public ExtentTest deactivateOrganization(ExtentReports report, TestData testData)
        {
            ExtentTest testSteps = report.StartTest("Deactivate Organization");
            try
            {
                System.Threading.Thread.Sleep(1000);
                performAction.clickButton(OrganizationPage.DEACTIVATEICON_ORGADMIN_XPATH, "DEACTIVATEICON_ORGADMIN_XPATH");
                testSteps.Log(LogStatus.Info, "Click on Deactivate Link", "");
                System.Threading.Thread.Sleep(2000);
                performAction.enterText(OrganizationPage.REASON_ORGADMIN_XPATH, "REASON_ORGADMIN_XPATH",testData.DeactivateReason);
                testSteps.Log(LogStatus.Info, "Enter Reason", testData.DeactivateReason);              
                performAction.clickButton(OrganizationPage.DEACTIVATEBUTTON_ORGADMIN_XPATH, "DEACTIVATEBUTTON_ORGADMIN_XPATH");
                testSteps.Log(LogStatus.Info, "Click on Deactivate button","");
            }
            catch (Exception e)
            {
                testSteps.Log(LogStatus.Fail, "Unable to Deactivate organization ", e);
                var imagePath = new CaptureScreenshot(driver).takeScreenshot(testData.testCaseName);
                testSteps.Log(LogStatus.Info, "Snapshot below: " + testSteps.AddScreenCapture(imagePath));
            }
            return testSteps;
        }

        //reactivate Organization
        public ExtentTest reactivateOrganization(ExtentReports report, TestData testData)
        {
            ExtentTest testSteps = report.StartTest("Reactivate Organization");
            try
            {
                System.Threading.Thread.Sleep(2000);
                performAction.clickButton(OrganizationPage.REACTIVATELINK_ORGADMIN_XPATH, "REACTIVATELINK_ORGADMIN_XPATH");
                testSteps.Log(LogStatus.Info, "Click on Reactivate Link", "");
                System.Threading.Thread.Sleep(2000);
                performAction.enterText(OrganizationPage.REASON_ORGADMIN_XPATH, "REASON_ORGADMIN_XPATH", testData.ReactivateReason);
                testSteps.Log(LogStatus.Info, "Enter Reason", testData.ReactivateReason);
                performAction.clickButton(OrganizationPage.REACTIVATEBUTTON_ORGADMIN_XPATH, "REACTIVATEBUTTON_ORGADMIN_XPATH");
                testSteps.Log(LogStatus.Info, "Click on Reactivate button", "");
                System.Threading.Thread.Sleep(800);
            }
            catch (Exception e)
            {
                testSteps.Log(LogStatus.Fail, "Unable to Reactivate organization ", e);
                var imagePath = new CaptureScreenshot(driver).takeScreenshot(testData.testCaseName);
                testSteps.Log(LogStatus.Info, "Snapshot below: " + testSteps.AddScreenCapture(imagePath));
            }
            return testSteps;
        }

        public String getActiveOrganizationCount()
        {
            String totalItems = performAction.getLocator(OrganizationPage.TOTALITEMS_ORGADMIN_XPATH, "TOTALITEMS_ORGADMIN_XPATH").Text;
           return totalItems = totalItems.Replace("1 - 5 of ", "");
        }

        //Click on requested Link/button
        public ExtentTest clickOn(String toClick, ExtentReports report, TestData testData)
        {
            ExtentTest testSteps = report.StartTest("Click ON " + toClick);
            toClick = toClick.ToUpper();
            String[] toClickList = toClick.Split(',');
            try
            {
                for (int i = 0; i < toClickList.Length; i++)
                {
                    if (toClickList[i].Equals("USER"))
                    {
                        System.Threading.Thread.Sleep(1000);
                        performAction.waitIfElementPresent(performAction.getLocator(MenuItemsPage.USERICON_EVENT_XPATH, "USERICON_EVENT_XPATH"), 10);
                        performAction.clickButton(MenuItemsPage.USERICON_EVENT_XPATH, "USERICON_EVENT_XPATH");
                        testSteps.Log(LogStatus.Pass, "Click on <b>" + toClickList[i] + "</b>");
                    }
                    else if (toClickList[i].Equals("SIGNOUT"))
                    {
                        System.Threading.Thread.Sleep(1000);
                        performAction.waitIfElementPresent(performAction.getLocator(MenuItemsPage.SIGNOUT_EVENT_XPATH, "SIGNOUT_EVENT_XPATH"), 10);
                        performAction.clickButton(MenuItemsPage.SIGNOUT_EVENT_XPATH, "SIGNOUT_EVENT_XPATH");
                        testSteps.Log(LogStatus.Pass, "Click on <b>" + toClickList[i] + "</b>");
                    }
                    else if (toClickList[i].Equals("ACCEPTALERT"))
                    {
                        System.Threading.Thread.Sleep(1000);
                        driver.FindElement(By.XPath("//button[text()='Ok']")).Click();
                        testSteps.Log(LogStatus.Pass, "Click on <b>" + toClickList[i] + "</b>");
                    }else if (toClickList[i].Equals("ADMIN"))
                    {
                        performAction.clickButton(MenuItemsPage.ADMINLINK_MENU_XPATH, "ADMINLINK_MENU_XPATH");
                        testSteps.Log(LogStatus.Pass, "Click on <b>" + toClickList[i] + "</b>");
                    }
                    else if (toClickList[i].Equals("EDITORGANIZATION") || toClickList[i].Equals("EDIT USER"))
                    {
                        System.Threading.Thread.Sleep(6000);
                        performAction.clickButton(UserAdminPage.EDITUSER_USERADMIN_XPATH, "EDITUSER_USERADMIN_XPATH");
                        testSteps.Log(LogStatus.Pass, "Click on <b>" + toClickList[i] + "</b>");
                    }
                    else if (toClickList[i].Equals("SAVEORGANIZATION"))
                    {
                        System.Threading.Thread.Sleep(4000);
                        performAction.clickButton(OrganizationPage.SAVEBUTTON_ORGADMIN_XPATH, "SAVEBUTTON_ORGADMIN_XPATH");
                        testSteps.Log(LogStatus.Pass, "Click on <b>" + toClickList[i] + "</b>");
                    }
                    else if (toClickList[i].Equals("SAVEANDUSERADMIN"))
                    {
                        System.Threading.Thread.Sleep(4000);
                        performAction.clickButton(OrganizationPage.SAVEANDUSERBUTTON_ORGADMIN_XPATH, "SAVEANDUSERBUTTON_ORGADMIN_XPATH");
                        testSteps.Log(LogStatus.Pass, "Click on <b>" + toClickList[i] + "</b>");
                        System.Threading.Thread.Sleep(2000);
                    }
                    else if (toClickList[i].Equals("CANCELORGANIZATION"))
                    {
                        performAction.clickButton(OrganizationPage.CANCELBUTTON_ORGADMIN_XPATH, "CANCELBUTTON_ORGADMIN_XPATH");
                        testSteps.Log(LogStatus.Pass, "Click on <b>" + toClickList[i] + "</b>");
                    }
                    else if (toClickList[i].Equals("LICENSINGDETAILS"))
                    {
                        performAction.clickButton(OrganizationPage.LICENSINGDETAILS_ORGADMIN_XPATH, "LICENSINGDETAILS_ORGADMIN_XPATH");
                        testSteps.Log(LogStatus.Pass, "Click on <b>" + toClickList[i] + "</b>");
                    }
                    else if (toClickList[i].Equals("ORGADMIN"))
                    {
                        performAction.clickButton(MenuItemsPage.ORGADMINLINK_MENU_XPATH, "ORGADMINLINK_MENU_XPATH");
                        testSteps.Log(LogStatus.Pass, "Click on <b>" + toClickList[i] + "</b>");
                    }
                    else if (toClickList[i].Equals("ADDORGANIZATION"))
                    {
                        System.Threading.Thread.Sleep(4000);
                        performAction.clickButton(OrganizationPage.ADDORGANIZATION_ORGADMIN_XPATH, "ADDORGANIZATION_ORGADMIN_XPATH");
                        testSteps.Log(LogStatus.Pass, "Click on <b>" + toClickList[i] + "</b>");
                    }
                    else if (toClickList[i].Equals("PRIMARYDETAILS"))
                    {
                        System.Threading.Thread.Sleep(2000);
                        performAction.clickButton(OrganizationPage.PRIMARYDETAILS_ORGADMIN_XPATH, "PRIMARYDETAILS_ORGADMIN_XPATH");
                        testSteps.Log(LogStatus.Pass, "Click on <b>" + toClickList[i] + "</b>");
                    }
                    else if (toClickList[i].Equals("LICENSEDETAILS"))
                    {
                        System.Threading.Thread.Sleep(2000);
                        performAction.clickButton(OrganizationPage.LICENSINGDETAILS_ORGADMIN_XPATH, "LICENSINGDETAILS_ORGADMIN_XPATH");
                        testSteps.Log(LogStatus.Pass, "Click on <b>" + toClickList[i] + "</b>");
                    }
                    else if (toClickList[i].Equals("DEACTIVATELINK"))
                    {
                        System.Threading.Thread.Sleep(2000);
                        performAction.clickButton(OrganizationPage.DEACTIVATEICON_ORGADMIN_XPATH, "DEACTIVATEICON_ORGADMIN_XPATH");
                        testSteps.Log(LogStatus.Pass, "Click on <b>" + toClickList[i] + "</b>");
                    }
                    else if (toClickList[i].Equals("DEACTIVATEBUTTON"))
                    {
                        System.Threading.Thread.Sleep(2000);
                        performAction.clickButton(OrganizationPage.DEACTIVATEBUTTON_ORGADMIN_XPATH, "DEACTIVATEBUTTON_ORGADMIN_XPATH");
                        testSteps.Log(LogStatus.Pass, "Click on <b>" + toClickList[i] + "</b>");
                    }
                    else if (toClickList[i].Equals("BACK") || toClickList[i].Equals("BACKBUTTON"))
                    {
                        performAction.clickButton(OrganizationPage.BACKBUTTON_ORGADMIN_XPATH, "BACKBUTTON_ORGADMIN_XPATH");
                        testSteps.Log(LogStatus.Pass, "Click on <b>" + toClickList[i] + "</b>");
                    }
                    else if (toClickList[i].Equals("USERADMINBUTTON") || toClickList[i].Equals("USERADMIN"))
                    {
                        performAction.clickButton(OrganizationPage.USERADMINBUTTON_ORGADMIN_XPATH, "USERADMINBUTTON_ORGADMIN_XPATH");
                        testSteps.Log(LogStatus.Pass, "Click on <b>" + toClickList[i] + "</b>");
                        System.Threading.Thread.Sleep(3000);
                        IWebElement ele = driver.FindElement(By.XPath("//span[text()='" + testData.OrganizationName + "']"));
                        performAction.highlightText(ele);
                    }
                    else if (toClickList[i].Equals("CANCELDEACTIVATE") || toClickList[i].Equals("CANCELREACTIVATE"))
                    {
                        System.Threading.Thread.Sleep(1000);
                        performAction.clickButton(OrganizationPage.CANCELBUTTON_ORGADMIN_XPATH, "CANCELBUTTON_ORGADMIN_XPATH");
                        testSteps.Log(LogStatus.Pass, "Click on <b>" + toClickList[i] + "</b>");
                    }
                    else if (toClickList[i].Equals("REACTIVATELINK"))
                    {
                        System.Threading.Thread.Sleep(1000);
                        performAction.clickButton(OrganizationPage.REACTIVATELINK_ORGADMIN_XPATH, "REACTIVATELINK_ORGADMIN_XPATH");
                        testSteps.Log(LogStatus.Pass, "Click on <b>" + toClickList[i] + "</b>");
                    }
                    else if (toClickList[i].Equals("ShowOnlyActiveOrganization"))
                    {
                        System.Threading.Thread.Sleep(2000);
                        performAction.clickButton(OrganizationPage.SHOWONLYACTIVEORG_ORGADMIN_XPATH, "SHOWONLYACTIVEORG_ORGADMIN_XPATH");
                        testSteps.Log(LogStatus.Pass, "Click on <b>" + toClickList[i] + "</b>");
                        System.Threading.Thread.Sleep(2000);
                        OrganizationAdmin organizationAdmin = new OrganizationAdmin(driver);
                        testData.UIActiveOrganizationCount = organizationAdmin.getActiveOrganizationCount();
                        Console.WriteLine("testData.UIActiveOrganizationCount=" + testData.UIActiveOrganizationCount);
                    }
                    else if (toClickList[i].Equals("VIEW") || toClickList[i].Equals("VIEWICON") || toClickList[i].Equals("VIEWLINK"))
                    {
                        System.Threading.Thread.Sleep(1000);
                        performAction.clickButton(OrganizationPage.VIEWICON_ORGADMIN_XPATH, "VIEWICON_ORGADMIN_XPATH");
                        testSteps.Log(LogStatus.Pass, "Click on <b>" + toClickList[i] + "</b>");
                    }
                    else if (toClickList[i].Equals("OK"))
                    {
                        System.Threading.Thread.Sleep(2000);
                        driver.FindElement(By.XPath("//div[@aria-labelledby='swal2-title']/div[3]/button[text()='OK']")).Click();
                        testSteps.Log(LogStatus.Pass, "Click on <b>" + toClickList[i] + "</b>");
                    }
                    else
                    {
                        testSteps.Log(LogStatus.Fail, "Unable to click on <b>" + toClickList[i] + "</b>");

                    }

                }

            }
            catch (Exception e)
            {
                testSteps.Log(LogStatus.Fail, "Unable to Click on ", e);
                var imagePath = new CaptureScreenshot(driver).takeScreenshot(testData.testCaseName);
                testSteps.Log(LogStatus.Info, "Snapshot below: " + testSteps.AddScreenCapture(imagePath));
            }
            return testSteps;
        }


    }
}

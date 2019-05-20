using Default.Web.Test.Automation.Entities;
using Default.Web.Test.Automation.Library;
using Default.Web.Test.Automation.ObjectRepository;
using OpenQA.Selenium;
using RelevantCodes.ExtentReports;
using System;

namespace Default.Web.Test.Automation.BusinessUitilities
{
    class MailDataActions
    {
        //Define Objects
        IWebDriver driver;
        PerformAction performAction;

        public MailDataActions(IWebDriver _driver)
        {
            driver = _driver;
            performAction = new PerformAction(driver);
        }
       
        //submit mailing schedule details
        public ExtentTest scheduleMail( ExtentReports report, TestData testdata)
        {
            ExtentTest testSteps = report.StartTest("Submit Mail Schedules Details");
            try
            {
                System.Threading.Thread.Sleep(3000);
                performAction.enterText(MailPage.MAILINGDATE_MAILDATACAPTURE_XPATH, "MAILINGDATE_MAILDATACAPTURE_XPATH", testdata.MailingDate);
                testSteps.Log(LogStatus.Info, "Enter the Mailing Date", "<b>" + testdata.MailingDate + "</b>");
                performAction.enterText(MailPage.MAILDESCRIPTION_MAILDATACAPTURE_XPATH, "MAILDESCRIPTION_MAILDATACAPTURE_XPATH", testdata.MailDescription);
                testSteps.Log(LogStatus.Info, "Enter the Mail Description", "<b>" + testdata.MailDescription + "</b>");
                performAction.enterText(MailPage.REFERENCENUMBER_MAILDATACAPTURE_XPATH, "REFERENCENUMBER_MAILDATACAPTURE_XPATH", testdata.ReferenceNumber);
                testSteps.Log(LogStatus.Info, "Enter the Reference Number",  testdata.ReferenceNumber);
            }
            catch (Exception e)
            {
                String methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                testSteps.Log(LogStatus.Fail, "Unable submit Mail Schedules", e);
                var imagePath = new CaptureScreenshot(driver).takeScreenshot(methodName+"_"+testdata.testCaseName);
                testSteps.Log(LogStatus.Info, "Snapshot below: " + testSteps.AddScreenCapture(imagePath));
            }
            return testSteps;
        }

        public ExtentTest submitRecipentInformation(TestData testdata, ExtentReports report,String dataSetCount)
        {
            ExtentTest testSteps = report.StartTest("Submit Recipient/Mailing Instructions");
            try
            {
                String[] firstName = testdata.PrimaryFirstName.Split('|');
                String[] lastName = testdata.PrimaryLastName.Split('|');
                String[] address1 = testdata.OrganizationAddress1.Split('|');
                String[] address2 = testdata.OrganizationAddress2.Split('|');
                String[] zipCode = testdata.Zipcode.Split('|');
                String[] mailType = testdata.MailType.Split('|');
                String[] mailService = testdata.MailService.Split('|');
                String[] mailEnclosure = testdata.MailEnclosure.Split('|');
                for (int i = 0; i < testdata.recipientListLength; i++)
                {
                    if (i > 0)
                    {
                        testSteps.Log(LogStatus.Info, "<b>=========================================Add Number "+(i+1)+" Recipient</b>", "<b>===================</b>");
                        performAction.clickButton(MailPage.ADDMAILRECIPEINT_MAILDATACAPTURE_XPATH, "ADDMAILRECIPEINT_MAILDATACAPTURE_XPATH");
                        testSteps.Log(LogStatus.Info, "Click on Add Recipient Icon", "");
                    }
                    driver.FindElement(By.XPath("(//input[@placeholder='First Name'])[" + (i + 1) + "]")).SendKeys(firstName[i]);
                    testSteps.Log(LogStatus.Info, "Enter the First Name", firstName[i]);
                    driver.FindElement(By.XPath("(//input[@placeholder='Last Name'])[" + (i + 1) + "]")).SendKeys(lastName[i]);
                    testSteps.Log(LogStatus.Info, "Enter the Last Name", lastName[i]);
                    driver.FindElement(By.XPath("(//input[@placeholder='Address 1'])[" + (i + 1) + "]")).SendKeys(address1[i]);
                    testSteps.Log(LogStatus.Info, "Enter the Address 1", address1[i]);
                    driver.FindElement(By.XPath("(//input[@placeholder='Address 2'])[" + (i + 1) + "]")).SendKeys(address2[i]);
                    testSteps.Log(LogStatus.Info, "Enter the Address 2", address1[i]);
                    driver.FindElement(By.XPath("(//input[@placeholder='ZIP Code'])[" + (i + 1) + "]")).SendKeys(zipCode[i]);
                    testSteps.Log(LogStatus.Info, "Enter the Zip Code", zipCode[i]);
                    performAction.clickButton(MailPage.MAILTYPE_MAILDATACAPTURE_XPATH, "MAILTYPE_MAILDATACAPTURE_XPATH");
                    testSteps.Log(LogStatus.Info, "Click on Mail Type drop down", "");
                    driver.FindElement(By.XPath("//span[text()=' " + mailType[i] + " ']")).Click();
                    testSteps.Log(LogStatus.Info, "Select Mail Type ", mailType[i]);
                    performAction.clickJavaScript(performAction.getLocator(MailPage.MAILSERVICE_MAILDATACAPTURE_XPATH, "MAILSERVICE_MAILDATACAPTURE_XPATH"));
                    testSteps.Log(LogStatus.Info, "Click on Mail Service drop down", "");
                    driver.FindElement(By.XPath("//span[text()=' " + mailService[i] + " ']")).Click();
                    testSteps.Log(LogStatus.Info, "Select Mail Service ", mailService[i]);
                    performAction.clickJavaScript(performAction.getLocator(MailPage.MAILENCLOSURE_MAILDATACAPTURE_XPATH, "MAILENCLOSURE_MAILDATACAPTURE_XPATH"));
                    testSteps.Log(LogStatus.Info, "Click on Mail Enclosure drop down", "");
                    driver.FindElement(By.XPath("//span[text()=' " + mailEnclosure[i] + " ']")).Click();
                    testSteps.Log(LogStatus.Info, "Select Mail Service ", mailEnclosure[i]);
                    System.Threading.Thread.Sleep(1000);
                    performAction.clickJavaScript(performAction.getLocator(MailPage.BACKGROUND_MAILDATACAPTURE_XPATH, "BACKGROUND_MAILDATACAPTURE_XPATH"));
                }
                System.Threading.Thread.Sleep(1000);
                performAction.clickButton(MailPage.RECIPIENTMAILINGINSTRUCTIONS_MAILDATACAPTURE_XPATH, "RECIPIENTMAILINGINSTRUCTIONS_MAILDATACAPTURE_XPATH");
            }
            catch (Exception e)
            {
                String methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                testSteps.Log(LogStatus.Fail, "Unable to submit Recipient/Mailing Instructions", e);
                var imagePath = new CaptureScreenshot(driver).takeScreenshot(methodName + "_" + testdata.testCaseName);
                testSteps.Log(LogStatus.Info, "Snapshot below: " + testSteps.AddScreenCapture(imagePath));
            }
            return testSteps;

        }

        public ExtentTest uploadDocuments(ExtentReports report, TestData testdata,String dataSetCount)
        {
            ExtentTest testSteps = report.StartTest("Upload Documents");
            try
            {
                System.Threading.Thread.Sleep(1000);
                performAction.clickButton(MailPage.DOCUMENTPANEL_MAILDATACAPTURE_XPATH, "DOCUMENTPANEL_MAILDATACAPTURE_XPATH");
                testSteps.Log(LogStatus.Info, "Click on Document Panel", "");
                String[] firstName = testdata.PrimaryFirstName.Split('|');
                String[] lastName = testdata.PrimaryLastName.Split('|');
                String[] address1 = testdata.OrganizationAddress1.Split('|');
                String[] address2 = testdata.OrganizationAddress2.Split('|');
                String[] zipCode = testdata.Zipcode.Split('|');
                String[] mailType = testdata.MailType.Split('|');
                String[] mailService = testdata.MailService.Split('|');
                String[] mailEnclosure = testdata.MailEnclosure.Split('|');
                String[] uploadDocList = testdata.DocumentName.Split('|');
                String[] banner = testdata.Banner.Split('|');
                String[] retainDocument = testdata.RetainDocument.Split('|');
                String[] selectAll = testdata.SelectAll.Split('|');
                testdata.docListLength = uploadDocList.Length;
                
                String projectDirectory = System.AppDomain.CurrentDomain.BaseDirectory;
                projectDirectory = projectDirectory.Replace("\\bin\\Debug\\", "");
                for (int i = 0; i < testdata.docListLength; i++)
                {                  
                    performAction.clickButton(MailPage.UPLOADDOCUMENT_MAILDATACAPTURE_XPATH, "UPLOADDOCUMENT_MAILDATACAPTURE_XPATH");
                    testSteps.Log(LogStatus.Info, "Click on Upload Document Link", "");
                    System.Threading.Thread.Sleep(2000);
                    String filePath = projectDirectory + @"\Documents\" + uploadDocList[i];
                    testSteps.Log(LogStatus.Info, "Document Path", filePath);
                    System.Windows.Forms.SendKeys.SendWait(projectDirectory + @"\Documents\" + uploadDocList[i]);
                    System.Windows.Forms.SendKeys.SendWait(@"{Enter}");
                    System.Threading.Thread.Sleep(1000);
                    if (selectAll[i].Equals("Y"))
                    {
                        driver.FindElement(By.XPath("//tbody/tr[" + (i + 1) + "]/td[4]/div/mat-checkbox/label")).Click();
                        testSteps.Log(LogStatus.Info, "Select All is selected", "");
                    }
                    if (banner[i].Equals("Y"))
                    {
                        driver.FindElement(By.XPath("//tbody/tr[" + (i + 1) + "]/td[2]/div/mat-checkbox/label")).Click();
                        testSteps.Log(LogStatus.Info, "Banner Included is selected", "");
                    }
                    if (retainDocument[i].Equals("Yes"))
                    {
                        driver.FindElement(By.XPath("//tbody/tr[" + (i + 1) + "]/td[3]/div/mat-checkbox/label")).Click();
                        testSteps.Log(LogStatus.Info, "Retain Document is selected", "");
                    }
                    System.Threading.Thread.Sleep(1000);
                }
                performAction.clickButton(MailPage.DOCUMENTPANEL_MAILDATACAPTURE_XPATH, "DOCUMENTPANEL_MAILDATACAPTURE_XPATH");
                testSteps.Log(LogStatus.Info, "Click on Document Panel", "");

                System.Threading.Thread.Sleep(700);
                performAction.clickButton(MailPage.REVIEWRELEASEPANEL_MAILDATACAPTURE_XPATH, "REVIEWRELEASEPANEL_MAILDATACAPTURE_XPATH");
                testSteps.Log(LogStatus.Info, "Click on Review Release Panel", "");
                System.Threading.Thread.Sleep(700);
                for (int j=0;j< testdata.recipientListLength;j++) {
                  
                   performAction.highlightText(driver.FindElement(By.XPath("//td[text()=' " + firstName[j] + " " + lastName[j] + "']")));
                    testSteps.Log(LogStatus.Info, "Verify Send To", firstName[j] + " " + lastName[j]);
                    performAction.highlightText(driver.FindElement(By.XPath("//td[text()=' " + mailType[j] + " ']")));
                    testSteps.Log(LogStatus.Info, "Verify Mail Type", mailType[j]);
                    performAction.highlightText(driver.FindElement(By.XPath("//span[text()=' " + mailService[j] + " ']")));
                    testSteps.Log(LogStatus.Info, "Verify Mail Service", mailService[j]);
                    performAction.highlightText(driver.FindElement(By.XPath("//span[text()=' " + mailEnclosure[j] + " ']")));
                    testSteps.Log(LogStatus.Info, "Verify Mail Enclosure", mailEnclosure[j]);
                    System.Threading.Thread.Sleep(800);
                    driver.FindElement(By.XPath("(//i[@ng-reflect-message='View Document'])["+(j+1)+"]")).Click();
                    testSteps.Log(LogStatus.Info, "Click on view Document", "");
                    performAction.highlightText(driver.FindElement(By.XPath("//h4[text()=' Attached Documents ']")));
                    testSteps.Log(LogStatus.Info, "Verify Attached Document Title", "");

                    if (selectAll[j].Equals("Y"))
                        {
                        for (int k = 0; k <uploadDocList.Length;k++)
                        {
                            performAction.highlightText(driver.FindElement(By.XPath("(//div[text()=' " + uploadDocList[k] + " '])["+(j+1)+"]")));
                            testSteps.Log(LogStatus.Info, "Verify Uploaded document", uploadDocList[k]);
                        }
                        System.Threading.Thread.Sleep(700);
                        performAction.clickButton(MailPage.CLOSEATTACHEDDOCS_MAILDATACAPTURE_XPATH, "CLOSEATTACHEDDOCS_MAILDATACAPTURE_XPATH");
                        testSteps.Log(LogStatus.Info, "Click on Close Attached Documents", "");
                    }else
                    {
                        int docListCount = driver.FindElements(By.XPath("//div[@id='pdf-loader']/div/div")).Count;
                        if (docListCount>0)
                        {
                            testSteps.Log(LogStatus.Fail, "Document is not selected but it displays as attached", "");
                        }else
                        {
                            testSteps.Log(LogStatus.Pass, "Document is not present in Attached modal pop-up", "");
                            System.Threading.Thread.Sleep(700);
                            performAction.clickButton(MailPage.CLOSEATTACHEDDOCS_MAILDATACAPTURE_XPATH, "CLOSEATTACHEDDOCS_MAILDATACAPTURE_XPATH");
                            testSteps.Log(LogStatus.Info, "Click on Close Attached Documents", "");

                        }
                    }

                }
                System.Threading.Thread.Sleep(1500);
                performAction.clickButton(MailPage.RELEASEDOCUMENT_MAILDATACAPTURE_XPATH, "RELEASEDOCUMENT_MAILDATACAPTURE_XPATH");
                testSteps.Log(LogStatus.Info, "Click on Release button", "");
                System.Threading.Thread.Sleep(5000);
                String mailingId = driver.FindElement(By.XPath("//p[contains(text(),' Mail Request ID is')]")).Text.Replace("Mail Request ID is ", "");
                testSteps.Log(LogStatus.Info, "Mail request Id is ", mailingId);
                performAction.clickButton(MailPage.CLOSE_MAILDATACAPTURE_XPATH, "CLOSE_MAILDATACAPTURE_XPATH");
                testSteps.Log(LogStatus.Info, "Click on close button", "");
                testdata.MailingId = mailingId;
            }
            catch (Exception e)
            {
                String methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                testSteps.Log(LogStatus.Fail, "Unable Release the document", e);
                var imagePath = new CaptureScreenshot(driver).takeScreenshot(methodName + "_" + testdata.testCaseName);
                testSteps.Log(LogStatus.Info, "Snapshot below: " + testSteps.AddScreenCapture(imagePath));
            }
            return testSteps;

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
            if (toClickList[i].Equals("MAIL"))
            {
                        System.Threading.Thread.Sleep(2000);
                        
               performAction.clickButton(MenuItemsPage.MAILLINK_MENU_XPATH, "MAILLINK_MENU_XPATH");
                testSteps.Log(LogStatus.Pass, "Click on <b>" + toClickList[i] + "</b>");
            }else if (toClickList[i].Equals("MAILDATACAPTURE"))
                    {
                        performAction.clickButton(MenuItemsPage.MAILDATACAPTURELINK_MENU_XPATH, "MAILDATACAPTURELINK_MENU_XPATH");
                        testSteps.Log(LogStatus.Pass, "Click on <b>" + toClickList[i] + "</b>");
                    }
                    else if (toClickList[i].Equals("ACCEPTALERT") || toClickList[i].Equals("OK"))
                    {
                        driver.FindElement(By.XPath("//button[text()='Ok']")).Click();
                        testSteps.Log(LogStatus.Pass, "Click on <b>" + toClickList[i] + "</b>");
                    }
                    else if (toClickList[i].Equals("RELEASE"))
                    {
                        performAction.clickButton(MailPage.REVIEWRELEASEPANEL_MAILDATACAPTURE_XPATH, "REVIEWRELEASEPANEL_MAILDATACAPTURE_XPATH");
                        System.Threading.Thread.Sleep(1000);
                        performAction.clickButton(MailPage.RELEASEDOCUMENT_MAILDATACAPTURE_XPATH, "RELEASEDOCUMENT_MAILDATACAPTURE_XPATH");
                        testSteps.Log(LogStatus.Pass, "Click on <b>" + toClickList[i] + "</b>");

                    }
                    else if (toClickList[i].Equals("CLOSE"))
                    {
                        driver.FindElement(By.XPath("(//button[text()=' Close '])[3]")).Click();
                        testSteps.Log(LogStatus.Pass, "Click on <b>" + toClickList[i] + "</b>");

                    }
                    else if (toClickList[i].Equals("MAILHISTORY"))
                    {
                        performAction.clickButton(MailPage.MAILHISTORY_MAILDATACAPTURE_XPATH, "MAILHISTORY_MAILDATACAPTURE_XPATH");
                        testSteps.Log(LogStatus.Pass, "Click on <b>" + toClickList[i] + "</b>");
                        System.Threading.Thread.Sleep(5000);
                    }
                    else if (toClickList[i].Equals("SEARCH") || toClickList[i].Equals("SEARCHICON"))
                    {
                        System.Threading.Thread.Sleep(1000);
                        performAction.clickButton(MailPage.SEARCHICON_MAILHISTORY_XPATH, "SEARCHICON_MAILHISTORY_XPATH");
                        testSteps.Log(LogStatus.Pass, "Click on <b>" + toClickList[i] + "</b>");
                        System.Threading.Thread.Sleep(1000);
                    }
                    else if (toClickList[i].Equals("MAILRECONCILIATION"))
                    {
                        performAction.clickButton(MailPage.MAILRECONCILIATION_MAIL_XPATH, "MAILRECONCILIATION_MAIL_XPATH");
                        testSteps.Log(LogStatus.Pass, "Click on <b>" + toClickList[i] + "</b>");
                        System.Threading.Thread.Sleep(5000);
                    }else if (toClickList[i].Equals("UPLOADDOCUMENT"))
                    {
                        String projectDirectory = System.AppDomain.CurrentDomain.BaseDirectory;
                        projectDirectory = projectDirectory.Replace("\\bin\\Debug\\", "");
                        performAction.clickButton(MailPage.DOCUMENTPANEL_MAILDATACAPTURE_XPATH, "DOCUMENTPANEL_MAILDATACAPTURE_XPATH");
                        testSteps.Log(LogStatus.Info, "Click on Document Panel", "");
                        System.Threading.Thread.Sleep(900);
                        performAction.clickButton(MailPage.UPLOADDOCUMENT_MAILDATACAPTURE_XPATH, "UPLOADDOCUMENT_MAILDATACAPTURE_XPATH");
                    testSteps.Log(LogStatus.Info, "Click on Upload Document Link", "");
                    System.Threading.Thread.Sleep(1000);
                    String filePath = projectDirectory + @"\Documents\" + testData.DocumentName;
                    testSteps.Log(LogStatus.Info, "Document Path", filePath);
                    System.Windows.Forms.SendKeys.SendWait(projectDirectory + @"\Documents\" + testData.DocumentName);
                    System.Windows.Forms.SendKeys.SendWait(@"{Enter}");
                    }
                    else if (toClickList[i].Equals("REMOVEDOCUMENT"))
                    {
                        System.Threading.Thread.Sleep(800);
                        performAction.clickButton(MailPage.REMOVEDOC_MAILDATACAPTURE_XPATH, "REMOVEDOC_MAILDATACAPTURE_XPATH");
                        testSteps.Log(LogStatus.Pass, "Click on Remove button","");
                        System.Threading.Thread.Sleep(800);
                        int documentPresentCount = driver.FindElements(By.XPath("//*[@id='cdk - accordion - child - 1']/div/div/div/div/div/table/tbody/tr")).Count;
                        if (documentPresentCount==0)
                        {
                            testSteps.Log(LogStatus.Pass, "Document is removed successfully","");
                        }else
                        {
                            testSteps.Log(LogStatus.Fail, "Unable to remove the uploaded document","");
                        }                     
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

        //Verify data in Review Release Section
        public ExtentTest reviewRelease(ExtentReports report, TestData testdata)
        {
            ExtentTest testSteps = report.StartTest("Review Release Steps");
            try
            {
                //fetch data
                String[] firstName = testdata.PrimaryFirstName.Split('|');
                String[] lastName = testdata.PrimaryLastName.Split('|');
                String[] address1 = testdata.OrganizationAddress1.Split('|');
                String[] address2 = testdata.OrganizationAddress2.Split('|');
                String[] zipCode = testdata.Zipcode.Split('|');
                String[] mailType = testdata.MailType.Split('|');
                String[] mailService = testdata.MailService.Split('|');
                String[] mailEnclosure = testdata.MailEnclosure.Split('|');
                String[] uploadDocList = testdata.DocumentName.Split('|');
                String[] banner = testdata.Banner.Split('|');
                String[] retainDocument = testdata.RetainDocument.Split('|');
                String[] selectAll = testdata.SelectAll.Split('|');
                System.Threading.Thread.Sleep(700);
                performAction.clickButton(MailPage.REVIEWRELEASEPANEL_MAILDATACAPTURE_XPATH, "REVIEWRELEASEPANEL_MAILDATACAPTURE_XPATH");
                testSteps.Log(LogStatus.Info, "Click on Review Release Panel", "");
                System.Threading.Thread.Sleep(700);
                for (int j = 0; j < Convert.ToInt32(testdata.recipientListLength); j++)
                {
                    performAction.highlightText(driver.FindElement(By.XPath("//td[text()=' " + firstName[j] + " " + lastName[j] + "']")));
                    testSteps.Log(LogStatus.Info, "Verify Send To", firstName[j] + " " + lastName[j]);
                    performAction.highlightText(driver.FindElement(By.XPath("//td[text()=' " + mailType[j] + " ']")));
                    testSteps.Log(LogStatus.Info, "Verify Mail Type", mailType[j]);
                    performAction.highlightText(driver.FindElement(By.XPath("//span[text()=' " + mailService[j] + " ']")));
                    testSteps.Log(LogStatus.Info, "Verify Mail Service", mailService[j]);
                    performAction.highlightText(driver.FindElement(By.XPath("//span[text()=' " + mailEnclosure[j] + " ']")));
                    testSteps.Log(LogStatus.Info, "Verify Mail Enclosure", mailEnclosure[j]);

                    driver.FindElement(By.XPath("(//i[@ng-reflect-message='View Document'])[" + (j + 1) + "]")).Click();
                    testSteps.Log(LogStatus.Info, "Click on view Document", "");
                    performAction.highlightText(driver.FindElement(By.XPath("//h4[text()=' Attached Documents ']")));
                    testSteps.Log(LogStatus.Info, "Verify Attached Document Title", "");

                    if (selectAll[j].Equals("Y"))
                    {
                        for (int k = 0; k < testdata.docListLength; k++)
                        {
                            performAction.highlightText(driver.FindElement(By.XPath("(//div[text()=' " + uploadDocList[k] + " '])[" + (j + 1) + "]")));
                            testSteps.Log(LogStatus.Info, "Verify Uploaded document", uploadDocList[k]);
                        }
                        System.Threading.Thread.Sleep(700);
                        performAction.clickButton(MailPage.CLOSEATTACHEDDOCS_MAILDATACAPTURE_XPATH, "CLOSEATTACHEDDOCS_MAILDATACAPTURE_XPATH");
                        testSteps.Log(LogStatus.Info, "Click on Close Attached Documents", "");
                    }
                    else
                    {
                        int docListCount = driver.FindElements(By.XPath("//div[@id='pdf-loader']/div/div")).Count;
                        if (docListCount > 0)
                        {
                            testSteps.Log(LogStatus.Fail, "Document is not selected but it displays as attached", "");
                        }
                        else
                        {
                            testSteps.Log(LogStatus.Pass, "Document is not present in Attached modal pop-up", "");
                            System.Threading.Thread.Sleep(700);
                            performAction.clickButton(MailPage.CLOSEATTACHEDDOCS_MAILDATACAPTURE_XPATH, "CLOSEATTACHEDDOCS_MAILDATACAPTURE_XPATH");
                            testSteps.Log(LogStatus.Info, "Click on Close Attached Documents", "");

                        }
                    }

                }
                System.Threading.Thread.Sleep(3000);
                performAction.clickButton(MailPage.RELEASEDOCUMENT_MAILDATACAPTURE_XPATH, "RELEASEDOCUMENT_MAILDATACAPTURE_XPATH");
                testSteps.Log(LogStatus.Info, "Click on Release button", "");
                System.Threading.Thread.Sleep(3000);
                String mailingId = driver.FindElement(By.XPath("//p[contains(text(),' Mail Request ID is')]")).Text.Replace("Mail Request ID is ", "");
                testSteps.Log(LogStatus.Info, "Mail request Id is ", mailingId);
                performAction.clickButton(MailPage.CLOSE_MAILDATACAPTURE_XPATH, "CLOSE_MAILDATACAPTURE_XPATH");
                testSteps.Log(LogStatus.Info, "Click on close button", "");
                testdata.MailingId = mailingId;
            }
            catch (Exception e)
            {
                String methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                testSteps.Log(LogStatus.Fail, "Unable Verify data in Review Release section", e);
                var imagePath = new CaptureScreenshot(driver).takeScreenshot(methodName + "_" + testdata.testCaseName);
                testSteps.Log(LogStatus.Info, "Snapshot below: " + testSteps.AddScreenCapture(imagePath));
            }
            return testSteps;
        }

    }
}

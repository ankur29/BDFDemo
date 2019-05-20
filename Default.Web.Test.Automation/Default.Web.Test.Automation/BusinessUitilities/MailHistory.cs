using Default.Web.Test.Automation.Entities;
using Default.Web.Test.Automation.Library;
using Default.Web.Test.Automation.ObjectRepository;
using OpenQA.Selenium;
using RelevantCodes.ExtentReports;
using System;


namespace Default.Web.Test.Automation.BusinessUitilities
{
    class MailHistory
    {
        //Define Objects
        IWebDriver driver;
        PerformAction performAction;
        public MailHistory(IWebDriver _driver)
        {
            driver = _driver;
            performAction = new PerformAction(driver);
        }

        //Mail History Page
        public ExtentTest searchMailHistory(ExtentReports report, TestData testdata)
        {
            ExtentTest testSteps = report.StartTest("Search Mail History Steps");
            
            String[] firstName = testdata.PrimaryFirstName.Split('|');
            String[] lastName = testdata.PrimaryLastName.Split('|');
            String[] uploadDocList = testdata.DocumentName.Split('|');
            String[] banner = testdata.Banner.Split('|');
            String[] retainDocument = testdata.RetainDocument.Split('|');
            String[] selectAll = testdata.SelectAll.Split('|');        
            String[] address1 = testdata.OrganizationAddress1.Split('|');
            String[] address2 = testdata.OrganizationAddress2.Split('|');
            String[] zipCode = testdata.Zipcode.Split('|');
            String[] mailType = testdata.MailType.Split('|');
            String[] mailService = testdata.MailService.Split('|');
            String[] mailEnclosure = testdata.MailEnclosure.Split('|');
            int searchCount = firstName.Length;
            verifyHeaders(testSteps,testdata);           
            try
            {
                for (int i = 0; i < searchCount; i++)
                {
                    testdata.SentTo = firstName[i] + " " + lastName[i];
                    System.Threading.Thread.Sleep(800);
                    performAction.enterText(MailPage.SENTTOSEARCH_MAILHISTORY_XPATH, "SENTTOSEARCH_MAILHISTORY_XPATH", testdata.SentTo);
                    testSteps.Log(LogStatus.Info, "Enter Sent To", testdata.SentTo);
                    performAction.enterText(MailPage.REFERENCENUMBER_MAILHISTORY_XPATH, "REFERENCENUMBER_MAILHISTORY_XPATH", testdata.ReferenceNumber);
                    testSteps.Log(LogStatus.Info, "Enter Reference Number", testdata.ReferenceNumber);
                    performAction.clickButton(MailPage.SEARCHICON_MAILHISTORY_XPATH, "SEARCHICON_MAILHISTORY_XPATH");
                    testSteps.Log(LogStatus.Info, "Click on Search Icon", "");
                    System.Threading.Thread.Sleep(3000);
                    int count = Convert.ToInt32(testdata.UploadDocumentCount);
                    for (int j = count; j >= 1; j--)
                    {
                        testSteps.Log(LogStatus.Info, "=============Verify Mailing Data for Recipient " + (j) + "===============", "============================");
                        //verify Search Data
                        performAction.highlightText(driver.FindElement(By.XPath("//tbody/tr[" + j + "]/td[contains(text(),'" + testdata.MailingId + "')]")));
                        String mailID = driver.FindElement(By.XPath("//tbody/tr[" + j + "]/td[contains(text(),'" + testdata.MailingId + "')]")).Text;
                        testSteps.Log(LogStatus.Info, "Verify Mail ID", mailID);
                        performAction.highlightText(driver.FindElement(By.XPath("//tbody/tr[" + j + "]/td[text()=' " + testdata.ReferenceNumber + " ']")));
                        testSteps.Log(LogStatus.Info, "Verify Reference Number", testdata.ReferenceNumber);
                        performAction.highlightText(driver.FindElement(By.XPath("//tbody/tr[" + j + "]/td[contains(text(),' " + testdata.SentTo + " ')]")));
                        testSteps.Log(LogStatus.Info, "Verify Recipient Name", firstName[i] + " " + lastName[i]);
                        performAction.highlightText(driver.FindElement(By.XPath("//tbody/tr[" + j + "]/td[contains(text(),'" + zipCode[i] + "')]")));
                        testSteps.Log(LogStatus.Info, "Verify Zip Code", zipCode[i]);
                        performAction.highlightText(driver.FindElement(By.XPath("//tbody/tr[" + j + "]/td[contains(text(),'" + mailType[i] + "')]")));
                        testSteps.Log(LogStatus.Info, "Verify Mail Type", mailType[i]);
                        performAction.highlightText(driver.FindElement(By.XPath("//tbody/tr[" + j + "]/td[contains(text(),'" + mailService[i] + "')]")));
                        testSteps.Log(LogStatus.Info, "Verify Mail Service", mailService[i]);
                        performAction.highlightText(driver.FindElement(By.XPath("//tbody/tr[" + j + "]/td[contains(text(),'" + testdata.MailDescription + "')]")));
                        if (mailService[count - j].Contains("Certified"))
                        {
                            IWebElement certifiedEle = driver.FindElement(By.XPath("//tr[" + j + "]/td[contains(@class,'certifiedMailIdNumber')]"));
                            performAction.highlightText(certifiedEle);
                            testSteps.Log(LogStatus.Info, "Verify Certified Number", testdata.CertifiedNumber);

                        }
                        performAction.highlightText(driver.FindElement(By.XPath("//tbody/tr[" + j + "]/td[contains(text(),'" + retainDocument[i] + "')]")));
                        testSteps.Log(LogStatus.Info, "Retain Document", retainDocument[i]);
                        testSteps.Log(LogStatus.Info, "Verify Mail Description", testdata.MailDescription);
                        performAction.highlightText(driver.FindElement(By.XPath("//tbody/tr[" + j + "]/td[contains(text(),'" + testdata.UserName + "')]")));
                        testSteps.Log(LogStatus.Info, "Verify Submitted By", testdata.UserName);

                        driver.FindElement(By.XPath("//tbody/tr[1]/td[13]/span/i")).Click();
                        System.Threading.Thread.Sleep(5000);
                        String url = driver.Url.Replace("blob:","");
                        testSteps.Log(LogStatus.Info, "Uploaded document Url", url);
                        

                    }
                }
           }
            catch (Exception e)
            {
                testSteps.Log(LogStatus.Fail, "Unable to Search Mail History", e);
                var imagePath = new CaptureScreenshot(driver).takeScreenshot(testdata.testCaseName);
                testSteps.Log(LogStatus.Info, "Snapshot below: " + testSteps.AddScreenCapture(imagePath));
            }
            return testSteps;
        }

       
    //Verify Searched Data on UI
    public ExtentTest verifyHeaders(ExtentTest testSteps, TestData testdata)
        {
            try
            {
                System.Threading.Thread.Sleep(1000);
                //Verify Table Headers
                int tableHeaderSize = driver.FindElements(By.XPath("//table/thead/tr/th")).Count;
                for (int i = 1; i <= tableHeaderSize; i++)
                {
                    performAction.highlightText(driver.FindElement(By.XPath("//table/thead/tr/th[" + i + "]")));
                    String headerValue = driver.FindElement(By.XPath("//table/thead/tr/th[" + i + "]")).Text;
                    testSteps.Log(LogStatus.Info, "Verify Table Header", headerValue);
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

     

        //verify Pagination Result
        public ExtentTest validatePaginationResult(ExtentReports report, TestData testdata)
        {
            ExtentTest testSteps = report.StartTest("Validate Pagination");
            try
            {
                System.Threading.Thread.Sleep(1000);
                performAction.clickButton(MailPage.ITEMPERPAGEDROPDOWN_MAILHISTORY_XPATH, "ITEMPERPAGEDROPDOWN_MAILHISTORY_XPATH");
                testSteps.Log(LogStatus.Info, "Click on Pagination Drop down", "");
                driver.FindElement(By.XPath("//span[@class='mat-option-text' and text()='"+testdata.PaginationCount+"']")).Click();
                testSteps.Log(LogStatus.Info, "Select Items Per page value", testdata.PaginationCount);
                System.Threading.Thread.Sleep(2000);

                int tableRowCount = driver.FindElements(By.XPath("//table/tbody/tr")).Count;
                System.Console.WriteLine("tableRowCount=" + tableRowCount);
                if (tableRowCount==Convert.ToInt32(testdata.PaginationCount))
                {
                    testSteps.Log(LogStatus.Pass, "Pagination Count and Data display Count is matched successfully", "");
                }else
                {
                    testSteps.Log(LogStatus.Fail, "Pagination Count and Data display Count does not match", "");
                }
            }
            catch (Exception e)
            {
                testSteps.Log(LogStatus.Fail, "Unable to Validate Pagination", e);
                var imagePath = new CaptureScreenshot(driver).takeScreenshot(testdata.testCaseName);
                testSteps.Log(LogStatus.Info, "Snapshot below: " + testSteps.AddScreenCapture(imagePath));
            }
            return testSteps;
        }


    }
}

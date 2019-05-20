using Default.Web.Test.Automation.Entities;
using Default.Web.Test.Automation.Library;
using Default.Web.Test.Automation.ObjectRepository;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using RelevantCodes.ExtentReports;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Default.Web.Test.Automation.BusinessUitilities
{
    class MailReconciliation
    {
        //Define Objects
        IWebDriver driver;
        PerformAction performAction;
        public MailReconciliation(IWebDriver _driver)
        {
            driver = _driver;
            performAction = new PerformAction(driver);
        }

        
        public ExtentTest reconcileMail(ExtentReports report, TestData testdata)
        {
            ExtentTest testSteps = report.StartTest("Mail Reconciliation Steps");
            try
            {
                //    System.Threading.Thread.Sleep(1000);                
                //    performAction.clickButton(MailPage.MAILRECONCILIATION_MAIL_XPATH, "MAILRECONCILIATION_MAIL_XPATH");
                //    testSteps.Log(LogStatus.Info, "Click on Mail Reconciliation Link", "");
                //System.Threading.Thread.Sleep(3000);
                //String currentDate = DateTime.Today.ToString("MM-dd-yyyy").ToString();
                //Console.WriteLine(currentDate);
              
                //    performAction.clickButton(MailPage.FILTER_MAIL_XPATH, "FILTER_MAIL_XPATH");
                //driver.FindElement(By.XPath("//span[text()=' All ']")).Click();
                //System.Threading.Thread.Sleep(2000);
                //performAction.clickButton(MailPage.MAILREQUESTID_RECONCILIATION_XPATH, "MAILREQUESTID_RECONCILIATION_XPATH");
                //System.Threading.Thread.Sleep(2000);
                //performAction.clickButton(MailPage.MAILREQUESTID_RECONCILIATION_XPATH, "MAILREQUESTID_RECONCILIATION_XPATH");
                //testSteps.Log(LogStatus.Info, "Click on MailRequest Header", "");
                System.Threading.Thread.Sleep(2000);

                //        int tbodyRowCount = driver.FindElements(By.XPath("//tbody/tr")).Count;
                //for(int i = 1; i <= tbodyRowCount; i++)
                //        {
                string existingWindowHandle = driver.CurrentWindowHandle;
                Console.WriteLine(existingWindowHandle);

                //            String MailRequestID = driver.FindElement(By.XPath("//tbody/tr[" + i + "]/td[2]")).Text.Trim();
                //            if (MailRequestID.Equals(testdata.MailingId)) {
                //                String mailId = MailRequestID + "-" + testdata.Id;
                //                performAction.highlightText(driver.FindElement(By.XPath("//tbody/tr/td[contains(text(),'" + mailId + "')]")));
                //                testSteps.Log(LogStatus.Info, "Verify Mail Id", mailId);
                //                performAction.highlightText(driver.FindElement(By.XPath("//tbody/tr[" + i + "]/td[4]")));
                //                testSteps.Log(LogStatus.Info, "Verify Printed date", driver.FindElement(By.XPath("//tbody/tr[" + i + "]/td[4]")).Text);
                //                driver.FindElement(By.XPath("//tbody/tr["+i+"]/td[6]/span/span[1]")).Click();
                //                testSteps.Log(LogStatus.Info, "Click on Send to GMC Icon", "");
                driver.FindElement(By.XPath("//tbody/tr[1]/td[6]/span/span[2]")).Click();
                        testSteps.Log(LogStatus.Info, "Click on print document Icon", "");
                //  System.Threading.Thread.Sleep(5000);
                //   Console.WriteLine(driver.FindElement(By.XPath("//*[@id='title']/span")).Text);
                ReadOnlyCollection<string> windowHandles = driver.WindowHandles;
                Console.WriteLine(windowHandles.Count);
                   Console.WriteLine(windowHandles);
               



                // }


            }
            catch (Exception e)
            {
                testSteps.Log(LogStatus.Fail, "Unable to verify the data on Mail History Page", e);
                var imagePath = new CaptureScreenshot(driver).takeScreenshot(testdata.testCaseName);
                testSteps.Log(LogStatus.Info, "Snapshot below: " + testSteps.AddScreenCapture(imagePath));
            }
            return testSteps;
        }


        public void pdfReader()
        {
            StringBuilder text = new StringBuilder();
            using (PdfReader reader = new PdfReader("C:/Users/ankur.choudhary/Downloads/Test.pdf"))
            {
                for (int i = 1; i <= reader.NumberOfPages; i++)
                {
                    text.Append(PdfTextExtractor.GetTextFromPage(reader, i));
                }
            }

            Console.WriteLine( text.ToString());
        }

    }
}

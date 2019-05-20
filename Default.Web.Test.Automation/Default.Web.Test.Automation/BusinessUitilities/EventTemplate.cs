using Default.Web.Test.Automation.Entities;
using Default.Web.Test.Automation.Library;
using Default.Web.Test.Automation.ObjectRepository;
using OpenQA.Selenium;
using RelevantCodes.ExtentReports;
using System;

namespace Default.Web.Test.Automation.BusinessUitilities
{
    class EventTemplate
    {
        //Define Objects
        IWebDriver driver;
        PerformAction performAction;
        public EventTemplate(IWebDriver _driver)
        {
            driver = _driver;
            performAction = new PerformAction(driver);
        }
        //Add Event Template
        public ExtentTest addTemplate(ExtentReports report, TestData testData)
        {
            ExtentTest testSteps = report.StartTest("Add Event Template Steps");
            try
            {
                selectOrganization(testSteps, testData);
                performAction.clickButton(EventPage.ADDNEWTEMPLATE_EVENTTEMPLATE_XPATH, "ADDNEWTEMPLATE_EVENTTEMPLATE_XPATH");
                testSteps.Log(LogStatus.Pass, "Click on Add New Template button", "");
                System.Threading.Thread.Sleep(700);
                performAction.highlightText(driver.FindElement(By.XPath("//input[@ng-reflect-value='"+testData.OrganizationName+"']")));
                testSteps.Log(LogStatus.Pass, "Verify Organization Name", testData.OrganizationName);
                performAction.clickButton(EventPage.TEMPLATECODE_ADDTEMPLATE_XPATH, "TEMPLATECODE_ADDTEMPLATE_XPATH");
                performAction.enterText(EventPage.TEMPLATECODE_ADDTEMPLATE_XPATH, "TEMPLATECODE_ADDTEMPLATE_XPATH",testData.TemplateCode);
                testSteps.Log(LogStatus.Pass, "Enter Template Code", testData.TemplateCode);
                performAction.clickButton(EventPage.TEMPLATENAME_ADDTEMPLATE_XPATH, "TEMPLATENAME_ADDTEMPLATE_XPATH");
                performAction.enterText(EventPage.TEMPLATENAME_ADDTEMPLATE_XPATH, "TEMPLATENAME_ADDTEMPLATE_XPATH", testData.EventName);
                testSteps.Log(LogStatus.Pass, "Enter Template Name", testData.EventName);
                performAction.clickButton(EventPage.STARTDATE_ADDTEMPLATE_XPATH, "STARTDATE_ADDTEMPLATE_XPATH");
                performAction.enterText(EventPage.STARTDATE_ADDTEMPLATE_XPATH, "STARTDATE_ADDTEMPLATE_XPATH",testData.StartDate);
                testSteps.Log(LogStatus.Pass, "Enter Start Date", testData.StartDate);
                performAction.clickButton(EventPage.ENDDATE_ADDTEMPLATE_XPATH, "ENDDATE_ADDTEMPLATE_XPATH");
                performAction.enterText(EventPage.ENDDATE_ADDTEMPLATE_XPATH, "ENDDATE_ADDTEMPLATE_XPATH", testData.EndDate);
                testSteps.Log(LogStatus.Pass, "Enter End Date", testData.EndDate);
                if (testData.IsPrimaryEvent.Equals("N"))
                {
                    performAction.clickButton(EventPage.PRIMARYEVENTCHECKBOX_ADDTEMPLATE_XPATH, "PRIMARYEVENTCHECKBOX_ADDTEMPLATE_XPATH");
                    testSteps.Log(LogStatus.Pass, "Primary Event Check box is De-selected", "");
                }else
                {
                    performAction.highlightText(performAction.getLocator(EventPage.PRIMARYEVNTCHECKBOXSTATUS_ADDTEMPLATE_XPATH, "PRIMARYEVNTCHECKBOXSTATUS_ADDTEMPLATE_XPATH"));
                    testSteps.Log(LogStatus.Pass, "Primary Event Check box is selected", "");
                }
                
            }
            catch (Exception e)
            {
                testSteps.Log(LogStatus.Fail, "Unable to Add Event Template", e);
                var imagePath = new CaptureScreenshot(driver).takeScreenshot(testData.testCaseName);
                testSteps.Log(LogStatus.Info, "Snapshot below: " + testSteps.AddScreenCapture(imagePath));
            }
            return testSteps;
        }
        //select Organization
        private ExtentTest selectOrganization(ExtentTest testSteps,TestData testData)
        {
            System.Threading.Thread.Sleep(7000);
            performAction.clickButton(EventPage.ORGANIZATIONDROPDOWN_EVENTTEMPLATE_XPATH, "ORGANIZATIONDROPDOWN_EVENTTEMPLATE_XPATH");
            testSteps.Log(LogStatus.Pass, "Click on Organization drop down", "");
            System.Threading.Thread.Sleep(3000);
            performAction.clickJavaScript(driver.FindElement(By.XPath("//span[text()=' " + testData.OrganizationName + " ']")));           
            testSteps.Log(LogStatus.Pass, "Select an Organization", testData.OrganizationName);
            return testSteps;
       }

        //Add Event to Template
        public ExtentTest addEventToTemplate(ExtentReports report, TestData testData)
        {
            ExtentTest testSteps = report.StartTest("Add Event To Template Steps");
            try
            {
                System.Threading.Thread.Sleep(1000);
                performAction.clickButton(EventPage.EVENTCODE_EVENTFINDER_XPATH, "EVENTCODE_EVENTFINDER_XPATH");
                performAction.enterText(EventPage.EVENTCODE_EVENTFINDER_XPATH, "EVENTCODE_EVENTFINDER_XPATH", testData.EventCode);
                testSteps.Log(LogStatus.Pass, "Enter an Event Code", testData.EventCode);
                performAction.clickButton(EventPage.EVENTDESCRIPTION_EVENTFINDER_XPATH, "EVENTDESCRIPTION_EVENTFINDER_XPATH");
                performAction.enterText(EventPage.EVENTDESCRIPTION_EVENTFINDER_XPATH, "EVENTDESCRIPTION_EVENTFINDER_XPATH", testData.EventName);
                testSteps.Log(LogStatus.Pass, "Enter an Event Name", testData.EventName);
                performAction.clickButton(EventPage.MILESTONE_EVENTFINDER_XPATH, "MILESTONE_EVENTFINDER_XPATH");
                testSteps.Log(LogStatus.Pass, "Click on MIleStone drop down", "");
                driver.FindElement(By.XPath("//span[text()=' "+testData.Milestone+" ']")).Click();
                testSteps.Log(LogStatus.Pass, "Milestone drop down selected as ", testData.Milestone);
                if (testData.ShowActiveEvents.Equals("Y"))
                {
                    performAction.clickButton(EventPage.SHOWACTIVEEVENTSCHECKBOX_EVENTFINDER_XPATH, "SHOWACTIVEEVENTSCHECKBOX_EVENTFINDER_XPATH");
                    testSteps.Log(LogStatus.Pass, "Click on Show Only Active Events Check box", "");
                }
                performAction.clickButton(EventPage.SEARCHICON_EVENTFINDER_XPATH, "SEARCHICON_EVENTFINDER_XPATH");
                testSteps.Log(LogStatus.Pass, "Click on Search Icon", "");
                addEventList(testSteps,testData);
                System.Threading.Thread.Sleep(2000);
                performAction.clickButton(EventPage.ADDTOTEMPLATE_EVENTFINDER_XPATH, "ADDTOTEMPLATE_EVENTFINDER_XPATH");
                System.Threading.Thread.Sleep(2000);
                submitEventDetails(testSteps, testData);
            }
            catch (Exception e)
            {
                testSteps.Log(LogStatus.Fail, "Unable to Search Event in Event Finder", e);
                var imagePath = new CaptureScreenshot(driver).takeScreenshot(testData.testCaseName);
                testSteps.Log(LogStatus.Info, "Snapshot below: " + testSteps.AddScreenCapture(imagePath));
            }
            return testSteps;
        }

        //Add Event
        public ExtentTest findEvent(ExtentTest testSteps, TestData testData)
        {          
                System.Threading.Thread.Sleep(1000);
                performAction.clickButton(EventPage.EVENTCODE_EVENTFINDER_XPATH, "EVENTCODE_EVENTFINDER_XPATH");
                performAction.enterText(EventPage.EVENTCODE_EVENTFINDER_XPATH, "EVENTCODE_EVENTFINDER_XPATH", testData.EventCode);
                testSteps.Log(LogStatus.Pass, "Enter an Event Code", testData.EventCode);
                performAction.clickButton(EventPage.EVENTDESCRIPTION_EVENTFINDER_XPATH, "EVENTDESCRIPTION_EVENTFINDER_XPATH");
                performAction.enterText(EventPage.EVENTDESCRIPTION_EVENTFINDER_XPATH, "EVENTDESCRIPTION_EVENTFINDER_XPATH", testData.EventName);
                testSteps.Log(LogStatus.Pass, "Enter an Event Name", testData.EventName);
                performAction.clickButton(EventPage.MILESTONE_EVENTFINDER_XPATH, "MILESTONE_EVENTFINDER_XPATH");
                testSteps.Log(LogStatus.Pass, "Click on MIleStone drop down", "");
                driver.FindElement(By.XPath("//span[text()=' " + testData.Milestone + " ']")).Click();
                testSteps.Log(LogStatus.Pass, "Milestone drop down selected as ", testData.Milestone);
                if (testData.ShowActiveEvents.Equals("Y"))
                {
                    performAction.clickButton(EventPage.SHOWACTIVEEVENTSCHECKBOX_EVENTFINDER_XPATH, "SHOWACTIVEEVENTSCHECKBOX_EVENTFINDER_XPATH");
                    testSteps.Log(LogStatus.Pass, "Click on Show Only Active Events Check box", "");
                }
                performAction.clickButton(EventPage.SEARCHICON_EVENTFINDER_XPATH, "SEARCHICON_EVENTFINDER_XPATH");
                testSteps.Log(LogStatus.Pass, "Click on Search Icon", "");       
            return testSteps;
        }

        public ExtentTest addEventList(ExtentTest testSteps, TestData testData)
        {
         //   ExtentTest testSteps = report.StartTest("Add Event Steps");
            //try
            //{
                System.Threading.Thread.Sleep(3000);
                //verify the header on Event finder page
                performAction.highlightText(performAction.getLocator(EventPage.EVENTID_EVENTFINDER_XPATH, "EVENTID_EVENTFINDER_XPATH"));
                testSteps.Log(LogStatus.Pass, "Verify Event ID header", "");
                performAction.highlightText(performAction.getLocator(EventPage.EVENTCODEHEADER_EVENTFINDER_XPATH, "EVENTCODEHEADER_EVENTFINDER_XPATH"));
                testSteps.Log(LogStatus.Pass, "Verify Event COde header", "");
                performAction.highlightText(performAction.getLocator(EventPage.EVENTNAMEHEADER_EVENTFINDER_XPATH, "EVENTNAMEHEADER_EVENTFINDER_XPATH"));
                testSteps.Log(LogStatus.Pass, "Verify Event Name header", "");
                performAction.highlightText(performAction.getLocator(EventPage.MILESTONEHEADER_EVENTFINDER_XPATH, "MILESTONEHEADER_EVENTFINDER_XPATH"));
                testSteps.Log(LogStatus.Pass, "Verify Milestone header", "");
                performAction.highlightText(performAction.getLocator(EventPage.ACTIVEHEADER_EVENTFINDER_XPATH, "ACTIVEHEADER_EVENTFINDER_XPATH"));
                testSteps.Log(LogStatus.Pass, "Verify Active header", "");
                performAction.highlightText(performAction.getLocator(EventPage.ACTIONHEADER_EVENTFINDER_XPATH, "ACTIONHEADER_EVENTFINDER_XPATH"));
                testSteps.Log(LogStatus.Pass, "Verify Action header", "");

                //Add Events to template
                IWebElement itemsElement = performAction.getLocator(EventPage.ITEMSPERPAGE_EVENTFINDER_XPATH, "ITEMSPERPAGE_EVENTFINDER_XPATH");
                int itemsPerPageCount =Convert.ToInt32(itemsElement.GetAttribute("ng-reflect-value"));
                int totalItems = Convert.ToInt32(performAction.getLocator(EventPage.LABELRANGE_EVENTFINDER_XPATH, "LABELRANGE_EVENTFINDER_XPATH").Text.Split(' ')[4]);
                int pageCount = totalItems / itemsPerPageCount;
                if (testData.Milestone.Equals("Yes"))
                {
                    testData.Milestone = "Y";
                }else
                {
                    testData.Milestone = "N";
                }
                for (int page = 0;page <= pageCount; page++){
                    int totalRowC = driver.FindElements(By.XPath("//tbody/tr")).Count;
                    for (int i = 1; i <= totalRowC; i++)
                    {
                            performAction.highlightText(driver.FindElement(By.XPath("//tbody/tr["+i+"]/td[1]")));
                            performAction.highlightText(driver.FindElement(By.XPath("//tbody/tr["+i+"]/td[contains(text(),'"+testData.EventCode+"')]")));
                            performAction.highlightText(driver.FindElement(By.XPath("//tbody/tr["+i+"]/td[contains(text(),'" + testData.EventName + "')]")));
                            performAction.highlightText(driver.FindElement(By.XPath("(//tbody/tr[" + i + "]/td[contains(text(),'" + testData.Milestone + "')])[1]")));
                            performAction.highlightText(driver.FindElement(By.XPath("(//tbody/tr[" + i + "]/td[contains(text(),'" + testData.ShowActiveEvents + "')])[2]")));
                            driver.FindElement(By.XPath("//tbody/tr["+i+ "]/td[6]/mat-checkbox")).Click();

                    }
                    if (page < pageCount)
                    {
                        performAction.clickButton(EventPage.NEXTPAGE_EVENTFINDER_XPATH, "NEXTPAGE_EVENTFINDER_XPATH");
                        testSteps.Log(LogStatus.Pass, "Click on Next Page", "");
                        System.Threading.Thread.Sleep(3000);
                    }
                }      
            return testSteps;
        }
        private ExtentTest submitEventDetails(ExtentTest testSteps, TestData testData)
        {
            int totalRowC = driver.FindElements(By.XPath("//tbody/tr")).Count;
            for (int i = 1; i <= totalRowC; i++)
            {
                performAction.highlightText(driver.FindElement(By.XPath("//tbody/tr[" + i + "]/td[contains(text(),'" + testData.EventCode + "')]")));
                performAction.highlightText(driver.FindElement(By.XPath("//tbody/tr[" + i + "]/td[contains(text(),'" + testData.EventName + "')]")));
                driver.FindElement(By.XPath("//tr[" + i + "]/td[3]/input[@placeholder='Number']")).Click();
                driver.FindElement(By.XPath("//tr[" + i + "]/td[3]/input[@placeholder='Number']")).SendKeys("1234");
                driver.FindElement(By.XPath("//tr[" + i + "]/td[4]")).Click();
                driver.FindElement(By.XPath("//span[text()=' Business Days ']")).Click();
                driver.FindElement(By.XPath("//tr[" + i + "]/td[5]")).Click();
                driver.FindElement(By.XPath("//span[text()=' Before ']")).Click();
                driver.FindElement(By.XPath("//tr[" + i + "]/td[6]")).Click();
                driver.FindElement(By.XPath("//span[text()=' E3469 ']")).Click();
                driver.FindElement(By.XPath("//tr[" + i + "]/td[7]")).Click();
                driver.FindElement(By.XPath("//span[text()=' Back Office Manager ']")).Click();
                driver.FindElement(By.XPath("//tr[" + i + "]/td[8]")).Click();
                driver.FindElement(By.XPath("//span[text()=' Manual ']")).Click();


            }

            return testSteps;
        }
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
                        System.Threading.Thread.Sleep(2000);
                        performAction.waitIfElementPresent(performAction.getLocator(MenuItemsPage.USERICON_EVENT_XPATH, "USERICON_EVENT_XPATH"), 10);
                        performAction.clickButton(MenuItemsPage.USERICON_EVENT_XPATH, "USERICON_EVENT_XPATH");
                        testSteps.Log(LogStatus.Pass, "Click on <b>" + toClickList[i] + "</b>");
                    }
                    else if (toClickList[i].Equals("SIGNOUT"))
                    {
                        System.Threading.Thread.Sleep(2000);
                        performAction.waitIfElementPresent(performAction.getLocator(MenuItemsPage.SIGNOUT_EVENT_XPATH, "SIGNOUT_EVENT_XPATH"), 10);
                        performAction.clickButton(MenuItemsPage.SIGNOUT_EVENT_XPATH, "SIGNOUT_EVENT_XPATH");
                        testSteps.Log(LogStatus.Pass, "Click on <b>" + toClickList[i] + "</b>");
                    }
                    else if (toClickList[i].Equals("ACCEPTALERT"))
                    {
                        driver.FindElement(By.XPath("//button[text()='Ok']")).Click();
                        testSteps.Log(LogStatus.Pass, "Click on <b>" + toClickList[i] + "</b>");
                    }
                    else if (toClickList[i].Equals("ADDNEWTEMPLATE"))
                    {
                        System.Threading.Thread.Sleep(7000);
                        performAction.clickButton(EventPage.ADDNEWTEMPLATE_EVENTTEMPLATE_XPATH, "ADDNEWTEMPLATE_EVENTTEMPLATE_XPATH");
                        testSteps.Log(LogStatus.Pass, "Click on <b>" + toClickList[i] + "</b>");
                    }
                    else if (toClickList[i].Equals("SAVETEMPLATE"))
                    {
                        performAction.clickButton(EventPage.SAVETEMPLATE_ADDTEMPLATE_XPATH, "SAVETEMPLATE_ADDTEMPLATE_XPATH");
                        testSteps.Log(LogStatus.Pass, "Click on <b>" + toClickList[i] + "</b>");
                    }
                    else if (toClickList[i].Equals("EVENTTEMPLATE"))
                    {
                        System.Threading.Thread.Sleep(2000);
                        performAction.waitIfElementPresent(performAction.getLocator(MenuItemsPage.EXPANDMODAL_EVENT_XPATH, "EXPANDMODAL_EVENT_XPATH"),5);
                        performAction.clickButton(MenuItemsPage.EVENTTEMPLATE_EVENT_XPATH, "EVENTTEMPLATE_EVENT_XPATH");
                        testSteps.Log(LogStatus.Pass, "Click on <b>" + toClickList[i] + "</b>");
                    }
                    else if (toClickList[i].Equals("MAINTENANCE"))
                    {
                        System.Threading.Thread.Sleep(2000);
                        performAction.clickButton(MenuItemsPage.MAINTENANCEICON_EVENT_XPATH, " MAINTENANCEICON_EVENT_XPATH");
                        testSteps.Log(LogStatus.Pass, "Click on <b>" + toClickList[i] + "</b>");
                    }
                    else if (toClickList[i].Equals("SAVETEMPLATEMODAL"))
                    {
                        System.Threading.Thread.Sleep(2000);
                        performAction.clickJavaScript(performAction.getLocator(EventPage.SAVEMODAL_ADDTEMPLATE_XPATH, "SAVEMODAL_ADDTEMPLATE_XPATH"));
                        testSteps.Log(LogStatus.Pass, "Click on <b>" + toClickList[i] + "</b>");
                    }
                    else if (toClickList[i].Equals("CANCELTEMPLATEMODAL") || toClickList[i].Equals("CANCELTEMPLATE"))
                    {
                        System.Threading.Thread.Sleep(2000);
                        performAction.clickButton(EventPage.CANCELMODAL_ADDTEMPLATE_XPATH, "CANCELMODAL_ADDTEMPLATE_XPATH");
                        testSteps.Log(LogStatus.Pass, "Click on <b>" + toClickList[i] + "</b>");
                    }
                    else if (toClickList[i].Equals("OK"))
                    {
                        System.Threading.Thread.Sleep(2000);
                        driver.FindElement(By.XPath("//div[@aria-labelledby='swal2-title']/div[3]/button[text()='OK']")).Click();
                        testSteps.Log(LogStatus.Pass, "Click on <b>" + toClickList[i] + "</b>");
                    }
                    else if (toClickList[i].Equals("ADDEVENT"))
                    {
                        System.Threading.Thread.Sleep(2000);
                        performAction.clickButton(EventPage.ADDEVENT_ADDTEMPLATE_XPATH, "ADDEVENT_ADDTEMPLATE_XPATH");
                        testSteps.Log(LogStatus.Pass, "Click on <b>" + toClickList[i] + "</b>");
                    }
                    else if (toClickList[i].Equals("ADDTOTEMPLATE"))
                    {
                        System.Threading.Thread.Sleep(2000);
                        performAction.clickButton(EventPage.ADDTOTEMPLATE_EVENTFINDER_XPATH, "ADDTOTEMPLATE_EVENTFINDER_XPATH");
                        testSteps.Log(LogStatus.Pass, "Click on <b>" + toClickList[i] + "</b>");
                    }else if (toClickList[i].Equals("TOTALEVENTLISTITEMS"))
                    {
                        System.Threading.Thread.Sleep(2000);
                        string totalItems = performAction.getLocator(EventPage.LABELRANGE_EVENTFINDER_XPATH, "LABELRANGE_EVENTFINDER_XPATH").Text.Split(' ')[4];
                        testData.totalAvailableItems = totalItems;
                        testSteps.Log(LogStatus.Pass, "Total Available Event List Items Count is ",totalItems);

                    }
                    else
                    {
                        testSteps.Log(LogStatus.Fail, "Unable to click on <b>" + toClickList[i] + "</b>");

                    }

                }

            }
            catch (Exception e)
            {
                testSteps.Log(LogStatus.Fail, "Unable to click",e);
                var imagePath = new CaptureScreenshot(driver).takeScreenshot(testData.testCaseName);
                testSteps.Log(LogStatus.Info, "Snapshot below: " + testSteps.AddScreenCapture(imagePath));
            }
            return testSteps;
        }
    }
}
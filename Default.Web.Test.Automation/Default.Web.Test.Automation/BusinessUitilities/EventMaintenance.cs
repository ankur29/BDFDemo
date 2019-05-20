using Default.Web.Test.Automation.Entities;
using Default.Web.Test.Automation.Library;
using Default.Web.Test.Automation.ObjectRepository;
using OpenQA.Selenium;
using RelevantCodes.ExtentReports;
using System;
using System.Globalization;
using System.Reflection;

namespace Default.Web.Test.Automation.BusinessUitilities
{
    class EventMaintenance
    {
        //Define Objects
        IWebDriver driver;
        PerformAction performAction;

        public EventMaintenance(IWebDriver _driver)
        {
            driver = _driver;
            performAction = new PerformAction(driver);

        }
        public ExtentTest eventAdd(ExtentReports report, TestData testdata)
        {
            ExtentTest loginSteps = report.StartTest("Add Event Steps");
            try
            {
                System.Threading.Thread.Sleep(4000);
                //creating a new event             
                performAction.clickJavaScript(performAction.getLocator(EventPage.ADDEVENTBUTTON_EVENT_XPATH, "ADDEVENTBUTTON_EVENT_XPATH"));
                loginSteps.Log(LogStatus.Info, "Click on Add event button", "");
                performAction.clickButton(EventPage.EVENTCODE_ADDEVENT_XPATH, "EVENTCODE_ADDEVENT_XPATH");
                performAction.enterText(EventPage.EVENTCODE_ADDEVENT_XPATH, "EVENTCODE_ADDEVENT_XPATH", testdata.EventCode);
                loginSteps.Log(LogStatus.Info, "Enter the Event code", testdata.EventCode);
                performAction.clickButton(EventPage.EVENTNAME_ADDEVENT_XPATH, "EVENTNAME_ADDEVENT_XPATH");
                performAction.enterText(EventPage.EVENTNAME_ADDEVENT_XPATH, "EVENTNAME_ADDEVENT_XPATH", testdata.EventName);
                loginSteps.Log(LogStatus.Info, "Enter the Event name", testdata.EventName);
                System.Threading.Thread.Sleep(2000);
                if (testdata.Milestone.Equals("Yes"))
                {
                    performAction.clickJavaScript(performAction.getLocator(EventPage.MILESTONE_ADDEVENT_XPATH, "MILESTONE_ADDEVENT_XPATH"));
                    loginSteps.Log(LogStatus.Info, "Milestone is selected", "");
                }
                performAction.clickButton(EventPage.SAVE_ADDEVENT_XPATH, "SAVE_ADDEVENT_XPATH");
                loginSteps.Log(LogStatus.Info, "Click on Save button", "");


            }
            catch (Exception e)
            {
                loginSteps.Log(LogStatus.Fail, "Unable to Add Event", e);
                var imagePath = new CaptureScreenshot(driver).takeScreenshot(testdata.testCaseName);
                loginSteps.Log(LogStatus.Info, "Snapshot below: " + loginSteps.AddScreenCapture(imagePath));
            }
            return loginSteps;
        }
        //searching of an event

        public ExtentTest EventSearch(ExtentReports report, TestData testdata)
        {
            String filters = testdata.Filters;
            testdata.SearchMilestone = testdata.Milestone;
            if (!filters.Equals(""))
            {
                String[] filterList = filters.Split('|');
                for (int i=0;i<filterList.Length;i++)
                {
                    String headerName = filterList[i].Split('=')[0];
                    String headerValue = filterList[i].Split('=')[1];
                    if (headerName.Equals("MILESTONE"))
                    {
                        if(headerValue.Equals("NOFILTER"))
                        {
                            testdata.Milestone = "No filter";
                        }else if (headerValue.Equals("NO"))
                        {
                            testdata.Milestone = "No";
                        }else
                        {
                            testdata.Milestone = "Yes";
                        }
                    }
                    else if (headerName.Equals("SHOWACTIVEEVENT"))
                    {
                        testdata.ShowActiveEvents = headerValue;
                    }

                }
            }
            ExtentTest loginSteps = report.StartTest("Search Event Steps");
            try
            {
                System.Threading.Thread.Sleep(2000);
                //Event Search Steps
                performAction.clickButton(EventPage.EVENTCODE_EVENTSEARCH_XPATH, "EVENTCODE_EVENTSEARCH_XPATH");
                performAction.enterText(EventPage.EVENTCODE_EVENTSEARCH_XPATH, "EVENTCODE_EVENTSEARCH_XPATH", testdata.EventCode);
                loginSteps.Log(LogStatus.Info, "Enter the Event code", testdata.EventCode);
              
                    performAction.clickButton(EventPage.EVENTNAME_EVENTSEARCH_XPATH, "EVENTNAME_EVENTSEARCH_XPATH");
                    performAction.enterText(EventPage.EVENTNAME_EVENTSEARCH_XPATH, "EVENTNAME_EVENTSEARCH_XPATH", testdata.EventName);
                    loginSteps.Log(LogStatus.Info, "Enter the Event name", testdata.EventName);
                
               
                performAction.clickJavaScript(performAction.getLocator(EventPage.EVENTNAME_DROPDOWN_XPATH, "EVENTNAME_DROPDOWN_XPATH"));
                loginSteps.Log(LogStatus.Info, "Click the drop down", "");
                System.Threading.Thread.Sleep(2000);
                performAction.clickJavaScript(driver.FindElement(By.XPath("//span[text()=' "+testdata.Milestone+" ']")));
                loginSteps.Log(LogStatus.Info, "Select Milestone value as ", testdata.Milestone);
                //performAction.clickButton(EventPage.SHOWONLYACTIVE_EVENTSEARCH_XPATH, "SHOWONLYACTIVE_EVENTSEARCH_XPATH");
                //loginSteps.Log(LogStatus.Info, "Click on Show only Active Events ", "");
                performAction.clickButton(EventPage.SEARCHICON_EVENTSEARCH_XPATH, "SEARCHICON_EVENTSEARCH_XPATH");
                loginSteps.Log(LogStatus.Info, "Click on Search Icon", "");

                if (testdata.Milestone.Equals(testdata.SearchMilestone) || testdata.Milestone.Equals("NOFILTER"))
                {
                    //verify Table Headers
                    performAction.highlightText(performAction.getLocator(EventPage.EVENTID_EVENTLIST_XPATH, "EVENTID_EVENTLIST_XPATH"));
                    performAction.highlightText(performAction.getLocator(EventPage.EVENTCODE_EVENTLIST_XPATH, "EVENTCODE_EVENTLIST_XPATH"));
                    performAction.highlightText(performAction.getLocator(EventPage.EVENTNAME_EVENTLIST_XPATH, "EVENTNAME_EVENTLIST_XPATH"));
                    performAction.highlightText(performAction.getLocator(EventPage.MILESTONE_EVENTLIST_XPATH, "MILESTONE_EVENTLIST_XPATH"));
                    performAction.highlightText(performAction.getLocator(EventPage.ACTIVE_EVENTLIST_XPATH, "ACTIVE_EVENTLIST_XPATH"));
                    performAction.highlightText(performAction.getLocator(EventPage.CREATEDON_EVENTLIST_XPATH, "CREATEDON_EVENTLIST_XPATH"));
                    performAction.highlightText(performAction.getLocator(EventPage.CREATEDBY_EVENTLIST_XPATH, "CREATEDBY_EVENTLIST_XPATH"));
                    performAction.highlightText(performAction.getLocator(EventPage.UPDATEDON_EVENTLIST_XPATH, "UPDATEDON_EVENTLIST_XPATH"));
                    performAction.highlightText(performAction.getLocator(EventPage.UPDATEDBY_EVENTLIST_XPATH, "UPDATEDBY_EVENTLIST_XPATH"));
                    performAction.highlightText(performAction.getLocator(EventPage.ACTION_EVENTLIST_XPATH, "ACTION_EVENTLIST_XPATH"));

                    performAction.highlightText(driver.FindElement(By.XPath("//tbody/tr/td[text()='" + testdata.EventCode + "']")));
                    //      performAction.highlightText(driver.FindElement(By.XPath("//tbody/tr/td[text()=' " + testdata.EventName + " ']")));
                    if (testdata.Milestone.Equals("Yes") || testdata.Milestone.Equals("No filter"))
                    {
                        performAction.highlightText(driver.FindElement(By.XPath("(//tbody/tr/td[text()=' Y '])[1]")));
                    }
                    else
                    {
                        performAction.highlightText(driver.FindElement(By.XPath("(//tbody/tr/td[text()=' N '])[1]")));
                    }
                    performAction.highlightText(performAction.getLocator(EventPage.UNIQUERECORD_EVENTLIST_XPATH, "UNIQUERECORD_EVENTLIST_XPATH"));

                }
            }
            catch (Exception e)
            {
                loginSteps.Log(LogStatus.Fail, "Unable to login", e);
                var imagePath = new CaptureScreenshot(driver).takeScreenshot(testdata.testCaseName);
                loginSteps.Log(LogStatus.Info, "Snapshot below: " + loginSteps.AddScreenCapture(imagePath));
            }
            return loginSteps;
        }

        // viewing event list

        public ExtentTest EventList(ExtentReports report, TestData testdata)
        {
            ExtentTest loginSteps = report.StartTest("view event list");
            try
            {
                System.Threading.Thread.Sleep(10000);
                performAction.clickJavaScript(performAction.getLocator(EventPage.MAINTENANCEICON_EVENT_XPATH, "MAINTENANCEICON_EVENT_XPATH"));
                loginSteps.Log(LogStatus.Info, "Click on maintenance icon", "");
                performAction.clickButton(EventPage.EVENTMAINTENANCELIST_EVENT_XPATH, "EVENTMAINTENANCELIST_EVENT_XPATH");
                loginSteps.Log(LogStatus.Info, "Click on event maintenance  list", "");
                System.Threading.Thread.Sleep(5000);

                performAction.highlightText(performAction.getLocator(EventPage.EVENTID_EVENTLIST_XPATH, "EVENTID_EVENTLIST_XPATH"));
                System.Threading.Thread.Sleep(1000);
                performAction.highlightText(performAction.getLocator(EventPage.EVENTCODE_EVENTLIST_XPATH, " EVENTCODE_EVENTLIST_XPATH"));

                System.Threading.Thread.Sleep(1000);
                performAction.highlightText(performAction.getLocator(EventPage.EVENTNAME_EVENTLIST_XPATH, "EVENTNAME_EVENTLIST_XPATH"));
                System.Threading.Thread.Sleep(1000);
                performAction.highlightText(performAction.getLocator(EventPage.MILESTONE_EVENTLIST_XPATH, "MILESTONE_EVENTLIST_XPATH"));
                System.Threading.Thread.Sleep(1000);
                performAction.highlightText(performAction.getLocator(EventPage.ACTIVE_EVENTLIST_XPATH, "ACTIVE_EVENTLIST_XPATH"));
                System.Threading.Thread.Sleep(1000);
                performAction.highlightText(performAction.getLocator(EventPage.CREATEDON_EVENTLIST_XPATH, " CREATEDON_EVENTLIST_XPATH"));
                System.Threading.Thread.Sleep(1000);
                performAction.highlightText(performAction.getLocator(EventPage.CREATEDBY_EVENTLIST_XPATH, " CREATEDBY_EVENTLIST_XPATH"));
                System.Threading.Thread.Sleep(1000);
                performAction.highlightText(performAction.getLocator(EventPage.UPDATEDON_EVENTLIST_XPATH, "UPDATEDON_EVENTLIST_XPATH"));
                System.Threading.Thread.Sleep(1000);
                performAction.highlightText(performAction.getLocator(EventPage.UPDATEDBY_EVENTLIST_XPATH, " UPDATEDBY_EVENTLIST_XPATH"));
                System.Threading.Thread.Sleep(1000);
                performAction.highlightText(performAction.getLocator(EventPage.ACTION_EVENTLIST_XPATH, "ACTION_EVENTLIST_XPATH"));
                performAction.clickButton(EventPage.PAGEDROPDOWN_EVENTLIST_XPATH, "PAGEDROPDOWN_EVENTLIST_XPATH");
                loginSteps.Log(LogStatus.Info, "Click on drop down", "");
                if (testdata.PageCount == "5")
                {
                    performAction.clickJavaScript(performAction.getLocator(EventPage.COUNT5_EVENTLIST_XPATH, "COUNT5_EVENTLIST_XPATH"));
                    loginSteps.Log(LogStatus.Info, "Select 5 elements", "");

                }
                if (testdata.PageCount == "10")
                {
                    performAction.clickJavaScript(performAction.getLocator(EventPage.COUNT10_EVENTLIST_XPATH, "COUNT10_EVENTLIST_XPATH"));
                    loginSteps.Log(LogStatus.Info, "Select 10 elements", "");
                }

                if (testdata.PageCount == "20")
                {
                    performAction.clickJavaScript(performAction.getLocator(EventPage.COUNT20_EVENTLIST_XPATH, "COUNT20_EVENTLIST_XPATH"));
                    loginSteps.Log(LogStatus.Info, "Select 20 elements", "");
                }

            }


            catch (Exception e)
            {
                loginSteps.Log(LogStatus.Fail, "Unable to login", e);
                var imagePath = new CaptureScreenshot(driver).takeScreenshot(testdata.testCaseName);
                loginSteps.Log(LogStatus.Info, "Snapshot below: " + loginSteps.AddScreenCapture(imagePath));
            }
            return loginSteps;
        }

        // modification of an event

        public ExtentTest ModifyEvent(ExtentReports report, TestData testdata)
        {
            ExtentTest loginSteps = report.StartTest("Modify Event Steps");
            try
            {

                System.Threading.Thread.Sleep(2000);
                performAction.clickButton(EventPage.MODIFYICON_EVENTMODIFY_XPATH, "MODIFYICON_EVENTMODIFY_XPATH");
                loginSteps.Log(LogStatus.Info, "Click the modify icon", "");
                System.Threading.Thread.Sleep(3000);
                performAction.enterText(EventPage.EVENTNAME_EVENTMODIFY_XPATH, "EVENTNAME_EVENTMODIFY_XPATH", testdata.ModifiedName);
                loginSteps.Log(LogStatus.Info, "Enter event name", testdata.ModifiedName);
                performAction.clickJavaScript(performAction.getLocator(EventPage.SAVEBUTTON_EVENTMODIFY_XPATH, "SAVEBUTTON_EVENTMODIFY_XPATH"));
                loginSteps.Log(LogStatus.Info, "Click on modify button", "");
            }



            catch (Exception e)
            {
                loginSteps.Log(LogStatus.Fail, "Unable to login", e);
                var imagePath = new CaptureScreenshot(driver).takeScreenshot(testdata.testCaseName);
                loginSteps.Log(LogStatus.Info, "Snapshot below: " + loginSteps.AddScreenCapture(imagePath));
            }
            return loginSteps;
        }
        //deactivation of an event 

        public ExtentTest DeactivateEvent(ExtentReports report, TestData testdata)
        {
            ExtentTest loginSteps = report.StartTest("deactivate event");
            try
            {

                performAction.clickButton(EventPage.MODIFYICON_EVENTMODIFY_XPATH, "MODIFYICON_EVENTMODIFY_XPATH");
                loginSteps.Log(LogStatus.Info, "Click on Modify Icon", "");
                System.Threading.Thread.Sleep(2000);
                performAction.clickJavaScript(performAction.getLocator(EventPage.INACTIVE_DEACTIVATEEVENT_XPATH, "INACTIVE_DEACTIVATEEVENT_XPATH"));
                loginSteps.Log(LogStatus.Info, "Uncheck Active Event ", "");
                System.Threading.Thread.Sleep(2000);
                if (testdata.EventState.Equals("REACTIVATEEVENT"))
                {
                    performAction.clickButton(EventPage.REASON_EVENTMODIFY_XPATH, "REASON_EVENTMODIFY_XPATH");
                    performAction.enterText(EventPage.REASON_EVENTMODIFY_XPATH, "REASON_EVENTMODIFY_XPATH", testdata.ReactivateReason);
                }else
                {
                    performAction.clickButton(EventPage.REASON_EVENTMODIFY_XPATH, "REASON_EVENTMODIFY_XPATH");
                    performAction.enterText(EventPage.REASON_EVENTMODIFY_XPATH, "REASON_EVENTMODIFY_XPATH", testdata.DeactivateReason);
                }
                loginSteps.Log(LogStatus.Info, "Enter Reason", testdata.DeactivateReason);
                performAction.clickButton(EventPage.SAVEBUTTON_EVENTMODIFY_XPATH, "SAVEBUTTON_EVENTMODIFY_XPATH");
                loginSteps.Log(LogStatus.Info, "Click on modify button", "");               

                System.Threading.Thread.Sleep(2000);

            }


            catch (Exception e)
            {
                loginSteps.Log(LogStatus.Fail, "Unable to login", e);
                var imagePath = new CaptureScreenshot(driver).takeScreenshot(testdata.testCaseName);
                loginSteps.Log(LogStatus.Info, "Snapshot below: " + loginSteps.AddScreenCapture(imagePath));
            }
            return loginSteps;
        }


        //Click on requested Link/button
        public ExtentTest Clickon(String toClick, ExtentReports report, TestData testData)
        {
            ExtentTest testSteps = report.StartTest("Click ON " + toClick);
            toClick = toClick.ToUpper();
            String[] toClickList = toClick.Split(',');
            try
            {
                for (int i = 0; i < toClickList.Length; i++)
                {
                    if (toClickList[i].Equals("Maintenance"))
                    {
                        System.Threading.Thread.Sleep(2000);

                        performAction.clickButton(MenuItemsPage.MAINTENANCEICON_EVENT_XPATH, " MAINTENANCEICON_EVENT_XPATH");
                        testSteps.Log(LogStatus.Pass, "Click on <b>" + toClickList[i] + "</b>");
                    }
                    else if (toClickList[i].Equals("EventMaintenance"))
                    {
                        performAction.clickButton(MenuItemsPage.EVENTMAINTENANCELIST_EVENT_XPATH, "EVENTMAINTENANCELIST_EVENT_XPATH");
                        testSteps.Log(LogStatus.Pass, "Click on <b>" + toClickList[i] + "</b>");
                    }

                    else if (toClickList[i].Equals("ACCEPT ALERT"))
                    {
                        driver.FindElement(By.XPath("//button[text()='Ok']")).Click();
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
                        System.Threading.Thread.Sleep(2000);
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
                    else if (toClickList[i].Equals("MAINTENANCE"))
                    {
                        System.Threading.Thread.Sleep(1000);
                        performAction.clickButton(MenuItemsPage.MAINTENANCEICON_EVENT_XPATH, "MAINTENANCEICON_EVENT_XPATH");
                        testSteps.Log(LogStatus.Pass, "Click on <b>" + toClickList[i] + "</b>");
                    }else if (toClickList[i].Equals("EVENTMAINTENANCE"))
                    {
                        System.Threading.Thread.Sleep(1000);
                        performAction.clickButton(MenuItemsPage.EVENTMAINTENANCELIST_EVENT_XPATH, "EVENTMAINTENANCELIST_EVENT_XPATH");
                        testSteps.Log(LogStatus.Pass, "Click on <b>" + toClickList[i] + "</b>");
                    }else if (toClickList[i].Equals("ADDEVENT"))
                    {
                        System.Threading.Thread.Sleep(1000);
                        performAction.clickButton(EventPage.ADDEVENTBUTTON_EVENT_XPATH, "ADDEVENTBUTTON_EVENT_XPATH");
                        testSteps.Log(LogStatus.Pass, "Click on <b>" + toClickList[i] + "</b>");
                    }
                    else if (toClickList[i].Equals("ACCEPTALERT") || toClickList[i].Equals("OK"))
                    {
                        System.Threading.Thread.Sleep(800);
                        driver.FindElement(By.XPath("//div[@class='swal2-actions']/button[text()='OK']")).Click();
                        testSteps.Log(LogStatus.Pass, "Click on <b>" + toClickList[i] + "</b>");
                    }
                    else if (toClickList[i].Equals("CLOSE") || toClickList[i].Equals("CLOSEBUTTON"))
                    {
                        System.Threading.Thread.Sleep(800);
                        performAction.clickButton(EventPage.CLOSE_ADDEVENT_XPATH, "CLOSE_ADDEVENT_XPATH");
                        testSteps.Log(LogStatus.Pass, "Click on <b>" + toClickList[i] + "</b>");
                    }
                    else if (toClickList[i].Equals("SAVE") || toClickList[i].Equals("SAVEBUTTON"))
                    {
                        System.Threading.Thread.Sleep(1500);
                        performAction.clickButton(EventPage.SAVE_ADDEVENT_XPATH, "SAVE_ADDEVENT_XPATH");
                        testSteps.Log(LogStatus.Pass, "Click on <b>" + toClickList[i] + "</b>");
                    }
                    else if (toClickList[i].Equals("SAVEANDNEW") || toClickList[i].Equals("SAVEANDNEWBUTTON"))
                    {
                        System.Threading.Thread.Sleep(1500);
                        performAction.clickButton(EventPage.SAVEANDNEW_ADDEVENT_XPATH, "SAVEANDNEW_ADDEVENT_XPATH");
                        testSteps.Log(LogStatus.Pass, "Click on <b>" + toClickList[i] + "</b>");
                    }
                    else if (toClickList[i].Equals("CLEARSEARCHFORM"))
                    {
                        System.Threading.Thread.Sleep(800);
                        performAction.clickButton(EventPage.CLEARSEARCHFORM_EVENTSEARCH_XPATH, "CLEARSEARCHFORM_EVENTSEARCH_XPATH");
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
                testSteps.Log(LogStatus.Fail, "Unable to Verify Message", e);
                var imagePath = new CaptureScreenshot(driver).takeScreenshot(testData.testCaseName);
                testSteps.Log(LogStatus.Info, "Snapshot below: " + testSteps.AddScreenCapture(imagePath));
            }
            return testSteps;
        }
    }

    }

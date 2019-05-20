using Default.Web.Test.Automation.Entities;
using Default.Web.Test.Automation.Library;
using Default.Web.Test.Automation.ObjectRepository;
using OpenQA.Selenium;
using RelevantCodes.ExtentReports;
using System;

namespace Default.Web.Test.Automation.BusinessUitilities
{
    class CommonUtility
    {
        //Define Objects
        IWebDriver driver;
        PerformAction performAction;

        public CommonUtility(IWebDriver _driver)
        {
            driver = _driver;
            performAction = new PerformAction(driver);

        }
        //verify Expected Message
        public ExtentTest verifyExpectedResult(string messageNeedToVerify, TestData testData,ExtentReports report)
        {
            ExtentTest verifyMessageSteps = report.StartTest("Verify Expected Messages");
            String[] messageIndex = messageNeedToVerify.Split(',');
            String[] messageLocatorList = testData.errorMessage.Replace("||","|").Split('|');
            try
            {
                IWebElement messageElement=null;
                for (int i = 0; i < messageIndex.Length; i++)
                {
                    System.Threading.Thread.Sleep(1000);                  
                        messageElement = driver.FindElement(By.XPath(messageLocatorList[Convert.ToInt32(messageIndex[i])-1]));
                        performAction.highlightText(messageElement);
                        verifyMessageSteps.Log(LogStatus.Pass, "Expected Message", messageElement.Text);
                    }
            }
            catch (Exception e)
            {
                verifyMessageSteps.Log(LogStatus.Fail, "Unable to Verify Expected Message", e);
                var imagePath = new CaptureScreenshot(driver).takeScreenshot(testData.testCaseName);
                verifyMessageSteps.Log(LogStatus.Info, "Snapshot below: " + verifyMessageSteps.AddScreenCapture(imagePath));
            }
            return verifyMessageSteps;
        }

        //Click on requested Link/button
        public ExtentTest clickOn(String toClick,ExtentReports report, TestData testData)
        {
            ExtentTest testSteps = report.StartTest("Click ON "+toClick);
            toClick = toClick.ToUpper();
            String[] toClickList = toClick.Split(',');
            try
            {
                for (int i = 0; i < toClickList.Length; i++)
                {
                    if (toClickList[i].Equals("ADMIN"))
                    {
                        performAction.clickButton(MenuItemsPage.ADMINLINK_MENU_XPATH, "ADMINLINK_MENU_XPATH");
                        testSteps.Log(LogStatus.Pass, "Click on <b>" + toClickList[i] + "</b>");
                    }
                    else if (toClickList[i].Equals("USER ADMIN"))
                    {
                        performAction.clickButton(MenuItemsPage.USERADMINLINK_MENU_XPATH, "USERADMINLINK_MENU_XPATH");
                        testSteps.Log(LogStatus.Pass, "Click on <b>" + toClickList[i] + "</b>");
                    }
                    else if (toClickList[i].Equals("SHOW ONLY ACTIVE USERS"))
                    {
                        performAction.clickButton(UserAdminPage.SHOWONLYACTIVEUSERS_USERADMIN_XPATH, "SHOWONLYACTIVEUSERS_USERADMIN_XPATH");
                        testSteps.Log(LogStatus.Pass, "Click on <b>" + toClickList[i] + "</b>");
                    } else if (toClickList[i].Equals("SEARCH BAR"))
                    {
                        performAction.clickButton(UserAdminPage.SEARCHBAR_USERADMIN_XPATH, "SEARCHBAR_USERADMIN_XPATH");
                        testSteps.Log(LogStatus.Pass, "Click on <b>" + toClickList[i] + "</b>");
                    }else if(toClickList[i].Equals("MODIFY USER"))		
                    {		
                        performAction.clickButton(UserAdminPage.MODIFY_USERADMIN_XPATH, "MODIFY_USERADMIN_XPATH");		
                        System.Threading.Thread.Sleep(4000);		
                        testSteps.Log(LogStatus.Pass, "Click on <b>" + toClickList[i] + "</b>");		
                    }		
                    else if (toClickList[i].Equals("BACK"))		
                    {		
                        performAction.highlightText(performAction.getLocator(UserAdminPage.BACK_USERADMIN_XPATH, "BACK_USERADMIN_XPATH"));		
                        performAction.clickButton(UserAdminPage.BACK_USERADMIN_XPATH, "BACK_USERADMIN_XPATH");		
                        System.Threading.Thread.Sleep(3000);		
                        testSteps.Log(LogStatus.Pass, "Click on <b>" + toClickList[i] + "</b>");		
                    }else if (toClickList[i].Equals("ADD USER"))
                    {
                        performAction.clickButton(UserAdminPage.ADDUSER_USERADMIN_XPATH, "ADDUSER_USERADMIN_XPATH");
                        testSteps.Log(LogStatus.Pass, "Click on <b>" + toClickList[i] + "</b>");
                    }else if (toClickList[i].Equals("ORGANIZATION DROPDOWN"))
                    {
                        System.Threading.Thread.Sleep(10000);
                        performAction.clickButton(UserAdminPage.SEARCHBAR_USERADMIN_XPATH, "SEARCHBAR_USERADMIN_XPATH");
                        System.Threading.Thread.Sleep(4000);
                        driver.FindElement(By.XPath("//span[text()=' System ']")).Click();
                        //performAction.dropdownSelection(UserAdminPage.SEARCHORGANIZATION_ORGADMIN_XPATH, "SEARCHORGANIZATION_ORGADMIN_XPATH", DropDownConstants.KEY_DESELECT_BY_VISIBLE_TEXT, "New Org Ankur");
                        testSteps.Log(LogStatus.Pass, "Click on <b>" + toClickList[i] + "</b>");
                        System.Threading.Thread.Sleep(10000);
                    }else if (toClickList[i].Equals("USER DETAILS"))
                    {
                        performAction.clickButton(UserAdminPage.USERDETAILS_USERADMIN_XPATH, "USERDETAILS_USERADMIN_XPATH");
                        testSteps.Log(LogStatus.Pass, "Click on <b>" + toClickList[i] + "</b>");
                    }else if (toClickList[i].Equals("CANCEL USER"))
                    {
                        performAction.clickButton(UserAdminPage.CANCELBUTTON_USERADMIN_XPATH, "CANCELBUTTON_USERADMIN_XPATH");
                        testSteps.Log(LogStatus.Pass, "Click on <b>" + toClickList[i] + "</b>");
                    }else if (toClickList[i].Equals("SAVE USER"))
                    {
                        performAction.clickJavaScript(performAction.getLocator(UserAdminPage.SAVEBUTTON_USERADMIN_XPATH, "SAVEBUTTON_USERADMIN_XPATH"));
                        testSteps.Log(LogStatus.Pass, "Click on <b>" + toClickList[i] + "</b>");
                    } else if (toClickList[i].Equals("SAVE AND NEW USER"))
                    {
                        performAction.clickButton(UserAdminPage.SAVEANDNEWBUTTON_USERADMIN_XPATH, "SAVEANDNEWBUTTON_USERADMIN_XPATH");
                        testSteps.Log(LogStatus.Pass, "Click on <b>" + toClickList[i] + "</b>");
                    }else if (toClickList[i].Equals("VIEW USER"))
                    {
                        performAction.clickButton(UserAdminPage.VIEWICON_USERADMIN_XPATH, "VIEWICON_USERADMIN_XPATH");
                        testSteps.Log(LogStatus.Pass, "Click on <b>" + toClickList[i] + "</b>");
                    }else if (toClickList[i].Equals("VIEW USER"))
                    {
                        performAction.clickButton(UserAdminPage.VIEWICON_USERADMIN_XPATH, "VIEWICON_USERADMIN_XPATH");
                        testSteps.Log(LogStatus.Pass, "Click on <b>" + toClickList[i] + "</b>");
                    }else if (toClickList[i].Equals("FIRST PAGE"))
                    {
                        performAction.clickButton(UserAdminPage.FIRSTPAGEUSER_USERADMIN_XPATH, "FIRSTPAGEUSER_USERADMIN_XPATH");
                        testSteps.Log(LogStatus.Pass, "Click on <b>" + toClickList[i] + "</b>");
                    }else if (toClickList[i].Equals("PREVIOUS PAGE"))
                    {
                        performAction.clickButton(UserAdminPage.PREVIOUSPAGEUSER_USERADMIN_XPATH, "PREVIOUSPAGEUSER_USERADMIN_XPATH");
                        testSteps.Log(LogStatus.Pass, "Click on <b>" + toClickList[i] + "</b>");
                    }else if (toClickList[i].Equals("NEXT PAGE"))
                    {
                        performAction.clickButton(UserAdminPage.NEXTPAGEUSER_USERADMIN_XPATH, "NEXTPAGEUSER_USERADMIN_XPATH");
                        testSteps.Log(LogStatus.Pass, "Click on <b>" + toClickList[i] + "</b>");
                    }else if (toClickList[i].Equals("LAST PAGE"))
                    {
                        performAction.clickButton(UserAdminPage.LASTPAGEUSER_USERADMIN_XPATH, "LASTPAGEUSER_USERADMIN_XPATH");
                        testSteps.Log(LogStatus.Pass, "Click on <b>" + toClickList[i] + "</b>");
                    }else if (toClickList[i].Equals("EDIT ORGANIZATION") || toClickList[i].Equals("EDIT USER"))
                    {
                        System.Threading.Thread.Sleep(6000);
                        performAction.clickButton(UserAdminPage.EDITUSER_USERADMIN_XPATH, "EDITUSER_USERADMIN_XPATH");
                        testSteps.Log(LogStatus.Pass, "Click on <b>" + toClickList[i] + "</b>");
                    } else if (toClickList[i].Equals("SAVE ORGANIZATION"))
                    {
                        System.Threading.Thread.Sleep(4000);
                        performAction.clickButton(OrganizationPage.SAVEBUTTON_ORGADMIN_XPATH, "SAVEBUTTON_ORGADMIN_XPATH");
                        testSteps.Log(LogStatus.Pass, "Click on <b>" + toClickList[i] + "</b>");
                    }else if (toClickList[i].Equals("SAVE AND USER ADMIN"))
                    {
                        System.Threading.Thread.Sleep(4000);
                        performAction.clickButton(OrganizationPage.SAVEANDUSERBUTTON_ORGADMIN_XPATH, "SAVEANDUSERBUTTON_ORGADMIN_XPATH");
                        testSteps.Log(LogStatus.Pass, "Click on <b>" + toClickList[i] + "</b>");
                        System.Threading.Thread.Sleep(2000);
                    }else if (toClickList[i].Equals("CANCEL ORGANIZATION"))
                    {
                        performAction.clickButton(OrganizationPage.CANCELBUTTON_ORGADMIN_XPATH, "CANCELBUTTON_ORGADMIN_XPATH");
                        testSteps.Log(LogStatus.Pass, "Click on <b>" + toClickList[i] + "</b>");
                    } else if (toClickList[i].Equals("LICENSING DETAILS"))
                    {
                        performAction.clickButton(OrganizationPage.LICENSINGDETAILS_ORGADMIN_XPATH, "LICENSINGDETAILS_ORGADMIN_XPATH");
                        testSteps.Log(LogStatus.Pass, "Click on <b>" + toClickList[i] + "</b>");
                    }else if (toClickList[i].Equals("ACCEPT ALERT"))
                    {
                        driver.FindElement(By.XPath("//button[text()='Ok']")).Click();
                        testSteps.Log(LogStatus.Pass, "Click on <b>" + toClickList[i] + "</b>");
                    } else if (toClickList[i].Equals("ORG ADMIN"))
                    {
                        performAction.clickButton(MenuItemsPage.ORGADMINLINK_MENU_XPATH, "ORGADMINLINK_MENU_XPATH");
                        testSteps.Log(LogStatus.Pass, "Click on <b>" + toClickList[i] + "</b>");                       
                    } else if (toClickList[i].Equals("ADD ORGANIZATION"))
                    {
                        System.Threading.Thread.Sleep(4000);
                        performAction.clickButton(OrganizationPage.ADDORGANIZATION_ORGADMIN_XPATH, "ADDORGANIZATION_ORGADMIN_XPATH");
                        testSteps.Log(LogStatus.Pass, "Click on <b>" + toClickList[i] + "</b>");
                    }else if (toClickList[i].Equals("PRIMARY DETAILS"))
                    {
                        System.Threading.Thread.Sleep(2000);
                        performAction.clickButton(OrganizationPage.PRIMARYDETAILS_ORGADMIN_XPATH, "PRIMARYDETAILS_ORGADMIN_XPATH");
                        testSteps.Log(LogStatus.Pass, "Click on <b>" + toClickList[i] + "</b>");
                    }else if (toClickList[i].Equals("LICENSE DETAILS"))
                    {
                        System.Threading.Thread.Sleep(2000);
                        performAction.clickButton(OrganizationPage.LICENSINGDETAILS_ORGADMIN_XPATH, "LICENSINGDETAILS_ORGADMIN_XPATH");
                        testSteps.Log(LogStatus.Pass, "Click on <b>" + toClickList[i] + "</b>");
                    }else if (toClickList[i].Equals("DEACTIVATELINK"))
                    {
                        System.Threading.Thread.Sleep(2000);
                        performAction.clickButton(OrganizationPage.DEACTIVATEICON_ORGADMIN_XPATH, "DEACTIVATEICON_ORGADMIN_XPATH");
                        testSteps.Log(LogStatus.Pass, "Click on <b>" + toClickList[i] + "</b>");
                    }else if (toClickList[i].Equals("DEACTIVATEBUTTON"))
                    {
                        System.Threading.Thread.Sleep(2000);
                        performAction.clickButton(OrganizationPage.DEACTIVATEBUTTON_ORGADMIN_XPATH, "DEACTIVATEBUTTON_ORGADMIN_XPATH");
                        testSteps.Log(LogStatus.Pass, "Click on <b>" + toClickList[i] + "</b>");
                    } else if (toClickList[i].Equals("BACKBUTTON"))
                    {
                        performAction.clickButton(OrganizationPage.BACKBUTTON_ORGADMIN_XPATH, "BACKBUTTON_ORGADMIN_XPATH");
                        testSteps.Log(LogStatus.Pass, "Click on <b>" + toClickList[i] + "</b>");
                    }else if (toClickList[i].Equals("USERADMINBUTTON"))
                    {
                        performAction.clickButton(OrganizationPage.USERADMINBUTTON_ORGADMIN_XPATH, "USERADMINBUTTON_ORGADMIN_XPATH");
                        testSteps.Log(LogStatus.Pass, "Click on <b>" + toClickList[i] + "</b>");
                        System.Threading.Thread.Sleep(2000);
                        IWebElement ele = driver.FindElement(By.XPath("//span[text()='"+testData.OrganizationName+"']"));
                        performAction.highlightText(ele);
                    }else if (toClickList[i].Equals("CANCELDEACTIVATE") || toClickList[i].Equals("CANCELREACTIVATE"))
                    {
                        System.Threading.Thread.Sleep(1000);
                        performAction.clickButton(OrganizationPage.CANCELBUTTON_ORGADMIN_XPATH, "CANCELBUTTON_ORGADMIN_XPATH");
                        testSteps.Log(LogStatus.Pass, "Click on <b>" + toClickList[i] + "</b>");                      
                    } else if (toClickList[i].Equals("REACTIVATELINK"))
                    {
                        performAction.clickButton(OrganizationPage.REACTIVATELINK_ORGADMIN_XPATH, "REACTIVATELINK_ORGADMIN_XPATH");
                        testSteps.Log(LogStatus.Pass, "Click on <b>" + toClickList[i] + "</b>");           
                    }else if (toClickList[i].Equals("ShowOnlyActiveOrganization"))
                    {
                        System.Threading.Thread.Sleep(2000);
                        performAction.clickButton(OrganizationPage.SHOWONLYACTIVEORG_ORGADMIN_XPATH, "SHOWONLYACTIVEORG_ORGADMIN_XPATH");
                        testSteps.Log(LogStatus.Pass, "Click on <b>" + toClickList[i] + "</b>");
                        System.Threading.Thread.Sleep(2000);
                        OrganizationAdmin organizationAdmin = new OrganizationAdmin(driver);
                        testData.UIActiveOrganizationCount = organizationAdmin.getActiveOrganizationCount();
                        Console.WriteLine("testData.UIActiveOrganizationCount="+testData.UIActiveOrganizationCount);
                    }else if ( toClickList[i].Equals("EDIT USER"))		
                    {		
                        performAction.clickButton(UserAdminPage.EDIT_USERADMIN_XPATH, "EDIT_USERADMIN_XPATH");		
                        testSteps.Log(LogStatus.Pass, "Click on <b>" + toClickList[i] + "</b>");		
                    }		
                    else if(toClickList[i].Equals("SET PASSWORD"))		
                    {		
                        performAction.clickButton(UserAdminPage.PASSWORDBUTTON_USERADMIN_XPATH, "PASSWORD_BUTTON_USERADMIN_XPATH");		
                        testSteps.Log(LogStatus.Pass, "Click on <b>" + toClickList[i] + "</b>");		
                    }else if (toClickList[i].Equals("STATE DROPDOWN"))		
                    {		
                        System.Threading.Thread.Sleep(10000);		
                        performAction.clickButton(UserAdminPage.STATE_USERADMIN_XPATH, "STATE_XPATH");		
                        System.Threading.Thread.Sleep(4000);		
                        driver.FindElement(By.XPath("//span[text() = 'Colorado']")).Click();		
                        //performAction.dropdownSelection(UserAdminPage.SEARCHORGANIZATION_ORGADMIN_XPATH, "SEARCHORGANIZATION_ORGADMIN_XPATH", DropDownConstants.KEY_DESELECT_BY_VISIBLE_TEXT, "New Org Ankur");		
                        testSteps.Log(LogStatus.Pass, "Click on <b>" + toClickList[i] + "</b>");		
                        System.Threading.Thread.Sleep(10000);		
                    }else if (toClickList[i].Equals("STATES DROPDOWN"))		
                    {		
                        System.Threading.Thread.Sleep(10000);		
                        performAction.clickButton(UserAdminPage.STATES_USERADMIN_XPATH, "STATES_XPATH");		
                        System.Threading.Thread.Sleep(4000);		
                        driver.FindElement(By.XPath("//span[text()='Arizona']")).Click();		
                        //performAction.dropdownSelection(UserAdminPage.SEARCHORGANIZATION_ORGADMIN_XPATH, "SEARCHORGANIZATION_ORGADMIN_XPATH", DropDownConstants.KEY_DESELECT_BY_VISIBLE_TEXT, "New Org Ankur");		
                        testSteps.Log(LogStatus.Pass, "Click on <b>" + toClickList[i] + "</b>");		
                        System.Threading.Thread.Sleep(10000);		
                    }else if (toClickList[i].Equals("CLIENTS DROPDOWN"))		
                    {		
                        System.Threading.Thread.Sleep(10000);		
                        performAction.clickButton(UserAdminPage.CLIENTGROUP_USERADMIN_XPATH, "CLIENT_GROUP_XPATH");		
                        System.Threading.Thread.Sleep(4000);		
                        driver.FindElement(By.XPath("//span[text()='Select All ']")).Click();		
                        //performAction.dropdownSelection(UserAdminPage.SEARCHORGANIZATION_ORGADMIN_XPATH, "SEARCHORGANIZATION_ORGADMIN_XPATH", DropDownConstants.KEY_DESELECT_BY_VISIBLE_TEXT, "New Org Ankur");		
                        testSteps.Log(LogStatus.Pass, "Click on <b>" + toClickList[i] + "</b>");		
                        System.Threading.Thread.Sleep(10000);		
                    }else if (toClickList[i].Equals("ROLE DETAILS"))
                    {
                        performAction.clickButton(UserAdminPage.ROLES_DETAILS_XPATH, "ROLES_DETAILS_XPATH");
                        testSteps.Log(LogStatus.Pass, "Click on <b>" + toClickList[i] + "</b>");
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

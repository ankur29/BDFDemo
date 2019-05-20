using Default.Web.Test.Automation.Entities;
using Default.Web.Test.Automation.Library;
using OpenQA.Selenium;
using RelevantCodes.ExtentReports;
using System;

using Default.Web.Test.Automation.ObjectRepository;

namespace Default.Web.Test.Automation.BusinessUitilities
{
    class UserAdmin
    {
        //Define Objects
        IWebDriver driver;
        PerformAction performAction;

        public UserAdmin(IWebDriver _driver)
        {
            driver = _driver;
            performAction = new PerformAction(driver);
        }

        public ExtentTest selectOrganization(ExtentReports report, TestData testdata)
        {
            ExtentTest testSteps = report.StartTest("Select Organization");            
            try
            {
                System.Threading.Thread.Sleep(5000);
                performAction.clickButton(UserAdminPage.SEARCHORGANIZATION_USERADMIN_XPATH, "SEARCHORGANIZATION_USERADMIN_XPATH");
                System.Threading.Thread.Sleep(3000);
                testSteps.Log(LogStatus.Pass, "Click on Search Organization Drop Down","");
                System.Threading.Thread.Sleep(5000);
                driver.FindElement(By.XPath("//span[text()=' "+testdata.OrganizationName+" ']")).Click();
                testSteps.Log(LogStatus.Info, "Selected Organization is ",testdata.OrganizationName);
            }
            catch (Exception e)
            {
                testSteps.Log(LogStatus.Fail, "Unable to select organization", e);
                var imagePath = new CaptureScreenshot(driver).takeScreenshot(testdata.testCaseName);
                testSteps.Log(LogStatus.Info, "Snapshot below: " + testSteps.AddScreenCapture(imagePath));
            }
            return testSteps;
        }
        public ExtentTest submitUserDetails(ExtentReports report, TestData testdata)
        {
            ExtentTest submituserSteps = report.StartTest("Submit User Details");
            try
            {
                System.Threading.Thread.Sleep(2000);
                performAction.clickJavaScript(performAction.getLocator(UserAdminPage.ADDUSER_USERADMIN_XPATH, "ADDUSER_USERADMIN_XPATH"));
                System.Threading.Thread.Sleep(1000);
                performAction.clickButton(UserAdminPage.FIRSTNAME_USERADMIN_XPATH, "FIRSTNAME_USERADMIN_XPATH");
                performAction.enterText(UserAdminPage.FIRSTNAME_USERADMIN_XPATH, "FIRSTNAME_USERADMIN_XPATH", testdata.FirstName);
                submituserSteps.Log(LogStatus.Info, "Enter First Name", testdata.FirstName);
                performAction.clickButton(UserAdminPage.LASTNAME_USERADMIN_XPATH, "LASTNAME_USERADMIN_XPATH");
                performAction.enterText(UserAdminPage.LASTNAME_USERADMIN_XPATH, "LASTNAME_USERADMIN_XPATH", testdata.LastName);
                submituserSteps.Log(LogStatus.Info, "Enter Last Name", testdata.LastName);
                performAction.clickButton(UserAdminPage.USERNAME_USERADMIN_XPATH, "USERNAME_USERADMIN_XPATH");
                performAction.enterText(UserAdminPage.USERNAME_USERADMIN_XPATH, "USERNAME_USERADMIN_XPATH", testdata.Email);
                submituserSteps.Log(LogStatus.Info, "Enter Email_Username", testdata.Email);
                performAction.clickButton(UserAdminPage.PASSWORDBUTTON_USERADMIN_XPATH, "PASSWORDBUTTON_USERADMIN_XPATH");
                submituserSteps.Log(LogStatus.Info, "Password Button Clicked","");
                performAction.clickButton(UserAdminPage.PHONE_USERADMIN_XPATH, "PHONE_USERADMIN_XPATH");
                performAction.enterText(UserAdminPage.PHONE_USERADMIN_XPATH, "PHONE_USERADMIN_XPATH", testdata.Phone);
                submituserSteps.Log(LogStatus.Info, "Enter Primary Phone", testdata.Phone);
                performAction.clickButton(UserAdminPage.ADDRESS1_USERADMIN_XPATH, "ADDRESS1_USERADMIN_XPATH");
                performAction.enterText(UserAdminPage.ADDRESS1_USERADMIN_XPATH, "ADDRESS1_USERADMIN_XPATH", testdata.Address1);
                submituserSteps.Log(LogStatus.Info, "Enter Address1", testdata.Address1);
                performAction.clickButton(UserAdminPage.ADDRESS2_USERADMIN_XPATH, "ADDRESS2_USERADMIN_XPATH");
                performAction.enterText(UserAdminPage.ADDRESS2_USERADMIN_XPATH, "ADDRESS2_USERADMIN_XPATH", testdata.Address2);
                submituserSteps.Log(LogStatus.Info, "Enter Address1", testdata.Address2);
                performAction.clickButton(UserAdminPage.ZIPCODE_USERADMIN_XPATH, "ZIPCODE_USERADMIN_XPATH");
                performAction.enterText(UserAdminPage.ZIPCODE_USERADMIN_XPATH, "ZIPCODE_USERADMIN_XPATH", testdata.Zipcode);
                submituserSteps.Log(LogStatus.Info, "Enter Zip Code", testdata.Zipcode);
                performAction.clickButton(UserAdminPage.CONTACTEMAIL_USERADMIN_XPATH, "CONTACTEMAIL_USERADMIN_XPATH");
                performAction.enterText(UserAdminPage.CONTACTEMAIL_USERADMIN_XPATH, "CONTACTEMAIL_USERADMIN_XPATH", testdata.CEmail);
                submituserSteps.Log(LogStatus.Info, "Enter Secondary Email", testdata.CEmail);
                String tempPass = performAction.getLocator(UserAdminPage.PASSWORD_USERADMIN_XPATH, "PASSWORD_USERADMIN_XPATH").GetAttribute("ng-reflect-model");

                testdata.password = tempPass;
                testdata.UserName = testdata.Email;

            }
            catch (Exception e)
            {
                submituserSteps.Log(LogStatus.Fail, "Unable to Submit User Details", e);
                var imagePath = new CaptureScreenshot(driver).takeScreenshot(testdata.testCaseName);
                submituserSteps.Log(LogStatus.Info, "Snapshot below: " + submituserSteps.AddScreenCapture(imagePath));
            }
            return submituserSteps;
        }
        public ExtentTest submitRoleDetails(ExtentReports report, TestData testdata)
        {
            ExtentTest roleSteps = report.StartTest("Submit Role Details");
            try
            {
                performAction.highlightText(performAction.getLocator(UserAdminPage.ROLEDETAILS_USERADMIN_XPATH, "ROLEDETAILS_USERADMIN_XPATH"));
                performAction.clickButton(UserAdminPage.ROLEDETAILS_USERADMIN_XPATH, "ROLEDETAILS_USERADMIN_XPATH");
                System.Threading.Thread.Sleep(1000);
                performAction.clickButton(UserAdminPage.ROLE_USERADMIN_XPATH, "ROLE_USERADMIN_XPATH");
                System.Threading.Thread.Sleep(1000);
                roleSteps.Log(LogStatus.Info, "Role selected","");
                performAction.clickButton(UserAdminPage.STATES_USERADMIN_XPATH, "STATES_USERADMIN_XPATH");
                System.Threading.Thread.Sleep(1000);
                driver.FindElement(By.XPath("//mat-option[@ng-reflect-value='3']")).Click();
                System.Threading.Thread.Sleep(1000);
                performAction.clickJavaScript(driver.FindElement(By.XPath("(//body/div[2]/div)[1]")));
                roleSteps.Log(LogStatus.Info, "State(s) selected","");
                performAction.clickButton(UserAdminPage.CLIENTGROUP_USERADMIN_XPATH, "CLIENTGROUP_USERADMIN_XPATH");
                System.Threading.Thread.Sleep(1000);
                driver.FindElement(By.XPath("//span[text()=' VBB ']")).Click();              
                roleSteps.Log(LogStatus.Info, "Client group selected","");
                System.Threading.Thread.Sleep(1000);

                int availableFeaturesCount = driver.FindElements(By.XPath("//div[@class='form-group row']")).Count;
                for (int i=1;i<=availableFeaturesCount;i++)
                {

                }
            }
            catch (Exception e)
            {
                roleSteps.Log(LogStatus.Fail, "Unable to submit role details", e);
                var imagePath = new CaptureScreenshot(driver).takeScreenshot(testdata.testCaseName);
                roleSteps.Log(LogStatus.Info, "Snapshot below: " + roleSteps.AddScreenCapture(imagePath));
            }
            return roleSteps;
        }
        public ExtentTest viewUser(ExtentReports report, TestData testdata)
        {
            ExtentTest viewUserSteps = report.StartTest("View User");
            try
            {
                System.Threading.Thread.Sleep(4000);
                performAction.clickButton(UserAdminPage.ROLES_DETAILS_XPATH, "ROLES_DETAILS_XPATH");
                System.Threading.Thread.Sleep(4000);
                performAction.clickButton(UserAdminPage.PRIMARY_DETAILS_XPATH, "PRIMARY_DETAILS_XPATH");
                System.Threading.Thread.Sleep(4000);
                viewUserSteps.Log(LogStatus.Pass, "View User Works");
            }
            catch (Exception e)
            {
                viewUserSteps.Log(LogStatus.Fail, "Unable to View", e);
                var imagePath = new CaptureScreenshot(driver).takeScreenshot(testdata.testCaseName);
                viewUserSteps.Log(LogStatus.Info, "Snapshot below: " + viewUserSteps.AddScreenCapture(imagePath));
            }
            return viewUserSteps;
        }
        public ExtentTest editUser(ExtentReports report, TestData testdata)
        {
            ExtentTest editUserSteps = report.StartTest("Edit User");
            try
            {
                System.Threading.Thread.Sleep(5000);
                performAction.highlightText(performAction.getLocator(UserAdminPage.ROLEDETAILS_USERADMIN_XPATH, "ROLEDETAILS_USERADMIN_XPATH"));
                performAction.clickButton(UserAdminPage.EDITLASTNAME_USERADMIN_XPATH, "EDITLASTNAME_USERADMIN_XPATH");
                performAction.enterText(UserAdminPage.EDITLASTNAME_USERADMIN_XPATH, "EDITLASTNAME_USERADMIN_XPATH", testdata.LastName);
                System.Threading.Thread.Sleep(2000);
                editUserSteps.Log(LogStatus.Pass, "User edited");
            }
            catch (Exception e)
            {
                editUserSteps.Log(LogStatus.Fail, "Unable to Edit", e);
                var imagePath = new CaptureScreenshot(driver).takeScreenshot(testdata.testCaseName);
                editUserSteps.Log(LogStatus.Info, "Snapshot below: " + editUserSteps.AddScreenCapture(imagePath));
            }
            return editUserSteps;
        }
        public ExtentTest editRole(ExtentReports report, TestData testdata)
        {
            ExtentTest editRoleSteps = report.StartTest("Edit User");
            try
            {
                System.Threading.Thread.Sleep(2000);
                performAction.clickButton(UserAdminPage.ROLEDETAILS_USERADMIN_XPATH, "ROLEDETAILS_USERADMIN_XPATH");
                System.Threading.Thread.Sleep(3000);
                performAction.clickButton(UserAdminPage.STATES_USERADMIN_XPATH, "STATES_USERADMIN_XPATH");
                System.Threading.Thread.Sleep(3000);
                driver.FindElement(By.XPath("//mat-option[@ng-reflect-value='3']")).Click();
                System.Threading.Thread.Sleep(2000);
                editRoleSteps.Log(LogStatus.Pass, "Role edited");
            }
            catch (Exception e)
            {
                editRoleSteps.Log(LogStatus.Fail, "Unable to Edit", e);
                var imagePath = new CaptureScreenshot(driver).takeScreenshot(testdata.testCaseName);
                editRoleSteps.Log(LogStatus.Info, "Snapshot below: " + editRoleSteps.AddScreenCapture(imagePath));
            }
            return editRoleSteps;
        }
       
        public ExtentTest deactivateUser(ExtentReports report, TestData testdata)
        {
            ExtentTest testSteps = report.StartTest("Deactivation User Steps");
            try
            {
                System.Threading.Thread.Sleep(1000);
                performAction.clickButton(UserAdminPage.DEACTIVATE_USERADMIN_XPATH, "DEACTIVATE_USERADMIN_XPATH");
                testSteps.Log(LogStatus.Pass, "Click on Deactivate Icon","");
                performAction.clickButton(UserAdminPage.DEACTIVATIONTEXT_USERADMIN_XPATH, "DEACTIVATIONTEXT_USERADMIN_XPATH");
                performAction.enterText(UserAdminPage.DEACTIVATIONTEXT_USERADMIN_XPATH, "DEACTIVATIONTEXT_USERADMIN_XPATH", testdata.DeactivateReason);
                testSteps.Log(LogStatus.Pass, "Enter Deactivation Reason", testdata.DeactivateReason);
                performAction.clickJavaScript(performAction.getLocator(UserAdminPage.DEACTIVATEBUTTON_USERADMIN_XPATH, "DEACTIVATEBUTTON_USERADMIN_XPATH"));
                testSteps.Log(LogStatus.Pass, "Click on Deactivate Button", "");
            }
            catch
            {
                testSteps.Log(LogStatus.Fail, "Unable to Deactivate the user");
                var imagePath = new CaptureScreenshot(driver).takeScreenshot(testdata.testCaseName);
                testSteps.Log(LogStatus.Info, "Snapshot below: " + testSteps.AddScreenCapture(imagePath));
            }
            return testSteps;
        }
        public ExtentTest reactivateUser(ExtentReports report, TestData testdata)
        {
            ExtentTest testSteps = report.StartTest("Reactivate User");
            try
            {
                System.Threading.Thread.Sleep(1000);
                performAction.clickButton(UserAdminPage.REACTIVATE_USERADMIN_XPATH, "REACTIVATE_USERADMIN_XPATH");
                testSteps.Log(LogStatus.Pass, "Click on Reactivate User Link","");
                System.Threading.Thread.Sleep(1000);
                performAction.clickButton(UserAdminPage.REACTIVATIONTEXT_USERADMIN_XPATH, "REACTIVATIONTEXT_USERADMIN_XPATH");
                performAction.enterText(UserAdminPage.REACTIVATIONTEXT_USERADMIN_XPATH, "REACTIVATIONTEXT_USERADMIN_XPATH", testdata.ReactivateReason);
                testSteps.Log(LogStatus.Pass, "Enter Reason for Reactivation", testdata.ReactivateReason);
                performAction.clickButton(UserAdminPage.REACTIVATEBUTTON_USERADMIN_XPATH, "REACTIVATEBUTTON_USERADMIN_XPATH");
                testSteps.Log(LogStatus.Pass, "Click on Reactivate button", "");
            }
            catch
            {
                testSteps.Log(LogStatus.Fail, "Unable to Reactivate the user");
                var imagePath = new CaptureScreenshot(driver).takeScreenshot(testdata.testCaseName);
                testSteps.Log(LogStatus.Info, "Snapshot below: " + testSteps.AddScreenCapture(imagePath));
            }
            return testSteps;
        }
        public ExtentTest reactivateCancel(ExtentReports report, TestData testdata)
        {
            ExtentTest reactivateCancelSteps = report.StartTest("Reactivation cancel");
            try
            {
                System.Threading.Thread.Sleep(5000);
                performAction.clickButton(UserAdminPage.REACTIVATE_USERADMIN_XPATH, "REACTIVATE_USERADMIN_XPATH");
                System.Threading.Thread.Sleep(5000);
                performAction.clickButton(UserAdminPage.CANCEL_BUTTON_XPATH, "CANCEL_BUTTON_XPATH");
                System.Threading.Thread.Sleep(5000);
                reactivateCancelSteps.Log(LogStatus.Pass, "Reactivation cancel");
            }
            catch
            {
                reactivateCancelSteps.Log(LogStatus.Fail, "Unable to Deactivate");
                var imagePath = new CaptureScreenshot(driver).takeScreenshot(testdata.testCaseName);
                reactivateCancelSteps.Log(LogStatus.Info, "Snapshot below: " + reactivateCancelSteps.AddScreenCapture(imagePath));
            }
            return reactivateCancelSteps;
        }
        public ExtentTest verifyIcon(ExtentReports report, TestData testdata)
        {
            ExtentTest verifyIconSteps = report.StartTest("Icon Verified");
            try
            {
                System.Threading.Thread.Sleep(5000);
                performAction.highlightText(performAction.getLocator(UserAdminPage.VIEWICON_USERADMIN_XPATH, "VIEWICON_USERADMIN_XPATH"));
                System.Threading.Thread.Sleep(5000);
                performAction.highlightText(performAction.getLocator(UserAdminPage.VIEWICON2_USERADMIN_XPATH, "VIEWICON2_USERADMIN_XPATH"));
                System.Threading.Thread.Sleep(5000);
                verifyIconSteps.Log(LogStatus.Pass, "Verified");
            }
            catch
            {
                verifyIconSteps.Log(LogStatus.Fail, "Unable to Verify");
                var imagePath = new CaptureScreenshot(driver).takeScreenshot(testdata.testCaseName);
                verifyIconSteps.Log(LogStatus.Info, "Snapshot below: " + verifyIconSteps.AddScreenCapture(imagePath));
            }
            return verifyIconSteps;
        }

        public ExtentTest searchUser(ExtentReports report, TestData testdata)
        {
            ExtentTest testSteps = report.StartTest("Search User");
            try
            {
                System.Threading.Thread.Sleep(4000);
                performAction.clickButton(UserAdminPage.SEARCHAREA_USERADMIN_XPATH, "SEARCHAREA_USERADMIN_XPATH");
                performAction.enterText(UserAdminPage.SEARCHAREA_USERADMIN_XPATH, "SEARCHAREA_USERADMIN_XPATH",testdata.Email);
                testSteps.Log(LogStatus.Info, "Enter User to search",testdata.Email);
                performAction.clickButton(UserAdminPage.SEARCHBUTTON_USERADMIN_XPATH, "SEARCHBUTTON_USERADMIN_XPATH");
                testSteps.Log(LogStatus.Info, "Click on Search button","");
                System.Threading.Thread.Sleep(2000);
                performAction.highlightText(driver.FindElement(By.XPath("//tbody/tr/td[text()=' "+testdata.Email+" ']")));
                performAction.highlightText(performAction.getLocator(UserAdminPage.UNIQUERECORD_USERADMIN_XPATH, "UNIQUERECORD_USERADMIN_XPATH"));
                performAction.highlightText(driver.FindElement(By.XPath("//tbody/tr/td[text()=' "+testdata.FirstName+" ']")));
                performAction.highlightText(driver.FindElement(By.XPath("//tbody/tr/td[text()=' "+testdata.LastName +" ']")));

            }
            catch(Exception e)
            {
                testSteps.Log(LogStatus.Fail, "Unable to Search User",e);
                var imagePath = new CaptureScreenshot(driver).takeScreenshot(testdata.testCaseName);
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
                        System.Threading.Thread.Sleep(3000);
                    }
                    else if (toClickList[i].Equals("ADMIN"))
                    {
                        performAction.clickButton(MenuItemsPage.ADMINLINK_MENU_XPATH, "ADMINLINK_MENU_XPATH");
                        testSteps.Log(LogStatus.Pass, "Click on <b>" + toClickList[i] + "</b>");
                    }
                    else if (toClickList[i].Equals("USERADMIN"))
                    {
                        performAction.clickButton(MenuItemsPage.USERADMINLINK_MENU_XPATH, "USERADMINLINK_MENU_XPATH");
                        testSteps.Log(LogStatus.Pass, "Click on <b>" + toClickList[i] + "</b>");
                    }
                    else if (toClickList[i].Equals("SHOWONLYACTIVEUSERS"))
                    {
                        performAction.clickButton(UserAdminPage.SHOWONLYACTIVEUSERS_USERADMIN_XPATH, "SHOWONLYACTIVEUSERS_USERADMIN_XPATH");
                        testSteps.Log(LogStatus.Pass, "Click on <b>" + toClickList[i] + "</b>");
                    }
                    else if (toClickList[i].Equals("SEARCHBAR"))
                    {
                        performAction.clickButton(UserAdminPage.SEARCHBAR_USERADMIN_XPATH, "SEARCHBAR_USERADMIN_XPATH");
                        testSteps.Log(LogStatus.Pass, "Click on <b>" + toClickList[i] + "</b>");
                    }
                    else if (toClickList[i].Equals("EDITUSER"))
                    {
                        performAction.clickButton(UserAdminPage.MODIFY_USERADMIN_XPATH, "MODIFY_USERADMIN_XPATH");
                        System.Threading.Thread.Sleep(4000);
                        testSteps.Log(LogStatus.Pass, "Click on <b>" + toClickList[i] + "</b>");
                    }
                    else if (toClickList[i].Equals("BACK"))
                    {
                        System.Threading.Thread.Sleep(1000);
                        performAction.clickJavaScript(performAction.getLocator(UserAdminPage.BACK_USERADMIN_XPATH, "BACK_USERADMIN_XPATH"));                       
                        testSteps.Log(LogStatus.Pass, "Click on <b>" + toClickList[i] + "</b>");
                    }
                    else if (toClickList[i].Equals("ADDUSER"))
                    {
                        System.Threading.Thread.Sleep(2000);
                        performAction.clickButton(UserAdminPage.ADDUSER_USERADMIN_XPATH, "ADDUSER_USERADMIN_XPATH");
                        testSteps.Log(LogStatus.Pass, "Click on <b>" + toClickList[i] + "</b>");
                    }
                    else if (toClickList[i].Equals("ORGANIZATIONDROPDOWN"))
                    {
                        System.Threading.Thread.Sleep(10000);
                        performAction.clickButton(UserAdminPage.SEARCHBAR_USERADMIN_XPATH, "SEARCHBAR_USERADMIN_XPATH");
                        System.Threading.Thread.Sleep(4000);
                        driver.FindElement(By.XPath("//span[text()=' System ']")).Click();
                        //performAction.dropdownSelection(UserAdminPage.SEARCHORGANIZATION_ORGADMIN_XPATH, "SEARCHORGANIZATION_ORGADMIN_XPATH", DropDownConstants.KEY_DESELECT_BY_VISIBLE_TEXT, "New Org Ankur");
                        testSteps.Log(LogStatus.Pass, "Click on <b>" + toClickList[i] + "</b>");
                        System.Threading.Thread.Sleep(8000);
                    }
                    else if (toClickList[i].Equals("USERDETAILS"))
                    {
                        System.Threading.Thread.Sleep(1000);
                        performAction.clickJavaScript(performAction.getLocator(UserAdminPage.USERDETAILS_USERADMIN_XPATH, "USERDETAILS_USERADMIN_XPATH"));
                        testSteps.Log(LogStatus.Pass, "Click on <b>" + toClickList[i] + "</b>");
                    }
                    else if (toClickList[i].Equals("CANCEL"))
                    {
                        System.Threading.Thread.Sleep(1000);
                        performAction.clickJavaScript(performAction.getLocator(UserAdminPage.CANCELBUTTON_USERADMIN_XPATH, "CANCELBUTTON_USERADMIN_XPATH"));
                        testSteps.Log(LogStatus.Pass, "Click on <b>" + toClickList[i] + "</b>");
                    }
                    else if (toClickList[i].Equals("SAVEUSER") || toClickList[i].Equals("SAVE"))
                    {
                        performAction.clickJavaScript(performAction.getLocator(UserAdminPage.SAVEBUTTON_USERADMIN_XPATH, "SAVEBUTTON_USERADMIN_XPATH"));
                        testSteps.Log(LogStatus.Pass, "Click on <b>" + toClickList[i] + "</b>");

                    }
                    else if (toClickList[i].Equals("SAVEANDNEWUSER"))
                    {
                        performAction.clickJavaScript(performAction.getLocator(UserAdminPage.SAVEANDNEWBUTTON_USERADMIN_XPATH, "SAVEANDNEWBUTTON_USERADMIN_XPATH"));
                        testSteps.Log(LogStatus.Pass, "Click on <b>" + toClickList[i] + "</b>");
                        System.Threading.Thread.Sleep(4000);
                    }
                    else if (toClickList[i].Equals("VIEWUSER"))
                    {
                        performAction.clickButton(UserAdminPage.VIEWICON_USERADMIN_XPATH, "VIEWICON_USERADMIN_XPATH");
                        testSteps.Log(LogStatus.Pass, "Click on <b>" + toClickList[i] + "</b>");
                    }                   
                    else if (toClickList[i].Equals("FIRSTPAGE"))
                    {
                        performAction.clickButton(UserAdminPage.FIRSTPAGEUSER_USERADMIN_XPATH, "FIRSTPAGEUSER_USERADMIN_XPATH");
                        testSteps.Log(LogStatus.Pass, "Click on <b>" + toClickList[i] + "</b>");
                    }
                    else if (toClickList[i].Equals("PREVIOUSPAGE"))
                    {
                        performAction.clickButton(UserAdminPage.PREVIOUSPAGEUSER_USERADMIN_XPATH, "PREVIOUSPAGEUSER_USERADMIN_XPATH");
                        testSteps.Log(LogStatus.Pass, "Click on <b>" + toClickList[i] + "</b>");
                    }
                    else if (toClickList[i].Equals("NEXTPAGE"))
                    {
                        performAction.clickButton(UserAdminPage.NEXTPAGEUSER_USERADMIN_XPATH, "NEXTPAGEUSER_USERADMIN_XPATH");
                        testSteps.Log(LogStatus.Pass, "Click on <b>" + toClickList[i] + "</b>");
                    }
                    else if (toClickList[i].Equals("LASTPAGE"))
                    {
                        performAction.clickButton(UserAdminPage.LASTPAGEUSER_USERADMIN_XPATH, "LASTPAGEUSER_USERADMIN_XPATH");
                        testSteps.Log(LogStatus.Pass, "Click on <b>" + toClickList[i] + "</b>");
                    }
                    else if (toClickList[i].Equals("EDITUSER"))
                    {
                        System.Threading.Thread.Sleep(6000);
                        performAction.clickButton(UserAdminPage.EDITUSER_USERADMIN_XPATH, "EDITUSER_USERADMIN_XPATH");
                        testSteps.Log(LogStatus.Pass, "Click on <b>" + toClickList[i] + "</b>");
                    }else if (toClickList[i].Equals("ACCEPTALERT"))
                    {
                        System.Threading.Thread.Sleep(1000);
                        driver.FindElement(By.XPath("//button[text()='Ok']")).Click();
                        testSteps.Log(LogStatus.Pass, "Click on <b>" + toClickList[i] + "</b>");
                    }
                    else if (toClickList[i].Equals("OK"))
                    {
                        System.Threading.Thread.Sleep(2000);
                        driver.FindElement(By.XPath("//div[@aria-labelledby='swal2-title']/div[3]/button[text()='OK']")).Click();
                        testSteps.Log(LogStatus.Pass, "Click on <b>" + toClickList[i] + "</b>");
                    }
                    else if (toClickList[i].Equals("ROLEDETAILS"))
                    {
                        System.Threading.Thread.Sleep(1000);
                        performAction.clickButton(UserAdminPage.ROLEDETAILS_USERADMIN_XPATH, "ROLEDETAILS_USERADMIN_XPATH");
                        testSteps.Log(LogStatus.Pass, "Click on <b>" + toClickList[i] + "</b>");
                    }
                    else if (toClickList[i].Equals("DEACTIVATE"))
                    {
                        System.Threading.Thread.Sleep(1000);
                        performAction.clickButton(UserAdminPage.DEACTIVATE_USERADMIN_XPATH, "DEACTIVATE_USERADMIN_XPATH");
                        testSteps.Log(LogStatus.Pass, "Click on <b>" + toClickList[i] + "</b>");
                    }
                    else if (toClickList[i].Equals("REACTIVATE"))
                    {
                        System.Threading.Thread.Sleep(1000);
                        performAction.clickButton(UserAdminPage.REACTIVATE_USERADMIN_XPATH, "REACTIVATE_USERADMIN_XPATH");
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

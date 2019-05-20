using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Default.Web.Test.Automation.ObjectRepository
{
    class UserAdminPage
    {
        //User Page Locators
        public static string SHOWONLYACTIVEUSERS_USERADMIN_XPATH = "//span[text()=' Show only active users ']";
        public static string SEARCHBAR_USERADMIN_XPATH = "//div[@class='mat-form-field-infix']/input";
        public static string ADDUSER_USERADMIN_XPATH = "//button[text()=' Add User ']";
        public static string SEARCHORGANIZATION_USERADMIN_XPATH = "(//div[@class='mat-select-value'])[1]";
        public static string VIEWICON_USERADMIN_XPATH = "(//i[@class='fas fa-eye'])[1]";
        public static string VIEWICON2_USERADMIN_XPATH = "(//i[@class='fas fa-eye'])[2]";
        public static string BACK_USERADMIN_XPATH = "//button[text()=' Back ']";
        public static string EDIT_USERADMIN_XPATH = "//i[@class='fas fa-pen mx-4']";
        public static string MODIFY_USERADMIN_XPATH = "//button[text()='Save']";
        public static string DEACTIVATIONTEXT_USERADMIN_XPATH = "//textarea[@ng-reflect-placeholder='Reason for deactivation']";
        public static string REACTIVATIONTEXT_USERADMIN_XPATH = "//textarea[@ng-reflect-placeholder='Reason for reactivation']";
        public static string PASSWORD_USERADMIN_XPATH = "//input[@placeholder='Password']";
        //ADD User page locators
        public static string USERDETAILS_USERADMIN_XPATH = "//div[text()='User Details']";
        public static string ROLEDETAILS_USERADMIN_XPATH = "//div[text()='Role Details']";
        public static string CANCELBUTTON_USERADMIN_XPATH = "//button[text()=' Cancel ']";
        public static string SAVEBUTTON_USERADMIN_XPATH = "//span[text()='Save']";
        public static string SAVEANDNEWBUTTON_USERADMIN_XPATH = "//span[text()=' Save and New ']";
        public static string EDITUSER_USERADMIN_XPATH = "//i[@class='fas fa-pen mx-4']";
        public static string DEACTIVATEUSER_USERADMIN_XPATH = "//i[@class='fas fa-times ng-star-inserted']";
        public static string FIRSTPAGEUSER_USERADMIN_XPATH = "(//span[@class='mat-button-wrapper'])[1]";
        public static string PREVIOUSPAGEUSER_USERADMIN_XPATH = "(//span[@class='mat-button-wrapper'])[2]";
        public static string NEXTPAGEUSER_USERADMIN_XPATH = "(//span[@class='mat-button-wrapper'])[3]";
        public static string LASTPAGEUSER_USERADMIN_XPATH = "(//span[@class='mat-button-wrapper'])[4]";

        //User Details
        //public static string USER_DETAILS_XPATH = "//div[@id='mat-tab-label-13-0']";
        public static string FIRSTNAME_USERADMIN_XPATH = "//input[@placeholder='First Name']";
        public static string LASTNAME_USERADMIN_XPATH = "//input[@formcontrolname='LastName']";
        public static string USERNAME_USERADMIN_XPATH = "//input[@formcontrolname='UserName']";
        //public static string PASSWORD_USERADMIN_XPATH = "//input[@formcontrolname='textTempPassword']";
        public static string PASSWORDBUTTON_USERADMIN_XPATH = "//button[text()=' Set Temporary Password ']";
        public static string CONTACTEMAIL_USERADMIN_XPATH = "//input[@placeholder='Secondary Email']";
        public static string ADDRESS1_USERADMIN_XPATH = "//input[@formcontrolname='Address1']";
        public static string ADDRESS2_USERADMIN_XPATH = "//input[@formcontrolname='Address2']";
        public static string ZIPCODE_USERADMIN_XPATH = "//input[@formcontrolname='PostalCode']";
        public static string CITY_USERADMIN_XPATH = "//input[@formcontrolname='City']";
        public static string STATE_USERADMIN_XPATH = "//span[@class ='mat-select-placeholder ng-tns-c13-322 ng-star-inserted']";
        public static string PHONE_USERADMIN_XPATH = "//input[@formcontrolname='PrimaryPhone']";

        //Role Details
        //public static string ROLE_DETAILS_XPATH = "//div[@id='mat-tab-label-13-1']";
        public static string STATES_USERADMIN_XPATH = "//span[text()='State(s)']";
        public static string CLIENTGROUP_USERADMIN_XPATH = "//span[text()='Client Group(s)']";
        public static string SAVE_BUTTON_XPATH = "//span[@class='btn dweb']";
        public static string CANCEL_BUTTON_XPATH = "//button[text()=' Cancel ']";
        public static string SAVE_AND_NEW_BUTTON_XPATH = "//span[@class='btn dweb d-block float-right mt-0']";
        public static string ORGANIZATION_XPATH = "//*[@id='mat-select-66']/div/div[1]";
        public static string ROLE_USERADMIN_XPATH = "//*[text()=' Case Manager ']";
        public static string CREATE_USER_XPATH = "//h1[text()='create user']";
        public static string TITLE_USERADMIN_XPATH = "//div[@class='cdk-overlay-container']";

        //view User Detail
        public static string ROLES_DETAILS_XPATH = "//div[@class='mat-tab-label mat-ripple ng-star-inserted']";
        public static string PRIMARY_DETAILS_XPATH = "//div[@class='mat-tab-label mat-ripple ng-star-inserted']";
        public static string SEARCHAREA_USERADMIN_XPATH = "//div[@class='mat-form-field-infix']/input";
        public static string SEARCHBUTTON_USERADMIN_XPATH = "//i[@mattooltip='Search']";
        public static string DEACTIVATE_USERADMIN_XPATH = "//i[@ng-reflect-message='Deactivate']";
        public static string REACTIVATE_USERADMIN_XPATH = "//i[@ng-reflect-message='Activate']";

        //edit User Detail
        public static string EDITLASTNAME_USERADMIN_XPATH = "//input[@formcontrolname='lastName']";
        public static string DEACTIVATEBUTTON_USERADMIN_XPATH = "//button[text() = ' Deactivate ']";
        public static string REACTIVATEBUTTON_USERADMIN_XPATH = "//button[text()= ' Reactivate ']";
        public static string SUCCESS_USERADMIN_XPATH = "//button[text() = 'Ok']";
        public static string UNIQUERECORD_USERADMIN_XPATH="//div[text()='1 - 1 of 1']";
        //public static string TEXT1_USERADMIN_XPATH = "//td[text() = ' srishty@gmail.com ']";
        //public static string TEXT2_USERADMIN_XPATH = "//div[text() = ' srishty@gmail.com ']";




    }
}

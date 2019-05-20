using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Default.Web.Test.Automation.ObjectRepository
{
    class OrganizationPage
    {
        //
        public static string ADDORGANIZATION_ORGADMIN_XPATH = "//button[text()=' Add Organization ']";
        
        //Organization details locators
        public static string ORGANIZATIONDETAILS_ORGADMIN_XPATH = "//h6[text()='Organization Details']";
        public static string ORGANIZATIONNAME_ORGADMIN_XPATH = "//input[@placeholder='Organization Name']";
        public static string ADDRESS1_ORGADMIN_XPATH = "//input[@placeholder='Address 1']";
        public static string ADDRESS2_ORGADMIN_XPATH = "//input[@placeholder='Address 2']";
        public static string ZIPCODE_ORGADMIN_XPATH = "//input[@placeholder='ZIP Code']";
        public static string CITY_ORGADMIN_XPATH = "//input[@placeholder='City']";
        public static string SELECTSTATE_ORGADMIN_XPATH = "//span[text()='Select State']";
        public static string PRIMARYDETAILS_ORGADMIN_XPATH = "//div[text()='Primary Details']";
        //Primary Contact Details Locators
        public static string PRIMARYCONTACTFIRSTNAME_ORGADMIN_XPATH = "//input[@formcontrolname='primaryContactFirstName']";
        public static string PRIMARYCONTACTLASTNAME_ORGADMIN_XPATH = "//input[@formcontrolname='primaryContactLastName']";
        public static string PRIMARYCONTACTEMAIL_ORGADMIN_XPATH = "//input[@formcontrolname='primaryContactEmail']";
        public static string PRIMARYCONTACTPHONE_ORGADMIN_XPATH = "//input[@formcontrolname='primaryContactPhone']";

        //Secondary Contact Details Locators
        public static string SECONDARYCONTACTFIRSTNAME_ORGADMIN_XPATH = "//input[@formcontrolname='secondaryContactFirstName']";
        public static string SECONDARYCONTACTLASTNAME_ORGADMIN_XPATH = "//input[@formcontrolname='secondaryContactLastName']";
        public static string SECONDARYCONTACTEMAIL_ORGADMIN_XPATH = "//input[@formcontrolname='secondaryContactEmail']";
        public static string SECONDARYCONTACTPHONE_ORGADMIN_XPATH = "//input[@formcontrolname='secondaryContactPhone']";

        //Billing Contact Details Locators
        public static string BILLINGCONTACTFIRSTNAME_ORGADMIN_XPATH = "//input[@formcontrolname='billingContactFirstName']";
        public static string BILLINGCONTACTLASTNAME_ORGADMIN_XPATH = "//input[@formcontrolname='billingContactLastName']";
        public static string BILLINGCONTACTEMAIL_ORGADMIN_XPATH = "//input[@formcontrolname='billingContactEmail']";
        public static string BILLINGCONTACTPHONE_ORGADMIN_XPATH = "//input[@formcontrolname='billingContactPhone']";

        //License Details Locators
        public static string LICENSINGDETAILS_ORGADMIN_XPATH = "//div[text()='Licensing Details']";
        public static string USERLICENSE_ORGADMIN_XPATH = "//input[@formcontrolname='userLicenses']";
        public static string FILELICENSE_ORGADMIN_XPATH = "//input[@formcontrolname='fileLicenses']";
        public static string STORAGELICENSE_ORGADMIN_XPATH = "//input[@formcontrolname='storageLicenses']";
        public static string BANKRUPTCYFEATURE_ORGADMIN_XPATH = "//span[text()=' Bankruptcy ']";
        public static string EVICTIONFEATURE_ORGADMIN_XPATH = "//span[text()=' Eviction ']";
        public static string TITLEFEATURE_ORGADMIN_XPATH = "//span[text()=' Title ']";
        public static string MISCELLEANEOUSFEATURE_ORGADMIN_XPATH = "//span[text()=' Miscellaneous ']";
        public static string FORECLOSUREFEATURE_ORGADMIN_XPATH = "//span[text()=' Foreclosure ']";
        public static string LITIGATIONFEATURE_ORGADMIN_XPATH = "//span[text()=' Litigation ']";
        public static string MAILINGFEATURE_ORGADMIN_XPATH = "//span[text()=' Mailing ']";
        public static string CANCELBUTTON_ORGADMIN_XPATH = "//button[text()=' Cancel ']";
        public static string SAVEBUTTON_ORGADMIN_XPATH = "//button[text()='Save']";
        public static string SAVEANDUSERBUTTON_ORGADMIN_XPATH = "//button[text()=' Save and User Admin ']";

        //view/deactivate/Edit Organization Page locators
        public static string SEARCHBAR_ORGADMIN_XPATH = "//div[@class='mat-form-field-infix']/input";
        public static string SEARCHICON_ORGADMIN_XPATH = "//i[@mattooltip='Search']";
        public static string VIEWICON_ORGADMIN_XPATH = "//i[@class='fas fa-eye']";
        public static string BACKBUTTON_ORGADMIN_XPATH = "//button[text()=' Back ']";
        public static string USERADMINBUTTON_ORGADMIN_XPATH = "//button[text()=' User Admin ']";
        public static string EDITICON_ORGADMIN_XPATH = "//i[@class='fas fa-pen mx-4']";
        public static string DEACTIVATEICON_ORGADMIN_XPATH = "//i[@class='fas fa-times ng-star-inserted']";
        public static string REASON_ORGADMIN_XPATH = "//textarea[@formcontrolname='statusChangeReason']";
        public static string DEACTIVATEBUTTON_ORGADMIN_XPATH = "//button[text()=' Deactivate ']";
        public static string REACTIVATELINK_ORGADMIN_XPATH = "//i[@class='fas fa-undo ng-star-inserted']";
        public static string REACTIVATEBUTTON_ORGADMIN_XPATH = "//button[text()=' Reactivate ']";
        public static string SHOWONLYACTIVEORG_ORGADMIN_XPATH = "//span[text()=' Show only active organizations ']";
        public static string TOTALITEMS_ORGADMIN_XPATH = "//div[@class='mat-paginator-range-label']";
        public static string PRIMARYDETAILSTITLE_ORGADMIN_XPATH = "//div[text()='Primary Details']";
        public static string ORGANIZATIONDETAILSTITLE_ORGADMIN_XPATH = "//th[text()=' Organization Details ']";
        public static string PRIMARYCONTACTTITLE_ORGADMIN_XPATH = "//th[text()=' Primary Contact ']";
        public static string SECONDARYCONTACTTITLE_ORGADMIN_XPATH = "//th[text()=' Secondary Contact ']";
        public static string BILLINGCONTACTTITLE_ORGADMIN_XPATH = "//th[text()=' Billing Contact ']";
        public static string LICENSINGDETAILSTITLE_ORGADMIN_XPATH = "//div[text()='Licensing Details']";

        //Mailing Details Locators
        public static string MAILINGDETAILSTITLE_ORGADMIN_XPATH = "//div[text()='Mailing Details']";
        public static string MAILPROCESSING_ORGADMIN_XPATH = "//div[@class='mat-select-value']";
        public static string CURRENT_ORGADMIN_XPATH = "//span[text()='Current']";
        public static string PREVIOUS_ORGADMIN_XPATH = "//label[text()='Previous']";











    }
}

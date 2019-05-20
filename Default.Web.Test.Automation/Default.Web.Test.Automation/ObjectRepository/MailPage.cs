using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Default.Web.Test.Automation.ObjectRepository
{
    class MailPage
    {
        public static string MAILDATACAPTURETITLE_MAILDATACAPTURE_XPATH = "//h1[text()='mail data capture']";
        public static string SENDFROM_MAILDATACAPTURE_XPATH = "//input[@placeholder='Send From']";
        public static string SENDFROMADDRESS_MAILDATACAPTURE_XPATH = "//div[@class='mt-4 mb-3 ml-5']";
        public static string MAILINGINSTRUCTIONSPANEL_MAILDATACAPTURE_XPATH = "//h6[text()='Mailing Instructions:']";
        public static string REVIEWRELEASEPANEL_MAILDATACAPTURE_XPATH = "//h6[text()='Review/Release:']";
        public static string FIRSTNAME_MAILDATACAPTURE_XPATH = "//input[@placeholder='First Name']";
        public static string LASTNAME_MAILDATACAPTURE_XPATH = "//input[@placeholder='Last Name']";
        public static string ADDRESS1_MAILDATACAPTURE_XPATH = "//input[@placeholder='Address 1']";
        public static string ADDRESS2_MAILDATACAPTURE_XPATH = "//input[@placeholder='Address 2']";
        public static string ZIPCODE_MAILDATACAPTURE_XPATH = "//input[@placeholder='ZIP Code']";
        public static string CITY_MAILDATACAPTURE_XPATH = "//input[@placeholder='City']";
        public static string SELECTSTATE_MAILDATACAPTURE_XPATH = "//span[text()='Select State']";
        public static string MAILTYPE_MAILDATACAPTURE_XPATH = "//span[text()='Mail Type']";
        public static string MAILSERVICE_MAILDATACAPTURE_XPATH = "//span[text()='Mail Service']";
        public static string MAILENCLOSURE_MAILDATACAPTURE_XPATH = "//span[text()='Mail Enclosures']";
        public static string MAILINSTRUCTIONS_MAILDATACAPTURE_XPATH = "//h6[text()='Mailing Instructions']";
        public static string ADDMAILRECIPEINT_MAILDATACAPTURE_XPATH = "//i[@class='fas fa-plus mt-2 ml-auto']";
        public static string REFERENCENUMBER_MAILDATACAPTURE_XPATH = "//input[@placeholder='Reference Number']";

        public static string MAILINGDATE_MAILDATACAPTURE_XPATH = "//input[@placeholder='Mailing Date']";
        public static string MAILDESCRIPTION_MAILDATACAPTURE_XPATH = "//textarea[@placeholder='Mail Description']";
        public static string RECIPIENTMAILINGINSTRUCTIONS_MAILDATACAPTURE_XPATH = "//h6[text()='Recipient / Mailing Instructions:']";
        public static string BACKGROUND_MAILDATACAPTURE_XPATH = "(//div[@class='cdk-overlay-container']/div)[1]";

        public static string DOCUMENTPANEL_MAILDATACAPTURE_XPATH = "//h6[text()='Document:']";
        public static string UPLOADDOCUMENT_MAILDATACAPTURE_XPATH = "//i[@mattooltip='Upload Document']";
        public static string SELECTALLDOCUMENT_MAILDATACAPTURE_XPATH = "//label[@for='mat-checkbox-3-input']";
        public static string VIEWDOCUMENT_MAILDATACAPTURE_XPATH = "//i[@ng-reflect-message='View Document']";
        public static string CLOSEATTACHEDDOCS_MAILDATACAPTURE_XPATH = "(//button[text()=' Close '])[1]";
        public static string RELEASEDOCUMENT_MAILDATACAPTURE_XPATH = "//button[text()=' Release ']";
        public static string CLOSE_MAILDATACAPTURE_XPATH = "//*[@id='myModal10']/div/div/div[2]/div[1]/button";
        public static string REMOVEDOC_MAILDATACAPTURE_XPATH = "//i[@ng-reflect-message='Remove']";

        //Mail History Page
        public static string REFERENCENUMBER_MAILHISTORY_XPATH = "//input[@placeholder='Reference Number']";
        public static string TITLE_MAILHISTORY_XPATH = "//h1[text()='mail history']";
        public static string MAILHISTORY_MAILDATACAPTURE_XPATH = "//span[text()='Mail History']";
        public static string ORGID_MAILHISTORY_XPATH = "//div[@class='col-md-3']//div[@class='row'][1]//b";
        public static string ORGNAME_MAILHISTORY_XPATH = "//div[@class='col-md-3']//div[@class='row'][2]//b";
        public static string DESCRIPTIONSEARCH_MAILHISTORY_XPATH = "//input[@placeholder='Description']";
        public static string SENTTOSEARCH_MAILHISTORY_XPATH = "//input[@placeholder='Sent To']";
        public static string MAILEDDATESEARCH_MAILHISTORY_XPATH = "//input[@placeholder='Mailed Date']";
        public static string REGISTEREDMAILNUMBERSEARCH_MAILHISTORY_XPATH = "//input[@placeholder='Registered Mail Number']";
        public static string SEARCHICON_MAILHISTORY_XPATH = "//div[1]/div[4]/i[@class='nc-icon nc-zoom-split']";
        public static string MAILINGIDBUTTON_MAILHISTORY_XPATH = "//button[text()=' Mailing ID ']";
        public static string MAILINGDESCRIPTIONBUTTON_MAILHISTORY_XPATH = "//button[text()=' Mailing Description ']";
        public static string SUBMITTEDDATEBUTTON_MAILHISTORY_XPATH = "//button[text()=' Submitted Date ']";
        public static string SUBMITTEDBY_MAILHISTORY_XPATH = "//button[text()=' Submitted By ']";
        public static string PRINTEDDATE_MAILHISTORY_XPATH = "//button[text()=' Printed Date ']";
        public static string MAILEDDATE_MAILHISTORY_XPATH = "//button[text()=' Mailed Date ']";
        public static string SENTTO_MAILHISTORY_XPATH = "//button[text()=' Sent To ']";
        public static string REGISTEREDMAILNUMBER_MAILHISTORY_XPATH = "//button[text()=' Registered ']";
        public static string IMAGEID_MAILHISTORY_XPATH = "//button[text()=' Image Id ']";
        public static string ACTION_MAILHISTORY_XPATH = "//th[text()='Action']";
        public static string IMAGELINK_MAILHISTORY_XPATH = "//tr[1]//td[10]/a";
        public static string ITEMPERPAGELABEL_MAILHISTORY_XPATH = "//div[text()='Items per page:']";
        public static string ITEMPERPAGEDROPDOWN_MAILHISTORY_XPATH = "//div[@class='mat-select-value']";
        public static string FIRSTOPTIONITEMPERPAGE_MAILHISTORY_XPATH = "//*[@id='mat-option-0']/span";
        public static string SECONDOPTIONITEMPERPAGE_MAILHISTORY_XPATH = "//*[@id='mat-option-1']/span";
        public static string THIRDOPTIONITEMPERPAGE_MAILHISTORY_XPATH = "//*[@id='mat-option-2']/span";
        public static string PAGECOUNT_MAILHISTORY_XPATH = "//div[@class='mat-paginator-range-label']";
        public static string FIRSTPAGEMAIL_MAILHISTORY_XPATH = "//button[@class='mat-paginator-navigation-first mat-icon-button ng-star-inserted']";
        public static string PREVIOUSPAGEMAIL_MAILHISTORY_XPATH = "//button[@class='mat-paginator-navigation-previous mat-icon-button']";
        public static string NEXTPAGEMAIL_MAILHISTORY_XPATH = "//button[@class='mat-paginator-navigation-next mat-icon-button']";
        public static string LASTPAGEMAIL_MAILHISTORY_XPATH = "//button[@class='mat-paginator-navigation-last mat-icon-button ng-star-inserted']";
        public static string RETURNBUTTON_MAILHISTORY_XPATH = "//button[text()=' Return ']";

        //Mail Validation
        public static string TITLE_MAILVALIDATION_XPATH = "//h1[text()='mail validation']";
        public static string BARCODENUMBERINPUT_MAILVALIDATION_XPATH = "//input[@placeholder='Bar Code Number']";
        public static string ENTERBUTTON_MAILVALIDATION_XPATH = "//button[@class='ml-3 btn dweb btn-sm mat-flat-button']";
        public static string BARCODE_MAILVALIDATION_XPATH = "//button[text()=' BarCode ']";
        public static string STATUS_MAILVALIDATION_XPATH = "//button[text()=' Status ']";
        public static string ITEMPERPAGELABEL_MAILVALIDATION_XPATH = "//DIV[text()='Items per page:']";
        public static string ITEMPERPAGEDROPDOWN_MAILVALIDATION_XPATH = "//div[@class='mat-select-value']";
        public static string PAGECOUNT_MAILVALIDATION_XPATH = "//div[@class='mat-paginator-range-label']";
        public static string MAILVALIDATION_MAIL_XPATH = "//span[text()='Mail Validation']";

        //Mail Reconciliation
        public static string MAILRECONCILIATION_MAIL_XPATH = "//span[text()='Mail Reconciliation']";
        public static string RECONCILIATIONDATE_MAIL_XPATH = "//input[@placeholder='Reconciliation Date']";
        public static string FILTER_MAIL_XPATH = "(//div[@class='mat-select-arrow'])[1]";
        public static string LASTPAGE_RECONCILIATION_XPATH = "//button[@aria-label='Last page']";
        public static string MAILREQUESTID_RECONCILIATION_XPATH = "//table/thead/tr/th/div/button[text()=' Mail Request ID ']";
    }
}

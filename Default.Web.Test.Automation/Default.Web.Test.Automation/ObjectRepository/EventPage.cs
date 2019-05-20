
namespace Default.Web.Test.Automation.ObjectRepository
{
    class EventPage
    {
        //Add event page locators
        public static string MAINTENANCEICON_EVENT_XPATH = "//i[@class='fas fa-cog']";
        public static string EVENTMAINTENANCELIST_EVENT_XPATH = "//*[@id='navigation']/ul/li[2]/div/a[1]";
        public static string EventMaintenanceTitle_event_XPATH = "//h1[text()='event maintenance list']";
        public static string ADDEVENTBUTTON_EVENT_XPATH = "//button[text()=' Add new event ']";
        public static string EVENTCODE_ADDEVENT_XPATH = "//input[@placeholder='Event code']";
        public static string EVENTNAME_ADDEVENT_XPATH = "//input[@formcontrolname='Name']";
        public static string MILESTONE_ADDEVENT_XPATH = "//span[text()='This event is a milestone']";
        public static string ACTIVE_ADDEVENT_XPATH = "//span[text()='This event is active']";
        public static string CLOSE_ADDEVENT_XPATH = "//button[text()=' Close ']";
        public static string SAVE_ADDEVENT_XPATH = "//button[text()=' Save ']";
        public static string SAVEANDNEW_ADDEVENT_XPATH = "//button[text()=' Save and New ']";
        public static string OKBUTTON_ADDEVENT_XPATH = "//div[3]/button[1]";


        //search event page locator
        public static string EVENTCODE_EVENTSEARCH_XPATH = "//input[@placeholder='Event Code']";
        public static string EVENTNAME_EVENTSEARCH_XPATH = "//input[@placeholder='Event Name']";
        public static string EVENTNAME_DROPDOWN_XPATH = "//*[@id='mat-select-0']/div/div[1]";
        public static string MILESTONEYES_EVENTSEARCH_XPATH = "//span[text()=' Yes ']";
        public static string MILESTONENO_EVENTSEARCH_XPATH = "//span[text()=' No ']";
        public static string CLEARSEARCHFORM_EVENTSEARCH_XPATH = "//div[2]/i";
        public static string ACTIVEEVENTS_EVENTSEARCH_XPATH = "//span[text()='Show only active events']";
        public static string SEARCHICON_EVENTSEARCH_XPATH = "//div[3]/div/i";
        public static string VERIFYCODE_EVENTSEARCH_XPATH = "//tr/td[2]";
        public static string SHOWONLYACTIVE_EVENTSEARCH_XPATH = "//span[text()='Show only active events']";
      
        //event list page locators
        public static string EVENTID_EVENTLIST_XPATH = "//tr/th[1]";
        public static string EVENTCODE_EVENTLIST_XPATH = "//tr/th[2]";
        public static string EVENTNAME_EVENTLIST_XPATH = "//tr/th[3]";
        public static string MILESTONE_EVENTLIST_XPATH = "//tr/th[4]";
        public static string ACTIVE_EVENTLIST_XPATH = "//tr/th[5]";
        public static string CREATEDON_EVENTLIST_XPATH = "//tr/th[6]";
        public static string CREATEDBY_EVENTLIST_XPATH = "//tr/th[7]";
        public static string UPDATEDON_EVENTLIST_XPATH = "//tr/th[8]";
        public static string UPDATEDBY_EVENTLIST_XPATH = "//tr/th[9]";
        public static string ACTION_EVENTLIST_XPATH = "//tr/th[10]";
        public static string PAGEDROPDOWN_EVENTLIST_XPATH = "//*[@id='mat-select-1']/div/div[2]";
        public static string COUNT5_EVENTLIST_XPATH = "//span[text()='5']";
        public static string COUNT10_EVENTLIST_XPATH = "//span[text()='10']";
        public static string COUNT20_EVENTLIST_XPATH = "//span[text()='20']";
       
        //event modification page
        public static string MODIFYICON_EVENTMODIFY_XPATH = "//tr/td[10]/i";
        public static string EVENTNAME_EVENTMODIFY_XPATH = "//input[@ng-reflect-name='Name']";
        public static string SAVEBUTTON_EVENTMODIFY_XPATH = "//button[text()=' Modify ']";
        public static string INACTIVE_DEACTIVATEEVENT_XPATH = "//span[text()='This event is a active']";
        public static string OKBUTTON_EVENTMODIFY_XPATH = "//button[text()='OK']";
        public static string UNIQUERECORD_EVENTLIST_XPATH = "//div[text()='1 - 1 of 1']";
        public static string REASON_EVENTMODIFY_XPATH = "//input[@placeholder='Reason']";

        //Event Template Locators
        public static string EVENTTEMPLATETITLE_EVENTTEMPLATE_XPATH = "//h1[text()='event template']";
        public static string ORGANIZATIONDROPDOWN_EVENTTEMPLATE_XPATH = "//mat-select[@placeholder='Organization']/div/div";
        public static string ADDNEWTEMPLATE_EVENTTEMPLATE_XPATH = "//button[text()=' Add new template ']";

        //ADD Event Template Locators
        public static string EVENTTEMPLATEDETAILS_ADDTEMPLATE_XPATH = "//h1[text()='event template details']";
        public static string TEMPLATEDETAILS_ADDTEMPLATE_XPATH = "//h6[text()='Template Details']";
        public static string TEMPLATECODE_ADDTEMPLATE_XPATH = "//input[@placeholder='Template Code']";
        public static string TEMPLATENAME_ADDTEMPLATE_XPATH = "//input[@placeholder='Template Name']";
        public static string STARTDATE_ADDTEMPLATE_XPATH = "//input[@placeholder='Start Date']";
        public static string ENDDATE_ADDTEMPLATE_XPATH = "//input[@placeholder='End Date']";
        public static string PRIMARYEVENTCHECKBOX_ADDTEMPLATE_XPATH = "//span[text()='This is PRIMARY event template']";
        public static string SAVETEMPLATE_ADDTEMPLATE_XPATH = "//button[text()=' Save Template ']";
        public static string SELECTEDORGANIZATION_ADDTEMPLATE_XPATH = "//button[text()=' Save Template ']";
        public static string PRIMARYEVNTCHECKBOXSTATUS_ADDTEMPLATE_XPATH = "//input[@id='mat-checkbox-2-input' and @aria-checked='true']";
        public static string SAVEMODAL_ADDTEMPLATE_XPATH = "//button[text()='Save']";
        public static string CANCELMODAL_ADDTEMPLATE_XPATH = "//button[text()='Cancel']";
        public static string ADDEVENT_ADDTEMPLATE_XPATH = "//span[text()='Add Event ']";

        public static string EVENTCODE_EVENTFINDER_XPATH = "//input[@placeholder='Event Code']";
        public static string EVENTDESCRIPTION_EVENTFINDER_XPATH = "//input[@placeholder='Event Description']";
        public static string MILESTONE_EVENTFINDER_XPATH = "//span[text()='Milestone']";
        public static string SHOWACTIVEEVENTSCHECKBOX_EVENTFINDER_XPATH = "//span[text()='Show only active events']";
        public static string SEARCHICON_EVENTFINDER_XPATH = "//i[@ng-reflect-message='Search']";
        public static string CLEARSEARCH_EVENTFINDER_XPATH = "//i[@ng-reflect-message='Clear']";
        public static string EVENTID_EVENTFINDER_XPATH = "//button[text()=' Event ID ']";
        public static string EVENTCODEHEADER_EVENTFINDER_XPATH = "//tr/th[2]/div/button[text()=' Event Code ']";
        public static string EVENTNAMEHEADER_EVENTFINDER_XPATH = "//tr/th[3]/div/button[text()=' Event Name ']";
        public static string MILESTONEHEADER_EVENTFINDER_XPATH = "//tr/th[4]/div/button[text()=' Milestone ']";
        public static string ACTIVEHEADER_EVENTFINDER_XPATH = "//button[text()=' Active ']";
        public static string ACTIONHEADER_EVENTFINDER_XPATH = "//button[text()=' Active ']//following::th[text()='Action']";
        public static string ITEMSPERPAGE_EVENTFINDER_XPATH = "//mat-select[@aria-label='Items per page:']";
        public static string LABELRANGE_EVENTFINDER_XPATH = "//div[@class='mat-paginator-range-label']";
        public static string NEXTPAGE_EVENTFINDER_XPATH = "//button[@ng-reflect-message='Next page']";
        public static string ADDTOTEMPLATE_EVENTFINDER_XPATH = "//button[text()=' Add to template ']";
    }
}

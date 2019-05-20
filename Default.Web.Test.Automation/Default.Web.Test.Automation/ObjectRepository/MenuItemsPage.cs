using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Default.Web.Test.Automation.ObjectRepository
{
    class MenuItemsPage
    {
        //Admin Links LOcator
        public static string ADMINLINK_MENU_XPATH = "//a[@id='dropdownMenuAdmin']";
        public static string ORGADMINLINK_MENU_XPATH = "//button[text()=' Organization Admin ']";
        public static string USERADMINLINK_MENU_XPATH = "//a[text() = 'User Admin']";
        //Mail Locators
        public static string MAILLINK_MENU_XPATH = "//p[text()='Mail']";
        public static string MAILDATACAPTURELINK_MENU_XPATH = "//span[text()='Mail Data Capture']";
        //MaintenanceLocators
        public static string MAINTENANCEICON_EVENT_XPATH = "//i[@class='fas fa-cog']";
        public static string EVENTMAINTENANCELIST_EVENT_XPATH = "//*[@id='navigation']/ul/li[2]/div/a[1]";
        //User Locators
        public static string USERICON_EVENT_XPATH = "//i[@class='fas fa-user']";
        public static string SIGNOUT_EVENT_XPATH = "//a[text()='Sign out']";
        //Event Locators
        public static string EVENTTEMPLATE_EVENT_XPATH  = "//a[text()='Event Template']";
        public static string EXPANDMODAL_EVENT_XPATH = "//div[@aria-labelledby='dropdownMenuMaintenance' and @class='dropdown-menu dropdown-menu-right show']";


    }
}

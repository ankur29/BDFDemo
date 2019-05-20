using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Default.Web.Test.Automation.ObjectRepository
{
   public  class WebMailPage
    {
        //Gmail Locators
        public static string CREATEACCOUNT_SIGNUP_XPATH = "//span[text()='Create account']";
        public static string EMAILORPHONE_SIGNIN_XPATH = "//input[@aria-label='Email or phone']";
        public static string PASSWORD_SIGNIN_XPATH = "//input[@aria-label='Enter your password']";
        public static string NEXT_SIGNIN_XPATH = "//span[text()='Next']";
        public static string SEARCHEMAIL_SIGNIN_XPATH = "//input[@placeholder='Search mail']";
        public static string SEARCHLINK_SIGNIN_XPATH = "//*[@id='aso_search_form_anchor']/button[4]/svg";

        //Proton Mail Locators
        public static string USERNAME_PROTONMAIL_XPATH = "//input[@ng-model='username']";
        public static string PASSWORD_PROTONMAIL_XPATH = "//input[@placeholder='Password']";
        public static string LOGINBUTTON_PROTONMAIL_XPATH = "//button[@id='login_btn']";
        public static string SEARCHMESSAGE_PROTONMAIL_XPATH = "//input[@placeholder='Search messages']";
        public static string SEARCHFORM_PROTONMAIL_XPATH = "//i[@class='fa fa-search']";
        public static string FIRSTEMAIL_PROTONMAIL_XPATH = "//span[@class='subject-text ellipsis']";
        public static string EMAILCONTENT_PROTONMAIL_XPATH = "(//div[2]/div[3]/div/text())[4]";
    }
}

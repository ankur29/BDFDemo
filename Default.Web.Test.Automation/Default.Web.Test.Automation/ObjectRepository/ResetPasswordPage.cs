using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Default.Web.Test.Automation.ObjectRepository
{
    class ResetPasswordPage
    {
        //Locators
        public static string RESETPASSWORDTITLE_RESETPASSWORD_XPATH = "//h3[text()=' Reset Password ']";
        public static string SAVEBUTTON_RESETPASSWORD_XPATH = "//button[text()=' Save ']";
        public static string NEWPASSWORD_RESETPASSWORD_XPATH = "//input[@placeholder='New password']";
        public static string CONFIRMNEWPASSWORD_RESETPASSWORD_XPATH = "//input[@placeholder='Confirm New password']";
        public static string EMAIL_RESETPASSWORD_XPATH = "//input[@placeholder='Email']";
        public static string CURRENTPASSWORD_RESETPASSWORD_XPATH = "//input[@placeholder='Current password']";


    }
}

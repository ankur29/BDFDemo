
namespace Default.Web.Test.Automation.ObjectRepository
{
    class LoginPage
    {
        //login page locators
        public static string PRODUCTLOGO_LOGIN_XPATH = "//img[@src='../../../assets/images/logo.png']";
        public static string LOGINTITLE_LOGIN_XPATH = "//h3[text()=' Log in ']";
        public static string USERNAME_LOGIN_XPATH = "//input[@placeholder='Enter your username']";
        public static string PASSWORD_LOGIN_XPATH = "//input[@placeholder='Enter your password']";
        public static string LOGINBUTTON_LOGIN_XPATH = "//button[text()=' Log in ']";
        public static string USERNAMEMANDATORYVALIDATION_LOGIN_XPATH = "//mat-error[text()='You must enter a value']";
        public static string INVALIDUSER_LOGIN_XPATH = "//p[text()='User does not Exist !']";
      

    }
}

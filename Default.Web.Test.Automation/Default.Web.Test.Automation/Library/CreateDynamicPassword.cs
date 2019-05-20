using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Default.Web.Test.Automation.Library
{
    class CreateDynamicPassword
    {
        public static string getPassword()
        {
            string allowedNumericChars = "0123456789";
            string allowedCapChars = "ABCDEFGHJKLMNOPQRSTUVWXYZ";
            string allowedSmallChars = "abcdefghijkmnopqrstuvwxyz";
            string allowedSpecialChars = "!@$?_-";
            string randomValue=DateTime.Now.ToString("HHmmss");
            StringBuilder password = new StringBuilder();
            Random rd = new Random();
            for (int i = 0; i < 2; i++)
            {
               password.Append(allowedNumericChars[rd.Next(0, allowedNumericChars.Length)]);
                password.Append(allowedCapChars[rd.Next(0, allowedCapChars.Length)]);
                password.Append(allowedSmallChars[rd.Next(0, allowedSmallChars.Length)]);
                password.Append(allowedSpecialChars[rd.Next(0, allowedSpecialChars.Length)]);
            }
           
            return password.ToString()+randomValue;
        }

        public static String setDynamicData(String needToAppend,int limit)
        {
            Random random = new Random();
            return needToAppend + Convert.ToString(random.Next(limit));

        }
    }
}
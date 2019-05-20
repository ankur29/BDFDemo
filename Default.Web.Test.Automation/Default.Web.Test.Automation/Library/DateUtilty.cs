﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Default.Web.Test.Automation.Library
{
   public class DateUtilty
    {

        public static String getCurrentDate()
        {
            return DateTime.Today.ToString("yyyy-MM-dd");
        }
        public static String getCurrentDate(String format)
        {
            return DateTime.Today.ToString(format);
        }

        public static String getCurrentTime()
        {
            return DateTime.Now.ToString("HH-mm-ss");
        }



    }
}

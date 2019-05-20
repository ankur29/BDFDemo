using Default.Web.Test.Automation.Library;
using NUnit.Framework;
using RelevantCodes.ExtentReports;
using System;
using System.Collections.Generic;
using System.IO;

namespace Default.Web.Test.Automation.ReportUtility
{
    [SetUpFixture]
    public class ReportGenerator
    {
        public List<string> passedTestCases = new List<string>();
        public List<string> totalTestCases;

        [OneTimeTearDown]
        public void endTest() // This method will be fired at the end of the test
        {
            try
            {
                Console.WriteLine("passedTestCases.Count=" + passedTestCases.Count);
     //           ReadTestData.writeTestData(passedTestCases, totalTestCases);
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception=" + e);

            }
        }

        //Test Case Result Report Location
        public static ExtentReports report = new ExtentReports(CreateReportPath.dynamicPath() + "\\Report.html", false);
        public ExtentReports createReport()
        {
            ExtentReports report;
            report = new ExtentReports("E:/Report.html", false);
            return report;
        }

        private byte[] ReadAllBytes2(string filePath, FileAccess fileAccess = FileAccess.ReadWrite, FileShare shareMode = FileShare.ReadWrite)
        {
            using (var fs = new FileStream(filePath, FileMode.Open, fileAccess, shareMode))
            {
                using (var ms = new MemoryStream())
                {
                    fs.CopyTo(ms);
                    return ms.ToArray();
                }
            }
        }

        public void storeReport(ExtentTest test,ExtentTest exception)
        {
            test.AppendChild(exception);
            report.EndTest(test);
            report.Flush();
        }
    }
}
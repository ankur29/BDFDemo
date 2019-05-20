using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using excel = Microsoft.Office.Interop.Excel;
using System.Diagnostics;
using System.IO;

namespace Default.Web.Test.Automation.Library
{
   public class ReadTestData
    {
        public  List<string> keyCount;
        public int loopCount=0;
      
        public  Dictionary<String, String>  readExcelData(String pageName)
        {
                var map = new Dictionary<String, String>();
                excel.Application xlApp = new excel.Application();
                Console.WriteLine("Directory.GetCurrentDirectory()=" + Directory.GetCurrentDirectory());
                String projectDirectory = System.AppDomain.CurrentDomain.BaseDirectory;
                projectDirectory = projectDirectory.Replace("\\bin\\Debug\\", "");
                excel.Workbook xlWorkbook = xlApp.Workbooks.Open(projectDirectory + @"\TestData\TestData.xlsx", false, true);
                excel.Worksheet x1Worksheet = xlWorkbook.Sheets[1];
                excel.Range xlRange = x1Worksheet.UsedRange;
                keyCount = new List<string>();

                int rowCount = xlRange.Rows.Count;
                int colCount = xlRange.Columns.Count;
                for (int i = 2; i <= rowCount; i++)
                {
                    String executionStatus = xlRange.Cells[i, 4].Value2.ToString();
                    String methodName = xlRange.Cells[i, 3].Value2.ToString();
           
                
                if (executionStatus.Equals("Y") && methodName.Equals(pageName))
                    {
                        loopCount = loopCount + 1;
                        for (int j = 1; j <= colCount; j++)
                        {
                            Console.WriteLine("Add " + j + "values to Map");
                            String key = xlRange.Cells[1, j].Value2.ToString() + "_" + i;
                            String value = xlRange.Cells[i, j].Value2.ToString();
                            if (value.Equals("NA"))
                            {
                                value = "";
                            }
                            map.Add(key, value);
                            if (!keyCount.Contains(i.ToString()))
                            {
                                keyCount.Add(i.ToString());
                            }
                        }
                    }
                }
                if (xlWorkbook != null)
                {
                    xlWorkbook.Close(false, Type.Missing, Type.Missing);
                    xlApp.Workbooks.Close();
                    Marshal.ReleaseComObject(xlWorkbook);
                }
                xlApp.Quit();
                GC.Collect();
                Marshal.FinalReleaseComObject(xlApp);         
            return map;     
                    
            }


        public static void writeTestData(List<string> passedTestCases, List<string> totalTestCases)
        {
            Process[] AllProcesses = Process.GetProcessesByName("Excel");

            foreach (Process ExcelProcess in AllProcesses)
            {
                ExcelProcess.Kill();

                Process[] AllProcesses1 = Process.GetProcessesByName("Excel");
                if (AllProcesses1.Length < 1)
                {
                    break;
                }
            }
     }
    }

    }


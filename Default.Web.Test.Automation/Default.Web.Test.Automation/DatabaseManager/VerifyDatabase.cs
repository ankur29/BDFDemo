using Default.Web.Test.Automation.Entities;
using RelevantCodes.ExtentReports;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;

namespace Default.Web.Test.Automation.DatabaseManager
{
   public class VerifyDatabase
    {
        public ExtentTest checkDBDetails(String expectedDBValues,TestData testData, ExtentReports report)
        {
            ExtentTest databaseVerificationSteps = report.StartTest("Database Validation");
            String columnName = null, expectedValue = null, dbColumnName = null; ;

            try
            {
                System.Threading.Thread.Sleep(5000);
                CreateDBConnection dbConnection = new CreateDBConnection();
                Console.WriteLine("Method checkDBDetails");
                Console.WriteLine("expectedDBValues= " + expectedDBValues);
                String[] queryIndex = expectedDBValues.Split(',');

                for (int databaseCount = 0; databaseCount < queryIndex.Length; databaseCount++)
                {
                    int itemNum = Convert.ToInt32(queryIndex[databaseCount]);
                    String databaseDetails = testData.validateDBValues.Replace("||", "%").Split('%')[itemNum - 1];

                    for (int i = 1; i < databaseDetails.Split('#').Length; i++)
                    {
                        //create Database Connection 
                        String databaseName = databaseDetails.Split('#')[0].ToString();
                        SqlConnection conn = dbConnection.getDBConnection(databaseName);
                        String queryDetails = databaseDetails.Split('#')[i];
                        Console.WriteLine("queryDetails=" + queryDetails);
                        String query = queryDetails.Replace("{", "%").Split('%')[0];
                        Console.WriteLine("query=" + query);
                        if (query.Contains("$"))
                        {
                            Console.WriteLine(query.Split('$')[1].Split('\'')[0]);
                            String needToreplace = query.Split('$')[1].Split('\'')[0];
                            if (needToreplace.Contains(";"))
                            {
                                needToreplace = needToreplace.Replace(";", "");
                            }

                            Type t = typeof(TestData);
                            PropertyInfo prop = t.GetProperty(needToreplace);
                            var dynamicData = (string)prop.GetValue(testData);

                            needToreplace = "$" + needToreplace;
                            //   var output = (string)this.GetType().GetField("dynamicData").GetValue(this); ;
                            query = query.Replace(needToreplace, dynamicData);
                        }
                        Console.WriteLine("query=" + query);
                        databaseVerificationSteps.Log(LogStatus.Info, databaseName, "<b><I>" + query + "</b><I>");
                        databaseVerificationSteps.Log(LogStatus.Info, "<b>Column Name</b>", "<font color=\"blue\"><b>Expected Value</b></font>||<font color=\"green\"><b>Actual Value</b></font>");

                        //execute Query
                        QueryExecutor queryExecutor = new QueryExecutor();
                        var map = new Dictionary<string, Object>();
                        map = queryExecutor.execute(query, conn);
                        conn.Close();
                        String dataString = queryDetails.Replace("{", "%").Split('%')[1].Replace("}", "");
                        Console.WriteLine("dataString=" + dataString);

                        String[] dataList = dataString.Split('|');

                        for (int dataCount = 0; dataCount < dataList.Length; dataCount++)
                        {
                            Console.WriteLine("dataList=" + dataList[dataCount]);

                            //if (dataList[dataCount].Contains("$"))
                            //{

                                //    if (dataList[dataCount].Contains("="))
                                //    {
                                //        dbColumnName = dataList[dataCount].Split('=')[0].Trim();
                                //        columnName = dataList[dataCount].Split('=')[1].Trim();
                                //    }
                                //    //create dynamic data
                                //    columnName = columnName.Replace("$", "");
                                //    Type t = typeof(TestData);
                                //    PropertyInfo prop = t.GetProperty(columnName);
                                //    expectedValue = (String)prop.GetValue(testData);
                                //}
                                //else
                                if (dataList[dataCount].Contains("="))
                            {
                                dbColumnName = dataList[dataCount].Split('=')[0].Trim();
                                Console.WriteLine("columnName=" + dbColumnName);
                                expectedValue = dataList[dataCount].Split('=')[1].Trim();
                                Console.WriteLine("expectedValue=" + expectedValue);
                                Type t = typeof(TestData);
                                if (expectedValue.Equals("NA"))
                                {
                                    expectedValue = "";
                                }
                                if (expectedValue.Contains('$'))
                                {
                                    expectedValue = expectedValue.Replace("$","");
                                    PropertyInfo prop = t.GetProperty(expectedValue);
                                    expectedValue = (string)prop.GetValue(testData);
                                }
                            }
                            else
                            {
                                databaseVerificationSteps.Log(LogStatus.Info, "No Data is found to validate");

                                Console.WriteLine("No Data is found to validate");
                                break;
                            }
                            String actualValue = map[dbColumnName].ToString();
                            if (expectedValue.Equals("SET"))
                            {
                                if (dbColumnName.Equals("ID"))
                                {
                                    testData.Id = map[dbColumnName].ToString();
                                    databaseVerificationSteps.Log(LogStatus.Pass, "<b>" + dbColumnName + "</b>", "<font color=\"blue\">" + testData.Id + "</font>");

                                    Console.WriteLine(testData.Id);
                                }
                                else if (dbColumnName.Equals("CertifiedNumber"))
                                {
                                    testData.CertifiedNumber = map[dbColumnName].ToString();
                                    databaseVerificationSteps.Log(LogStatus.Pass, "<b>" + dbColumnName + "</b>", "<font color=\"blue\">" + testData.CertifiedNumber + "</font>");
                                    Console.WriteLine(testData.Id);
                                }
                            }
                            else if (expectedValue.Equals(actualValue))
                            {
                                databaseVerificationSteps.Log(LogStatus.Pass, "<b>" + dbColumnName + "</b>", "<font color=\"blue\">" + expectedValue + "</font>||<font color=\"green\">" + map[dbColumnName].ToString() + "</font>");
                                Console.WriteLine("Passed");
                            }
                            else
                            {
                                databaseVerificationSteps.Log(LogStatus.Fail, dbColumnName, expectedValue + "||" + map[columnName].ToString());
                               Console.WriteLine("FAILED");
                            }

                        }
                    }

                }
            }
            catch (Exception e)
            {
                databaseVerificationSteps.Log(LogStatus.Fail, "<font color=\"red\"> Unable to verify " + dbColumnName+"</font>", "<font color=\"red\"> "+expectedValue + "</font>");
                databaseVerificationSteps.Log(LogStatus.Fail, "Exception", e);
               
            }
            return databaseVerificationSteps;

        }

    }
}

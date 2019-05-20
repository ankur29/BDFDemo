using Npgsql;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Default.Web.Test.Automation.DatabaseManager
{
    class QueryExecutor
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="query"></param>
        /// <param name="conn"></param>
        /// <returns></returns>
        //fetch data from database and store in Map<Key,Value>
        public  Dictionary<string, Object> execute(String query, SqlConnection conn)
        {
            var map = new Dictionary<string, Object>();
            //Console.WriteLine("Inside Query Executor");
            //String tableName = "\"tblEndpointDashboard\"";
            //String columnName = "\"ServiceTag\"";
            var queryString = conn.CreateCommand();
            //String queryToExecute = "Select * from it2db5eaf57eef483182520d025033e70d." + tableName + " where " + columnName + "='78LCHR2';";

            Console.WriteLine(query);

            queryString.CommandText = query;
            var reader = queryString.ExecuteReader();
            string ColumnName = string.Empty;
            string columnValues = string.Empty;
            int columnCount = reader.FieldCount;
            Console.WriteLine("columnCount="+ columnCount);
            while (reader.Read())
            {
                for (int i = 0; i < columnCount; i++)
                {
                    ColumnName = reader.GetName(i).ToString();
                    Console.WriteLine("ColumnName="+ ColumnName);
                    columnValues = reader[i].ToString();
                    Console.WriteLine("columnValues=" + columnValues);

                    map.Add(ColumnName, columnValues);
                }
            }
            Console.WriteLine("Done");
            conn.Close();
            return map;

        }

    }
}

using Npgsql;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Default.Web.Test.Automation.DatabaseManager
{
    class CreateDBConnection
    {

        //Create Database Connection
        public SqlConnection getDBConnection(String dbName)
        {
            SqlConnection conn = new SqlConnection(getConnectionString(dbName));
            conn.Open();
            return conn;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dbName"></param>
        /// <returns></returns>
        //create connection string
        private string getConnectionString(String dbName)
        {
            string connString = string.Empty;
            string host = string.Empty;
            string user = string.Empty;
            string databaseName = string.Empty;
            string port = string.Empty;
            string password = string.Empty;
            if (dbName.Equals("DWeb"))
            {
                host = "10.3.2.6\\DEVDBServer";
                user = "dwebdevuserRW";
                databaseName = "DWeb";
                password = "P@ssw0rd";
            }else if (dbName.Equals("DWebAdmin"))
            {
                host = "10.3.2.6\\QADBServer";
                user = "dwebdevuserRW";
                databaseName = "DWebAdmin";
                password = "P@ssw0rd";
            }
            else
            {
                Console.WriteLine(dbName+" database is not found");
            }
            connString =
                    String.Format(
                        "data source={0}; initial catalog={2};uid={1};pwd={3};",
                        host,
                        user,
                        dbName,
                        password);
            Console.WriteLine(connString);
            return connString;
        }
    }
}

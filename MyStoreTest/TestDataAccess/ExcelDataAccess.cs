using Dapper;
using MyStoreTest.DTO_s;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;

namespace MyStoreTest.TestDataAccess
{
    public class ExcelDataAccess
    {
        public static string TestDataFileConnection()
        {
            var fileName = ConfigurationManager.AppSettings["TestDataSheetPath"];
            var con = string.Format(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source = {0}; Extended Properties=Excel 12.0;", fileName);
            return con;
        }

        public static Data GetTestData(string QueryName)
        {
            using (var connection = new System.Data.OleDb.OleDbConnection(TestDataFileConnection()))
            {
                connection.Open();
                var query = string.Format("select * from [DataSet$] where Query='{0}'", QueryName);
                var value = connection.Query<Data>(query).FirstOrDefault();
                connection.Close();
                return value;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using MongoDB.Driver;
using MongoDB;
using System.Data.SqlClient;

namespace ConsoleAppSecretMgr
{
    class Program
    {
        static void Main(string[] args)
        {
            var secretManager = new SecretManager();            
            string secretName = "dev/db/testapp";
            
            var cso = JsonConvert.DeserializeObject<SqlServerConnString>(secretManager.Get(secretName));
            string connString = "Data Source=" + cso.Host + "," + cso.Port + ";Initial Catalog=" + cso.Dbname + ";User ID=" + cso.UserName + ";Password=" + cso.Password;
            var connection = new SqlConnection(connString);

            string sql = "select count(Username) from dbo.Users";
            SqlCommand command = connection.CreateCommand();
            command.CommandText = sql;
            connection.Open();
            object count = command.ExecuteScalar();
            Console.WriteLine("How many user = " + count);
            Console.ReadLine();
            
        }
    }
}

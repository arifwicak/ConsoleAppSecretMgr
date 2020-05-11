using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppSecretMgr
{
    public class SqlServerConnString
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Engine { get; set; }
        public string Host { get; set; }
        public string Port { get; set; }
        public string Dbname { get; set; }
    }
}

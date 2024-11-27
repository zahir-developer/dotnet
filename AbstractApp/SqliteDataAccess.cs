using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractApp
{
    public class SqliteDataAccess : DataAccess
    {
        public override string LoadConnectionString(string name)
        {
            string output = base.LoadConnectionString(name);
            return output += "from SQLite";
        }
        public override void LoadData(string sql)
        {
            Console.WriteLine("Loading SQLLite Data");
        }

        public override void SaveData(string sql)
        {
            Console.WriteLine("Saving SQLLite Data");
        }
    }
}

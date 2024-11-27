using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractApp
{
    public class SqlDataAccess : DataAccess
    {
        public override void LoadData(string sql)
        {
            Console.WriteLine("Loading SQL Data");
        }

        public override void SaveData(string sql)
        {
            Console.WriteLine("Saving SQL Data");
        }
    }
}

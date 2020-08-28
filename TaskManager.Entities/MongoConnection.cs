using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.Entities
{
    public static class MongoConnection
    {
        public static string ConnectionString { get; set; }
        public static string DatabaseName { get; set; }
    }
}

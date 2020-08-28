using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskManager.Entities;

namespace TaskManager.WebApi.Services
{
    public class TaskManagerUserRepository : BaseMongoRepository<TaskManagerUser>
    {
        public TaskManagerUserRepository(string mongoDBConnectionString, string dbName, string collectionName) : base(mongoDBConnectionString, dbName, collectionName)
        {
        }
    }
}

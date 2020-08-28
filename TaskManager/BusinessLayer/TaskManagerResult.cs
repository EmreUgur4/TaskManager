using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskManager.Entities;
using TaskManager.Entities.Messages;

namespace TaskManager.WebApp.BusinessLayer
{
    public class TaskManagerResult<TModel> where TModel : MongoBaseModel
    {
        public List<ErrorMessageObj> Errors { get; set; }
        public TModel Result { get; set; }

        public TaskManagerResult()
        {
            Errors = new List<ErrorMessageObj>();
        }

        public void AddError(ErrorMessageCode code, string message)
        {
            Errors.Add(new ErrorMessageObj() { Code = code, Message = message });
        }
    }
}

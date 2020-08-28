using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TaskManager.Entities;
using TaskManager.WebApi.Services;

namespace TaskManager.WebApi.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class TaskManagerUserController : BaseMongoController<TaskManagerUser>
    {
        public TaskManagerUserController(TaskManagerUserRepository taskManagerUserRepository) : base(taskManagerUserRepository)
        {
        }
    }
}
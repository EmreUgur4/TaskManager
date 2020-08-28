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
    public class PlanController : BaseMongoController<Plan>
    {
        public PlanController(BaseMongoRepository<Plan> baseMongoRepository) : base(baseMongoRepository)
        {
        }
    }
}
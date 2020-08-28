using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskManager.Entities;
using TaskManager.Entities.Messages;
using TaskManager.WebApi.Services;

namespace TaskManager.WebApp.BusinessLayer
{
    public class PlanManager
    {
        PlanRepository repo_plan = new PlanRepository(MongoConnection.ConnectionString, MongoConnection.DatabaseName, "Plan");
        TaskManagerResult<Plan> res = new TaskManagerResult<Plan>();

        public TaskManagerResult<Plan> AddPlan(Plan model)
        {
                try
                {
                    repo_plan.Create(model);
                }
                catch (Exception ex)
                {
                    res.AddError(ErrorMessageCode.Exception, ex.ToString());

                    return res;
                }

            return res;
        }

        public List<Plan> GetPlan(string userId)
        {
            List<Plan> plans = new List<Plan>();

            try
            {
                plans = repo_plan.GetList().FindAll(x => x.UserId == userId && x.IsDone == false && x.EndTime > DateTime.Now).OrderBy(x => x.EndTime).ToList();
            }
            catch (Exception ex)
            {
                return null;
            }

            return plans;
        }

        public List<Plan> GetEndPlan(string userId)
        {
            List<Plan> plans = new List<Plan>();

            try
            {
                plans = repo_plan.GetList().FindAll(x => x.UserId == userId && x.IsDone == true).OrderBy(x => x.EndTime).ToList();
            }
            catch (Exception ex)
            {
                return null;
            }

            return plans;
        }

        public List<Plan> GetInCompletePlan(string userId)
        {
            List<Plan> plans = new List<Plan>();

            try
            {
                plans = repo_plan.GetList().FindAll(x => x.UserId == userId && x.IsDone == false && x.EndTime <= DateTime.Now).OrderBy(x => x.EndTime).ToList();
            }
            catch (Exception ex)
            {
                return null;
            }

            return plans;
        }

        public TaskManagerResult<Plan> GetPlanById(string Id)
        {
            try
            {
                res.Result = repo_plan.GetById(Id);
            }
            catch (Exception ex)
            {
                res.AddError(ErrorMessageCode.Exception, ex.ToString());

                return res;
            }

            return res;
        }

        public TaskManagerResult<Plan> DeletePlan(string Id)
        {
            try
            {
                repo_plan.Delete(Id);
            }
            catch (Exception ex)
            {
                res.AddError(ErrorMessageCode.Exception, ex.ToString());

                return res;
            }

            return res;
        }

        public TaskManagerResult<Plan> UpdatePlan(Plan model, string Id)
        {
            try
            {
                model.Id = new MongoDB.Bson.ObjectId();

                repo_plan.Update(Id, model);
            }
            catch (Exception ex)
            {
                res.AddError(ErrorMessageCode.Exception, ex.ToString());

                return res;
            }

            return res;
        }
    }
}

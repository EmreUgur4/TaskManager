using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Protocols;
using MongoDB.Driver.Core.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskManager.Entities;
using TaskManager.Entities.Messages;
using TaskManager.Entities.ValueObjects;
using TaskManager.WebApi.Services;

namespace TaskManager.WebApp.BusinessLayer
{
    public class TMUserManager
    {
        TaskManagerUserRepository repo_user = new TaskManagerUserRepository(MongoConnection.ConnectionString, MongoConnection.DatabaseName, "TaskManagerUser");
        TaskManagerResult<TaskManagerUser> res = new TaskManagerResult<TaskManagerUser>();

        public TaskManagerResult<TaskManagerUser> RegisterUser(RegisterViewModel model)
        {
            TaskManagerUser user = repo_user.Find(x => x.Email == model.Email);

            if (user != null)
            {
                res.AddError(ErrorMessageCode.EmailAlreadyExists, "E-posta Adresi Kayıtlı");
            }
            else
            {
                try
                {
                   repo_user.Create(new TaskManagerUser()
                    {
                        Name = model.Name,
                        Surname = model.Surname,
                        Email = model.Email,
                        Password = model.Password
                    });
                }
                catch (Exception ex)
                {
                    res.AddError(ErrorMessageCode.Exception, ex.ToString());

                    return res;
                }
                
            }

            return res;
        }

        public TaskManagerResult<TaskManagerUser> GetUser(string v)
        {
            try
            {
                res.Result = repo_user.Find(x => x.Email == v);
            }
            catch (Exception ex)
            {
                res.AddError(ErrorMessageCode.Exception, ex.ToString());

                return res;
            }

            return res;
        }

        public TaskManagerResult<TaskManagerUser> LoginUser(LoginViewModel model)
        {
            res.Result = repo_user.Find(x => x.Email == model.Email && x.Password == model.Password);

            if (res.Result == null)
            {
                res.AddError(ErrorMessageCode.UserNameOrPassWrong, "Kullanıcı adı ya da şifre uyuşmuyor.");
            }

            return res;
        }
    }
}

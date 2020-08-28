using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Entities;

namespace TaskManager.Common
{
    public static class Ortak
    {
        public static List<PlanType> GetPlanTypeList()
        {
            List<PlanType> planTypes = new List<PlanType>();

            planTypes.Add(PlanType.Günlük);
            planTypes.Add(PlanType.Haftalık);
            planTypes.Add(PlanType.Aylık);

            return planTypes;
        }
    }
}

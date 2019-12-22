using System;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using pis_c.Models.DBEntities;

namespace pis_c.Models
{
    public static class Extensions
    {
        private readonly static Dictionary<string, Func<List<Car>, PropertyInfo, List<Car>>> sortRules = new Dictionary<string, Func<List<Car>, PropertyInfo, List<Car>>>
        {
            { "asc", (list, propertyInfo) => list.OrderBy(p => propertyInfo.GetValue(p)).ToList() },
            { "desc", (list, propertyInfo) => list.OrderByDescending(p => propertyInfo.GetValue(p)).ToList() },
        };

        public static List<Car> Sort(this List<Car> list, string sortColumn, string sortRule)
        {
            if (sortColumn == null || sortRule == null || !sortRules.ContainsKey(sortRule))
                return list;

            var propertyInfo = list.FirstOrDefault().GetType().GetProperty(sortColumn);

            return sortRules[sortRule](list, propertyInfo);
        }
    }
}
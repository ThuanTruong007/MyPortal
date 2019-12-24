using System;
using System.Linq;
using System.Reflection;


namespace DataManagement.Common
{
    public static class Utils
    {
        public static PropertyInfo GetEntityProperty<T>(string name)
        {
            var properties = typeof(T).GetProperties();

            return properties.FirstOrDefault
                 (p => string.Compare
                     (p?.CustomAttributes?.FirstOrDefault()?.AttributeType?.Name, name, ignoreCase: true) == 0
                 );
        }

        public static bool EndsWithList(this string s, string[] list)
        {
            if(string.IsNullOrWhiteSpace(s) || list?.Length<=0)
            {
                return false;
            }
            return list.Any(l => s.EndsWith(l, StringComparison.InvariantCultureIgnoreCase));
        }
    }
}

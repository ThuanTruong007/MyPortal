using System;
using System.Linq;
using System.Reflection;


namespace Common
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
    }
}

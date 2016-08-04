using System;
using System.Collections;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace ADMA.Common
{
    public static class Extensions
    {
        public static XElement SingleOrDefault(this XElement element, string name)
        {
            return element.Name == name ? element : element.Elements(name).SingleOrDefault();
        }

        public static string Body(this HttpRequestBase request)
        {
            string body;

            using (var reader = new StreamReader(request.InputStream))
            {
                request.InputStream.Position = 0;
                body = reader.ReadToEnd();
            }

            return body;
        }

        public static Type ToNullableType(this Type type)
        {
            var newType = Nullable.GetUnderlyingType(type) ?? type;
            return newType.IsValueType ? typeof(Nullable<>).MakeGenericType(newType) : newType;
        }

        public static bool IsNullable(this Type type)
        {
            return Nullable.GetUnderlyingType(type) != null;
        }

        public static Type GetUnderlyingType(this Type type)
        {
            return Nullable.GetUnderlyingType(type) ?? type;
        }

        public static object GetDefaultValue(this Type type)
        {
            if (type.IsValueType)
            {
                return Activator.CreateInstance(type);
            }
            return null;
        }

        public static string ToLowerCaseString(this bool value)
        {
            return value.ToString(CultureInfo.InvariantCulture).ToLower();
        }

        public static bool ExtendedEquals(this object value, object valueToCompare)
        {
            if (valueToCompare == null)
            {
                return value == null;
            }

            if (value.GetType() == valueToCompare.GetType() && value is IEnumerable)
            {
                var valueArray = (value as IEnumerable).Cast<object>().ToArray();
                var valueToCompareArray = (valueToCompare as IEnumerable).Cast<object>().ToArray();

                if (valueArray.Length != valueToCompareArray.Length)
                    return false;

                for (int i = 0;i<valueArray.Length; i++)
                {
                    if (valueArray[i] == null &&  valueToCompareArray[i] != null)
                        return false;
                     if (valueArray[i] != null &&  valueToCompareArray[i] == null)
                        return false;
                     if (valueArray[i] != null && valueToCompareArray[i] != null)
                         if (!valueArray[i].Equals(valueToCompareArray[i]))
                             return false;
                }

                return true;
            }

            return value.Equals(valueToCompare);
        }
    }
}

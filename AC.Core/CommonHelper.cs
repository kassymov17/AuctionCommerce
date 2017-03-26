using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Hosting;
using AC.Core.ComponentModel;

namespace AC.Core
{
    public partial class CommonHelper
    {
        /// <summary>
        /// Перевод виртуального пути в физический путь на диске
        /// </summary>
        /// <param name="path">Путь виртуальный</param>
        public static string MapPath(string path)
        {
            if (HostingEnvironment.IsHosted)
            {
                return HostingEnvironment.MapPath(path);
            }

            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            path = path.Replace("~/", "").TrimStart('/').Replace('/', '\\');
            return Path.Combine(baseDirectory, path);
        }

        /// <summary>
        /// Конвертация значения в нужное
        /// </summary>
        /// <typeparam name="T">Выходное значение</typeparam>
        /// <param name="value">Значение конвертируемое</param>
        /// <returns>Отконвертируемое значение</returns>
        public static T To<T>(object value)
        {
            return (T)To(value, typeof(T));
        }

        public static object To(object value, Type destinationType)
        {
            return To(value, destinationType, CultureInfo.InvariantCulture);
        }

        public static object To(object value, Type destinationType, CultureInfo culture)
        {
            if (value != null)
            {
                var sourceType = value.GetType();

                TypeConverter destinationConverter = GetACCustomTypeConverter(destinationType);
                TypeConverter sourceConverter = GetACCustomTypeConverter(sourceType);
                if (destinationConverter != null && destinationConverter.CanConvertFrom(value.GetType()))
                    return destinationConverter.ConvertFrom(null, culture, value);
                if (sourceConverter != null && sourceConverter.CanConvertTo(destinationType))
                    return sourceConverter.ConvertTo(null, culture, value, destinationType);
                if (destinationType.IsEnum && value is int)
                    return Enum.ToObject(destinationType, (int) value);
                if (!destinationType.IsInstanceOfType(value))
                    return Convert.ChangeType(value, destinationType, culture);
            }
            return value;
        }

        public static TypeConverter GetACCustomTypeConverter(Type type)
        {
            if (type == typeof(List<int>))
                return new GenericListTypeConverter<int>();
            if (type == typeof(List<decimal>))
                return new GenericListTypeConverter<decimal>();
            if (type == typeof(List<string>))
                return new GenericListTypeConverter<string>();
            if (type == typeof(Dictionary<int, int>))
                return new GenericDictionaryTypeConverter<int, int>();

            return TypeDescriptor.GetConverter(type);
        }
    }
}

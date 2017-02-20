using System;
using System.Collections.Generic;
using System.IO; 

namespace AC.Core.Data
{
    // класс со строкой подключения, параметры подключения
    public partial class DataSettingsManager
    {
        protected const char separator = ':';
        protected const string filename = "Settings.txt";

        /// <summary>
        /// Парсить настройки
        /// </summary>
        /// <param name="text">Text of settings file</param>
        protected virtual DataSettings ParseSettings(string text)
        {
            var shellSettings = new DataSettings();
            if (String.IsNullOrEmpty(text))
                return shellSettings;

            var settings = new List<string>();
            using (var reader = new StringReader(text))
            {
                string str;
                while ((str = reader.ReadLine()) != null)
                    settings.Add(str);
            }

            foreach(var setting in settings)
            {
                var separatorIndex = setting.IndexOf(separator);
                if (separatorIndex == -1)
                {
                    continue;
                }

                string key = setting.Substring(0, separatorIndex).Trim();
                string value = setting.Substring(separatorIndex + 1).Trim();

                switch (key)
                {
                    case "DataProvider":
                        shellSettings.DataProvider = value;
                        break;
                    case "DataConnectionString":
                        shellSettings.DataConnectionString = value;
                        break;
                    default:
                        shellSettings.RawDataSettings.Add(key, value);
                        break;
                }
            }
            return shellSettings;
        }

        public virtual DataSettings LoadSettings(string filePath = null)
        {
            if (String.IsNullOrEmpty(filePath))
            {
                filePath = Path.Combine(CommonHelper.MapPath("~/App_Data/"), filename);
            }
            if (File.Exists(filePath))
            {
                string text = File.ReadAllText(filePath);
                return ParseSettings(text);
            }
            return new DataSettings();
        }
    }
}

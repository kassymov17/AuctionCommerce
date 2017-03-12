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
        /// <param name="text">Текст файла</param>
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
        /// <summary>
        /// Конвертация настроек данных в строку 
        /// </summary>
        /// <param name="settings">Параметры</param>
        /// <returns>Строка</returns>
        protected virtual string ComposeSettings(DataSettings settings)
        {
            if (settings == null)
                return "";

            return string.Format("DataProvider: {0}{2}DataConnectionString: {1}{2}",
                                settings.DataProvider,
                                settings.DataConnectionString,
                                Environment.NewLine
                );
        }

        /// <summary>
        /// Загрузка настроек подключения к бд
        /// </summary>
        /// <param name="filePath">Путь к файлу с настройками</param>
        /// <returns></returns>
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

        /// <summary>
        /// Сохранить настройки в файл
        /// </summary>
        /// <param name="settings"></param>
        public virtual void SaveSettings(DataSettings settings)
        {
            if (settings == null)
                throw new ArgumentNullException("settings");

            string filePath = Path.Combine(CommonHelper.MapPath("~/App_Data/"), filename);
            if (!File.Exists(filePath))
            {
                using (File.Create(filePath))
                {
                    // использовать using для закрытия файла после создания его
                }
            }

            var text = ComposeSettings(settings);
            File.WriteAllText(filePath, text);
        }
    }
}

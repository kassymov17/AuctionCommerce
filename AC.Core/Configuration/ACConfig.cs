using System;
using System.Configuration;
using System.Xml;

namespace AC.Core.Configuration
{
    public partial class ACConfig : IConfigurationSectionHandler
    {
        ///<summary>
        /// creates a configuration section handler
        ///</summary>
        public object Create(object parent, object configContext, XmlNode section)
        {
            var config = new ACConfig();

            var startupNode = section.SelectSingleNode("Startup");
            config.IgnoreStartupTasks = GetBool(startupNode, "IgnoreStartupTasks");

            var redisCachingNode = section.SelectSingleNode("RedisCaching");
            config.RedisCachingEnabled = GetBool(redisCachingNode, "Enabled");
            config.RedisCachingConnectionString = GetString(redisCachingNode, "ConnectionString");

            var userAgentStringsNode = section.SelectSingleNode("UserAgentStrings");
            config.UserAgentStringsPath = GetString(userAgentStringsNode, "databasePath");

            return config;
        }

        private string GetString(XmlNode node, string attrName)
        {
            return SetByXElement<string>(node, attrName, Convert.ToString);
        }

        private bool GetBool(XmlNode node, string attrName)
        {
            return SetByXElement<bool>(node, attrName, Convert.ToBoolean);
        }

        private T SetByXElement<T>(XmlNode node, string attrName, Func<string, T> converter)
        {
            if (node == null || node.Attributes == null) return default(T);
            var attr = node.Attributes[attrName];
            if (attr == null) return default(T);
            var attrVal = attr.Value;
            return converter(attrVal);
        }

        public bool IgnoreStartupTasks { get; private set; }

        public string UserAgentStringsPath { get; private set; }

        public bool RedisCachingEnabled { get; private set; }

        public string RedisCachingConnectionString { get; private set; }


    }
}

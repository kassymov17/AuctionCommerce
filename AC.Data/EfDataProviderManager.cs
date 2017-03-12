using System;
using AC.Core;
using AC.Core.Data;

namespace AC.Data
{
    public partial class EfDataProviderManager : BaseDataProviderManager
    {
        public EfDataProviderManager(DataSettings settings) : base(settings)
        {
        }

        public override IDataProvider LoadDataProvider()
        {
            var providerName = Settings.DataProvider;
            if (string.IsNullOrEmpty(providerName))
                throw new Exception("Data Settings не содержит провайдера данных ");

            switch (providerName.ToLowerInvariant())
            {
                case "sqlserver":
                    return new SqlServerDataProvider();
                default:
                    throw new Exception(string.Format("Не поддерживаемое имя провайдера данных: {0}", providerName));
            }
        }
    }
}

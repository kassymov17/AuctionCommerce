using System.Collections.Generic;
using AC.Web.Framework.Mvc;

namespace AC.Web.Models.Catalog
{
    public partial class TopMenuModel
    {
        public TopMenuModel()
        {
            Categories = new List<CategorySimpleModel>();
            Topics = new List<TopMenuTopicModel>();
        }

        public IList<CategorySimpleModel> Categories { get; set; }
        public IList<TopMenuTopicModel> Topics { get; set; }

        #region Вложенные классы

        public class TopMenuTopicModel : BaseACEntityModel
        {
            public string Name { get; set; }
            public string SeName { get; set; }
        }

        #endregion
    }
}
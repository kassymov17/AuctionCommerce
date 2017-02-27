using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AC.Core.Domain.Topics
{
    public partial class Topic : BaseEntity
    {
        public string SystemName { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
    }
}

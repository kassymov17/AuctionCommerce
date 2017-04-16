using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AC.Web.Models.Media
{
    public partial class PictureModel
    {
        public string ImageUrl { get; set; }
        
        public string FullSizeImgUrl { get; set; }
        
        public string Title { get; set; }

        public string AlternateText { get; set; }
    }
}
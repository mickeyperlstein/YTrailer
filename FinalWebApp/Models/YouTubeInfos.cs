using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinalWebApp.Models
{
    public class YouTubeInfos
    {
        public int Id { get; set; }

        public int PromoRequestId { get; set; }
        public virtual PromoRequest PromoRequest { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }

    }
}
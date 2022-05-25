using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinalWebApp.Models
{
    public class VideoAnalysisReport
    {
        public int Id { get; set; }
        public int PromoRequestId { get; set; }
        public string OriginalVideo { get; set; }
        public string LowResVideoFile { get; set; }


        public string Scenes { get; set; }

    }
}
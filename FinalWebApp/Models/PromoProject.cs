using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinalWebApp.Models
{
    public class PromoProject
    {
        public PromoProject()
        {
            StartDate = DateTime.UtcNow;
        }
        public int Id { get; set; }
        public int YouTubeInfosId { get; set; }
       // public virtual YouTubeInfos YouTubeInfos { get; set; }
        public int PromoRequestId { get; set; }
       // public virtual PromoRequest PromoRequest { get; set; }
        public string StartingTitle { get; set; }
        public string MidTitle { get; set; }
        public string MidTitle2 { get; set; }
        public string EndTitle { get; set; }

        public string BgMusicFile { get; set; }
        public int? secs { get; set; }

        public DateTime StartDate { get; set; }
        public TimeSpan EndedOn { get; set; }

        public string OutputAvi { get; set; }


    }
}
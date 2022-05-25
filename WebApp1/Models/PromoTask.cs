using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WebApp1.Models
{
    public class PromoTask
    {
        //public PromoTask()
        //{
        //    Requests = new List<PromoRequest>();
        //}
        public int Id { get; set; }
        public string YouTubeUrl { get; set; }

        public DateTime? StartDate { get; set; }
        public DateTime? StopTime { get; set; }

        //public virtual ICollection<PromoRequest> Requests { get; set; }
        //public virtual TitleDetails TitleDetails { get; set; }

        public bool isHandled { get; set; }
    }
}

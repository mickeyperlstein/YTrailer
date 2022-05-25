using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FinalWebApp.Models
{
    public class PromoRequest
    {
        public int Id { get; set; }

        public string YoutTubeUrl { get; set; }

       // public virtual YouTubeInfos YouTubeInfos { get; set; }

        public ePromoStatus Status { get; set; }
        public string ProjectIds { get; set; }

        public override string ToString()
        {
            string s = string.Format("Id={0} | Status={1} ", Id, Status);
            return s;
        } 
    }
}
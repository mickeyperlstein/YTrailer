using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace YTrailerWebApp.Models
{
    public class PromoTask
    {
        public PromoTask()
        {
            Requests = new List<PromoRequest>();
        }
        public int Id { get; set; }
        public string YouTubeUrl { get; set; }

        public DateTime? StartDate { get; set; }
        public DateTime? StopTime { get; set; }

        public virtual ICollection<PromoRequest> Requests { get; set; }
        public virtual TitleDetails TitleDetails { get; set; }
    }
    public class PromoRequest
    {
        public PromoRequest() { }

        public int Id { get; set; }
      
        //PromoTaskId is not following code first conventions name
        public int PromoTaskId { get; set; }

        public virtual PromoTask PromoTask { get; set; }
    }
    public class PromoResponse
    {
        public PromoResponse() {}
        [Key]public int Id { get; set; }
        
        public int PromoTaskId { get; set; }
        [ForeignKey("PromoTaskId")]
        public virtual PromoTask PromoTask { get; set; }


        public int PromoRequestId { get; set; }
        [ForeignKey("PromoRequestId")]
        public virtual PromoRequest Request { get; set; }
        public PromoTaskState State { get; set; }

    }
        public enum PromoTaskState
    {
        donme, dow
    }

    public class TitleDetails
    {
        [Key] public int Id { get; set; }
        public string Title { get; set; }
        
        public int TaskId { get; set; }

        [ForeignKey("TaskId")]
        public PromoTask Task { get; set; }
    }
   
}
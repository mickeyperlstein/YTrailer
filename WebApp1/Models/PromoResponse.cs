using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace WebApp1.Models
{
    public class PromoResponse
    {
        public PromoResponse() { }
        [Key]
        public int Id { get; set; }

        public int PromoTaskId { get; set; }
        //[ForeignKey("PromoTaskId")]
        //public virtual PromoTask PromoTask { get; set; }


        public int PromoRequestId { get; set; }
        //[ForeignKey("PromoRequestId")]
        //public virtual PromoRequest Request { get; set; }
        public YTaskState State { get; set; }

    }
}

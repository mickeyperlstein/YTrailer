using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace WebApp1.Models
{
    public class TitleDetails
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }

        public int TaskId { get; set; }

        //[ForeignKey("TaskId")]
        //public PromoTask Task { get; set; }
    }
}

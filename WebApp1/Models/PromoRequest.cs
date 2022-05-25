using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WebApp1.Models
{
    public class PromoRequest
    {
        public PromoRequest() { }

        public int Id { get; set; }

        //PromoTaskId is not following code first conventions name
        public int PromoTaskId { get; set; }

        //public virtual PromoTask PromoTask { get; set; }
    }
}

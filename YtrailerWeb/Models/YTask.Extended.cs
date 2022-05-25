using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using YTrailerWeb.Models;
using YTrailerWeb.Extensions;

namespace YTrailerWeb.Models
{
    public partial class YTask
    {
       
        

        public string StateStr { get { return this.YTaskState.GetEnumDescription(); } }

    }
}
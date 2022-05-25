using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FinalWebApp.Models
{
    public enum ePromoStatus
    {
        NotStarted = 0,
        GettingYouTubeDetails ,
        DownloadingOriginalVideo ,
        DownloadedOriginalVideo  ,
        CreatingLowResVideo ,
        Analyzing ,
        ReadyToCreatePromo,
        CreatingPromo ,
        Done 

    }
}

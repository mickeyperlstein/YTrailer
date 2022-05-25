using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace YTrailerWeb.Models
{
    public enum YTaskState
    {
        [Description("Connecting to YouTube")]
        e10_YouTubeDetails = 10,
        [Description("Downloading video from YouTube")]
        e20_DownloadingSrcAndUserInteraction = 20,
        [Description("Creating low res file")]
        e30_CreatingLowResFileAndUserInteraction = 30,
        [Description("Analyzing scenes in video")]
        e40_AnalyzingVideo = 40,
        [Description("Awaiting user command")]
        e50_WaitingForUser = 50,
        [Description("Creating promo video")]
        e60_CreatingPromo = 60,
        [Description("Done")]
        e70_Done = 70
    }
}
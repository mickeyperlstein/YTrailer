//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace  YTrailerWeb.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class PromoRequest
    {
        public int Id { get; set; }
        public string Title1 { get; set; }
        public string Title2 { get; set; }
        public string Title3 { get; set; }
        public string Title4 { get; set; }
        public string BgMusicFile { get; set; }
        public double Seconds { get; set; }
    
        public virtual YTask YTask { get; set; }
    }
}

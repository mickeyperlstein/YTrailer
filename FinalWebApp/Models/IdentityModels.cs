using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace FinalWebApp.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection")
        {
        }



        public DbSet<PromoRequest> PromoRequests { get; set; }
        
        public DbSet<YouTubeInfos> YouTubeInfos { get; set; }

        public DbSet<PromoProject> PromoProjects { get; set; }
        public DbSet<VideoAnalysisReport> VideoAnalysisReports { get; set; }
    }
}
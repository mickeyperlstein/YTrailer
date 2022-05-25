using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace YTrailerWebApp.Models
{
    public class MyDbContext :DbContext
    {


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {



            //one-to-many 
            modelBuilder.Entity<PromoRequest>() // many
                        .HasOptional<PromoTask>(s => s.PromoTask) //one
                        .WithMany(s => s.Requests)
                        .HasForeignKey(s => s.PromoTaskId);



            // Map one-to-zero or one relationship 
            modelBuilder.Entity<TitleDetails>()
                .HasRequired(t => t.Task)
                .WithOptional(t => t.TitleDetails);

        }

        public DbSet<Models.PromoRequest> Requests { get; set; }
        public DbSet<Models.PromoResponse> Responses { get; set; }
        public DbSet<Models.PromoTask> Tasks { get; set; }

    }
}
using DanceCon.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DanceCon.Context
{
    public class EFCContext : IdentityDbContext
    {


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(@"Data Source=LAPTOP-6U2NJESB\SQLEXPRESS;Initial Catalog=DanConDb;Integrated Security=True");
        }
        public DbSet<ContestViewModel> Contests { get; set; }
       public DbSet<Judge> Judges { get; set; }
        public DbSet<ParticipantViewModel> Participants { get; set; }
      
    }
}

using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using TransAltaInterview.Models;

namespace TransAltaInterview.DbContexts
{
    public class TransAltaDbContext: DbContext
    {
        public TransAltaDbContext(DbContextOptions<TransAltaDbContext> options): base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<WeatherRecord>()
                .HasAlternateKey(wr => wr.TimeStamp);
        }

        public DbSet<WeatherRecord> WeatherRecords { get; set; }
    }
}

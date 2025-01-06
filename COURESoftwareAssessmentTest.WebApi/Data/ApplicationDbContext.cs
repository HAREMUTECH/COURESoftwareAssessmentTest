using Microsoft.EntityFrameworkCore;
using System;

namespace COURESoftwareAssessmentTest.WebApi.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Country> Countries { get; set; }
        public DbSet<CountryDetail> CountryDetails { get; set; }
    }
}

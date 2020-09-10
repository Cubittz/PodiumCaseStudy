using Microsoft.EntityFrameworkCore;
using PodiumCaseStudy.Data.Entities;
using PodiumCaseStudy.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PodiumCaseStudy.Data
{
    public class PodiumDbContext : DbContext
    {
        public PodiumDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Applicant> Applicants { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<MortgageRequirement> MortgageRequirements { get; set; }
        public DbSet<MortgageProposal> MortgageProposals { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            


            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Id = Guid.NewGuid(),
                    Lender = "Bank A",
                    InterestRate = (decimal)0.02,
                    LoanType = LoanType.Variable,
                    LoanToValue = (decimal)0.60
                },
                new Product
                {
                    Id = Guid.NewGuid(),
                    Lender = "Bank B",
                    InterestRate = (decimal)0.03,
                    LoanType = LoanType.Fixed,
                    LoanToValue = (decimal)0.60
                },
                new Product
                {
                    Id = Guid.NewGuid(),
                    Lender = "Bank C",
                    InterestRate = (decimal)0.04,
                    LoanType = LoanType.Variable,
                    LoanToValue = (decimal)0.90
                }
    );
        }
    }
}

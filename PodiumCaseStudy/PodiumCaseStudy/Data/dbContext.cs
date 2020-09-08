﻿using Microsoft.EntityFrameworkCore;
using PodiumCaseStudy.Data.Entities;
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
    }
}
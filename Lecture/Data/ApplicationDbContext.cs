using System;
using System.Collections.Generic;
using System.Text;
using Lecture.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Lecture.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        // Add DB Set
        public DbSet<BandModel> bands{get;set;}
    }
}

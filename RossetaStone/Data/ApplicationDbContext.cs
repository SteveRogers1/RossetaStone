using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RossetaStone.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RossetaStone.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Dictionary> Dictionaries { get; set; }
    }
}

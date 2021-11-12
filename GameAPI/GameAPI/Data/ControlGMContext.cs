using GameAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameAPI.Data
{
    public class ControlGMContext : DbContext
    {
        public ControlGMContext(DbContextOptions<ControlGMContext> options)
            : base(options)
        {
            this.Database.EnsureCreated();
        }

        public DbSet<Deal> Deals { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<Store> Stores { get; set; }
    }
}

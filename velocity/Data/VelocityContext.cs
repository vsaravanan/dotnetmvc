using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace velocity.Models
{
    public class VelocityContext : DbContext
    {
        public VelocityContext(DbContextOptions<VelocityContext> options)
            : base(options)
        {
        }

        public DbSet<Trader> Trader { get; set; }
    }
}

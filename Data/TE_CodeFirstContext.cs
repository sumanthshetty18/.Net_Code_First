using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TE_CodeFirst.Models;

namespace TE_CodeFirst.Data
{
    public class TE_CodeFirstContext : DbContext
    {
        public TE_CodeFirstContext (DbContextOptions<TE_CodeFirstContext> options)
            : base(options)
        {
        }

        public DbSet<TE_CodeFirst.Models.Trainee> Trainee { get; set; } = default!;
    }
}

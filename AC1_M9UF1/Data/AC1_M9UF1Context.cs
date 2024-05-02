using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AC1_M9UF1.Models;

namespace AC1_M9UF1.Data
{
    public class AC1_M9UF1Context : DbContext
    {
        public AC1_M9UF1Context (DbContextOptions<AC1_M9UF1Context> options)
            : base(options)
        {
        }

        public DbSet<AC1_M9UF1.Models.Customer> Customer { get; set; } = default!;
    }
}

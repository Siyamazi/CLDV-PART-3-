using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CLDV_Part2.Models;

namespace CLDV_Part2.Data
{
    public class CLDV_Part2Context : DbContext
    {
        public CLDV_Part2Context (DbContextOptions<CLDV_Part2Context> options)
            : base(options)
        {
        }

        public DbSet<CLDV_Part2.Models.Products> Products { get; set; } 
        public DbSet<CLDV_Part2.Models.History> History { get; set; } = default!;
    }
}

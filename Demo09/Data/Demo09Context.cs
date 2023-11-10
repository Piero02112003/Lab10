using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Demo09.Models;

namespace Demo09.Data
{
    public class Demo09Context : DbContext
    {
        public Demo09Context (DbContextOptions<Demo09Context> options)
            : base(options)
        {
        }

        public DbSet<Demo09.Models.InvoiceModel> InvoiceModel { get; set; } = default!;
    }
}

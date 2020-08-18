using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WebCashback.Models
{
    public class WebCashbackContext : DbContext
    {
        public WebCashbackContext(DbContextOptions<WebCashbackContext> options)
            : base(options)
        {
        }



        public DbSet<Revendedor> Revendedor { get; set; }
        public DbSet<Compra> Compra { get; set; }
    }
}

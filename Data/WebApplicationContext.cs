using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApplication.Models;

namespace WebApplication.Data
{
    public class WebApplicationContext : DbContext
    {
        public WebApplicationContext (DbContextOptions<WebApplicationContext> options)
            : base(options)
        {
        }

        public DbSet<WebApplication.Models.Book> Book { get; set; }

        public DbSet<WebApplication.Models.Cars> Car { get; set; }

        public DbSet<WebApplication.Models.Driver_Detailss> Driver { get; set; }

        
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.SqlServer;
using demodb.Models;
using Microsoft.EntityFrameworkCore;

namespace demodb.Data
{
    public class DatabaseContext : DbContext
    {

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }
        public DbSet<Product> Products { get; set; }
        public DbSet<demodb.Models.Customer> Customer { get; set; }
        public DbSet<demodb.Models.ProductFeatImg> ProductFeatImg { get; set; }
    }
    
    }

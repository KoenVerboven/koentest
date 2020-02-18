using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace packt_webapp.Entities
{
    public class PacktDbContext : DbContext
    {
        
        //snippet voor aanmaken constructor : ctor Tab !!!!
        public PacktDbContext(DbContextOptions<PacktDbContext> options): base(options) // : base => call the base constructor
        {

        }

        public DbSet<Customer> Customers { get; set; } //toegevoegd door Koen
    }
}

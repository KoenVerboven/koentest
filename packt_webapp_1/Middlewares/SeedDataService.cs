using packt_webapp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace packt_webapp.Middlewares
{
    public class SeedDataService : ISeedDataService
    {
        private PacktDbContext _context;
        public SeedDataService(PacktDbContext context)
        {
            _context = context;
        }
        
        public async Task EnsureSeedData()
        {
            _context.Database.EnsureCreated();
            _context.Customers.RemoveRange(_context.Customers);
            _context.SaveChanges();

            Customer customer = new Customer();
            customer.FirstName = "Jan";
            customer.LastName = "Peeters";
            customer.Age = 32;
            customer.Id = Guid.NewGuid();
            _context.Add(customer);

            Customer customer2 = new Customer();
            customer2.FirstName = "Ludo";
            customer2.LastName = "Janssens";
            customer2.Age = 40;
            customer2.Id = Guid.NewGuid();
            _context.Add(customer);

            await _context.SaveChangesAsync();

        }
    }
}

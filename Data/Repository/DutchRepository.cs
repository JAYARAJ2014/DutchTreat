using System.Collections.Generic;
using System.Linq;
using DutchTreat.Data.Entities;

namespace DutchTreat.Data.Repository
{
    public class DutchRepository : IDutchRepository
    {
        private readonly DutchContext _context;

        public DutchRepository(DutchContext context)
        {
            _context = context;
        }
        public IEnumerable<Product> GetAllProducts()
        {
            return _context.Products.OrderBy(p => p.Title).ToList();
        }
        public IEnumerable<Product> GetProductsByCategory(string category)
        {
            return _context.Products.Where(p => p.Category == category).ToList();
        }
        public bool SaveAll()
        {
            return _context.SaveChanges() > 0;
        }
    }
}
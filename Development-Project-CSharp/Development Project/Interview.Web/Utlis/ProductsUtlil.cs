using Sparcpoint.Abstract;
using Sparcpoint.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Sparcpoint.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Interview.Web.Utlis
{
    public class ProductsUtil : IProduct
    {
        private readonly DatabaseContext _context;

        public ProductsUtil(DatabaseContext context)
        {
            _context = context;
        }

        public async Task Add(Product item)
        {
            await _context.Products.AddAsync(item);
            await _context.SaveChangesAsync();
        }

        public async Task<Product> Get(int key)
        {
            var result = await _context.Products.FindAsync(key);
            return result;
        }

        public async Task<IList<Product>> GetAll()
        {
            var result = await _context.Products.ToListAsync();
            return result;
        }

        public async Task<int> GetCount()
        {
            var result = await _context.Products.ToListAsync();
            return result.Count;
        }
    }
}

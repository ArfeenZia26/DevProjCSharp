using Microsoft.EntityFrameworkCore;
using Sparcpoint.Abstract;
using Sparcpoint.DAL;
using Sparcpoint.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Interview.Web.Utlis
{
    public class SearchUtils : ISearch
    {
        private readonly DatabaseContext _context;

        public SearchUtils(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<IList<Product>> SearchInventoryTransactionsAsync(int instanceId)
        {
            var inventory = await _context.InventoryTransactions.Where(i => i.TransactionId == instanceId).ToListAsync();
            var res = from pro in _context.Products
                      join inv in inventory on pro.InventoryTransactions.FirstOrDefault(i => i.TransactionId == instanceId).TransactionId equals inv.TransactionId
                      select pro;
            return res.ToList();
        }

        public async Task<IList<Product>> SearchProductAttributeAsync(int instanceId)
        {
            var prodAtt = await _context.ProductAttributes.Where(a => a.InstanceId == instanceId).ToListAsync();
            var res = from pro in _context.Products
                      join att in prodAtt on pro.ProductAttributes.FirstOrDefault(a => a.InstanceId == instanceId).InstanceId equals att.InstanceId
                      select pro;
            return res.ToList();
        }

        public async Task<IList<Product>> SearchProductCategoryAsync(int instanceId)
        {
            var category = await _context.ProductCategories.Where(a => a.InstanceId == instanceId).ToListAsync();
            var res = from pro in _context.Products
                      join cat in category on pro.ProductCategories.FirstOrDefault(a => a.InstanceId == instanceId).InstanceId equals cat.InstanceId
                      select pro;
            return res.ToList();
        }
    }
}

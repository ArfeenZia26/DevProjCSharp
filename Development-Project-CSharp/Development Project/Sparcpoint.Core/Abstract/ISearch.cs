using Sparcpoint.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
namespace Sparcpoint.Abstract
{
    public interface ISearch
    {
        Task<IList<Product>> SearchInventoryTransactionsAsync(int instanceId);
        Task<IList<Product>> SearchProductAttributeAsync(int instanceId);
        Task<IList<Product>> SearchProductCategoryAsync(int instanceId);
    }
}

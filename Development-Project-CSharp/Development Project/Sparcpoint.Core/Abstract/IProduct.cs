using Sparcpoint.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Sparcpoint.Abstract
{
    public interface IProduct
    {
        Task<Product> Get(int key);
        Task<IList<Product>> GetAll();
        Task Add(Product item);
        Task<int> GetCount();
    }
}

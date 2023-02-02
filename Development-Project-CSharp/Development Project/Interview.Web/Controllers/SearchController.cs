using Microsoft.AspNetCore.Mvc;
using Sparcpoint.Abstract;
using Sparcpoint.Models;
using System.ComponentModel;
using System.Threading.Tasks;

namespace Interview.Web.Controllers
{
    [Route("api/v1/search")]
    public class SearchController : Controller
    {
        private readonly ISearch _search;
        
        public SearchController(ISearch search)
        {
            _search = search;
        }
        [HttpGet]
        public async Task<IActionResult> SearchInventoryTransactionsAsync(InventoryTransaction inventory)
        {
           var res = await _search.SearchInventoryTransactionsAsync(inventory.TransactionId);
           return Ok(res);
        }

        [HttpGet]
        public async Task<IActionResult> SearchProductAttributeAsync(ProductAttribute productAttribute) 
        {
            var res = await _search.SearchProductAttributeAsync(productAttribute.InstanceId);
            return Ok(res);
        }

        [HttpGet]
        public async Task<IActionResult> SearchProductCategoryAsync(ProductCategory productCategory)
        {
            var res = await _search.SearchProductCategoryAsync(productCategory.InstanceId);
            return Ok(res);
        }
    }
}

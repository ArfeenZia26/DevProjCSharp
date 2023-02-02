using Interview.Web.Utlis;
using Microsoft.AspNetCore.Mvc;
using Sparcpoint.Abstract;
using Sparcpoint.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Interview.Web.Controllers
{
    [Route("api/v1/products")]
    public class ProductController : Controller
    {
        private readonly IProduct _product;

        public ProductController(IProduct product)
        {
            _product = product;
        }

        [HttpGet]
        public Task<IActionResult> Get()
        {
            return Task.FromResult((IActionResult)Ok(_product.GetAll()));
        }
        [HttpGet("{id}")]
        public Task<IActionResult> Get(int id)
        {
            return Task.FromResult((IActionResult)Ok(_product.Get(id)));
        }
        [HttpPost]
        public Task<IActionResult> Post(Product product)
        {
            return Task.FromResult((IActionResult)Ok(_product.Add(product)));
        }
        [HttpDelete]
        public Task<IActionResult> Delete()
        {
            return Task.FromResult((IActionResult)BadRequest(new Exception("Delete Operation is not allowed at this point of time")));
        }
    }
}

using DataManager.Contracts;
using DataManager.Library.DataAccess;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DataManager.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private IProductData _productData;

        public ProductController(IProductData productData)
        {
            _productData = productData;
        }

        [HttpPost(ApiRoutes.Product.Get)]
        public async Task<ActionResult<List<string>>> Get()
        {

            var products = await _productData.GetProducts();
            return Ok(products);
        }


    }
}

using DataManager.Contracts;
using DataManager.Library.DataAccess;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

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
        public ActionResult<List<string>> Get()
        {

            var products = _productData.GetProducts();
            return Ok(products);
        }


    }
}

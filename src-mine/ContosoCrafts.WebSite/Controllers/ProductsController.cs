using ContosoCrafts.WebSite.Models;
using ContosoCrafts.WebSite.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ContosoCrafts.WebSite.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public IEnumerable<Product> Get()
        {
            return _productService.GetProducts();
        }


        [HttpGet]
        [Route("rate")]
        public ActionResult Get(
            [FromQuery] string productId,
            [FromQuery] int rating)
        {
            _productService.AddRating(productId, rating);
            return Ok();
        }
    }
}

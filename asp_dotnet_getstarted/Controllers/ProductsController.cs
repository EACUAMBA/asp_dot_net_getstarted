﻿using asp_dotnet_getstarted.Models;
using asp_dotnet_getstarted.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace asp_dotnet_getstarted.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        public JsonProductService productService;

        public ProductsController(JsonProductService productService)
        {
            this.productService = productService;
        }

        [HttpGet]
        public IEnumerable<Product> Get()
        {
            return this.productService.GetProducts();
        }

        [Route("rate")]
        [HttpGet]
        public ActionResult Get([FromQuery(Name ="product-id")]string ProductId, [FromQuery(Name = "rating")] int Rating)
        {
            this.productService.AddRating(ProductId, Rating);
            return Ok();
        }
    }
}

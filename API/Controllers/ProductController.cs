using API.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API.Controllers
{
    [RoutePrefix("api/products")]
    public class ProductController : ApiController
    {
        private readonly IProductService productService;

        public ProductController(IProductService productService)
        {
            this.productService = productService;
        }

        [HttpGet]
        [Route("{barCode}")]
        public IHttpActionResult GetProductByBarCode([FromUri]string barCode)
        {
            return this.Ok(this.productService.GetProductByBarCode(barCode));
        }
    }
}

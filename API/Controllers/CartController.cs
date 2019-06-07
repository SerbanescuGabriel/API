using API.Entities.Requests;
using API.Services.Interfaces;
using System.Web.Http;

namespace API.Controllers
{
    [RoutePrefix("api/cart")]
    public class CartController : ApiController
    {
        private readonly ICartService cartService;

        public CartController(ICartService cartService)
        {
            this.cartService = cartService;
        }

        [HttpPost]
        public IHttpActionResult AddItemToCart([FromBody] AddItemToCartRequest request)
        {
            return this.Ok(this.cartService.AddItemToActiveCart(request.UserId, request.ProductId, request.Quantity));
        }

        [HttpGet]
        [Route("{userId}")]
        public IHttpActionResult GetItemsFromCurrentCart([FromUri] long userId)
        {
            return this.Ok(cartService.GetCurrentCartProducts(userId));
        }

        [HttpPost]
        [Route("finish/{cartId}")]
        public IHttpActionResult FinishShopping([FromUri] long cartId)
        {
            return this.Ok(cartService.FinishShoping(cartId));
        }

        [HttpGet]
        [Route("cartId/{userId}")]
        public IHttpActionResult GetCurrentCartId([FromUri] long userId)
        {
            return this.Ok(this.cartService.GetCurrentCartId(userId));
        }

        [HttpPost]
        [Route("add")]
        public IHttpActionResult Add(ModifyQuantityRequest request)
        {
            return this.Ok(this.cartService.AddOneProductToQuantity(request.UserId, request.ProductId));
        }

        [HttpPost]
        [Route("substract")]
        public IHttpActionResult Substract(ModifyQuantityRequest request)
        {
            return this.Ok(this.cartService.SubstractOneProductToQuantity(request.UserId, request.ProductId));
        }
    }
}

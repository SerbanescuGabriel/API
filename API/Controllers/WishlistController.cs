using API.Entities.Requests;
using API.Services.Classes;
using API.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API.Controllers
{
    [RoutePrefix("api/wishlist")]
    public class WishlistController : ApiController
    {
        private readonly IWishlistService wishlistService;

        public WishlistController(IWishlistService wishlistService)
        {
            this.wishlistService = wishlistService;
        }

        [HttpPost]
        public IHttpActionResult AddProductToWishlist(AddProductToWislistRequest request)
        {
            return this.Ok(this.wishlistService.AddProductToWishList(request.UserId, request.ProductId));
        }

        [HttpGet]
        [Route("{userId}")]
        public IHttpActionResult GetAllWishListProducts([FromUri] long userId)
        {
            return this.Ok(wishlistService.GetAllWishlistProducts(userId));
        }

        [HttpPost]
        [Route("remove")]
        public IHttpActionResult DeleteWishListItem(DeleteWishListItemRequest request)
        {
            if (request == null)
                return this.Ok(false);

            return this.Ok(wishlistService.DeleteWishListItem(request.UserId, request.ProductId));
        }
    }
}

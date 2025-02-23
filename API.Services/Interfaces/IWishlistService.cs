﻿using API.Repository.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Services.Interfaces
{
    public interface IWishlistService
    {
        bool AddProductToWishList(long userId, long productId);

        List<ProductEntity> GetAllWishlistProducts(long userId);

        bool DeleteWishListItem(long userId, long productId);
    }
}

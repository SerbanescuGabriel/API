﻿using API.Repository.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Repository.Interfaces
{
    public interface IWishlistRepository
    {
        bool AddProductToWishlist(long userId, long productId);

        List<ProductEntity> GetAllWishlistProducts(long userId);

        bool DeleteWishListItem(long userId, long productId);
    }
}

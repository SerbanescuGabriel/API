﻿using API.Repository.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Services.Interfaces
{
    public interface ICartService
    {
        bool AddItemToActiveCart(long userId, long productId);

        List<ProductEntity> GetCurrentCartProducts(long userId);

        bool FinishShoping(long cartId);
    }
}

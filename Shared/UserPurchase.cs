﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopProduct.Shared
{
    public class UserPurchase
    {
        public int UserId { get; set; }
        public int ProductType { get; set; }
        public int Price { get; set; }
        public int Amount { get; set; }
    }
}

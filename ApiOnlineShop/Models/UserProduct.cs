﻿using System;
using System.Collections.Generic;

namespace ApiOnlineShop.Models
{
    public partial class UserProduct
    {
        public int UserProductId { get; set; }
        public int UserId { get; set; }
        public int ProductId { get; set; }

        public virtual Product? Product { get; set; } = null!;
        public virtual User? User { get; set; } = null!;
    }
}
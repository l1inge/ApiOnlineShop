using System;
using System.Collections.Generic;

namespace ApiOnlineShop.Models
{
    public partial class Product
    {
        public int ProductId { get; set; }
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public decimal Price { get; set; }
        public string Condition { get; set; } = null!;
        public string Category { get; set; } = null!;
        public DateTime DateListed { get; set; }
        public int? PictureId { get; set; }
        public int SellerUserId { get; set; }

        public virtual Picture? Picture { get; set; }
        public virtual User? SellerUser { get; set; } = null!;
    }
}

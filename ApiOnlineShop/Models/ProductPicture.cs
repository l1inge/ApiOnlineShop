using System;
using System.Collections.Generic;

namespace ApiOnlineShop.Models
{
    public partial class ProductPicture
    {
        public int IdProductPictures { get; set; }
        public int PictureId { get; set; }
        public int ProductId { get; set; }

        public virtual Picture? Picture { get; set; } = null!;
        public virtual Product? Product { get; set; } = null!;
    }
}

using System;
using System.Collections.Generic;

namespace ApiOnlineShop.Models
{
    public partial class Chat
    {
       
        public int ChatId { get; set; }
        public int ProductId { get; set; }
        public int UserId1 { get; set; }
        public int UserId2 { get; set; }

        public virtual Product? Product { get; set; } = null!;
        public virtual User? UserId1Navigation { get; set; } = null!;
        public virtual User? UserId2Navigation { get; set; } = null!;
    }
}

﻿using System;
using System.Collections.Generic;

namespace ApiOnlineShop.Models
{
    public partial class UserPicture
    {
        public int PhotoId { get; set; }
        public int UserId { get; set; }
        public byte[] PhotoData { get; set; } = null!;
        public DateTime UploadDate { get; set; }

        public virtual User? User { get; set; } = null!;
    }
}
